using System.IO;
using System.Text.Json;
using Indica.System.Application.DTO;
using Indica.System.FileParser;
namespace Indica.System.Test
{
    public class FileParserTests
    {
        [Fact]
        public void ParseXLSX_ValidFile_Test()
        {
            var filepathXlsxSample = Path.Combine(
                AppContext.BaseDirectory, "Samples",
                "FileParserExcelXlsxFileSample.xlsx"
            );
            var filepathJsonSample = Path.Combine(
                AppContext.BaseDirectory, "Samples",
                "FileParserExcelJsonFileSample.xlsx"
            );
            var objListFromSample = JsonSerializer.Deserialize<List<FieldTeamDTO>>(filepathJsonSample);
            var objListToBeTested = ParseXLSX.ParseByFilepath<FieldTeamDTO>(filepathXlsxSample, "Planilha1");
            Assert.Equal(objListFromSample, objListToBeTested);
        }
    }
}