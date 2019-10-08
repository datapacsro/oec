# OEC.LAN September release notes

## Dostupnosť
September release je dostupný v týchto updatoch
|Zariadenie|Verzia update|SWID|
|----|----|----|
|OEC.LAN Standalone|update 005|8C2D63F7240D7F05B9B9FB1A9CE4DD020D39BDAC|
|OEC.LAN Internal|update 002|854E46AA328D7EC1CD4DF12C5A5D68F18DBB4044|
|OEC.USB CHDU.sk|update 001|5C34558A85441CF744FC0B87853457D143979416|

## Nová funkcionalita
### Podpora Proxy
OEC.LAN podporuje použitie Proxy servera pre komunikáciu s eKasa a Update Service.
Nastavenie je možné cez OECConfigurator alebo API v rámci Globálnej konfigurácie. Default je proxy vpnuté.

### Nastavenie stavu pokladní
Je možné nastaviť stav pokladne cez OECConfigurator alebo API v konfigurácii pokladne.
- Aktívna - Aktívne používaná pokladňa
- Pozastavená - Pozastavená pokladňa. Neumožňuje evidovať doklady. Reportuje sa v healthcheck. Pri pokuse o evidenciu dokladu OEC vráti HTTP status 405.
- Neaktívna - Neaktívna pokladňa. Neumožňuje evidovať doklady. Nereportuje sa v healthcheck. Pri pokuse o evidenciu dokladu OEC vráti HTTP status 405.

### Posielanie dát o doklade emailom
Pri konfigurácii SMTP je možné povoliť zasielanie dát o doklade emailom. Email bude v tom prípade okrem PDF prílohy s tlačovou podobou dokladu obsahovať aj ďalšiu prílohu JSON request, ktorý odoslala pokladňa do OEC.

### Možnosť vypnúť SSL pri SMTP
Je možné vpnúť a zapnúť SSL komunikáciu s SMTP serverom pomocou OECConfigurator alebo API v Globálnej konfigurácii a konfigurácii pokladne.

### Nové administratívne API
Nové api obsahuje možnosti 
- ```GET /api/reboot``` - vykoná reštart zariadenie
- ```GET /api/ping``` - jednoduchý ping, zariadenie vráti HTTP status 200

### Nové API na zistenie stavu dokladu
Nové API umožňuje zistiť kompletný stav dokladu. Na základe dátumu a čísla dokladu poskytne informácie o kompletnom spracovaní dokladu vrátane všetkých pokusoch o odoslanie dokladu do eKasa.

```GET /api/documentinfo/{cashRegisterCode}/{year}/{month}/{receiptNumber}```

### Metóda na otvorenie pokladničnej zásuvky
V prípade, že pokladničná zásuvka je pripojená k tlačiarni, je možné metódou 
```POST api/{cashRegisterCode}/opencashdrawer```
poslať do tlačiarne ESC sekvenciu na otvorenie zásuvky. ESC sekvenciu je možné nadefinovať v PrinterConfiguration podľa typu pripojenej tlačiarne.

### Nové UI pre OECConfigurator
OECConfigurátor dostal nový prehľadnejší vzhľad.

## Zmeny
### CompanyAddress je povinný tag
Tag CompanyAddress je povinný a kontrolovaný v tlačovej šablone


## Bugfixes a zlepšenia stability
### Doposielanie správ
Doposielanie správ je upravené tak aby neblokovalo bežnú prevádzku (registráciu dokladov) aj v prípade, že sa doposiela veľké množstvo správ.

### Chyba 504 pri nepripravenej tlačiarni
Pri nepripravenej tlačiarni (otvorené dvierka, chýba papier, ...) zariadenie čaká definovaný timeout (default 20s). Ak do timeoutu tlačiareň neodpovie, zariadenie vráti korektný HTTP status 202 a výsledok podľa toho ako sa zaevidoval doklad.

### Lepšie spracovanie chýb
Neočakávené chyby a výnimky sú reportované v ReceiptResponse s väčším detailom aby bolo možné určiť príčinu.

### Lepšie uvoľnovanie zdrojov
Lepšie uvoľnovanie zdrojov pri zápise na storage.