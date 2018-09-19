using System.Collections.Generic;
using System.Text;

namespace Company
{
    public interface IReportStrategy
    {
        string GenerateReport(IList<Worker> workers);
    }

    public class XmlReportStrategy : IReportStrategy
    {
        public string GenerateReport(IList<Worker> workers)
        {
            StringBuilder reportBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            reportBuilder.AppendLine("<Workers>");
            foreach (var worker in workers)
            {
                reportBuilder.AppendLine(GenerateWorkerReport(worker.GetReportData()));
            }
            reportBuilder.AppendLine("</Workers>");
            return reportBuilder.ToString();
        }

        string GenerateWorkerReport(Dictionary<string, string> reportData)
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

    public class JsonReportStrategy : IReportStrategy
    {
        public string GenerateReport(IList<Worker> workers)
        {
            StringBuilder reportBuilder = new StringBuilder("{ \"Workers\" : [");
            foreach (var worker in workers)
            {
                reportBuilder.Append(GenerateWorkerReport(worker.GetReportData()));
            }
            reportBuilder.AppendLine("]}");
            return reportBuilder.ToString();
        }

        string GenerateWorkerReport(Dictionary<string, string> reportData)
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
