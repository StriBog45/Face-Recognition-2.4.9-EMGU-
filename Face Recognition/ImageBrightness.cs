using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    public class ImageBrightness
    {
        //http://www.cyberforum.ru/csharp-beginners/thread182545.html

        public Bitmap ChangeBrightness(Bitmap image, float brightness)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            int width = image.Width;
            int height = image.Height;

            float[][] colorMatrixElements = {
                        new float[] {brightness, 0, 0, 0, 0},
                        new float[] {0, brightness, 0, 0, 0},
                        new float[] {0, 0, brightness, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                      };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
              colorMatrix,
              ColorMatrixFlag.Default,
              ColorAdjustType.Bitmap);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width,
                     height,
                     GraphicsUnit.Pixel,
                     imageAttributes);

            return new Bitmap(image);
        }
        public Image AddInterference(Bitmap image, float brightness)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            int width = image.Width;
            int height = image.Height;

            float[][] colorMatrixElements = {
                        new float[] {brightness, 0, 0, 0, 0},
                        new float[] {0, brightness, 0, 0, 0},
                        new float[] {0, 0, brightness, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                      };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
              colorMatrix,
              ColorMatrixFlag.Default,
              ColorAdjustType.Bitmap);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width,
                     height,
                     GraphicsUnit.Pixel,
                     imageAttributes);

            return image;
        }
    }
}
