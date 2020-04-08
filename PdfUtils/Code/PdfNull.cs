// Copyright (c) Lode King Industries. All rights reserved.
// Licensed under the MIT License.

using iTextSharp.text;

namespace Lodeking.PdfUtils
{
    public class PdfNull : PdfElement
    {
        public override IElement AsIText()
        {
            throw new System.NotImplementedException();
        }
    }
}