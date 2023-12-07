using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;

namespace test_read_uploaded_pdf
{
    public class iTextCorePdfReader
    {
        public string readPdfFile(IFormFile pdfFile)
        {
            StringBuilder result = new StringBuilder();
            using (var stream = pdfFile.OpenReadStream())
            {
                using (iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(new PdfReader(stream)))
                {
                    for (int pageNumber = 1; pageNumber <= pdfDoc.GetNumberOfPages(); pageNumber++)
                    {
                        PdfPage page = pdfDoc.GetPage(pageNumber);
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string pageText = PdfTextExtractor.GetTextFromPage(page, strategy);
                        result.Append(pageText);
                    }
                }
            }
            return result.ToString();
        }

    }
}
