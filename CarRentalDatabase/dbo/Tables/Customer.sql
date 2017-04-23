CREATE TABLE [dbo].[Customer]
(
	[CustomerID] INT NOT NULL PRIMARY KEY DEFAULT (NEXT VALUE FOR [dbo].[CustomerIDSequence]), 
    [firstname] VARCHAR(50) NOT NULL, 
    [lastname] VARCHAR(50) NOT NULL, 
    [title] VARCHAR(50) NULL DEFAULT 'Herr/Frau', 
    [age] SMALLINT NOT NULL, 
    [notes] VARCHAR(50) NULL DEFAULT 'N/A'
)
