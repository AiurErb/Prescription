CREATE TABLE [dbo].[Doctor] (
    [Id]   INT    IDENTITY        NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    [LANR] NCHAR (9)      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

