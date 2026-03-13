# OEC March 2026 release notes

- Súlad so zákonom 384/2025
- zlepšenia pri odosielaní dokladu emailom


## Dostupnosť
March 2026 release je dostupný v týchto updatoch

|Zariadenie|Verzia update|SWID|Verzia SW|
|----|----|----|----|
|OEC.LAN Standalone|update 022|71DAC91FCEEFA6EE2CADA283FF8CA9A93C99D746|1.7.0.0|
|OEC.LAN Internal|update 019|87F1E812CBA5F8563CEEC3B213F66F294A75540E|1.7.0.0|
|OEC.Android Swissbit|update 017|9E018572FB15D0CF3F914FF2FAFFA37826D2178D|1.7.0.0|

> Release March 2025 je delta update.  

> Vyžaduje nainštalovanú predošlú verziu. Pre OEC.LAN Standalone minimálne verziu 016. Pred spustením update sa uistite, že máte nainštalovanú minimálne verziu 016. Návod na zistenie verzie je dostupný na [Wiki](https://github.com/datapacsro/oec/wiki/Ako-zisti%C5%A5-verziu-software-OEC)

# Nová funkcionalita
## Súlad so zákonom 384/2025
Táto verzia je v súlade so zákonom 384/2025 a zmenami z neho vyplývajúcimi:
### Posielanie rozpisu DPH do eKasa
Podľa požiadaviek zákona sa znovu zavádza posielanie rozpisu DPH do eKasa. 
- V kategórii základná sadzba 23%, 
- V kategórii znížená sadzba je spočítaná znížená sadzba 19% a 5%

Pokladňa môže odoslať sumár DPH priamo v požiadavke na registráciu dokladu. Pokiaľ pokladnňa nepošle sumár DPH, OEC ho automaticky spočíta na základe položiek dokladu takto: Pre každú sadzbu DPH spočíta sumu za položky a z výslednej sumy vypočíta základ a DPH.
Pri odosielaní správy do eKasa OEC automaticky spočíta do zníženej sadzby DPH sadzby 19% a 5%.

### Minimálna doba odozvy 5s
Defaultná minimálna doba odozvy bola zvýšená na 5s a OEC neumožňuje nastaviť kratšiu dobu odozvy.

### Vklady a výbery sa neodosielajú do eKasa
Vklady a výbery sa neodosielajú do eKasa. Kôli zachovaniu spätnej kompatibility OEC umožňuje pokladni aj naďalej poslať do OEC vklad a výber, vytlačí ho, ale neodošle do eKasa


# Zmeny
## Zlepšenia pri odosielaní dokladu emailom
### Tlač pri chybe SMTP servera
Rozšírili sme kontrolu odpovedí z SMTP servera a v prípade ak indikuje, že email nebol odoslaný, je doklad automaticky vytlačený na tlačiarni.

### Vlastné telo emailu
Pridali sme možnosť nastaviť vlastné telo emailu. Je možné ho nastaviť 
- konfiguráciou globálne alebo pre každú pokladňu
- individuálne ako súčasť requestu na registráciu dokladu. 

OEC použije telo emailu na základe tohto algoritmu
1. Ak je špecifikované pri requeste o evidecniu dokladu https://datapacsro.github.io/oec/#api-Default-addReceipt v sekcii ```ReceiptRenderer/EmailHeaders/Body```, použije sa z requestu
2. Ak je špecifikované v konfigurácii pokladne https://datapacsro.github.io/oec/#api-Default-getCashRegisterConfiguration v sekcii ```SMTPConfiguration/Body```, použije sa z konfigurácie pokladne
3. Ak je špecifikované v globálnej konfigurácii https://datapacsro.github.io/oec/#api-Default-getGlobalConfiguration ```SMTPConfiguration/Body```, použije sa z globálnej konfigurácie

Ak nie je špecifikované, odošle sa prázdne telo emailu (tak ako do teraz).

> Telo emailu môže byť v HTML alebo plain text.


# Bugfixes a zlepšenia stability



