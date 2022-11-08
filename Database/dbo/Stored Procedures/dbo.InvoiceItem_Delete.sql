

CREATE PROCEDURE [dbo].[InvoiceItem_Delete] ( @Id INT )
	AS
	BEGIN
		DELETE FROM dbo.InvoiceItem
		WHERE Id = @Id;
	END;
