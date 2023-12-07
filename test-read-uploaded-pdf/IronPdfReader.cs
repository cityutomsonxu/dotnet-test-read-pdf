using Microsoft.AspNetCore.Http;

namespace test_read_uploaded_pdf
{
    public class IronPdfReader
    {
        public string readPdfFile(IFormFile pdfFile)
        {
            using (var stream = pdfFile.OpenReadStream())
            {
                //!!!!CAN'T find method "FromStream" in IronPdf
                //ar pdfDocument = IronPdf.PdfDocument.FromStream(stream);

                // Extract the text from the PDF document
                //string extractedText = pdfDocument.ExtractAllText();
            }

            return "";

        }
    }
}
