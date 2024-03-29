CREATE TABLE [dbo].[Permit]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DocumentId] Int,
	[InsuranceId] int,
	[PermitNr] NVARCHAR(50),
	[Date] date,
	[PrescriptionId] int,
	[Created] timestamp,
	[Modifed] timestamp,
	[Deleted] bit DEFAULT 0, 
    CONSTRAINT [FK_Permit_Document] FOREIGN KEY ([DocumentId]) REFERENCES [Document]([Id]),
	CONSTRAINT [FK_Permit_Insurance] FOREIGN KEY ([InsuranceId]) REFERENCES [Insurance]([Id]),
	CONSTRAINT [FK_Permit_Prescription] FOREIGN KEY ([PrescriptionId]) REFERENCES [Prescription]([Id])
	
)
