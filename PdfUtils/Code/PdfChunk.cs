// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;

namespace Lodeking.PdfUtils
{
    public class PdfChunk : PdfElement
    {
        private string text;

        public PdfChunk(string text)
        {
            this.text = text;
        }

        public override IElement AsIText()
        {
            return new Chunk(text, Font.AsITextFont());
        }
    }
}