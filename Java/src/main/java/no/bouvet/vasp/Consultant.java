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
	public double calculateYearlyCost() {
		// TODO: Bør flyttes ut v.h.a. Visitor-pattern

		return monthlyFee * 12;
	}

	@Override
	public double calculateHourlyCost() {
		// TODO: Bør flyttes ut v.h.a. Visitor-pattern
		
		Double hoursPerMonth = 37.5 * 4;
		return Math.round(100 * monthlyFee / hoursPerMonth) / 100.0;
	}

	@Override
	public Map<String, String> getReportData() {
		// TODO: Kan evt. flyttes ut v.h.a. en kombinasjon av Strategy- og Visitor-pattern

		Map<String, String> reportData = new HashMap<>();
		
		reportData.put("Name", getName());
		reportData.put("WorkerType", getWorkerType());
		reportData.put("Company", company);
		reportData.put("MonthlyFee", String.valueOf(monthlyFee));
		
		return reportData;
	}
}
