CREATE TABLE [dbo].[Table]
(
	[ProductId] INT NOT NULL PRIMARY KEY, 
    [Price] MONEY NOT NULL, 
    [Amount] INT NULL, 
    [Description] CHAR(15) NOT NULL, 
    [Order] CHAR(10) NULL, 
    [Name] NCHAR(30) NULL 
)
