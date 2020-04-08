// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Lodeking.PdfUtils
{
    public class PdfTable : PdfElement
    {
        private float? spacingBefore;
        private float? spacingAfter;
        private float? totalWidth;
        private float widthPercentage = 100;

        private float[] columns = new float[0];

        public PdfTable WithSpacing(float? spacingBefore = null, float? spacingAfter = null)
        {
            this.spacingBefore = spacingBefore;
            this.spacingAfter = spacingAfter;
            return this;
        }

        public PdfTable WithTotalWidth(float totalWidth)
        {
            this.totalWidth = totalWidth;
            return this;
        }

        public PdfTable WithWidthPct(float widthPercentage)
        {
            this.widthPercentage = widthPercentage;
            return this;
        }

        public PdfTable WithColumns(params float[] columns)
        {
            this.columns = columns;
            return this;
        }

        public override IElement AsIText()
        {
            PdfPTable table = null;

            if (columns.Any())
            {
                table = new PdfPTable(columns);
            }
            else
            {
                table = new PdfPTable(Children.Count);
            }

            if (spacingBefore.HasValue)
            {
                table.SpacingBefore = spacingBefore.Value;
            }

            if (spacingAfter.HasValue)
            {
                table.SpacingAfter = spacingAfter.Value;
            }

            if (totalWidth.HasValue)
            {
                table.TotalWidth = totalWidth.Value;
            }

            table.WidthPercentage = widthPercentage;
            table.DefaultCell.Border = PdfPCell.NO_BORDER;

            Children.ForEach(child =>
            {
                table.AddCell((PdfPCell)child.AsIText());
            });

            return table;
        }
    }
}