CREATE TABLE [dbo].[Document]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Name] NCHAR(250) NULL, 
    [Type] INT NULL, 
    [Link] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NULL, 
    [Modifed] DATETIME NULL, 
    [Deleted] BIT NULL DEFAULT 0
)
