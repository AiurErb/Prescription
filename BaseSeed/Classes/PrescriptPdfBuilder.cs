using Prescription.DAL.Repos;
using PdfSharp;
using System.Data;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;


namespace BaseSeed.Classes
{
    public class PrescriptPdfBuilder
    {
        private PrescriptPdf pdf;
        private IDbConnection _connection;
        public PrescriptPdfBuilder(IDbConnection connection) 
        {
            pdf = new PrescriptPdf();
            _connection = connection;
        }
        public void SetName (string name ) => pdf.FileName = name;
        public void SetPath (string path ) => pdf.Path = path;
        public void SetPatient (long id)
        {
            PatientRepo repo = new PatientRepo(_connection);
            pdf.Patient = repo.GetOne( id );
        }
        public void SetDoctor(long id)
        {
            DoctorRepo repo = new DoctorRepo(_connection);
            pdf.Doctor = repo.GetOne( id );
        }
        public void SetInsurance(long id)
        {
            InsuranceRepo repo = new InsuranceRepo(_connection);
            pdf.Insurance = repo.GetOne(id);
        }
        public void SaveFile()
        {
            if (Capabilities.Build.IsCoreBuild)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
            var document = new PdfDocument();
            document.Info.Title = "Ärztliche Verordnung";
            document.Info.Subject = "Generated";

            var page = document.AddPage();
            page.Size = PageSize.A4;

            var gfx = XGraphics.FromPdfPage( page );
            var font = new XFont("Arial", 12);
            XRect patientRect = new XRect(0, 100, 300, 0);
            gfx.DrawString(pdf.Patient.Name, font, XBrushes.Black,patientRect);
            XRect doctorRect = new XRect(0, 200, 300, 0);
            gfx.DrawString(pdf.Doctor.Name, font, XBrushes.Black, doctorRect);
            XRect insuranceRect= new XRect(0, 400, 300, 0);
            gfx.DrawString(pdf.Insurance.Name, font, XBrushes.Black, insuranceRect);

            string fullPath = Path.Combine(pdf.Path, pdf.FileName);

            document.Save(fullPath);
        }
    }
}
