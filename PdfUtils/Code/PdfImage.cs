using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text;

namespace Lodeking.PdfUtils
{
    public class PdfImage : PdfElement
    {
        private readonly FileStream fileStream;
        private float? scalePercent;
        private int hAlign = Element.ALIGN_LEFT;

        public PdfImage(FileStream fileStream)
        {
            this.fileStream = fileStream;
        }

        public PdfImage ScalePercent(float scalePercent)
        {
            this.scalePercent = scalePercent;
            return this;
        }

        public PdfImage CenterAlign()
        {
            this.hAlign = Element.ALIGN_CENTER;
            return this;
        }

        public override IElement AsIText()
        {
            using (fileStream)
            {
                var img = Image.GetInstance(System.Drawing.Image.FromStream(fileStream), ImageFormat.Png);

                if (scalePercent.HasValue)
                {
                    img.ScalePercent(scalePercent.Value);
                }

                img.Alignment = hAlign;

                return img;
            }
        }
    }
}