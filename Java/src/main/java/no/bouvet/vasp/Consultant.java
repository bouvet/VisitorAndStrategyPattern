package no.bouvet.vasp;

import java.util.HashMap;
import java.util.Map;

public class Consultant extends Worker {

	private String company;
	private double monthlyFee;

	public Consultant(String name, String company, double monthlyFee) {
		super(name, "Consultant");
		this.company = company;
		this.monthlyFee = monthlyFee;
	}

	public String getCompany() {
		return company;
	}

	public double getMonthlyFee() {
		return monthlyFee;
	}

	@Override
	public Map<String, String> getReportData() {
		Map<String, String> reportData = new HashMap<>();
		
		reportData.put("Name", getName());
		reportData.put("WorkerType", getWorkerType());
		reportData.put("Company", company);
		reportData.put("MonthlyFee", String.valueOf(monthlyFee));
		
		return reportData;
	}

	@Override
	public void accept(WorkerVisitor visitor) {
		visitor.visit(this);
	}
}
