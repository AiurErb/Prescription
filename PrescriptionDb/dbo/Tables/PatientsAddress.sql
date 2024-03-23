CREATE TABLE [dbo].[PatientsAddress] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Street]    NVARCHAR (50) NULL,
    [Haus]      NCHAR (10)    NULL,
    [ZIP]       NCHAR (10)    NULL,
    [City]      NVARCHAR (50) NULL,
    [PatientId] INT           NULL,
    [Current]   BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([Id])
);

