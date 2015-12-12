# Blodbanken - school project

Nettstedet bruker Windows forms autentisering mot database, der hvor passord hash krypteres i
databasen. Databasen er relasjonell med nødvendige relasjoner mellom tabellene av hensyn til
datamodelleringen som var fornuftig for å bygge prosjektet.

Det finnes ikke noe ER diagram over databasen, men den er modellert etter kravene i oppgaven. Det er
greit å legge til at en parkering bare kan bookes i samsvar med en time booking for enten
helseundersøkelse eller doneringstime. Dette er ivaretatt i databaseskjema, da det er relasjoner mellom
timeregistrering og parkering. Logikken er videreført i GUI og backendkode.

Det er et rettighetssystem implementert i l�sningen.
Koden er bygd etter den modellen som er vist ovenfor. Dette for å sortere koden i e oppgavene den er
ment å gjøre, og slik gjøre systemet mer vedlikeholdbart. Dette ble undergravd av mye rask grisekoding,
copy pasting og lite tid til testing for å bli ferdig.


# Bruken av systemet:
   1. Mann logger inn med bruker, eller oppretter en bruker. Sammen med databasen og dens sql
      definisjon er det opprettet en admin bruker med brukernavn Admin og passord: Passord1
   2. Deretter følger man workflow flyten definert i skissen systemet er designet etter. Man kan følge
      denne opp ved å trykke p� velkomstbeskjeden:

Da f�r man en fargekodet liste med meldinger, som viser oppgaver tilknyttet det å være donor,
En rekke andre muligheter er der også, slik som endre passord etc.

   3. Bare administratorer har adgang til kontrollpanelet. Her kan man administrere hele systemet, og
      styre noe med andre brukere. Det er likevel ikke slik at oppgaver som må utføres av dem kan
      utføres av admin selv, det ville for eksempel undergravd poenget med personvernerklæringen.


# Ting som er spesielt bra
   1. Det er brukt mye mer teknologi i løsningen enn kurset har lagt opp til. Det er slik blitt utført mer
      enn pensum. Dette inkluderer JSON, JavaScript generelt, og jQuery. Det er satt opp en asmx
      service for å svare på asynkrone Ajax kall gjort med jQuery.
   2. Det er iplemenert skikkelig Foms Autentisering via Authenticationodule ved å la denne
      implementere RoleProvider. Dette muliggjør vidstrakt autentiseringshåndtering via
       HttpContext.Current.User.
   3. Hele backend er mget godt designet og håndtert objektorientert. All data som hentes og sendes
      omkring i systemet er representert av instantierte klasser. Dette gir også et konseptuelt konsept
      til koden som gjør den lettere å lese.�

# Kjente feil med systemet

Systemet rakk jeg ikke å programmere helt ferdig. Arbeidet med det så mye jeg klarte, men
denne gangen ser det ut som om arbeidsmengden ble mer enn jeg klarte å rekke over til å kunne
skape et system som var 100%.

      * Oppdaterer man bruker i AdminArea.aspx, da lukker alle kontroller seg etterpå, dette er
       ikke korrekt. Grunnen er at GetPostBackControlId ikke klarer å finne knapper.
       
     * Extension method GetPostBackControlId klarer ikke å finne knapper, har prøvd å fikse
       det. Ved postback fra knapper finnes ikke knappen og dermed fungerer ikke koden. Dette
       fører til at seksjoner på kontrollpanelet lukker seg når postback kommer fra en knapp.
       
     * Når man aksepterer en helseundersøkelse lastes siden på nytt og man får ikke beskjed om
       hva som skjer, formen resettes også til start. Dette er feil.
       
     * Akkurat nå kan man booke hele døgnet, la man bare kunne booke i åpningstidene.
     
     * En bruker kan booke timer flere ganger per dag, det skla ikke være lov. Man må vente en
       viss mengde tid mellom gangene.
       
     * Når man velger dato fra kalender for å booke en parkering, skal info om tatte
       parkeringsplasser vises for den dagen. Dette er ikke implementert.
       Mulige timebestillinger å booke parkering for filtreres heller ikke. Dette var planen.
       
    * Man kan ikke slå av JavaScript i browseren, da virker ikke systemet.
    
    * Kode for booking av parkering er laget, men dette fungerer bare delvis. Det ser ikke ut til
       at dato for når bookingen skjer pleier å bli feil, og booking av parkering for ulik type
       tomebooking kan bli feil da typefeltet ikke alltid blir populert.
       
    * Det er ikke skrevet ferdig kode for å vise hvilke parkeringsplasser er opptatt, men det er
       laget mulighet for å vise dette i GUI.
      
    * Det er ingen restriksjoner i Parkeringsbookeren. Det er ingen sjekking av om plassen allerede er tatt.

    * Parkeringsbookeren må testes mye mer før den kan tas i bruk skikkelig, dem har ikke all
       funksjonalitet en gang.
       
    * Automatisk timebooking, denne har jeg ikke rukket å lage annet enn GUI for.
    
    * Det er mulig å booke timer før personalia er utfylt, dette er ikke gunstig da man bare ser
       en brukerkonto på bookingen og ikke noe navn.
       
    * Det burde være mye mer backendverifikasjon av data. Det er for eksempel i visse tilfeller
       mulig å poste data fra en side som ikke lenger viser data i dens rette tilstand, eller er i en
       tilstand som ikke lenger er rett. Dette ville vært unngått om dataen ble verifisert på
       tjenersiden.

    * Det kommer ingen feilmelding når man forsøker å oppdatere passord og dette ikke
       fungerer. Ved autentisering av opprinnelig passord der det skrives feil passord inn og
       autentiseringen feiler, vil ikke passordet oppdateres slk tiltenkt, men ingen beskjd om
       dette kommer. Du får likevel beskjed når alt fungerer.
       
    * Har prøvd å bygge koden så fort som mulig. Dette har gjort at kvaliteten og lesbarheten
       har måtte gi etter. Det er lite kommentarer i koden.


*- Atle Holm - December 2015*