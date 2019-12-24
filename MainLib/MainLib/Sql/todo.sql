-- convert string to 'fr-FR'
SELECT PARSE ('mars 15 2012' AS datetime2 using 'fr-FR')

-- roll back work
-- When nesting transactions, ROLLBACK WORK always rolls back to the outermost BEGIN TRANSACTION statement and decrements the @@TRANCOUNT system function to 0.

-- NOT EXISTS
SELECT Name FROM Production.Product WHERE NOT EXISTS (SELECT * FROM Production.ProductSubcategory WHERE ProductSubcategoryID =             Production.Product.ProductSubcategoryID AND Name = 'Mountain Bikes')
SELECT Style FROM Production.Product WHERE EXISTS (SELECT * FROM Production.ProductSubcategory WHERE ProductSubcategoryID =             Production.Product.ProductSubcategoryID AND Name = 'Mountain Bikes')


-- Lock
PAGLOCK
TABLOCK
ROWLOCK
READPAST

-- try catch
BEGIN TRY
    -- Generate a divide-by-zero error.
    SELECT 1/0;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

--CROSS APPLY


-- Create Table
CREATE TABLE Hovercraft.Orders
(
	orderid INT NOT NULL IDENTITY(1, 1)
	CONSTRAINT PK_Orders_orderid PRIMARY KEY,
	custid INT NOT NULL,
	empid INT NOT NULL,
	orderdate DATE NOT NULL
	CONSTRAINT DFT_MyOrders_orderdate DEFAULT (CAST(SYSDATETIME() AS DATE)), shipcountry NVARCHAR(15) NOT NULL,
	freight MONEY NOT NULL
);

-- store procedure with ENCRYPTION
CREATE PROCEDURE HumanResources.uspNamePhoneEmail
WITH ENCRYPTION
AS
   SET NOCOUNT ON;
   SELECT FirstName, LastName, EmailAddress, PhoneNumber
   FROM HumanResources.vEmployee;

-- join Hints
SELECT ph.PurchaseOrderID, ph.OrderDate, pd.ProductID, pd.DueDate, ph.VendorID
FROM Purchasing.PurchaseOrderHeader AS ph
INNER LOOP JOIN Purchasing.PurchaseOrderDetail AS pd
    ON ph.PurchaseOrderID = pd.PurchaseOrderID;

-- Disable/Enable Trigger
DISABLE TRIGGER Hovercraft.service_reminder ON Hovercraft.Logbook
ENABLE TRIGGER Hovercraft.service_reminder ON Hovercraft.Logbook

-- STDEV
Select AVG(Rate) AS 'Average Rate', STDEV(Rate) AS 'Standard Deviation'
FROM HumanResources.EmployeePayHistory
WHERE PayFrequency = 2;

-- TRY_CONVERT will return null
-- CONVERT will not return


-- add sql server example here
-- so that add this as function name format