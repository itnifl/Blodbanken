DROP TABLE [dbo].[Users];
DROP TABLE [dbo].[Roles];
CREATE TABLE [dbo].[Users] (
   [logonName] [varchar] (35) NOT NULL ,
   [password] [varchar] (35) NOT NULL ,
   [userRole] [varchar] (35) NOT NULL, 
   [firstName] [varchar] (35), 
   [lastName] [varchar], 
   [phoneNumber] [varchar], 
   [age] [int], 
   [address] [varchar],
   [persInfoConsent] [int]
) ON [PRIMARY];
CREATE TABLE [dbo].[Roles] (
   [userRole] [varchar] (35) NOT NULL,
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

ALTER TABLE [dbo].[Users] WITH NOCHECK ADD 
CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[logonName]
) ON [PRIMARY];

ALTER TABLE [dbo].[Roles] WITH NOCHECK ADD 
CONSTRAINT [PK_Roles] PRIMARY KEY NONCLUSTERED 
(
	[userRole]
) ON [PRIMARY];
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
INSERT INTO Users values('Admin','2ac9cb7dc02b3c0083eb70898e549b63','Admin');
GO