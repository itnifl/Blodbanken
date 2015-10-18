CREATE TABLE [dbo].[Users] (
   [logonName] [varchar] (25) NOT NULL ,
   [password] [varchar] (25) NOT NULL ,
   [userRole] [varchar] (25) NOT NULL, 
) ON [PRIMARY];
CREATE TABLE [dbo].[Roles] (
   [userRole] [varchar] (25) NOT NULL,
   [level] [int] NOT NULL, 
   
) ON [PRIMARY];
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
INSERT INTO Users values('Admin','password1','Admin');
GO