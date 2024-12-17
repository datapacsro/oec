# OEC December 2024 release notes

- Zrušenie kontroly kríženia DPH pri odpočítateľnej zálohe a JUP po zmene DPH 1.1.2025


## Dostupnosť
December 2024 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 020|EBF6656EBC366B1C667B5EA4E85D8300AD7F8996|1.6.1.0|
|OEC.LAN Internal|update 017|2B2D8DEE7D2150BFF95BCC3F0711D2A709BAF45A|1.6.1.0|
|OEC.Android Swissbit|update 015|3F2077D71C84905B2088ED37240FDA5719794CF8|1.6.1.0|

> Release December 2024 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone minimálne verziu 016. Pred spustením update sa uistite, že máte nainštalovanú minimálne verziu 016. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

# Nová funkcionalita

# Zmeny

## Zrušenie kontroly kríženia DPH pri odpočítateľnej zálohe a JUP po zmene DPH 1.1.2025
Ak zákazník zaplatil zálohu alebo si obstaral JUP v roku 2024 s DPH 0,10,20%, OEC kontrolovať kríženie DPH pri odpočítaní zálohy alebo uplatnení JUP s novými sadzbami DPH 5,19,23%.

## Odosielanie VATBreakdown do Receipt portal 
Digitálne doklady odosielané do Receipt portal obsahujú členenie DPH v novej štruktúre VATBreakdown

# Bugfixes a zlepšenia stability
## Oprava chyby pri tlaci rozpisu DPH ked je rozdiel vo formatovani elementov
Problém nastáva, ak VatBase0 má iné formátovanie ako VatAmountTotal0. Vtedy sa v rozpise chybne vytlačí text [VATBaseFree:R5.2
[VatRate0:L2.0]%    [VatBase0:R4.2]      [VatAmount0:R4.2]       [VatAmountTotal0:R5.2]



