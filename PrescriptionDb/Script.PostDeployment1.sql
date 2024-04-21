/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM dbo.Prescript;
DELETE FROM dbo.PatientsAddress;
DELETE FROM dbo.DoctorsAddress;
DELETE FROM dbo.Doctor;
DELETE FROM dbo.Patient;
DELETE FROM dbo.Insurance;
DELETE FROM dbo.[Service];
DELETE FROM dbo.Document;

DBCC CHECKIDENT('dbo.Patient',RESEED,0);
DBCC CHECKIDENT('dbo.Doctor',RESEED,0);
DBCC CHECKIDENT('dbo.Insurance',RESEED,0);
DBCC CHECKIDENT('dbo.PatientsAddress',RESEED,0);
DBCC CHECKIDENT('dbo.DoctorsAddress',RESEED,0)
DBCC CHECKIDENT('dbo.Prescript',RESEED,0);
DBCC CHECKIDENT('dbo.Service',RESEED,0);
DBCC CHECKIDENT('dbo.Document',RESEED,0);

IF NOT EXISTS (SELECT 1 FROM dbo.Document)
BEGIN
    INSERT INTO dbo.Document
    ([Name],[Type],[Link],[Created],[Modifed])
    VALUES
    ('Doc 1',1,'C:\Users\Aiur\source\repos\Prescription\Prescriptions.MVC\Documents\Scan20240402102954.pdf',GETDATE(),GETDATE()),
    ('Doc 2',1,'C:\Users\Aiur\source\repos\Prescription\Prescriptions.MVC\Documents\Scan20240403132336.pdf',GETDATE(),GETDATE())
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Insurance)
BEGIN
    INSERT INTO dbo.Insurance ([Name])
    VALUES ('DAK'),('AOK')
END;
IF NOT EXISTS (SELECT 1 FROM dbo.Doctor)
BEGIN
    INSERT INTO dbo.Doctor
    ([Name],[LANR])
    VALUES ('Ulrich Peters', '123456789'),
    ('Sibil Shepard', '987654321')
END;
IF NOT EXISTS (SELECT 1 FROM [dbo].[DoctorsAddress])
BEGIN
    INSERT INTO [dbo].DoctorsAddress
    ([Street],[Haus], [ZIP],[DoctorId],[Current])
    VALUES
    ('BuchheimerWeg','23a','51090',1,1),
    ('Müllheimerstr.','140','51130',2,1)
END;
IF NOT EXISTS (SELECT 1 FROM dbo.Patient)
BEGIN
    INSERT INTO dbo.Patient
    ([Name],[InsuranceNumber],[Birthday])
    VALUES ('Robert Höpgen', '345S34589', '1969-05-13'),
    ('Annelene Berke','5634J45','1950-09-21')
END;
IF NOT EXISTS (SELECT 1 FROM dbo.PatientsAddress)
BEGIN
    INSERT INTO PatientsAddress
    ([Street],[Haus],[ZIP],[City],[PatientId],[Current])
    VALUES
    ('Mülheimerstr.','12','51104','Köln',1,1),
    ('Buchheimerstr.','236','51210','Köln',2,1)
END
IF NOT EXISTS (SELECT 1 FROM dbo.ServiceCathegory)
BEGIN
    INSERT INTO dbo.ServiceCathegory ([Name])
    VALUES
    ('Medikamentengabe'),
    ('Herrichten der Medikamentenbox'),
    ('Injection herrichten'),
    ('Injection intrmuskulär'),
    ('Injection subkutan'),
    ('Blutzuckermessung Erst- oder Neueinstellung'),
    ('Blutzuckermessung bei intensivierter Insulintherapie'),
    ('Kompressionsbehandlung rechts'),
    ('Kompressionsbehandlung links'),
    ('Kompressionsbehandlung beideseits'),
    ('Kompressionsstrümpfe anziehen'),
    ('Kompressionsstrümpfe ausziehen'),
    ('Kompressionsverbände anlegen'),
    ('Kompressionsverbande abnehmen'),
    ('Stützende und stabilisierende Verbände, Art')
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Prescript)
BEGIN
    INSERT INTO dbo.Prescript
    ([Date],[PatientId],[DoctorId],[InsuranceId],[Strart],[End],[DocumentId])
    VALUES
    ('2023-03-15',1,1,1,'2023-03-20','2023-04-20',1),
    ('2023-03-30',2,2,2,'2023-04-01','2023-04-30',2)
END;

IF NOT EXISTS (SELECT 1 FROM dbo.[Service])
BEGIN
    INSERT INTO dbo.[Service]
    ([Description],[CathegoryId],[Frequence],[Start],[End],[ParentId],[ParentType])
    VALUES
    ('Beschreibung 1',1,'1t1w1m','2023-04-01','2023-04-30',1,1),
    ('Beschreibung 2',4,'2t1w1m','2023-04-01','2023-04-30',1,1),
    ('',5,'1t1w1m','2023-04-01','2023-04-20',2,1),
    ('Beschreibung 4',6,'2t1w1m','2023-04-20','2023-04-30',2,1)
END;

IF NOT EXISTS (SELECT 1 FROM auth.[User])
BEGIN
    INSERT INTO auth.[User]
    ([Name],[Password],[Role])
    VALUES
    ('User1','1','admin'),
    ('User2','2','user')
END;