using System.IO;
using System.Text;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using ExcelDataReader;
using Indica.System.Shared.Interfaces;
namespace Indica.System.Shared
{
    public class FileParser : IFileParser, IDisposable
    {
        private IExcelDataReader? reader = null;
        private DataTable? datatable = null;
        private Stream? stream = null;
        public static string ToPascalPropertyName(string input)
        {
            var result = new StringBuilder();
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            // Normalize and remove diacritics
            foreach (char c in input.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    result.Append(c);
            }
            // Remove non-letter/digit characters
            var ascii = Regex.Replace(result.ToString(), @"[^a-zA-Z0-9\s]", " ");
            result.Clear();
            // Split, capitalize, and combine
            var parts = ascii.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                result.Append(char.ToUpperInvariant(part[0]));
                if (part.Length > 1)
                {
                    result.Append(part.Substring(1).ToLowerInvariant());
                }
            }
            return result.ToString();
        }
        public List<T> ParseByFilepath<T>(string filepath) where T : new()
        {
            if (!File.Exists(filepath))
            {
                throw new InvalidOperationException();
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var config = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
            if (string.Equals(Path.GetExtension(filepath), ".xlsx"))
            {
                reader = ExcelReaderFactory.CreateReader(stream);
                if (reader.AsDataSet().Tables.Count == 0)
                {
                    throw new InvalidOperationException("Planilha não encontrada!");
                }
                if (reader.AsDataSet().Tables.Count > 1)
                {
                    throw new InvalidOperationException("Somente uma planilha é suportada!");
                }
                datatable = reader.AsDataSet(config).Tables[0];
            }
            else if (string.Equals(Path.GetExtension(filepath), ".csv"))
            {
                reader = ExcelReaderFactory.CreateCsvReader(stream);
                datatable = reader.AsDataSet(config).Tables[0];
            }
            else
            {
                throw new InvalidOperationException("Formato de arquivo não suportado!");
            }
            if (datatable is null)
            {
                throw new InvalidOperationException("Planilha não encontrada!");
            }
            var type = typeof(T);
            var list = new List<T>();
            var properties = type.GetProperties();
            foreach (DataRow row in datatable.Rows)
            {
                T item = new();
                foreach (DataColumn header in datatable.Columns)
                {
                    var propertyName = ToPascalPropertyName(header.ColumnName);
                    // get property by property name or aliases
                    var property = type.GetProperty(propertyName) ?? properties.FirstOrDefault(
                        p => p.GetCustomAttributes(typeof(AliasAttribute), true).Any(attr =>
                            ((AliasAttribute)attr).Name.Equals(header.ColumnName, StringComparison.OrdinalIgnoreCase) ||
                            ((AliasAttribute)attr).Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)));
                    if (property is null) continue;
                    var value = row[header.ColumnName];
                    if (value is null || value is DBNull) continue;
                    property.SetValue(item, Converter.GetDesiredType(property.PropertyType, value));
                    value = null;
                }
                list.Add(item);
            }
            return list;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (datatable is not null)
                {
                    datatable.Dispose();
                    datatable = null;
                }
                if (reader is not null)
                {
                    reader.Dispose();
                    reader = null;
                }
                if (stream is not null)
                {
                    stream.Dispose();
                    stream = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
