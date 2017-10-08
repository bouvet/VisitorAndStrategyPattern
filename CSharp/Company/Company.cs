using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
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

        public string GeneratePlainTextWorkerReport()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var worker in _workers)
            {
                worker.SetReportFormat(new PlainTextReport());
                reportBuilder.AppendLine(worker.Report());
            }
            return reportBuilder.ToString();
        }

        public string GenerateJsonWorkerReport()
        {
            StringBuilder reportBuilder = new StringBuilder("[");
            foreach (var worker in _workers)
            {
                worker.SetReportFormat(new JsonReport());
                reportBuilder.AppendLine(worker.Report() + ",");
            }
            string result = reportBuilder.ToString();
            return result.TrimEnd(',') + "]";
        }
    }
}
