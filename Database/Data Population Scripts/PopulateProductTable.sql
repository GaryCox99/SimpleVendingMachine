

EXEC dbo.Product_Insert 
	@ProductName = "Soda" , 
	@ProductCost = 0.95 , 
	@ProductQuantity = 10

EXEC dbo.Product_Insert
	@ProductName = "Candy Bar" , 
	@ProductCost = 0.60 , 
	@ProductQuantity = 15

EXEC dbo.Product_Insert
	@ProductName = "Chips" , 
	@ProductCost = 0.99 , 
	@ProductQuantity = 12
