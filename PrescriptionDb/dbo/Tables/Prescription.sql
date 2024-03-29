CREATE TABLE [dbo].[Prescription] (
    [Id]          INT            NOT NULL,
    [Date]        DATE           NULL,
    [PatientId]   INT            NULL,
    [DoctorId]    INT            NULL,
    [InsuranceId] INT            NULL,
    [Strart]      DATE           NULL,
    [End]         DATE           NULL,
    [DocumentId]        INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Prescription_Doctor] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctor] ([Id]),
    CONSTRAINT [FK_Prescription_Insurance] FOREIGN KEY ([InsuranceId]) REFERENCES [dbo].[Insurance] ([Id]),
    CONSTRAINT [FK_Prescription_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK_Prescription_Document] FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Document] ([Id])
);

