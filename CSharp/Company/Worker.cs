using System;

namespace Company
{
    public abstract class Worker
    {
        private IReport _reportType;

        protected Worker(string name)
        {
            Name = name;
            _reportType = new PlainTextReport();
        }

        public string Name { get; }

        public string WorkerType { get; protected set; }

        public virtual void SetReportFormat(IReport reportFormat)
        {
            _reportType = reportFormat;
        }

        public virtual string Report()
        {
            return _reportType.GenerateReport(this);
        }
    }

    public class Employee : Worker
    {
        public Employee(string name, string position, decimal monthlySalary)
            : base(name)
        {
            Position = position;
            MonthySalary = monthlySalary;
            WorkerType = "Employee";
        }

        public string Position { get; private set; }
        public decimal MonthySalary { get; private set; }
    }

    public class Consultant : Worker
    {
        public Consultant(string name, string company, decimal monthlyFee)
            : base(name)
        {
            Company = company;
            MonthlyFee = monthlyFee;
            WorkerType = "Consultant";
        }

        public string Company { get; private set; }
        public decimal MonthlyFee { get; private set; }
    }
}
