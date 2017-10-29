# Visitor- og Strategy-pattern

## Strategy-pattern for rapporter

Logikken for de ulike rapport-formatene (XML, JSON) er nå skilt ut i egne klasser **XmlReport** og **JsonReport** som implementerer grensesnittet **ReportStrategy**. Metoden **generateReport** tar en liste med **Worker** og hver strategi-implementasjon produserer rapporten på sitt format. Dette åpner også for å utvide med nye implementasjoner for andre rapport-formater.

## Visitor-pattern for kostnadsberegninger

Grensesnittet **Worker** og subklassene **Employee** og **Consultant** har nå en metode **accept** som tar en **WorkerVisitor** som parameter. Den kaller visitorens metode **visit** med seg selv som parameter.

Beregninger av årlige kostnader og timekostnader er nå flyttet ut i to implementasjoner av **WorkerVisitor**, nemlig **YearlyCostVisitor** og **HourlyCostVisitor**. I disse samles all relatert logikk for kostnadsberegninger. Visitorene har tilstand og akumulerer kostnader for hver enkelt **Worker** som besøkes.

## Lenker
* http://www.oodesign.com/visitor-pattern.html
* http://www.oodesign.com/strategy-pattern.html