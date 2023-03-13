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
### Unhealthy bez certifikátov
V prípade, že v OEC nie je nainštalovaný žiadny certifikát, je výsledný stav reportovaný ako ```Unhealthy```
> Do teraz bol takýto stav reportovaný ako ```Healthy```

## Bugfixes a zlepšenia stability
### Zrýchlená reindexácia Swissbit karty

