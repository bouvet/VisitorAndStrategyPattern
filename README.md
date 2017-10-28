# Visitor- og Strategy-pattern

Den abstrakte klassen **Worker** har to implementasjoner, **Employee** og **Consultant**. Disse inneholder logikk som bør flyttes ut i separate klasser:
* Logikk for kostnadsberegninger
* Logikk for å levere rådata til rapporter

Klassen **Company** inneholder funksjonalitet for å generere rapporter på XML- og JSON-format. Også denne logikken bør flyttes ut.

Dette kan gjøres vha Visitor- og/eller Strategy-pattern.

Oppgavene går ut på å refaktorere slik at logikken flyttes uten å bryte testene i CompanyTests:
* Bruk **Strategy**-pattern for å flytte ut rapport-logikken fra Company
* Bruk **Visitor**-pattern for å flytte ut kostnadsberegningene fra Worker og subklasser
* Kombiner **Visitor** med **Strategy** for å fjerne all rapport-relatert kode fra Worker og subklasser

Lenker:
* http://www.oodesign.com/visitor-pattern.html
* http://www.oodesign.com/strategy-pattern.html