DROP TABLE [dbo].[Schema];
DROP TABLE [dbo].[ExaminationBooking];
DROP TABLE [dbo].[Users];
DROP TABLE [dbo].[Roles];

CREATE TABLE [dbo].[Schema] (
	[schemaID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[logonName] [varchar] (35) NOT NULL,
	[spm1] [int], /*Har du fått informasjon om blodgivning?*/
	[spm2] [int], /*Føler du deg frisk nå?*/
	[spm3] [int], /*Hvis du har gitt blod tidligere, har du vært frisk i*/
	[spm4] [int], /*perioden fra forrige blodgivning og til nå?*/
	[spm5] [int], /*Veier du 50 kg eller mer?*/
	[spm6] [int], /*Har du åpne sår, eksem eller hudsykdom?*/
	[spm7] [int], /*Har du piercing i slimhinne?*/
	[spm8] [int], /*Har du i løpet av de siste fire uker - brukt medisiner?*/
	[spm9] [int], /*Har du i løpet av de siste fire uker - vært syk eller hatt feber?*/
	[spm10] [int], /*Har du i løpet av de siste fire uker - hatt løs avføring?*/
	[spm11] [int], /*Har du i løpet av de siste fire uker - fått vaksine?*/
	[spm12] [int], /*Har du i løpet av de siste fire uker - vært hos tannlege eller tannpleier?*/
	[spm13] [int], /*Har du i løpet av de siste seks måneder - vært til legeundersøkelse eller på sykehus, */
	[spm14] [int], /*Har du i løpet av de siste seks måneder - fått behandling for noen sykdom?*/
	[spm15] [int], /*Har du i løpet av de siste seks måneder - fått behandling med sprøyter?*/
	[spm16] [int], /*Har du i løpet av de siste seks måneder - hatt kjønnssykdom, eller fått behandling for kjønnssykdom?*/
	[spm17] [int], /*Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person med HIVinfeksjon eller hepatitt B eller hepatitt C, eller med person som har hatt positiv test for en av disse sykdommene?*/
	[spm18] [int], /*Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person som bruker eller har brukt dopingmidler eller narkotiske midler som sprøyter?*/
	[spm19] [int], /*Har du i løpet av de siste seks måneder - hatt seksuell kontakt med prostituerte eller tidligere prostituerte?*/
	[spm20] [int], /*Har du i løpet av de siste seks måneder - blitt tatovert, fått piercing eller tatt hull i ørene?*/
	[spm21] [int], /*Har du i løpet av de siste seks måneder - fått akupunktur?*/
	[spm22] [int], /*Har du i løpet av de siste seks måneder - stukket eller skåret deg på gjenstander som var forurenset med blod eller kroppsvæsker,*/
	[spm23] [int], /*Har du i løpet av de siste seks måneder - bodd i samme husstand som en person som har hepatitt B?*/
	[spm24] [int], /*Har du i løpet av de siste seks måneder - fått blodsøl på slimhinner eller skadet hud?*/
	[spm25] [int], /*Har du i løpet av de siste seks måneder - blitt bitt av flått?*/
	[spm26] [int], /*Har du i løpet av de siste seks måneder - hatt seksualpartner som har bodd mer enn ett år sammenhengende utenfor Vest-Europa ?*/
	[spm27] [int], /*Har du i løpet av de siste seks måneder - hatt seksualpartner som har vært i Afrika?*/
	[spm28] [int], /*Har du i løpet av de siste seks måneder - hatt seksuell kontakt med en person som har fått blod eller blodprodukter utenfor Norden?*/
	[spm29] [int], /*Har du i løpet av de siste seks måneder - hatt ny seksualpartner?*/
	[spm30] [int], /*Har du i løpet av de siste seks måneder - vært utenfor Vest-Europa?*/
	[spm31] [int], /*Har du i løpet av de siste to år - hatt sjeldne eller alvorlige infeksjonssykdommer?*/
	[spm32] [int], /*Har du på noe tidspunkt gjennom livet - hatt, hjerte-, lever-, eller lungesykdom?*/
	[spm33] [int], /*Har du på noe tidspunkt gjennom livet - hatt kreft?*/
	[spm34] [int], /*Har du på noe tidspunkt gjennom livet - hatt blødningstendens?*/
	[spm35] [int], /*Har du på noe tidspunkt gjennom livet - hatt allergi mot mat eller medisiner?*/
	[spm36] [int], /*Har du på noe tidspunkt gjennom livet - hatt malaria?*/
	[spm37] [int], /*Har du på noe tidspunkt gjennom livet - hatt tropesykdommer?*/
	[spm38] [int], /*Har du på noe tidspunkt gjennom livet - hatt hepatitt (gulsott), HIV-infeksjon eller AIDS?*/
	[spm39] [int], /*Har du på noe tidspunkt gjennom livet - hatt positiv prøve for hepatitt (gulsott) eller HIVinfeksjon?*/
	[spm40] [int], /*Har du på noe tidspunkt gjennom livet - fått blodoverføring?*/
	[spm41] [int], /*Har du på noe tidspunkt gjennom livet - fått veksthormon?*/
	[spm42] [int], /*Har du på noe tidspunkt gjennom livet - fått hornhinnetransplantat?*/
	[spm43] [int], /*Har du på noe tidspunkt gjennom livet - hatt syfilis?*/
	[spm44] [int], /*Har du på noe tidspunkt gjennom livet - hatt alvorlig sykdom som ikke er nevnt her?*/
	[spm45] [int], /*Har du på noe tidspunkt gjennom livet - brukt dopingmidler eller narkotiske midler som sprøyter?*/
	[spm46] [int], /*Har du på noe tidspunkt gjennom livet - mottatt penger eller narkotika som gjenytelse for sex?*/
	[spm47] [int], /*Besvares av kvinner - Er du gravid?*/
	[spm48] [int], /*Besvares av kvinner - Har du vært gravid i løpet av de siste tolv måneder, eller ammer du nå?*/
	[spm49] [int], /*Besvares av kvinner - Hvis du har gitt blod tidligere, har du vært gravid siden forrige blodgivning?*/
	[spm50] [int], /*Besvares av kvinner - Har du i løpet av de siste seks måneder hatt seksuell kontakt med en mann som du vet har hatt seksuell kontakt med andre menn?*/
	[spm51] [int], /*Besvares av menn - Har eller har du hatt seksuell kontakt med andre menn?*/
	[spm52] [int], /*Har du brukt narkotika en eller flere ganger de siste 12 måneder?*/
	[spm53] [int], /*Har du eller noen i familien hatt Creutzfeldt-Jakob sykdom eller variant CJD?*/
	[spm54] [int], /*Har du oppholdt deg i Storbritannia i mer enn ett år til sammen i perioden mellom 1980 og 1996?*/
	[spm55] [int], /*Har du i løpet av de siste tre år vært i områder der malaria forekommer?*/
	[spm56] [int], /*Har du oppholdt deg sammenhengende i minst seks måneder i områder der malaria forekommer?*/
	[spm57] [int], /*Har du oppholdt deg i Afrika i mer enn fem år til sammen?*/
	[spm58] [int], /*Er du eller din mor født i Amerika sør for USA?*/
	[spm59] [int], /*Godtar du at anonymiserte prøver av ditt blod kan brukes til forskning? Du er like velkommen som blodgiver enten du svarer ja eller nei. Blodbanken kan gi informasjon om aktuelle forskningsprosjekter.*/
	[spm60] [int] /*Har du deltatt i medikamentforsøk de siste 12 måneder?*/

) ON [PRIMARY];

CREATE TABLE [dbo].[Users] (
   [logonName] [varchar] (35) NOT NULL PRIMARY KEY,
   [password] [varchar] (35) NOT NULL,
   [userRole] [varchar] (35) NOT NULL, 
   [firstName] [varchar] (35), 
   [lastName] [varchar], 
   [phoneMobile] [varchar], 
   [phoneWork] [varchar], 
   [phonePrivate] [varchar], 
   [eMail] [varchar],
   [age] [int], 
   [address] [varchar],
   [nationalIdentity] [int],
   [persInfoConsent] [int],
   [eMailConsent] [int],
   [phoneConsent] [int]
) ON [PRIMARY];
CREATE TABLE [dbo].[Roles] (
   [userRole] [varchar] (35) NOT NULL PRIMARY KEY,
   [level] [int] NOT NULL, 
   
) ON [PRIMARY];
CREATE TABLE [dbo].[ExaminationBooking] (
   [bookingID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
   [bookingDate] [date] NOT NULL,
   [logonName] [varchar] (35) NOT NULL
) ON [PRIMARY];
GO
ALTER TABLE [dbo].[ExaminationBooking] WITH NOCHECK ADD 
CONSTRAINT [FK_ExaminationBooking] FOREIGN KEY([logonName]) REFERENCES [dbo].[Users]
(
	[logonName]
);
GO

CREATE TABLE [dbo].[DonorBooking] (
   [bookingID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
   [bookingDate] [date] NOT NULL,
   [logonName] [varchar] (35) NOT NULL
) ON [PRIMARY];
GO
ALTER TABLE [dbo].[DonorBooking] WITH NOCHECK ADD 
CONSTRAINT [FK_DonorBooking] FOREIGN KEY([logonName]) REFERENCES [dbo].[Users]
(
	[logonName]
);
GO

ALTER TABLE [dbo].[Schema] WITH NOCHECK ADD 
CONSTRAINT [FK_Schema] FOREIGN KEY([logonName]) REFERENCES [dbo].[Users]
(
	[logonName]
);
GO

ALTER TABLE [dbo].[Users] WITH NOCHECK ADD 
CONSTRAINT [FK_Users] FOREIGN KEY([userRole]) REFERENCES [dbo].[Roles]
(
	[userRole]
);
GO

INSERT INTO Roles values('Admin' ,1);
INSERT INTO Roles values('Donor', 2);
INSERT INTO Roles values('Viewer', 3)
INSERT INTO Users (logonName,password,userRole) values('Admin','2ac9cb7dc02b3c0083eb70898e549b63','Admin');
GO
/*Hele skjema her:*/
/*
Har du fått informasjon om blodgivning?
Føler du deg frisk nå?
Hvis du har gitt blod tidligere, har du vært frisk i
perioden fra forrige blodgivning og til nå?
Veier du 50 kg eller mer?
Har du åpne sår, eksem eller hudsykdom?
Har du piercing i slimhinne?
Har du i løpet av de siste fire uker - brukt medisiner?
Har du i løpet av de siste fire uker - vært syk eller hatt feber?
Har du i løpet av de siste fire uker - hatt løs avføring?
Har du i løpet av de siste fire uker - fått vaksine?
Har du i løpet av de siste fire uker - vært hos tannlege eller tannpleier?
Har du i løpet av de siste seks måneder - vært til legeundersøkelse eller på sykehus, 
Har du i løpet av de siste seks måneder - fått behandling for noen sykdom?
Har du i løpet av de siste seks måneder - fått behandling med sprøyter?
Har du i løpet av de siste seks måneder - hatt kjønnssykdom, eller fått behandling for kjønnssykdom?
Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person med HIVinfeksjon eller hepatitt B eller hepatitt C, eller med person som har hatt positiv test for en av disse sykdommene?
Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person som bruker eller har brukt dopingmidler eller narkotiske midler som sprøyter?
Har du i løpet av de siste seks måneder - hatt seksuell kontakt med prostituerte eller tidligere prostituerte?
Har du i løpet av de siste seks måneder - blitt tatovert, fått piercing eller tatt hull i ørene?
Har du i løpet av de siste seks måneder - fått akupunktur?
Har du i løpet av de siste seks måneder - stukket eller skåret deg på gjenstander som var forurenset med blod eller kroppsvæsker,
Har du i løpet av de siste seks måneder - bodd i samme husstand som en person som har hepatitt B?
Har du i løpet av de siste seks måneder - fått blodsøl på slimhinner eller skadet hud?
Har du i løpet av de siste seks måneder - blitt bitt av flått?
Har du i løpet av de siste seks måneder - hatt seksualpartner som har bodd mer enn ett år sammenhengende utenfor Vest-Europa ?
Har du i løpet av de siste seks måneder - hatt seksualpartner som har vært i Afrika?
Har du i løpet av de siste seks måneder - hatt seksuell kontakt med en person som har fått blod eller blodprodukter utenfor Norden?
Har du i løpet av de siste seks måneder - hatt ny seksualpartner?
Har du i løpet av de siste seks måneder - vært utenfor Vest-Europa?
Har du i løpet av de siste to år - hatt sjeldne eller alvorlige infeksjonssykdommer?
Har du på noe tidspunkt gjennom livet - hatt, hjerte-, lever-, eller lungesykdom?
Har du på noe tidspunkt gjennom livet - hatt kreft?
Har du på noe tidspunkt gjennom livet - hatt blødningstendens?
Har du på noe tidspunkt gjennom livet - hatt allergi mot mat eller medisiner?
Har du på noe tidspunkt gjennom livet - hatt malaria?
Har du på noe tidspunkt gjennom livet - hatt tropesykdommer?
Har du på noe tidspunkt gjennom livet - hatt hepatitt (gulsott), HIV-infeksjon eller AIDS?
Har du på noe tidspunkt gjennom livet - hatt positiv prøve for hepatitt (gulsott) eller HIVinfeksjon?
Har du på noe tidspunkt gjennom livet - fått blodoverføring?
Har du på noe tidspunkt gjennom livet - fått veksthormon?
Har du på noe tidspunkt gjennom livet - fått hornhinnetransplantat?
Har du på noe tidspunkt gjennom livet - hatt syfilis?
Har du på noe tidspunkt gjennom livet - hatt alvorlig sykdom som ikke er nevnt her?
Har du på noe tidspunkt gjennom livet - brukt dopingmidler eller narkotiske midler som sprøyter?
Har du på noe tidspunkt gjennom livet - mottatt penger eller narkotika som gjenytelse for sex?
Besvares av kvinner - Er du gravid?
Besvares av kvinner - Har du vært gravid i løpet av de siste tolv måneder, eller ammer du nå?
Besvares av kvinner - Hvis du har gitt blod tidligere, har du vært gravid siden forrige blodgivning?
Besvares av kvinner - Har du i løpet av de siste seks måneder hatt seksuell kontakt med en mann som du vet har hatt seksuell kontakt med andre menn?
Besvares av menn - Har eller har du hatt seksuell kontakt med andre menn?
Har du brukt narkotika en eller flere ganger de siste 12 måneder?
Har du eller noen i familien hatt Creutzfeldt-Jakob sykdom eller variant CJD?
Har du oppholdt deg i Storbritannia i mer enn ett år til sammen i perioden mellom 1980 og 1996?
Har du i løpet av de siste tre år vært i områder der malaria forekommer?
Har du oppholdt deg sammenhengende i minst seks måneder i områder der malaria forekommer?
Har du oppholdt deg i Afrika i mer enn fem år til sammen?
Er du eller din mor født i Amerika sør for USA?
Godtar du at anonymiserte prøver av ditt blod kan brukes til forskning? Du er like velkommen som blodgiver enten du svarer ja eller nei. Blodbanken kan gi informasjon om aktuelle forskningsprosjekter.
Har du deltatt i medikamentforsøk de siste 12 måneder?

Jeg samtykker i at mitt plasma føres ut av Norge for legemiddelproduksjon
Dato og underskrift

Plass for eventuelle tilleggsopplysninger

Dato Din underskrift

Fylles ut av blodbanken
Hb: BT: Puls Konklusjon vedrørende blodgivning:
Dato: ......................... Blodbankens signatur: ........................................................................................................
*/