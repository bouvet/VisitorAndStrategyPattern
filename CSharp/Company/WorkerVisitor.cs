using System.Text;
using System;
using System.Xml.Linq;

namespace Company
{
    public interface IWorkerVisitor
    {
        void Visit(Employee employee);
        void Visit(Consultant consultant);
    }

    public class ReportPlainTextVisitor : IWorkerVisitor
    {
        private readonly StringBuilder _reportBuilder;

        public ReportPlainTextVisitor()
        {
            _reportBuilder = new StringBuilder();
        }

        public void Visit(Employee employee)
        {
            var employeeInfo = string.Format("Employee {0} works as {1} and earns {2} per month.", employee.Name, employee.Position, employee.MonthySalary);
            _reportBuilder.AppendLine(employeeInfo);
        }

        public void Visit(Consultant consultant)
        {
            var consultantInfo = string.Format("Consultant {0} from {1} costs {2} per month.", consultant.Name, consultant.Company, consultant.MonthlyFee);
            _reportBuilder.AppendLine(consultantInfo);
        }

        private string RemoveTrailingNewLine(string value)
        {
            if(!value.EndsWith(Environment.NewLine))
               return value;

            return value.Substring(0, value.Length - Environment.NewLine.Length);
        }

        public string Report { get { return RemoveTrailingNewLine(_reportBuilder.ToString()); } }
    }

    public class ReportJsonVisitor : IWorkerVisitor
    {
        private readonly StringBuilder _reportBuilder;

        public ReportJsonVisitor()
        {
            _reportBuilder = new StringBuilder();
        }

        public void Visit(Employee employee)
        {
            _reportBuilder.Append(string.Format(@"{{ ""workerType"": ""Employee"", ""name"": ""{0}"", ""position"": ""{1}"", ""monthlySalary"": {2} }}", employee.Name, employee.Position, employee.MonthySalary));
        }

        public void Visit(Consultant consultant)
        {
            _reportBuilder.Append(string.Format(@"{{ ""workerType"": ""Consultant"", ""name"": ""{0}"", ""company"": ""{1}"", ""monthlyFee"": {2} }}", consultant.Name, consultant.Company, consultant.MonthlyFee));
        }

        public string Report
        {
            get { return "[" + _reportBuilder.ToString() + "]"; }
        }
    }
}
