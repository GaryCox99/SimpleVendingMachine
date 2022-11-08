

CREATE VIEW [dbo].[ViewInvoices]
AS 
	SELECT 
		ii.InvoiceId ,
		p.ProductName ,
		ii.ProductQuantity ,
		i.TransactionTotalDue ,
		i.TransactionTotalQuantity,
		i.CreatedDate
	FROM 
		dbo.Invoice i
	INNER JOIN dbo.InvoiceItem ii
		ON ii.InvoiceId = i.Id
	INNER JOIN dbo.Product p
		ON p.Id = ii.ProductId
