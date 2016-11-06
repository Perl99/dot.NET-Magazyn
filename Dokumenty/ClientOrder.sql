CREATE TABLE [dbo].[Table]
(
	[OrderId] INT NOT NULL PRIMARY KEY, 
    [DataTime] DATETIME NOT NULL, 
    [Paid] BIT NULL, 
    [Status] CHAR(10) NOT NULL, 
    [Amount] MONEY NULL, 
    [ProductId] INT NULL, 
    [Product] NCHAR(10) NULL, 
    [ClientId] INT NULL, 
    [Client] NCHAR(10) NULL
)
