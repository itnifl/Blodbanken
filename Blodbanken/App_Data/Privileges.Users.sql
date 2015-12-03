DROP TABLE [dbo].[Schema];
DROP TABLE [dbo].[ExaminationBooking];
DROP TABLE [dbo].[DonorBooking];
DROP TABLE [dbo].[ParkspaceBooking];
DROP TABLE [dbo].[Users];
DROP TABLE [dbo].[Roles];

/**NEW TABLE HERE**/
CREATE TABLE [dbo].[Roles] (
   [userRole] [varchar] (35) NOT NULL PRIMARY KEY,
   [level] [int] NOT NULL, 
   
) ON [PRIMARY];
/*
Select u.logonName From Users AS u JOIN ExaminationBooking AS e ON (u.logonName=e.logonName)
*/
/**NEW TABLE HERE**/
CREATE TABLE [dbo].[Users] (
   [logonName] [varchar] (35) NOT NULL PRIMARY KEY,
   [password] [varchar] (35) NOT NULL,
   [userRole] [varchar] (35) NOT NULL, 
   [firstName] [varchar] (35), 
   [lastName] [varchar] (35), 
   [gender] [varchar] (6) check(gender = 'female' or gender = 'male'),
   [phoneMobile] [varchar] (8), 
   [phoneWork] [varchar] (8), 
   [phonePrivate] [varchar] (8), 
   [eMail] [varchar] (100),
   [age] [int], 
   [address] [varchar] (400),
   [nationalIdentity] [varchar] (11), /* Her har vi fødselsnummeret */
   [persInfoConsent] [int],
   [eMailConsent] [int],
   [phoneConsent] [int]
) ON [PRIMARY];

/**NEW TABLE HERE**/
CREATE TABLE [dbo].[Schema] (
	[schemaID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[logonName] [varchar] (35) NOT NULL,
	[spm1] [int], /*Har du fått informasjon om blodgivning?*/
	[spm2] [int], /*Føler du deg frisk nå?*/
	[spm3] [int], /*Har du gitt blod tidligere*/
	[spm4] [int], /*Hvis du har gitt blod tidligere, har du vært frisk i perioden fra forrige blodgivning og til nå?*/
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
	[spm22] [int], /*Har du i løpet av de siste seks måneder - fått blodoverføring i Afrika eller Sør-Amerika?*/
	[spm23] [int], /*Har du i løpet av de siste seks måneder - stukket eller skåret deg på gjenstander som var forurenset med blod eller kroppsvæsker, bodd i samme husstand som en person som har hepatitt B?*/
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

ALTER TABLE [dbo].[Schema] WITH NOCHECK ADD 
CONSTRAINT [FK_Schema] FOREIGN KEY([logonName]) REFERENCES [dbo].[Users]
(
	[logonName]
);
GO

ALTER TABLE [dbo].[Users] WITH NOCHECK ADD 
CONSTRAINT [FK_Users_Roles] FOREIGN KEY([userRole]) REFERENCES [dbo].[Roles]
(
	[userRole]
);
GO

/**NEW TABLE HERE**/
CREATE TABLE [dbo].[ParkspaceBooking] (
   [bookingID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
   [bookingDate] [DateTime] NOT NULL,
   [parkingSpace] [int] check(parkingSpace >= 1 and parkingSpace <= 10)
) ON [PRIMARY];
GO
/*
SELECT PB.bookingID, PB.bookingDate, PB.parkingSpace, DB.logonName FROM DonorBooking AS DB JOIN ParkspaceBooking AS PB ON (DB.parkingID=PB.parkingSpace) WHERE DB.logonName=@logonNameParam AND PB.bookingDate=@bookingDateParam
*/
/**NEW TABLE HERE**/
CREATE TABLE [dbo].[ExaminationBooking] (
   [bookingID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
   [bookingDate] [DateTime] NOT NULL,
   [durationHours] [int] NOT NULL,
   [logonName] [varchar] (35) NOT NULL,
   [examinationApproved] [DateTime],
   [parkingID] [int]
) ON [PRIMARY];
GO
ALTER TABLE [dbo].[ExaminationBooking] WITH NOCHECK ADD 
CONSTRAINT [FK_ToUsers_ExaminatonBooking] FOREIGN KEY([logonName]) REFERENCES [dbo].[Users]
(
	[logonName]
);
GO

ALTER TABLE [dbo].[ExaminationBooking] WITH NOCHECK ADD 
CONSTRAINT [FK_ToParkingBooking_ExaminationBooking] FOREIGN KEY([parkingID]) REFERENCES [dbo].[ParkspaceBooking]
(
	[bookingID]
);
GO

/**NEW TABLE HERE**/
CREATE TABLE [dbo].[DonorBooking] (
   [bookingID] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
   [bookingDate] [DateTime] NOT NULL,
   [durationHours] [int] NOT NULL,
   [logonName] [varchar] (35) NOT NULL,
   [parkingID] [int]
) ON [PRIMARY];
GO
ALTER TABLE [dbo].[DonorBooking] WITH NOCHECK ADD 
CONSTRAINT [FK_ToUsers] FOREIGN KEY([logonName]) REFERENCES [dbo].[Users]
(
	[logonName]
);
GO
ALTER TABLE [dbo].[DonorBooking] WITH NOCHECK ADD 
CONSTRAINT [FK_ToParkingBooking_DonorBooking] FOREIGN KEY([parkingID]) REFERENCES [dbo].[ParkspaceBooking]
(
	[bookingID]
);
GO

INSERT INTO Roles values('Admin' ,1);
INSERT INTO Roles values('Donor', 2);
INSERT INTO Roles values('Viewer', 3)
INSERT INTO Users (logonName,password,userRole) values('Admin','2ac9cb7dc02b3c0083eb70898e549b63','Admin');
GO