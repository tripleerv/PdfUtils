// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Lodeking.PdfUtils
{
    public class PdfCell : PdfElement
    {
        private float leftBorder;
        private float rightBorder;
        private float topBorder;
        private float bottomBorder;

        private int[] borderColor = new int[] { 0, 0, 0 };

        private float leftPadding;
        private float rightPadding;
        private float topPadding;
        private float bottomPadding;

        private int hAlign = Element.ALIGN_LEFT;
        private int vAlign = Element.ALIGN_TOP;
        private float? fixedHeight;

        public PdfCell Borders(float? left = null, float? right = null, float? top = null, float? bottom = null)
        {
            this.leftBorder = left ?? 0;
            this.rightBorder = right ?? 0;
            this.topBorder = top ?? 0;
            this.bottomBorder = bottom ?? 0;
            return this;
        }

        public PdfCell Borders(float border)
        {
            this.leftBorder = border;
            this.rightBorder = border;
            this.topBorder = border;
            this.bottomBorder = border;
            return this;
        }

        public PdfCell BorderColor(params int[] rgb)
        {
            this.borderColor = rgb;
            return this;
        }

        public PdfCell Padding(float? left = null, float? right = null, float? top = null, float? bottom = null)
        {
            this.leftPadding = left ?? 0;
            this.rightPadding = right ?? 0;
            this.topPadding = top ?? 0;
            this.bottomPadding = bottom ?? 0;
            return this;
        }

        public PdfCell Padding(float padding)
        {
            this.leftPadding = padding;
            this.rightPadding = padding;
            this.topPadding = padding;
            this.bottomPadding = padding;
            return this;
        }

        public PdfCell CenterAlign()
        {
            this.hAlign = Element.ALIGN_CENTER;
            return this;
        }

        public PdfCell RightAlign()
        {
            this.hAlign = Element.ALIGN_RIGHT;
            return this;
        }

        public PdfCell VerticalCenter()
        {
            this.vAlign = Element.ALIGN_MIDDLE;
            return this;
        }

        public PdfCell FixedHeight(float fixedHeight)
        {
            this.fixedHeight = fixedHeight;
            return this;
        }

        public override IElement AsIText()
        {
            PdfPCell cell = new PdfPCell();

            Children?.ForEach(child =>
            {
                cell.AddElement(child.AsIText());
            });

            if (fixedHeight.HasValue)
            {
                cell.FixedHeight = fixedHeight.Value;
            }

            cell.BorderWidthTop = topBorder;
            cell.BorderWidthRight = rightBorder;
            cell.BorderWidthBottom = bottomBorder;
            cell.BorderWidthLeft = leftBorder;

            cell.BorderColor = new BaseColor(borderColor[0], borderColor[1], borderColor[2]);

            cell.PaddingTop = topPadding;
            cell.PaddingRight = rightPadding;
            cell.PaddingBottom = bottomPadding;
            cell.PaddingLeft = leftPadding;

            cell.HorizontalAlignment = hAlign;
            cell.VerticalAlignment = vAlign;

            return cell;
        }
    }
}