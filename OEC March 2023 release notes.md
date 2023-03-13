# OEC March 2023 release notes
Zrušenie UIK

## Dostupnosť
March 2023 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 017|60A1929729828DAA625B70A066909B9078F8FB81|1.5.0.0|
|OEC.LAN Internal|update 014|A92CBE0EA1835415B7574638409E3BCF2649EF83|1.5.0.0|
|OEC.USB CHDU.sk|update 014|6CA04DEF6A138F21862A5ACF89332C93108BD9A6|1.5.0.0|
|OEC.Android Swissbit|update 006|19E9F99167003C2E383983D4B282098A64611C94|1.5.0.0|

> Release March 2023 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone minimálne verziu 016. Pred spustením update sa uistite, že máte nainštalovanú minimálne verziu 016. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
### Dátum najstaršej neodoslanej správy
Do healtcheck/unsentmessages sme doplnili element
```oldestMessageDate```, ktorý obsahuje dátum a čas najstaršej neodoslanej správy

Príklad
```json
{
    "unsentMessages": {
        "status": "Healthy",
        "description": "Žiadne neodposlané správy",
        "data": {
            "innerData": [
                {
                    "cashRegisterCode": "88812345678900001",
                    "count": 2,
                    "status": "active",
                    "oldestMessageDate": "2022-09-22T17:27:41+02:00",
                    "healthStatus": "Degraded"
                }
            ]
        }
    }
}
```

## Zmeny
### Zrušenie UIK
OEC už do eKasa neposiela Unikátny identifikátor kupujúceho (UIK). Ak sa v requeste z pokladne bude UIK (CustomerID) nachádzať, OEC ho zmaže a do eKasa nepošle. Doklad bude registrovaný bez UIK.

> V zmysle rozhodnutia Ústavného súdu SR č. 492/2021 Z. z., Nález Ústavného súdu Slovenskej republiky č. k. PL. ÚS 25/2019-117 z 10. novembra 2021 vo veci vysloveniu nesúladu ustanovenia § 8a ods. 1 zákona č. 289/2008 Z. z. o používaní elektronickej registračnej pokladnice a o zmene a doplnení zákona Slovenskej národnej rady č. 511/1992 Zb. o správe daní a poplatkov a o zmenách v sústave územných finančných orgánov v znení neskorších predpisov v časti „unikátny identifikátor kupujúceho, ak je predložený kupujúcim pred zaevidovaním prijatej tržby“ s čl. 16 ods. 1, čl. 19 ods. 2 a 3 Ústavy Slovenskej republiky (https://www.slov-lex.sk/pravne-predpisy/SK/ZZ/2021/492/vyhlasene_znenie.html), bola zrušená existencia unikátneho identifikátora kupujúceho (ďalej len „UIK“).

### Unhealthy bez certifikátov
V prípade, že v OEC nie je nainštalovaný žiadny certifikát, je výsledný stav reportovaný ako ```Unhealthy```
> Do teraz bol takýto stav reportovaný ako ```Healthy```

## Bugfixes a zlepšenia stability
### Zrýchlená reindexácia Swissbit karty

