CREATE TABLE [dbo].[Service] (
    [Id]   INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [CathegoryId] int NULL,
    [Frequence] NVARCHAR(12),
    [Start] date,
    [End] date,
    [ParentId] int,
    [ParentType] int
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Service_ToTable] FOREIGN KEY ([CathegoryId]) REFERENCES [ServiceCathegory]([Id])
);

