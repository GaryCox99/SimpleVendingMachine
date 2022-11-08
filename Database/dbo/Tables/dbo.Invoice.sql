CREATE TABLE [dbo].[Invoice]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [NameOnCard] VARCHAR(50) NULL, 
    [CreditCardNumber] VARCHAR(20) NULL, 
    [CreditCardExpiration] VARCHAR(6) NULL, 
    [CreditCardCVV] VARCHAR(3) NULL DEFAULT 000, 
    [CreditCardZipcode] VARCHAR(5) NULL DEFAULT 00000, 
    [TransactionTotalDue] MONEY NULL DEFAULT 0.00, 
    [TransactionTotalQuantity] INT NULL DEFAULT -1, 
    [TransactionStatus] VARCHAR(20) NULL,
    [CreatedDate] DATETIME NULL, 
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED([Id] ASC)
)
