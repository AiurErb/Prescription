CREATE TABLE [dbo].[Service] (
    [Id]   INT IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (250) NULL,
    [CathegoryId] int NULL,
    [Frequence] NVARCHAR(12),
    [Start] date,
    [End] date,
    [ParentId] int,
    [ParentType] INT,
    [Deleted] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Service_ToTable] FOREIGN KEY ([CathegoryId]) REFERENCES [ServiceCathegory]([Id])
);

