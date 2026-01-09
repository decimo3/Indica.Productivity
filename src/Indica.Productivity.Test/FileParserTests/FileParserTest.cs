using System.IO;
using System.Text.Json;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Shared;
namespace Indica.Productivity.Test
{
    public class FileParserTests
    {
        [Fact]
        public void ParseXLSX_ValidFile_Test()
        {
            var filepathXlsxSample = Path.Combine(
                AppContext.BaseDirectory, "FileParserTests",
                "Samples", "FileParserExcelFileSample.xlsx"
            );
            var filepathJsonSample = Path.Combine(
                AppContext.BaseDirectory, "FileParserTests",
                "Samples", "FileParserExcelFileSample.json"
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
                AppContext.BaseDirectory, "FileParserTests",
                "Samples", "FileParserReportFileSample.csv"
            );
            var filepathJsonSample = Path.Combine(
                AppContext.BaseDirectory, "FileParserTests",
                "Samples", "FileParserReportFileSample.xlsx"
            );
            if (!File.Exists(filepathCsvSample) || !File.Exists(filepathJsonSample)) Assert.Fail();
            using var fileparser = new FileParser();
            var objListFromSample = fileparser.ParseByFilepath<WorkOrderDTO>(filepathJsonSample)
                .OrderBy(l => l.IdActivity).ToList();
            var objListToBeTested = fileparser.ParseByFilepath<WorkOrderDTO>(filepathCsvSample)
                .OrderBy(l => l.IdActivity).ToList();
            objListToBeTested.Should().BeEquivalentTo(objListFromSample, options => options.WithTracing());
        }
    }
}