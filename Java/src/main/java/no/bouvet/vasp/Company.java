package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

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
		StringBuilder reportBuilder = new StringBuilder("{ \"Workers\" : [");
		for (Worker worker : workers) {
			reportBuilder.append("{\n");
			for (Map.Entry<String, String> reportLine : worker.getReportData().entrySet()) {
				reportBuilder.append(String.format("\"%s\":\"%s\",\n", reportLine.getKey(), reportLine.getValue()));
			}
			reportBuilder.deleteCharAt(reportBuilder.length() - 2);
			reportBuilder.append("},\n");
		}
		reportBuilder.deleteCharAt(reportBuilder.length() - 2);
		reportBuilder.append("]}\n");
		return reportBuilder.toString();
	}

	private String generateXmlReport() {
		StringBuilder reportBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
		reportBuilder.append("<Workers>\n");
		for (Worker worker : workers) {
			reportBuilder.append("<Worker>\n");
			for (Map.Entry<String, String> reportLine : worker.getReportData().entrySet()) {
				reportBuilder
						.append(String.format("<%s>%s</%s>\n", reportLine.getKey(), reportLine.getValue(), reportLine.getKey()));
			}
			reportBuilder.append("</Worker>\n");
		}
		reportBuilder.append("</Workers>\n");
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
