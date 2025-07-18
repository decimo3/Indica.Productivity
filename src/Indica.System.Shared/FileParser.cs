using System.IO;
using System.Text;
using System.Data;
using System.Reflection;
using ExcelDataReader;
using Indica.System.Shared.Interfaces;
namespace Indica.System.Shared
{
    public class FileParser : IFileParser, IDisposable
    {
        private IExcelDataReader? reader = null;
        private DataTable? datatable = null;
        private Stream? stream = null;
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
            var properties = type.GetProperties();
            var list = new List<T>();
            object? converted;
            foreach (DataRow row in datatable.Rows)
            {
                T item = new();
                foreach (var property in properties)
                {
                    var value = row[property.Name];
                    if (value is null || value is DBNull) continue;
                    if (property.PropertyType == typeof(DateOnly))
                    {
                        if (value.GetType() == typeof(String))
                            value = DateTime.Parse((string)value);
                        converted = DateOnly.FromDateTime((DateTime)value);
                    }
                    else if (property.PropertyType == typeof(TimeOnly))
                    {
                        converted = TimeOnly.FromDateTime((DateTime)value);
                    }
                    else
                    {
                        converted = Convert.ChangeType(value, property.PropertyType, null);
                    }
                    property.SetValue(item, converted);
                    converted = null;
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
