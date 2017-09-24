using System;
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

        public string WorkerReportPlainText
        {
            get
            {
                var visitor = new ReportPlainTextVisitor();
                foreach (var worker in _workers)
                    worker.Accept(visitor);
                return visitor.Report;
            }
        }

        public string WorkerReportJson
        {
            get
            {
                var visitor = new ReportJsonVisitor();
                foreach (var worker in _workers)
                    worker.Accept(visitor);
                return visitor.Report;
            }
        }
    }
}
