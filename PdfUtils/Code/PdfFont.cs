// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;

namespace Lodeking.PdfUtils
{
    public class PdfFont
    {
        private float size = 10;
        private bool bold = false;
        private int[] color = new int[] { 0, 0, 0 };

        public static PdfFont Normal(float size)
        {
            return new PdfFont
            {
                size = size,
            };
        }

        public PdfFont WithSize(float size)
        {
            return new PdfFont
            {
                size = size,
                bold = this.bold,
                color = this.color,
            };
        }

        public PdfFont AsBold()
        {
            return new PdfFont
            {
                size = this.size,
                bold = true,
                color = this.color,
            };
        }

        public PdfFont WithColor(params int[] rgb)
        {
            return new PdfFont
            {
                size = this.size,
                bold = this.bold,
                color = rgb,
            };
        }

        public Font AsITextFont()
        {
            Font font = new Font(Font.HELVETICA, size, bold ? Font.BOLD : Font.NORMAL);
            font.SetColor(color[0], color[1], color[2]);
            return font;
        }
    }
}