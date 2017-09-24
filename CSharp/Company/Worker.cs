namespace Company
{
    public abstract class Worker
    {
        public Worker(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public abstract void Accept(IWorkerVisitor visitor);
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

        public override void Accept(IWorkerVisitor visitor)
        {
            visitor.Visit(this);
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

        public override void Accept(IWorkerVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
