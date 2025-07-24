using System.IO;
using System.Text.Json;
using Indica.System.Application.DTO;
using Indica.System.Shared;
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
                "FileParserExcelJsonFileSample.json"
            );
            if (!File.Exists(filepathXlsxSample) || !File.Exists(filepathJsonSample)) Assert.Fail();
            var JsonSampleContent = File.ReadAllText(filepathJsonSample);
            var objListFromSample = JsonSerializer.Deserialize<List<FieldTeamDTO>>(JsonSampleContent);
            if (objListFromSample is null || objListFromSample.Count == 0) Assert.Fail();
            using var fileparser = new FileParser();
            var objListToBeTested = fileparser.ParseByFilepath<FieldTeamDTO>(filepathXlsxSample);
            objListToBeTested.Should().BeEquivalentTo(objListFromSample, options => options.WithTracing());
        }
        [Fact]
        public void ParseCSV_ValidFile_Test()
        {
            var filepathCsvSample = Path.Combine(
                AppContext.BaseDirectory, "Samples",
                "FileParserExcelCsvFileSample.csv"
            );
            var filepathJsonSample = Path.Combine(
                AppContext.BaseDirectory, "Samples",
                "FileParserExcelJsonFileSample.json"
            );
            if (!File.Exists(filepathCsvSample) || !File.Exists(filepathJsonSample)) Assert.Fail();
            var JsonSampleContent = File.ReadAllText(filepathJsonSample);
            var objListFromSample = JsonSerializer.Deserialize<List<WorkOrderDTO>>(JsonSampleContent);
            if (objListFromSample is null || objListFromSample.Count == 0) Assert.Fail();
            using var fileparser = new FileParser();
            var objListToBeTested = fileparser.ParseByFilepath<WorkOrderDTO>(filepathCsvSample);
            objListToBeTested.Should().BeEquivalentTo(objListFromSample, options => options.WithTracing());
        }        
    }
}