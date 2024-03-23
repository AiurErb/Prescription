CREATE TABLE [dbo].[DoctorsAddress] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Street]   NVARCHAR (50) NULL,
    [Haus]     NCHAR (10)    NULL,
    [ZIP]      NCHAR (10)    NULL,
    [City]     NVARCHAR (50) NULL,
    [DoctorId] INT           NULL,
    [Current]  BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Doctors] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctor] ([Id])
);

