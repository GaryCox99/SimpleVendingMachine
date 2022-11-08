CREATE TABLE [dbo].[InvoiceItem]
(
	[Id] INT IDENTITY NOT NULL, 
    [InvoiceId] INT NULL, 
    [ProductId] INT NULL, 
    [ProductQuantity] INT NULL,
    CONSTRAINT [PK_InvoiceItem] PRIMARY KEY CLUSTERED([Id] ASC),
    CONSTRAINT [FK_InvoiceItem_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_InvoiceItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON UPDATE CASCADE
)
