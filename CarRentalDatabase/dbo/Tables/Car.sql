CREATE TABLE [dbo].[Car]
(
	[CarID] INT NOT NULL PRIMARY KEY DEFAULT (NEXT VALUE FOR [dbo].[CarIDSequence]), 
    [make] VARCHAR(50) NULL DEFAULT 'N/A', 
    [name] VARCHAR(50) NULL DEFAULT 'N/A', 
    [pricePerHour] DECIMAL(18, 2) NOT NULL, 
    [colour] VARCHAR(50) NULL DEFAULT 'N/A' 
)
