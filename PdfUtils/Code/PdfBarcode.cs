// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Lodeking.PdfUtils
{
    public class PdfBarcode : PdfElement
    {
        private string text;
        private int scalePercent = 120;
        private int hAlign = Element.ALIGN_LEFT;

        public PdfBarcode(string text)
        {
            this.text = text;
        }

        public PdfBarcode ScalePercent(int scalePercent)
        {
            this.scalePercent = scalePercent;
            return this;
        }

        public PdfBarcode CenterAlign()
        {
            this.hAlign = Element.ALIGN_CENTER;
            return this;
        }

        public override IElement AsIText()
        {
            var bc = new Barcode39
            {
                Code = text,
                AltText = string.Empty,
                Baseline = 0,
            };

            var bcImg = bc.CreateImageWithBarcode(Writer.DirectContent, null, null);
            bcImg.ScalePercent(scalePercent);
            bcImg.SpacingAfter = 0;
            bcImg.SpacingBefore = 0;

            var chunk = new Chunk(bcImg, 0, 0, false);
            var paragraph = new Paragraph
            {
                Alignment = hAlign,
            };

            paragraph.Add(chunk);

            return paragraph;
        }
    }
}