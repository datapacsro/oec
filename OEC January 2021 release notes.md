# OEC January 2021 release notes
Stabilizačný a bugfix release. Vzhľadom na blížiaci sa termín expirácie prvých certifikátov vydaných 1.4.2019 ale odporúčame inštaláciu tohto release najneskôr do 30.3.2021.

## Dostupnosť
July 2021 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 010|77CD92682012DE2205502BE0FCBE0019B420D7F5|1.0.7.0|
|OEC.LAN Internal|update 007|05110DDDD41762272F1EC55CDB014DB6EE865842|1.0.7.0|
|OEC.USB CHDU.sk|update 007|10F8AB952D2D9C7AE62BCB516EAE359E93DCAD98|1.0.7.0|

> Release January 2021 je delta update.  

> Vyžaduje nainštalovanú verziu 009. Pred spustením update sa uistite, že máte nainštalovanú verziu 009. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita

## Zmeny
### Vylepšená detekcia DIČ v autentifikačných údajoch
V testovacom prostredí eKasa v nových autentifikačných údajoch je použitý iný spôsob uloženia DIČ. OEC bolo upravené tak aby DIČ vedelo získať aj zo zmeneného formátu uloženia DIČ v autentifikačných údajoch.

## Bugfixes a zlepšenia stability
### Oprava preklepu Degrated->Degraded v healthcheck
V healthcheck certifikátov bol opravený preklep pri vyhodnotení zdravia certifikátov. Teraz sa korektne uvádza Degraded. 

### Oprava expiresInDays v healthcheck
expiresInDays nekorektne uvádzal 0 dní v prípade, že certifikát bol ešte platný, ale menej ako 30 dní do skončenia platnosti. Teraz uvádza korektný počet dní.
