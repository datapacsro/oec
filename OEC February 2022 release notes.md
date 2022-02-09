# OEC February 2022 release notes
Bugfixy a stabilizácia

## Dostupnosť
February 2022 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 015|3938CC215CE8589E5040FCBE1C820C417BCE9FD8|1.4.1.1|
|OEC.LAN Internal|update 012|4BF64CCA104F5477DF3C9F8FCE520BEE7E902CE7|1.4.1.1|
|OEC.USB CHDU.sk|update 012|4944B020BD32E2173F41175D1FDFDD0242475740|1.4.1.1|
|OEC.Android Swissbit|update 004|5F68F7AE51BDD6582EFC9C68D6B90089FA423D30|1.4.1.1|

> Release February 2022 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone minimálne verziu 010. Pred spustením update sa uistite, že máte nainštalovanú minimálne verziu 010. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
### Možnosť zadať aj čas do getTransactionsFromTo
Do polí From/To môžete zadať okrem dátumu aj čas vo formáte 2019-10-16T09:27:36
https://datapacsro.github.io/oec/#api-Default-getTransactionFromTo

## Zmeny
### Timeout na dlhšie requesty voči OEC zvýšený na 10 minút
### Zjednotený endpoint na získanie autentifikačných údajov v OEC.Android 
GET authidset/{cashregistercode}/current

## Bugfixes a zlepšenia stability
### Odstránený problém pri spracovaní viacerých žiadostí o registráciu dokladu

### Opravená chyba keď nesprávna konfigurácia spôsobila error 500

### Odstránený problém pri rýchlo za sebou idúcich dokladoch v OEC.Android

### Odstránený občasný problém s kódovaním diakritiky v OEC.Android

