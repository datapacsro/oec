# OEC July 2020 release notes

## Dostupnosť
July 2020 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 009|E90A0E255D1352EC2C4C3BC14CEAC6EEB05755E6|1.0.6.0|
|OEC.LAN Internal|update 006|A3772145C1132E6D120A82610F19295E67501530|1.0.6.0|
|OEC.USB CHDU.sk|update 006|DC52DC8B6B2239003726B77FD4AA0010CD3A081F|1.0.6.0|

> Release July 2020 je kompletný update. Preto a kôli migrácii na novú platformu je veľkosť update väčšia ako delta updatov. Obsahuje všetky funkcionality z predoškých releasov. 

> Vyžaduje nainštalovanú verziu 008. Pred spustením update sa uistite, že máte nainštalovanú verziu 008. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita

## Zmeny
### Vypnutie kontroly dostupnosti eKasa systému
Na základe informácií z Finančnej správy a avízovaným zmenám bolo vypnuté zisťovanie dostupnosti eKasa systému. Funkcionalita bola postavená na princípe, ktorý eKasa ruší. FS zatiaľ neplánuje poskytnúť funkcionalitu na overenie dostupnosti eKasa systému.

### Zmena platformy
OEC bolo zmigrované na najnovšiu verziu .net core 3.1. Cieľom zmeny je
- zrýchlenie
- optimalizácia využitia zdrojov
- zvýšenie bezpečnosti
- využitie nových možností

Najvýraznejšia zmena je zrýchlenie, kde sa evidencia dokladov je rýhlejšia o 20% a nábeh OEC po reštarte o viac ako 30%.

Zmigrované na novú platformu je samotné PPEKK a OEC Configurator. Ostatné aplikácie budú zmigrované v ďalších releasoch.

> Zmena platformy je výrazná zmena, ktorá bola dôsledne otestovaná a je plne spätne kompatibilná. Napriek tomu je dôležité a odporúčané aby ste pred inštaláciou do prevádzky otestovali kompatibilitu a funkčnosť s pokladničným programom.

### Doplnená dokumentácia k Deep health check

## Bugfixes a zlepšenia stability
### Lepšie ošetrenie stavu preťaženia systému eKasa
V prípade, že je systém eKasa preťažený (pri registrácií dokladov vracia chybu -1), OEC v súlade s požiadavkami FS uzavrie doklad ako offline a zaradí ho do fronty na doposlanie. V prípade, že aj počas doposlania je systém eKasa preťažený, OEC sa bude snažiť doposielať doklad opakovane až kým systém eKasa doklad neakceptuje alebo nevráti inú chybu ako -1.

> OEC automaticky dopošle všetky existujúce doklady s chybou -1.
