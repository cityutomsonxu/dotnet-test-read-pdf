using Docnet.Core.Models;
using Docnet.Core;
using System.Text;
using System.IO;


namespace test_read_uploaded_pdf
{
    public class DocNetReader
    {
        public string readPdfFile(IFormFile pdfFile)
        {
            StringBuilder result = new StringBuilder();
            // Read the uploaded file into a byte array

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                pdfFile.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            using (var docReader = DocLib.Instance.GetDocReader(fileBytes, new PageDimensions()))
            {
                int count = docReader.GetPageCount();
                for (int i = 0; i < docReader.GetPageCount(); i++)
                {
                    using (var pageReader = docReader.GetPageReader(i))
                    {
                        var pageText = pageReader.GetText();
                        result.Append(pageText);
                    }
                }
            }

            return result.ToString();
        }

    }
}
