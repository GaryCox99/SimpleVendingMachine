

CREATE PROCEDURE [dbo].[InvoiceItem_ReadByInvoiceId] ( @InvoiceId INT
	)
AS
	SET ANSI_NULLS ON
	SET NOCOUNT ON

	SELECT 
		Id ,
		InvoiceId ,
		ProductId ,
		ProductQuantity
	FROM 
		dbo.InvoiceItem
	WHERE
		InvoiceId = @InvoiceId
