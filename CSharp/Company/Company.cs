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

        public string GenerateShortWorkerReport()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var worker in _workers)
            {
                // Strategy pattern: Vi endrer oppførsel, slik at worker.Report() vil generere en kort rapport
                worker.SetReportFormat(new ShortReport());
                var shortReport = worker.Report();
                reportBuilder.AppendLine(shortReport);
            }
            return reportBuilder.ToString();
        }

        public string GenerateDetailedWorkerReport()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var worker in _workers)
            {
                // Strategy pattern: Vi endrer oppførsel, slik at worker.Report() vil generere en detaljert rapport
                worker.SetReportFormat(new DetailedReport());
                var detailedReport = worker.Report();
                reportBuilder.AppendLine(detailedReport);
            }
            return reportBuilder.ToString();
        }
    }
}
