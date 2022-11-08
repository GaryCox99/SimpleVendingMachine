CREATE PROCEDURE [dbo].[InvoiceItem_ReadByProductId] ( @ProductId INT
	)
AS
	SET ANSI_NULLS ON
	SET NOCOUNT ON

	SELECT 
		Id ,
		ProductId ,
		ProductId ,
		ProductQuantity
	FROM 
		dbo.InvoiceItem
	WHERE
		ProductId = @ProductId
