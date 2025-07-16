using System.IO;
using System.Data;
using System.Reflection;
using ExcelDataReader;
namespace Indica.System.FileParser
{
    public static class ParseXLSX
    {
        public static List<T> ParseByFilepath<T>(string filepath, string sheetname) where T : new()
        {
            if (!File.Exists(filepath))
            {
                throw new InvalidOperationException();
            }
            if (!string.Equals(Path.GetExtension(filepath), ".xlsx"))
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
            using var stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var datatable = reader.AsDataSet(config).Tables[sheetname];
            if (datatable is null)
            {
                throw new InvalidOperationException("Planilha não encontrada!");
            }
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public);
            var list = new List<T>();
            foreach (DataRow row in datatable.Rows)
            {
                T item = new();
                foreach (var property in properties)
                {
                    var value = row[property.Name];
                    if (value is null) continue;
                    var converted = Convert.ChangeType(value, property.GetType(), null);
                    property.SetValue(item, converted);
                }
                list.Add(item);
            }
            return list;
        }
    }
}
