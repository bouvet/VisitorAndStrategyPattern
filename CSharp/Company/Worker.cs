namespace Company
{
    public abstract class Worker
    {
        public Worker(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public abstract string ReportPlainText { get; }
        public abstract string ReportJson { get; }
        public abstract decimal CalculateYearlyCost();
    }

    public class Employee : Worker
    {
        public Employee(string name, string position, decimal monthlySalary)
            : base(name)
        {
            Position = position;
            MonthySalary = monthlySalary;
        }

        public string Position { get; private set; }
        public decimal MonthySalary { get; private set; }

        public override string ReportPlainText
        {
            get
            {
                return string.Format("Employee {0} works as {1} and earns {2} per month.", Name, Position, MonthySalary);
            }
        }

        public override string ReportJson
        {
            get
            {
                return string.Format(@"{{ ""workerType"": ""Employee"", ""name"": ""{0}"", ""position"": ""{1}"", ""monthlySalary"": {2} }}", Name, Position, MonthySalary);
            }
        }

        public override decimal CalculateYearlyCost()
        {
            return MonthySalary * 12;
        }
    }

    public class Consultant : Worker
    {
        public Consultant(string name, string company, decimal monthlyFee)
            : base(name)
        {
            Company = company;
            MonthlyFee = monthlyFee;
        }

        public string Company { get; private set; }
        public decimal MonthlyFee { get; private set; }

        public override string ReportPlainText
        {
            get
            {
                return string.Format("Consultant {0} from {1} costs {2} per month.", Name, Company, MonthlyFee);
            }
        }

        public override string ReportJson
        {
            get
            {
                return string.Format(@"{{ ""workerType"": ""Consultant"", ""name"": ""{0}"", ""company"": ""{1}"", ""monthlyFee"": {2} }}", Name, Company, MonthlyFee);
            }
        }

        public override decimal CalculateYearlyCost()
        {
            return MonthlyFee * 12;
        }
    }
}
