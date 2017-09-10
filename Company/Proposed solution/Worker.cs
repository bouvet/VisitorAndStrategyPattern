namespace Company
{
    public interface IWorker
    {
        string Name { get; }
        void accept(IWorkerVisitor visitor);
    }

    public class Employee : IWorker
    {
        public Employee(string name, string position, decimal monthlySalary)
        {
            Name = name;
            Position = position;
            MonthySalary = monthlySalary;
        }

        public string Name { get; private set; }
        public string Position { get; private set; }
        public decimal MonthySalary { get; private set; }

        public void accept(IWorkerVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Consultant : IWorker
    {
        public Consultant(string name, string company, decimal monthlyFee)
        {
            Name = name;
            Company = company;
            MonthlyFee = monthlyFee;
        }
         
        public string Name { get; private set; }
        public string Company { get; private set; }
        public decimal MonthlyFee { get; private set; }

        public void accept(IWorkerVisitor visitor)
        {
            visitor.visit(this);
        }
    }

}
