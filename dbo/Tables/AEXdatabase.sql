CREATE TABLE [dbo].[AEXdatabase]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [UserLocation] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(500) NOT NULL,
    [MacAddress] NVARCHAR(500) NOT NULL,
    [PhoneNumber]NVARCHAR(50) NOT NULL,
    [DateRegister] DATE NOT NULL, 
    [DateExpire] DATE NOT NULL
)

