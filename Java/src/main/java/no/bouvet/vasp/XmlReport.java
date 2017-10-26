package no.bouvet.vasp;

import java.util.List;
import java.util.Map;

/**
 * Rapport-strategi som genererer en XML-rapport.
 *
 */
public class XmlReport implements ReportStrategy {

	public String generateReport(List<Worker> workers) {
		StringBuilder reportBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
		reportBuilder.append("<Workers>\n");
		for (Worker worker : workers) {
			reportBuilder.append("<Worker>\n");
			for (Map.Entry<String, String> reportLine : worker.getReportData().entrySet()) {
				reportBuilder.append(String.format("<%s>%s</%s>\n", reportLine.getKey(), reportLine.getValue(), reportLine.getKey()));
			}
			reportBuilder.append("</Worker>\n");
		}
		reportBuilder.append("</Workers>\n");
		return reportBuilder.toString();
	}
}
