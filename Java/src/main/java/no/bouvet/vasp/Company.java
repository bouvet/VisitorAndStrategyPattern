package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;

public class Company {
	
	public static final String XML_FORMAT = "xml";
	public static final String JSON_FORMAT = "json";
	
	private List<Worker> workers;
	
	private ReportStrategy reportStrategy;

	public Company() {
		workers = new ArrayList<Worker>();
	}

	public void addWorker(Worker worker) {
		workers.add(worker);
	}
	
	public void setReportFormat(String reportFormat) {
		if (JSON_FORMAT.equals(reportFormat)) {
			reportStrategy = new JsonReport();
		} else {
			reportStrategy = new XmlReport();
		}
	}
	
	public String generateReport() {
		return reportStrategy.generateReport(workers);
	}

	public double calculateYearlyCost() {
		double yearlyCost = 0.0;
		for (Worker worker : workers) {
			yearlyCost += worker.calculateYearlyCost();
		}
		return yearlyCost;
	}

	public double calculateAverageHourlyCost() {
		if (workers.size() == 0)
			return 0.0;

		double sumHourlyCost = 0.0;
		for (Worker worker : workers) {
			sumHourlyCost += worker.calculateHourlyCost();
		}

		return Math.round(100 * sumHourlyCost / workers.size()) / 100.0;
	}
}
