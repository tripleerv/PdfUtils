// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;

namespace Lodeking.PdfUtils
{
    public class PdfParagraph : PdfElement
    {
        private float? before;
        private float? after;
        private string hAlign = "LEFT";
        private string text;

        public PdfParagraph(string text = null)
        {
            this.text = text;
        }

        public PdfParagraph Spacing(float? before = null, float? after = null)
        {
            this.before = before;
            this.after = after;
            return this;
        }

        public PdfParagraph RightAlign()
        {
            this.hAlign = "RIGHT";
            return this;
        }

        public PdfParagraph CenterAlign()
        {
            this.hAlign = "CENTER";
            return this;
        }

        public override IElement AsIText()
        {
            var p = new Paragraph(text, Font.AsITextFont());

            if (before.HasValue)
            {
                p.SpacingBefore = before.Value;
            }

            if (after.HasValue)
            {
                p.SpacingAfter = after.Value;
            }

            p.SetAlignment(hAlign);
            p.Leading = 12;

            Children?.ForEach(child =>
            {
                p.Add(child.AsIText());
            });
            return p;
        }
    }
}