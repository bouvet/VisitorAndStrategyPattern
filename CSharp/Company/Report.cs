
using System.Collections.Generic;
using System.Text;

namespace Company
{
    public interface IReportStrategy
    {
        string GenerateReport(Dictionary<string, string> reportData);
    }

    public class XmlReport : IReportStrategy
    {
        public string GenerateReport(Dictionary<string, string> reportData)
        {
            var reportBuilder = new StringBuilder("");
            foreach (var reportLine in reportData)
            {
                reportBuilder.AppendLine(string.Format("<{0}>{1}</{0}>", reportLine.Key, reportLine.Value));
            }
            return reportBuilder.ToString();
        }
    }

    public class JsonReport : IReportStrategy
    {
        public string GenerateReport(Dictionary<string, string> reportData)
        {
            var reportBuilder = new StringBuilder("");
            foreach (var reportLine in reportData)
            {
                reportBuilder.AppendLine(string.Format("{{{0}:{1}}}>", reportLine.Key, reportLine.Value));
            }
            return reportBuilder.ToString();
        }
    }
}
