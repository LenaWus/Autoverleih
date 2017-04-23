CREATE TABLE [dbo].[RentedCars]
(
	[CustomerID] INT NOT NULL, 
    [CarID] INT NOT NULL, 
    [beginOfRenting] DATETIME NOT NULL, 
    [endOfRenting] DATETIME NOT NULL, 
    CONSTRAINT [CustomerID_FK] FOREIGN KEY (CustomerID) REFERENCES Customer([CustomerID]), 
    CONSTRAINT [CarID_FK] FOREIGN KEY (CarID) REFERENCES Car([CarID]),
	CONSTRAINT [RentedCar_PK] PRIMARY KEY (CustomerID, CarID)
)
