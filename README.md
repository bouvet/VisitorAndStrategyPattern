# Visitor- og Strategy-pattern

I denne løsningen kombineres Visitor- og Strategy-pattern for å forbedre koden for rapportfunksjonalitet. En ny klasse **ReportVisitor** implementerer **WorkerVisitor** og den instansieres med ønsker strategi for rapportgenerering. På denne måten kan metoden **getReportData** fjernes fra **Worker** og subklasser. Dermed sitter vi igjen med helt "rene" domene-klasser. 

## Lenker
* http://www.oodesign.com/visitor-pattern.html
* http://www.oodesign.com/strategy-pattern.html