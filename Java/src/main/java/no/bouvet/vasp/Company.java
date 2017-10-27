package no.bouvet.vasp;

import static java.util.stream.Collectors.toList;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.base.Joiner;

public class Company {
	
	public static final String XML_FORMAT = "xml";
	public static final String JSON_FORMAT = "json";
	
	private List<Worker> workers;
	
	private String reportFormat;

	public Company() {
		workers = new ArrayList<Worker>();
	}

	public void addWorker(Worker worker) {
		workers.add(worker);
	}
	
	public void setReportFormat(String reportFormat) {
		this.reportFormat = reportFormat;
	}
	
	public String generateReport() {
		if (JSON_FORMAT.equals(reportFormat)) {
			return generateJsonReport();
		} else {
			return generateXmlReport();
		}
	}

	private String generateJsonReport() {
		StringBuilder reportBuilder = new StringBuilder();
		List<String> workerReports = workers.stream()
				.map(Company::generateWorkerJsonReport)
				.collect(toList());
		
		reportBuilder.append("{\"Workers\": [");
		reportBuilder.append(Joiner.on(", ").join(workerReports));
		reportBuilder.append("]}");

		return reportBuilder.toString();
	}
	
	private static String generateWorkerJsonReport(Worker worker) {
		StringBuilder reportBuilder = new StringBuilder();
		Map<String, String> reportData = worker.getReportData();
		
		reportBuilder.append("{");
		reportBuilder.append(Joiner.on(", ").join(reportData.entrySet().stream()
				.map(reportLine -> String.format("\"%s\": \"%s\"", reportLine.getKey(), reportLine.getValue()))
				.collect(toList())));
		reportBuilder.append("}");

		return reportBuilder.toString();
	}

	private String generateXmlReport() {
		StringBuilder reportBuilder = new StringBuilder();
		List<String> workerReports = workers.stream()
				.map(Company::generateWorkerXmlReport)
				.collect(toList());

		reportBuilder.append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		reportBuilder.append("<Workers>");
		workerReports.forEach(reportBuilder::append);
		reportBuilder.append("</Workers>");

		return reportBuilder.toString();
	}
	
	private static String generateWorkerXmlReport(Worker worker) {
		StringBuilder reportBuilder = new StringBuilder();
		Map<String, String> reportData = worker.getReportData();

		reportBuilder.append("<Worker>");
		reportData.entrySet().forEach(
				reportLine -> reportBuilder.append(
						String.format("<%s>%s</%s>", reportLine.getKey(), reportLine.getValue(), reportLine.getKey())));
		reportBuilder.append("</Worker>");

		return reportBuilder.toString();
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
