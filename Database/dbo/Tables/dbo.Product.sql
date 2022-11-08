CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [ProductName] VARCHAR(50) NULL, 
    [ProductCost] MONEY NULL, 
    [ProductQuantity] INT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED([Id] ASC)
)
