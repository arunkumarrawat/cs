using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MainLib
{
    /// <summary>
    /// Use GDI+ to operate pictures.
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// Resize png file
        /// </summary>
        /// <param name="imageFile">image files</param>
        /// <param name="outputFile">output file</param>
        /// <param name="scaleFactor">scale factor</param>
        public void Resize(string imageFile, string outputFile, double scaleFactor)
        {
            using (var srcImage = Image.FromFile(imageFile))
            {
                var newWidth = (int)(srcImage.Width * scaleFactor);
                var newHeight = (int)(srcImage.Height * scaleFactor);
                using (var newImage = new Bitmap(newWidth, newHeight))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                    newImage.Save(outputFile);
                }
            }
        }
    }
}
