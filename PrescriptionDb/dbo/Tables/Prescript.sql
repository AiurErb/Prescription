CREATE TABLE [dbo].[Prescript] (
    [Id]          INT            NOT NULL IDENTITY,
    [Date]        DATE           NULL,
    [PatientId]   INT            NULL,
    [DoctorId]    INT            NULL,
    [InsuranceId] INT            NULL,
    [Strart]      DATE           NULL,
    [End]         DATE           NULL,
    [DocumentId]        INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Prescript_Doctor] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctor] ([Id]),
    CONSTRAINT [FK_Prescript_Insurance] FOREIGN KEY ([InsuranceId]) REFERENCES [dbo].[Insurance] ([Id]),
    CONSTRAINT [FK_Prescript_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK_Prescript_Document] FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Document] ([Id])
);

