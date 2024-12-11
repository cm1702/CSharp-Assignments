create database db13

use db13

CREATE TABLE ProductsDetails (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Price FLOAT,  
    DiscountedPrice AS (Price * 0.9)  
);

CREATE PROCEDURE InsertProduct
    @ProductName VARCHAR(100),
    @Price FLOAT  
AS
BEGIN
    DECLARE @NewProductId INT; 

    DECLARE @InsertedIds TABLE (ProductId INT);

    INSERT INTO ProductsDetails (ProductName, Price)
    OUTPUT INSERTED.ProductId INTO @InsertedIds  
    VALUES (@ProductName, @Price);

    SELECT @NewProductId = ProductId FROM @InsertedIds;

    SELECT @NewProductId AS GeneratedProductId;

	SELECT * FROM ProductsDetails;
END;

EXEC InsertProduct @ProductName = 'COCA COLA', @Price = 120.00;  