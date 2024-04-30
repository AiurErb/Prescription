CREATE TABLE [dbo].[Doctor] (
    [Id]   INT    IDENTITY        NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    [LANR] NCHAR (9)      NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

