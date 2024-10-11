# OEC May 2021 release notes
Zjednodušená možnosť nahratia identifikačných a autentifikačných údajov.

## Dostupnosť
May 2021 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 011|95D183DEF6B2DDA651A86BD8D809548219B9DCE5|1.0.8.0|
|OEC.LAN Internal|update 008|EC0968F61CBA4520C8A5BF7A099F622543AD4749|1.0.8.0|
|OEC.USB CHDU.sk|update 008|C5B7F24331A32DC312AF569FE3A02FE92DAD6D46|1.0.8.0|
|OEC.Android Swissbit|update 001|41BF6E82CD944529AFA2863728C61F95E5473C00|1.3.0.0|

> Release May 2021 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone veriu 010. Pred spustením update sa uistite, že máte nainštalovanú verziu 010. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

## Nová funkcionalita
### Možnosť uploadu autentifikačných a identifikačných údajov cez POST form/multipart-data
 OEC podporuje novú metódu
 ```yaml
 /authidsetraw/{CashRegisterCode}:    
   post:
      summary: Pridá raw AuthId set pre pokladňu
      operationId: addAuthIdSetRaw
      description: |
        Pridá AuthId set pre pokladňu. AuthSet Id nastaví na max(AuthSetId)+1
        Vstup sú autentifikačné alebo identifikačné údaje a heslo. 
        * Ak sú špecifikované autentifikačné aj identifikačné údaje, OEC pridá oba
        * Ak sú špecifikované len autentifikačné alebo len identifikačné, OEC pridá len tie, ktoré sú špecifikované a druhé použije existujúce. Je teda možné poslať len autentifikačné údaje
        * Heslo je povinné pokiaľ sa posielajú autentifikačné údaje
      consumes:
      - multipart/form-data
       
      parameters:
      - in: path
        name: CashRegisterCode
        description: Kód on-line registračnej pokladnice
        required: true
        type: string
      - in: formData
        name: upfile1
        type: file
        required: true
        description: XML súbor
      - in: formData
        name: upfile2
        type: file
        required: false
        description: XML súbor
      - in: query
        name: password
        type: string
        required: false
        description: Heslo k autentifikačným údajom ak sú poslané
      responses:
        201:
          description: AuthId set pridaný
        400:
          description: Zlé heslo alebo autentifikačné údaje nesedia s identifikačnými alebo číslom pokladne
        507:
          description: Kapacita CHDU vyčerpaná
          schema:
            $ref: '#/definitions/ReceiptResponse'
```

## Zmeny
Príprava na optimalizáciu tlače v ďalšich verziách

## Bugfixes a zlepšenia stability
### Odstránený problem update OEC.LAN Internal pri väčších update

### Oprava tlače znaku % v OEC.Android Swissbit
