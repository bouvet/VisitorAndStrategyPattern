# VisitorAndStrategyPattern

Den abstrakte klassen Worker har to implementasjoner, Employee og Consultant.
Begge disse klassene implementerer metodene ReportPlainText og ReportJson.
Oppgaven går ut på å refaktorere slik at denne logikken flyttes ut av Worker og sub-klasser uten å bryte testene i CompanyTests.

Dette kan gjøres vha Visitor- og/eller Strategy-pattern.

http://www.oodesign.com/visitor-pattern.html
http://www.oodesign.com/strategy-pattern.html