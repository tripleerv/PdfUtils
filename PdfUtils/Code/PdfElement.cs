// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Lodeking.PdfUtils
{
    public abstract class PdfElement
    {
        private PdfElement parent;

        private PdfWriter writer;
        private PdfFont font;
        private List<PdfElement> children = new List<PdfElement>();

        public PdfWriter Writer
        {
            get => writer ?? parent?.Writer;
            set => writer = value;
        }

        public PdfFont Font
        {
            get => font ?? parent?.Font ?? PdfFont.Normal(10);
            set => font = value;
        }

        public List<PdfElement> Children
        {
            get => children?.Where(x => !(x is PdfNull))?.ToList();
        }

        public PdfElement Bold()
        {
            this.font = Font.AsBold();
            return this;
        }

        public PdfElement FontSize(int size)
        {
            this.font = Font.WithSize(size);
            return this;
        }

        public PdfElement Color(params int[] rgb)
        {
            this.font = Font.WithColor(rgb);
            return this;
        }

        public PdfElement Add(params PdfElement[] list)
        {
            return Add(list.ToList());
        }

        public PdfElement Add(List<PdfElement> list)
        {
            list.ForEach(child => child.parent = this);
            children.AddRange(list);
            return this;
        }

        public abstract IElement AsIText();
    }
}