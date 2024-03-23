CREATE TABLE [dbo].[PrescribedService] (
    [Id]             INT        NOT NULL,
    [ServiceId]      INT        NULL,
    [PrescriptionId] INT        NULL,
    [Frequency]      NCHAR (10) NULL,
    [Start]          DATE       NULL,
    [End]            DATE       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrescribedService_Prescription] FOREIGN KEY ([PrescriptionId]) REFERENCES [dbo].[Prescription] ([Id]),
    CONSTRAINT [FK_PrescribedService_Service] FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Service] ([Id])
);

