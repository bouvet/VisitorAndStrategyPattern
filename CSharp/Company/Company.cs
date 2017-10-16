using System.Collections.Generic;
using System.Text;

namespace Company
{
    public class Company
    {
        private readonly IList<Worker> _workers;

        public Company()
        {
            _workers = new List<Worker>();
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public string GenerateJsonReport()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var worker in _workers)
            {
                // Strategy pattern: Vi endrer oppførsel, slik at worker.Report() vil generere en Json-rapport
                worker.SetReportStrategy(new JsonReport());
                var shortReport = worker.Report();
                reportBuilder.AppendLine(shortReport);
            }
            return reportBuilder.ToString();
        }

        public string GenerateXmlReport()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var worker in _workers)
            {
                // Strategy pattern: Vi endrer oppførsel, slik at worker.Report() vil generere en Xml-rapport
                worker.SetReportStrategy(new XmlReport());
                var detailedReport = worker.Report();
                reportBuilder.AppendLine(detailedReport);
            }
            return reportBuilder.ToString();
        }
    }
}
