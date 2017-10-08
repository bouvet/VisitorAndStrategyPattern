using System.Text;
using System;
using System.Collections.Generic;

namespace Company
{
    public interface IReport
    {
        string GenerateReport(Worker worker);
    }

    public class PlainTextReport : IReport
    {
        //private readonly StringBuilder _reportBuilder;

        //public PlainTextReport()
        //{
        //    _reportBuilder = new StringBuilder();
        //}

        public string GenerateReport(Worker worker)
        {
            return $"{worker.Name} is working as {worker.WorkerType} at our company.";
        }

        //private string RemoveTrailingNewLine(string value)
        //{
        //    if(!value.EndsWith(Environment.NewLine))
        //       return value;

        //    return value.Substring(0, value.Length - Environment.NewLine.Length);
        //}

        //public string Report => RemoveTrailingNewLine(_reportBuilder.ToString());
    }

    public class JsonReport : IReport
    {
        //private readonly StringBuilder _reportBuilder;

        //public JsonReport()
        //{
        //    _reportBuilder = new StringBuilder("");
        //}

        public string GenerateReport(Worker worker)
        {
            //if (_reportBuilder.Length > 0)
            //    _reportBuilder.Append(",");
            return $@"{{ ""workerType"": ""{worker.WorkerType}"", ""name"": ""{worker.Name}"" }}";
        }
        
        //public string Report => "[" + _reportBuilder + "]";
    }
}
