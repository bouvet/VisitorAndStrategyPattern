package no.bouvet.vasp;

import java.util.HashMap;
import java.util.Map;

public class ReportVisitor implements WorkerVisitor {

	private ReportStrategy reportStrategy;
	private String report;

	public ReportVisitor(ReportStrategy reportStrategy) {
		this.reportStrategy = reportStrategy;
	}

	public String getReport() {
		return report;
	}

	@Override
	public void visit(Employee employee) {
		Map<String, String> reportData = new HashMap<>();

		reportData.put("Name", employee.getName());
		reportData.put("WorkerType", employee.getWorkerType());
		reportData.put("Position", employee.getPosition());
		reportData.put("MonthlySalary", String.valueOf(employee.getMonthlySalary()));

		report = reportStrategy.generateWorkerReport(reportData);
	}

	@Override
	public void visit(Consultant consultant) {
		Map<String, String> reportData = new HashMap<>();

		reportData.put("Name", consultant.getName());
		reportData.put("WorkerType", consultant.getWorkerType());
		reportData.put("Company", consultant.getCompany());
		reportData.put("MonthlyFee", String.valueOf(consultant.getMonthlyFee()));

		report = reportStrategy.generateWorkerReport(reportData);
	}
}
