CREATE TABLE [dbo].[Address] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Street]    NVARCHAR (50) NULL,
    [Haus]      NVARCHAR (10)    NULL,
    [ZIP]       NVARCHAR (10)    NULL,
    [City]      NVARCHAR (50) NULL,
    [OwnerId] INT           NULL,
    [OwnerType] INT NULL,
    [Current]   BIT           NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
