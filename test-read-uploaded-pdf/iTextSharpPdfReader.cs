using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace test_read_uploaded_pdf
{
    public class iTextSharpPdfReader
    {
        public string readPdfFile(IFormFile pdfFile)
        {
            StringBuilder result = new StringBuilder();
            using (var stream = pdfFile.OpenReadStream())
            {
                // Create a reader for the PDF stream
                using (PdfReader reader = new PdfReader(stream))
                {
                    // Read each page in the PDF document
                    for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
                    {
                        // Extract the text from the current page
                        string pageText = PdfTextExtractor.GetTextFromPage(reader, pageNumber);
                        result.Append(pageText);
                    }
                }
            }
            return result.ToString();
        }

    }
}
