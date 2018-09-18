package no.bouvet.vasp;

import java.util.List;
import java.util.Map;

public class XmlReportStrategy implements ReportStrategy {

    @Override
    public String generateWorkerReport(Map<String, String> reportData) {
        StringBuilder reportBuilder = new StringBuilder();

        reportBuilder.append("<Worker>");
        reportData.forEach((key, value) ->
                reportBuilder.append(String.format("<%s>%s</%s>", key, value, key)));
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
