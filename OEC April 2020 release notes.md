# OEC April 2020 release notes

## Dostupnosť
April 2020 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 008|69FCD13AAF6E00A309EF6373A3677A2DB0DF963A|1.0.5.0|
|OEC.LAN Internal|update 005|77814CF625089DBAF1B78C17B9661FE14F6E35A6|1.0.5.0|
|OEC.USB CHDU.sk|update 005|C44F5EA9F7CB9EF128E416B7B513F343F28F692B|1.0.5.0|

> Release April 2020 je delta update. Vyžaduje nainštalovanú predošlú verziu. Pred spustením update sa uistite, že máte nainštalovanú predošlú verziu. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
### Podpora autentifikacie a autorizacie
Implementovana podpora pre autentifikaciu a autorizaciu volani OEC API a OEC aplikacii. Funkcionalita je pripravou, samotne zabezpecenie bude predmetom dalsieho update.


### Deep health check
Deep healtcheck umoznuje detailne zistit stav zabudovanej SD karty. Pre zvysenu casovu a vypoctovu narocnost odporucame vykonavat v casovych intervaloch 7 a viac dni. Pocas deephealthcheck moze dojst k pomalsim odozvam a timeouty.

## Zmeny

## Bugfixes a zlepšenia stability
- Oprava memory leak a SQL error 14
