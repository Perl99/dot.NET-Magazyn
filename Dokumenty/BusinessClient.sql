CREATE TABLE [dbo].[Table]
(
	[ClientId] INT NOT NULL PRIMARY KEY, 
    [Address] CHAR(30) NOT NULL, 
    [Email] CHAR(20) NULL, 
    [Telephone] CHAR(15) NOT NULL, 
    [Active] BIT NULL, 
    [ClientsOrders] CHAR(10) NULL, 
    [Nip] NCHAR(20) NULL, 
    [Name] NCHAR(30) NULL 
)
