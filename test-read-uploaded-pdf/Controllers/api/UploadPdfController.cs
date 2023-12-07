using Microsoft.AspNetCore.Mvc;

namespace test_read_uploaded_pdf.Controllers.api
{
    [Route("api/upload")]
    [ApiController]
    public class UploadPdfController : ControllerBase
    {
        [HttpPost("{type}")]
        public IActionResult UploadFile(IFormFile file, string type)
        {
            if (file != null && file.Length > 0)
            {
                string pdfContent = "";
                if (type == "itextsharp")
                {
                    iTextSharpPdfReader reader = new iTextSharpPdfReader();
                    pdfContent = reader.readPdfFile(file);
                }
                else if (type == "itextcore")
                {
                    iTextCorePdfReader reader = new iTextCorePdfReader();
                    pdfContent = reader.readPdfFile(file);
                }
                else if (type == "pdfpig")
                {
                    PdfPigReader reader = new PdfPigReader();
                    pdfContent = reader.readPdfFile(file);
                }
                else if (type == "docnet")
                {
                    DocNetReader reader = new DocNetReader();
                    pdfContent = reader.readPdfFile(file);
                }
                else if (type == "pdfsharp")
                {
                    PdfSharpPdfReader reader = new PdfSharpPdfReader();
                    pdfContent = reader.readPdfFile(file);
                }

                return Ok(pdfContent);
            }

            return BadRequest("No file uploaded.");
        }
    }
}
