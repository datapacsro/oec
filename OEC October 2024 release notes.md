# OEC October 2024 release notes

Podpora nových sadzieb DPH od 1.1.2025
Úprava pre vratné obaly s oslobodením od DPH
Rozšírená podpora Android zariadení


## Dostupnosť
May 2024 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 019|7F08506D1B9FF0481F68D8FDF6552823DAED7E1E|1.6.0.0|
|OEC.LAN Internal|update 016|423A27245CA984FE830BF729794027B85EC3938C|1.6.0.0|
|OEC.USB CHDU.sk|update 016|98C6A1851A6AAE57417BE33272DF8A587D7FA18F|1.6.0.0|

> Release October 2024 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone minimálne verziu 016. Pred spustením update sa uistite, že máte nainštalovanú minimálne verziu 016. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
OEC bolo úspešne certifikované na Finančnej správe a certifikát je platných ďalších 5 rokov do mája 2029.
Pri certifikácii boli zapracované zmeny, ktoré Finančná spáva vyžaduje. Detailný popis nájdete v zmenách nižšie.
Táto verzia prináša aj podporu pre nové sadzby DPH platné od 1.1.2025 na základe rozhodnutia vlády a usmernenia Finančnej správy k implementácii v eKasa.


## Zmeny
### Vratné obaly bez DPH
Vratné obaly sú oslobodené od DPH preto sa nesmú uvádzať v rozpise DPH, ale na samostatnom riadku Oslobodené od DPH.
- Pri predaji vratného obalu OEC akceptuje položku vratný obal s **kladnou** hodnotou a uvedie ju na doklade bez vypísanej sadzby DPH. Typ položky musí byť VO
- Pri výkupe vratného obalu OEC akceptuje položku vratný obal so **zápornou** hodnotou a uvedie ju na doklade bez vypísanej sadzby DPH. Typ položky musí byť VO.

Túto úpravu je potrebné vykonať aj na úrovni pokladničného systému. 

OEC uvedie sumár všetkých položiek mimo režim DPH v samostatnom riadku.

> Do eKasa bude výkup vratných obalov odoslaný ako položka typu VO. Keďže eKasa nepozná predaj vratných obalov, ale zároveň vyžaduje režim mimo DPH, tak označenie predaného vratného obalu VO slúži pre OEC na rozlíšenie predaja a vyčíslenie v rámci sumáru položiek mimo režim DPH. Predaj vratných obalov OEC odosiela do eKasa ako kladnú položku typu K.

### Podpora pre nové sadzby DPH od 1.1.2025
Finančná správa upraví rozhranie eKasa aby podporovalo nové sadzby DPH (celé usmernenie FS nižšie). Na základe toho je potrebné upraviť OEC aj pokladničné aplikácie tak aby boli kompatibilné s týmto usmernením.

#### Úprava OEC
OEC podporuje nové sadzby DPH v novom elemente VATBreakdown pridanom do ReceiptRequest. Tento element je sumár za celý doklad pre ľubovolné sadzby DPH. Využíva sa len na tlač rozpisu DPH na doklade. Do eKasa sa sumár za DPH od 1.1.2025 neposiela.

|Element|Popis|
|---|---|
|TotalBaseAmount|Suma dokladu bez DPH|
|TotalVATAmount|Celková DPH dokladu|
|TotalAmount|Celková suma dokladu s DPH|

Pre jednotlivé sadzby DPH je v elemente VATBreakdown pole VATAmount pre jednotlivé sadzby DPH
|Element|Popis|
|---|---|
|Percentage|Sadzba DPH v percentach|
|BaseAmount|Základ dane za sadzbu|
|VATAmount|Hodnota DPH za sadzbu|
|Amount|Suma s DPH za sadzbu|


**Príklad pre doklad so sadzbami 5, 9, 23**

|Sadzba|Zaklad|DPH|Spolu|
|---:|---:|---:|---:|
| 5%|20.00€|1.00€|21.00€|
| 9%|40.00€|3.60€|43.60€|
|23%|60.00€|13.80€|73.80€|

|Zaklad DPH|DPH celkom|Suma|
|---:|---:|---:|
|120.00€|18.40€|138.40€|

```json
"VATBreakdown": {
                "TotalBaseAmount": 120.00,
                "TotalVATAmount": 18.40,
                "TotalAmount": 138.40,
                "VATAmount": [
                    {
                        "Percentage": 5,
                        "BaseAmount": 20.00,
                        "VATAmount": 1.00,
                        "Amount": 21.00
                    },
                    {
                        "Percentage": 9,
                        "BaseAmount": 40.00,
                        "VATAmount": 3.60,
                        "Amount": 43.60
                    },
                    {
                        "Percentage": 23,
                        "BaseAmount": 60.00,
                        "VATAmount": 13.80,
                        "Amount": 73.80
                    }
                ]
            }
```


#### Usmernenie Finančnej správy z 7.10.2024
> Finančné riaditeľstvo Slovenskej republiky Vám oznamuje, že v rámci zmien dane z pridanej hodnoty (pridanie novej zníženej sadzby a zmeny sadzieb DPH) bol predbežne zvolený variant úpravy systému e-kasa a ORP tak, že v dátovej správe ORP nebude posielať  od. 1.1.2025 žiadnu hodnotu rekapitulácie DPH TaxBaseBasic“, BasicVatAmout“, „TaxBaseReduced“, „ReducedVatAmount“, „TaxFreeAmount“ – aktuálne vo WSDL schéme sú tieto hodnoty ako „optional“, avšak systém e-kasa kontroluje prítomnosť aspoň jednej uvedenej hodnoty v dátovej správe (táto kontrola bude odstránená, o odstránení Vás budeme informovať). Pokladničné doklady rekapituláciu DPH budú naďalej obsahovať v štandardnej forme rozdelenú v členení za jednotlivé sadzby DPH. Bude vykonaná aj úprava tlačového výstupu Neodoslané dátové správy tak, aby tento výstup z ORP neobsahoval rekapituláciu DPH (o prípadnom celkovom zrušení tlačového výstupu Neodoslané dátové správy od. 1.1.2025 Vás budeme informovať).

#### Príklady použitia
##### Doklad registrovaný v roku 2024 so sadzbami DPH 0, 10, 20%
- Doklad je možné zaslať v pôvodnej štruktúre s vyplnenými elementami TaxBaseBasic, TaxBaseReduced, TaxFreeAmount, BasicVatAmount, ReducedVatAmount
- Doklad je možné zaslať aj v novej štruktúre s VATBreakdown za predpokladu, že budú použité len sadzby 0, 10, 20% platné v roku 2024

##### Doklad registrovaný v roku 2025 so sadzbami DPH 0, 5, 10, 19, 20, 23%
- Doklad je možné zaslať **len** v novej štruktúre s VATBreakdown. Doklad zaslaný bez VATBreakdown OEC zamietne




### Jednoúčelové poukazy
- JUP je možné použiť len v kombinácii 1 JUP na 1 položku. Nie je možné mať v doklade viac položiek alebo použiť viac JUP v jednom doklade.
- Ak je výsledná suma dokladu pri použití JUP 0 (JUP sa použije na úhradu celého dokladu), netlačí sa DPH na riadkoch ani sa netlačí rozpis DPH

### Znak €
Znak € nesmie byť použitý v názve položky

### Zabezpečenie Android
Na podporované Android zariadenia je možné nainštalovať len OEC.Adnroid a aplikácie tretích strán podpísané Datapacom. 
Podporované zariadenia od výrobcov Sunmi, PAX a Nexgo sú uvedené v tabuľke nižšie

|Výrobca |Model|
|----|----|
|PAX|A8500|
|PAX|IM25|
|PAX|A6650|
|PAX|A960|
|PAX|A920MAX|
|PAX|A920Pro|
|PAX|A920|
|PAX|A910S|
|PAX|A800|
|PAX|A80|
|PAX|A77|
|PAX|A50S|
|PAX|A50|
|PAX|A35|
|PAX|Aries8|
|PAX|Aries6|
|PAX|M8|
|PAX|M50|
|PAX|E800|
|PAX|E700Mini|
|PAX|E600Mini|
|PAX|IM30|
|PAX|SK800|
|PAX|SK700|
|Nexgo|N86|
|Nexgo|N62|
|Nexgo|N96|
|Nexgo|N82|
|Nexgo|N5|
|Nexgo|N6|
|Nexgo|P200|
|Nexgo|AF910|
|Nexgo|UN20|
|Nexgo|EF60|
|Nexgo|EF910|
|Sunmi|V3 MIX|
|Sunmi|V2 PRO|
|Sunmi|V2s PLUS|
|Sunmi|V2s|
|Sunmi|L2s PRO|
|Sunmi|L2Ks|
|Sunmi|L2H|
|Sunmi|M2|
|Sunmi|M2 MAX|
|Sunmi|P3 MIX|
|Sunmi|P2 LITE SE|
|Sunmi|P2 SE|
|Sunmi|P2 PRO|
|Sunmi|P2|
|Sunmi|P2 SMARTPAD|
|Sunmi|T3 PRO|
|Sunmi|T3 PRO MAX|
|Sunmi|T2s|
|Sunmi|T2s LITE|
|Sunmi|T2|
|Sunmi|T2 MINI|
|Sunmi|D3 PRO|
|Sunmi|D3 MINI|
|Sunmi|D2s KDS|
|Sunmi|D2s PLUS COMBO|
|Sunmi|D2s PLUS|
|Sunmi|D2s COMBO|
|Sunmi|D2s|
|Sunmi|D2s LITE|
|Sunmi|D2 MINI|
|Sunmi|S2|
|Sunmi|FT2|
|Sunmi|K2|
|Sunmi|K2 MINI|
|Sunmi|T1|
|Sunmi|V2|


## Bugfixes a zlepšenia stability


