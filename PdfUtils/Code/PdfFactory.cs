// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Lodeking.PdfUtils
{
    public class PdfFactory
    {
        public static PdfElement Null()
        {
            return new PdfNull();
        }

        public static PdfDocument Document()
        {
            return new PdfDocument();
        }

        public static PdfCell Cell()
        {
            return new PdfCell();
        }

        public static PdfParagraph Paragraph(string text = null)
        {
            return new PdfParagraph(text);
        }

        public static PdfChunk Chunk(string text)
        {
            return new PdfChunk(text);
        }

        public static PdfBarcode Barcode(string text)
        {
            return new PdfBarcode(text);
        }

        public static PdfTable Table()
        {
            return new PdfTable();
        }

        public static PdfDottedLineSeparator DottedLine()
        {
            return new PdfDottedLineSeparator();
        }

        public static PdfPageBreak PageBreak()
        {
            return new PdfPageBreak();
        }

        public static PdfImage Image(FileStream fileStream)
        {
            return new PdfImage(fileStream);
        }
    }
}