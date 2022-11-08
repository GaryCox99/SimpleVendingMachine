

CREATE FUNCTION [dbo].[InvoiceItemTotalCost]
(
	@Id INT
)
RETURNS INT
AS
BEGIN
	DECLARE @ReturnVar Money

	SELECT @ReturnVar = (
		SELECT SUM(p.ProductCost)
		FROM dbo.InvoiceItem ii
		INNER JOIN dbo.Product p
			ON p.Id = ii.ProductId
		WHERE
			ii.Id = @Id
	)

	RETURN @ReturnVar
END
