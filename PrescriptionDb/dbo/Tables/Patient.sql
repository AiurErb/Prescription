CREATE TABLE [dbo].[Patient] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NULL,
    [InsuranceNumber] NCHAR (10)    NULL,
    [Birthday]        DATE          NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

