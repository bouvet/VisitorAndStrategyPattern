namespace Company
{
    public abstract class Worker
    {
        private IReport _reportType;

        protected Worker(string name, string workerType)
        {
            Name = name;
            WorkerType = workerType;
            _reportType = new ShortReport();
        }

        public string Name { get; }

        public string WorkerType { get; }

        public void SetReportFormat(IReport reportFormat)
        {
            _reportType = reportFormat;
        }

        public virtual string Report()
        {
            return _reportType.GenerateReport(this);
        }

        public abstract string GetWorkerDetails();
    }

    public class Employee : Worker
    {
        public Employee(string name, string position, decimal monthlySalary)
            : base(name, "Employee")
        {
            Position = position;
            MonthySalary = monthlySalary;
        }

        public string Position { get; private set; }
        public decimal MonthySalary { get; private set; }
        public override string GetWorkerDetails()
        {
            return $"{Name} works as {Position}, and has a monthly salary of {MonthySalary}";
        }
    }

    public class Consultant : Worker
    {
        public Consultant(string name, string company, decimal monthlyFee)
            : base(name, "Consultant")
        {
            Company = company;
            MonthlyFee = monthlyFee;
        }

        public string Company { get; private set; }
        public decimal MonthlyFee { get; private set; }
        public override string GetWorkerDetails()
        {
            return $"{Name} currently works for {Company}, for a monthy fee of {MonthlyFee}";
        }
    }
}
