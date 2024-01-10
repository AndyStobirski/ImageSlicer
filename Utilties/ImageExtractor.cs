using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSlicer.ImageExractors
{
    /// <summary>
    /// Extract from the 
    /// </summary>
    public class ImageExtractor 
    {
        /// <summary>
        /// Extract the portion of the image defined by the polygon, returned in it's bounding rectangle, and save it
        /// </summary>
        /// <param name="pOriginalImage"></param>
        /// <param name="pPolygonPoints"></param>
        /// <param name="pFilePath"></param>
        public static void ExtractAreaUnderPolygon(Image pOriginalImage, PointF[] pPolygonPoints, string pFilePath)
        {
            // Create a GraphicsPath based on the polygon coordinates
            GraphicsPath polygonPath = new GraphicsPath();

            // Create a GraphicsPath from the array of points
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(pPolygonPoints);

            // Create a region from the GraphicsPath
            Region region = new Region(path);

            // Create a new bitmap to extract the area defined by the polygon
            Bitmap extractedBitmap = new Bitmap(pOriginalImage.Width, pOriginalImage.Height);

            // Set the clipping region to the Graphics object of the extracted bitmap
            using (Graphics g = Graphics.FromImage(extractedBitmap))
            {
                g.Clip = region;


                // Draw the portion of the original image within the polygon area onto the new bitmap
                g.DrawImage(
                    pOriginalImage
                    , new Rectangle(0, 0, pOriginalImage.Width, pOriginalImage.Height)    //dest rectangle
                    , new Rectangle(0, 0, pOriginalImage.Width, pOriginalImage.Height)    //source rectangle
                    , GraphicsUnit.Pixel
                );
            }

            //now we have the clipped image under the polygon
            int polyX = (int)pPolygonPoints.Min(p => p.X);
            int polyY = (int)pPolygonPoints.Min(p => p.Y);
            int polyWidth = (int)pPolygonPoints.Max(p => p.X) - (int)pPolygonPoints.Min(p => p.X);
            int polyHeight = (int)pPolygonPoints.Max(p => p.Y) - (int)pPolygonPoints.Min(p => p.Y);

            using (Bitmap returnBmp = new Bitmap(polyWidth, polyHeight))
            {
                using (Graphics g = Graphics.FromImage(returnBmp))
                {
                    g.DrawImage(extractedBitmap
                        , new Rectangle(0, 0, polyWidth, polyHeight)
                        , new Rectangle(polyX, polyY, polyWidth, polyHeight)
                        , GraphicsUnit.Pixel
                        );
                }
                returnBmp.Save(pFilePath);
            }

            extractedBitmap.Dispose();

        }
    }
}
