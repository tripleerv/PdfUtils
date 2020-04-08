// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;
using iTextSharp.text.pdf.draw;

namespace Lodeking.PdfUtils
{
    public class PdfDottedLineSeparator : PdfElement
    {
        public override IElement AsIText()
        {
            return new DottedLineSeparator();
        }
    }
}