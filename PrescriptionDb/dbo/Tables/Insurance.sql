CREATE TABLE [dbo].[Insurance] (
    [Id]   INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

