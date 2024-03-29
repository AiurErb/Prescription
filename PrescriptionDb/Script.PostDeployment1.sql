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
    ('BuchheimerWeg','23a','51090',1,1)
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
    ('Mülheimerstr.','12','51104','Köln',1,1)
END
IF NOT EXISTS (SELECT 1 FROM dbo.ServiceCathgory)
BEGIN
    INSERT INTO dbo.ServiceCathgory ([Name])
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
END