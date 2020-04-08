// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Lodeking.PdfUtils
{
    public class PdfDocument : PdfElement
    {
        private float leftMargin;
        private float rightMargin;
        private float topMargin;
        private float bottomMargin;

        public PdfDocument Margins(float? left = null, float? right = null, float? top = null, float? bottom = null)
        {
            this.leftMargin = left ?? 30;
            this.rightMargin = right ?? 30;
            this.topMargin = top ?? 20;
            this.bottomMargin = bottom ?? 20;
            return this;
        }

        public override IElement AsIText()
        {
            throw new System.NotImplementedException();
        }

        public byte[] Generate()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var document = new Document(PageSize.Letter, leftMargin, rightMargin, topMargin, bottomMargin);
                Writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                Children.ForEach(child =>
                {
                    if (child is PdfPageBreak)
                    {
                        document.NewPage();
                    }
                    else
                    {
                        document.Add(child.AsIText());
                    }
                });
                document.Close();
                return stream.ToArray();
            }
        }
    }
}