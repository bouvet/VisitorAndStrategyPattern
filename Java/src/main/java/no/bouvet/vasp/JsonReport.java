package no.bouvet.vasp;

import java.util.List;
import java.util.Map;

/**
 * Rapport-strategi som genererer en rapport på JSON-format.
 *
 */
public class JsonReport implements ReportStrategy {

	public String generateReport(List<Worker> workers) {
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
}
