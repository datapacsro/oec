# OEC October 2021 release notes
Vylepšené doposielanie správ a zistenie stavu tlačiarne v OEC.Android

## Dostupnosť
October 2021 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 014|36903A7BF85408A30A1F4DE4F458DCF0D977859C|1.4.1.0|
|OEC.LAN Internal|update 010|02A8FEACE3F2219F4F7F8E266E94FA14ED9211AD|1.4.1.0|
|OEC.USB CHDU.sk|update 010|90980513BAA71CDD78E9691EE457AF3D147EDE64|1.4.1.0|
|OEC.Android Swissbit|update 003|1CFE110A00E58E8470B6C095B8A4DF50645132CC|1.4.1.0|

> Release October 2021 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone veriu 013. Pred spustením update sa uistite, že máte nainštalovanú verziu 013. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
### Zistenie stavu tlačiarne pre OEC.Android
Vráti stav tlačiarne. Tlačiareň je pripravená na tlač v stave ***Success***

Príklad volania:
```
curl GET http://adresa/oec/api/printerstatus
```

> Podporované pre OEC.Android
```
  /printerstatus:
    get:
      summary: Vráti stav tlačiarne
      description: |
        Tlačiareň je funkčná len ak je jej status ***Success***
        * Success
        * PrinterIsBusy
        * OutOfPaper
        * TheFormatOfPrintDataPacketError
        * PrinterMalfunctions
        * PrinterOverHeats
        * PrinterVoltageIsTooLow
        * PrintingIsUnfinished
        * CutJamError
        * CoverOpenError
        * ThePrinterHasNotInstalledFontLibrary
        * DataPackageIsTooLong
        * OtherError
      responses:
        200: 
          description: OK
          schema:
            type: object
            properties:
              Status:
                type: string
                example: Success
```                

## Zmeny
## Bugfixes a zlepšenia stability
### Vylepšené doposielanie neodoslaných správ
OEC teraz automaticky začne doposielanie neodoslaných správ hneď ako detekuje, že je online. Nie je nutné aby 3 po sebe idúce správy boli offline. Odosielanie sa aktivuje už keď 1 správe je offline a následujúca prejde online.

Zmena sa prejaví najmä na nestabilných pripojeniach.

