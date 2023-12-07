using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Text;
using System;
using System.IO;

namespace test_read_uploaded_pdf
{
    public class PdfSharpPdfReader
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

            // Open the PDF document from the byte array
            PdfSharp.Pdf.PdfDocument document;
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                document = PdfReader.Open(memoryStream, PdfDocumentOpenMode.ReadOnly);
            }

            foreach (PdfPage page in document.Pages)
            {
                CObject content = ContentReader.ReadContent(page);
                ExtractText(content, result);
            }

            return result.ToString();
        }

        public string readPdfFile2(IFormFile pdfFile)
        {
            StringBuilder result = new StringBuilder();

            // Read the uploaded file into a byte array
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                pdfFile.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            // Open the PDF document from the byte array
            PdfSharp.Pdf.PdfDocument document;
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                document = PdfReader.Open(memoryStream, PdfDocumentOpenMode.ReadOnly);
            }

            foreach (PdfPage page in document.Pages)
            {
                result.Append(page.Contents.Elements.GetDictionary(0).Stream.ToString());
            }

            return result.ToString();
        }

        private void ExtractText(CObject cObject, StringBuilder textBuilder)
        {
            if (cObject is COperator)
            {
                var cOperator = cObject as COperator;
                if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
                    cOperator.OpCode.Name == OpCodeName.TJ.ToString())
                {
                    foreach (var operand in cOperator.Operands)
                    {
                        if (operand is CString)
                        {
                            var cString = operand as CString;
                            textBuilder.Append(cString.Value);
                        }
                    }
                    textBuilder.Append(Environment.NewLine);
                }
            }
            else if (cObject is CSequence)
            {
                var cSequence = cObject as CSequence;
                foreach (var element in cSequence)
                {
                    ExtractText(element, textBuilder);
                }
            }
        }

    }
}
