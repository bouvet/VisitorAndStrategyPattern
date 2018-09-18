package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ReportVisitor implements WorkerVisitor {

	private ReportStrategy reportStrategy;
	private List<String> workerReports = new ArrayList<>();

	public ReportVisitor(ReportStrategy reportStrategy) {
		this.reportStrategy = reportStrategy;
	}

	public String getReport() {
		return reportStrategy.assembleReport(workerReports);
	}

	@Override
	public void visit(Employee employee) {
		Map<String, String> reportData = new HashMap<>();

		reportData.put("Name", employee.getName());
		reportData.put("WorkerType", employee.getWorkerType());
		reportData.put("Position", employee.getPosition());
		reportData.put("MonthlySalary", String.valueOf(employee.getMonthlySalary()));

		workerReports.add(reportStrategy.generateWorkerReport(reportData));
	}

	@Override
	public void visit(Consultant consultant) {
		Map<String, String> reportData = new HashMap<>();

		reportData.put("Name", consultant.getName());
		reportData.put("WorkerType", consultant.getWorkerType());
		reportData.put("Company", consultant.getCompany());
		reportData.put("MonthlyFee", String.valueOf(consultant.getMonthlyFee()));

		workerReports.add(reportStrategy.generateWorkerReport(reportData));
	}
}
