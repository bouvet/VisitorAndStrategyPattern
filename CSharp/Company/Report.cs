
namespace Company
{
    public interface IReport
    {
        string GenerateReport(Worker worker);
    }

    public class ShortReport : IReport
    {
        public string GenerateReport(Worker worker)
        {
            return $"{worker.Name} is working as {worker.WorkerType} at our company.";
        }
    }

    public class DetailedReport : IReport
    {
        public string GenerateReport(Worker worker)
        {
            return $"{worker.Name} is working as {worker.WorkerType} at our company. {worker.GetWorkerDetails()}";
        }
    }
}
