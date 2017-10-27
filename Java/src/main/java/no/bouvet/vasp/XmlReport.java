package no.bouvet.vasp;

import java.util.List;
import java.util.Map;

/**
 * Rapport-strategi som genererer en XML-rapport.
 *
 */
public class XmlReport implements ReportStrategy {

	@Override
	public String generateWorkerReport(Map<String, String> reportData) {
		StringBuilder reportBuilder = new StringBuilder();

		reportBuilder.append("<Worker>");
		reportData.entrySet().forEach(
				reportLine -> reportBuilder.append(
						String.format("<%s>%s</%s>", reportLine.getKey(), reportLine.getValue(), reportLine.getKey())));
		reportBuilder.append("</Worker>");

		return reportBuilder.toString();
	}

	@Override
	public String assembleReport(List<String> workerReports) {
		StringBuilder reportBuilder = new StringBuilder();

		reportBuilder.append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		reportBuilder.append("<Workers>");
		workerReports.forEach(reportBuilder::append);
		reportBuilder.append("</Workers>");

		return reportBuilder.toString();
	}
}
