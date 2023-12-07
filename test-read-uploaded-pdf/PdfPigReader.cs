using PdfSharp.Snippets.Drawing;
using System.Text;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace test_read_uploaded_pdf
{
    public class PdfPigReader
    {
        public string readPdfFile(IFormFile pdfFile)
        {
            StringBuilder result = new StringBuilder();
            using (var stream = pdfFile.OpenReadStream())
            {
                using (UglyToad.PdfPig.PdfDocument document = UglyToad.PdfPig.PdfDocument.Open(stream))
                {
                    foreach (var page in document.GetPages())
                    {
                        var pageText = ContentOrderTextExtractor.GetText(page, true);
                        result.Append(pageText);
                    }
                }
            }
            return result.ToString();
        }

    }
}
