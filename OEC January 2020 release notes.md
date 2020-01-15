# OEC January 2020 release notes

## Dostupnosť
September release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 006|06A37BE0649B765B89884BDF8A062A791F6E1A1F|1.0.3.0|
|OEC.LAN Internal|update 003|CA26A6D1EB6E7DF8AF082E78B4D746A9AA618B57|1.0.3.0|
|OEC.USB CHDU.sk|update 003|2ED5A43EA2B276164FF6A1DDA58DA450A0B9447C|1.0.3.0|

> Release January 2020 je delta update. Vyžaduje nainštalovanú predošlú verziu. Pred spustením update sa uistite, že máte nainštalovanú predošlú verziu. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
### Zistenie stavu dokladu
OEC umožňuje zistenie stavu dokladu pomocou API

```
/transaction/{CashRegisterCode} - Vráti poslednú transakciu
/transaction/{CashRegisterCode}/{Count} - Vráti Count posledných transakcií
/transaction/{CashRegisterCode}/{From}/{To} - Vráti transakcie za zvolené dátumové obdobie
```
OEC vráti stav transakcie (spracovania dokladu) tak ako je aktuálne evidovaný v CHDU. Pre každú transakciu vráti
* Request - pôvodný request zrekonštruovaný z informácií v CHDU. Obsahuje len tie informácie, ktoré obsahuje dátová správa. Neobsahuje doplnkové informácie ako napríklad platby atď.
* Response - odpoveď na registráciu dokladu vrátane UID alebo OKP a tlačového výstupu ak bol ako Renderer použitý printer
* TransactionState 
  * Idle - ešte neprebehlo spracovanie dokladu
  * Pending - doklad sa práve spracováva
  * Online - doklad bol spracovaný online
  * Offline - doklad bol spracovaný offline
  * Warning - varovanie pri spracovaní dokladu
  * Error - doklad skončil s chybou (odpoveď z eKasa)

Odporúčané použitie týchto metód je na
* Zistenie stavu poslednej transakcie v prípade výpadku komunikácie medzi pokladňou a OEC. Napríklad z dôvodu výpadku siete, napájania, technického problému na strane pokladne alebo OEC, poškodenia a pod.
* Získanie zoznamu dokladov za určité obdobie a následné porovnanie s dokladmi evidovanými v eKasa systéme pomocou exportu dokladov z eKasa

## Zmeny
### getUnsentMessagesCount vracia iba neodoslané správy
Počet správ nezahŕňa chybné správy.

## Bugfixes a zlepšenia stability
### Oprava číslovania dokladov pri prechode cez mesiac
V niektorých prípadoch keď po prechode na nový mesiac súčasne bežalo doposielanie starých správ a zároveň evidencia nového dokladu sa mohlo stať, že číslovanie dokladov v novom mesiaci sa zmenilo a číslovalo podľa starého mesiaca.

### Chybné dátové správy sa opakovane neposielajú
Chybné dátové správy (pre ktoré eKasa vrátil kód chyby) sa už nedoposielajú keďže ich spracovanie v eKasa pri opätovných pokusoch zlyhá. 
Dátové správy s kódmi chýb -103, -104, -108 je stále možné opraviť pomocou repairReceiptError a repairLocationError
