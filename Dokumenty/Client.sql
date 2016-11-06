CREATE TABLE [dbo].Client]
(
	[ClientId] INT NOT NULL PRIMARY KEY, 
    [Address] CHAR(30) NULL, 
    [Email] CHAR(20) NULL, 
    [Telephone] CHAR(15) NULL, 
    [Active] BIT NULL, 
    [ClientsOrders] CHAR(10) NULL 
)