using System.IO;
using System.Text;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using ExcelDataReader;
using Indica.Productivity.Shared.Interfaces;
namespace Indica.Productivity.Shared
{
    public class FileParser : IFileParser, IDisposable
    {
        private IExcelDataReader? reader = null;
        private DataTable? datatable = null;
        public List<T> ParseByFilepath<T>(Stream stream, string filename) where T : new()
        {
            ArgumentNullException.ThrowIfNull(filename);
            if (stream is null || stream.Length == 0 || !stream.CanRead)
                throw new ArgumentException("O fluxo de dados é inválido!");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var config = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            if (string.Equals(Path.GetExtension(filename), ".xlsx"))
            {
                reader = ExcelReaderFactory.CreateReader(stream);
                if (reader.AsDataSet().Tables.Count == 0)
                    throw new InvalidOperationException("Planilha não encontrada!");
                if (reader.AsDataSet().Tables.Count > 1)
                    throw new InvalidOperationException("Somente uma planilha é suportada!");
                datatable = reader.AsDataSet(config).Tables[0];
            }
            else if (string.Equals(Path.GetExtension(filename), ".csv"))
            {
                reader = ExcelReaderFactory.CreateCsvReader(stream);
                datatable = reader.AsDataSet(config).Tables[0];
            }
            else
                throw new InvalidOperationException("Formato de arquivo não suportado!");
            if (datatable is null)
                throw new InvalidOperationException("Planilha não encontrada!");
            var type = typeof(T);
            var list = new List<T>();
            var properties = type.GetProperties();
            foreach (DataRow row in datatable.Rows)
            {
                T item = new();
                var propertiesAdded = 0;
                foreach (DataColumn header in datatable.Columns)
                {
                    var property = type.GetProperty(header.ColumnName) ?? properties.FirstOrDefault(
                        p => p.GetCustomAttributes(typeof(AliasAttribute), true).Any(attr =>
                            ((AliasAttribute)attr).Name.Equals(header.ColumnName, StringComparison.OrdinalIgnoreCase)));
                    if (property is null) continue;
                    var value = row[header.ColumnName];
                    if (value is null || value is DBNull) continue;
                    property.SetValue(item, Converter.GetDesiredType(property.PropertyType, value));
                    propertiesAdded++;
                    value = null;
                }
                if (propertiesAdded == 0)
                    throw new InvalidOperationException($"Nenhuma propriedade mapeada para a classe {type.Name} na planilha {filename}!");
                list.Add(item);
            }
            return list;
        }

        public List<T> ParseByFilepath<T>(string filepath) where T : new()
        {
            ArgumentNullException.ThrowIfNull(filepath);
            if (!File.Exists(filepath))
                throw new FileNotFoundException("Arquivo não encontrado!", filepath);
            using var stream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return ParseByFilepath<T>(stream, Path.GetFileName(filepath));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                datatable?.Dispose();
                datatable = null;
                reader?.Dispose();
                reader = null;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
