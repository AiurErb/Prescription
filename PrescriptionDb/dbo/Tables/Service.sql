CREATE TABLE [dbo].[Service] (
    [Id]   INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [Type] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

