package no.bouvet.vasp;

import java.util.List;
import java.util.Map;

/**
 * Rapport-strategi som genererer en XML-rapport.
 *
 */
public class XmlReport implements ReportStrategy {

	public String generateReport(List<Worker> workers) {
		StringBuilder reportBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		reportBuilder.append("<Workers>");
		for (Worker worker : workers) {
			reportBuilder.append("<Worker>");
			for (Map.Entry<String, String> reportLine : worker.getReportData().entrySet()) {
				reportBuilder.append(String.format("<%s>%s</%s>", reportLine.getKey(), reportLine.getValue(), reportLine.getKey()));
			}
			reportBuilder.append("</Worker>");
		}
		reportBuilder.append("</Workers>");
		System.out.println(reportBuilder.toString());
		return reportBuilder.toString();
	}
}
