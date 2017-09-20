using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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
                StringBuilder builder = new StringBuilder();
                foreach (var worker in _workers)
                {
                    if (builder.Length > 0)
                        builder.Append(Environment.NewLine);
                    builder.Append(worker.ReportPlainText);
                }
                return builder.ToString();
            }
        }

        public string WorkerReportJson
        {
            get
            {
                StringBuilder builder = new StringBuilder("[");
                foreach (var worker in _workers)
                {
                    builder.Append(worker.ReportJson);
                }
                builder.Append("]");
                return builder.ToString();
            }
        }
    }
}
