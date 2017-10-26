using System.Collections.Generic;
using System.Text;

namespace Company
{
    public interface IReportStrategy
    {
        string GenerateWorkerReport(Dictionary<string, string> reportData);
    }

    public class XmlReport : IReportStrategy
    {
        public string GenerateWorkerReport(Dictionary<string, string> reportData)
        {
            var reportBuilder = new StringBuilder("<Worker>");
            foreach (var reportLine in reportData)
            {
                reportBuilder.AppendLine($"<{reportLine.Key}>{reportLine.Value}</{reportLine.Key}>");
            }
            reportBuilder.AppendLine("</Worker>");
            return reportBuilder.ToString();
        }
    }

    public class JsonReport : IReportStrategy
    {
        public string GenerateWorkerReport(Dictionary<string, string> reportData)
        {
            var reportBuilder = new StringBuilder("{");
            foreach(var reportLine in reportData)
            {
                reportBuilder.AppendLine($"\"{reportLine.Key}\":\"{reportLine.Value}\",");
            }
            reportBuilder.RemoveLastComma();
            reportBuilder.AppendLine("},");
            return reportBuilder.ToString();
        }
    }
}
