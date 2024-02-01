using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Cropper
{
    public static class EdgeGetter
    {

        /* 
         * TODO    Investigate other A-Forge edge detectors:  
         * 
         * SobelEdgeDetector (in user)
         * CannyEdgeDetector (more complex than SobelEdgeDetector)
         * HomogenityEdgeDetector (simple edge detector that checks for homogeneity in pixel intensity)
         * DifferenceEdgeDetector ( detects edges based on the difference in intensity between neighboring pixels)
         * GradientEdgeDetector (GradientEdgeDetector detects edges based on the gradient of pixel intensities)
         * 

        using AForge.Imaging.Filters;

        CannyEdgeDetector filter = new CannyEdgeDetector();
        Bitmap edges = filter.Apply(grayscaleImage);

        HomogenityEdgeDetector filter = new HomogenityEdgeDetector();
        Bitmap edges = filter.Apply(grayscaleImage);

        DifferenceEdgeDetector filter = new DifferenceEdgeDetector();
        Bitmap edges = filter.Apply(grayscaleImage);

        GradientEdgeDetector filter = new GradientEdgeDetector();
        Bitmap edges = filter.Apply(grayscaleImage);

         */


        /// <summary>
        /// Perform edge analysis of an image returning an array of rectangles representing those edges
        /// based on the sensitivity provided
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pThresholdSensitivity"></param>
        public static Rectangle[] GetEdges(Bitmap pImage, int pThresholdSensitivity)
        {
            Bitmap grayscale = Grayscale.CommonAlgorithms.BT709.Apply(pImage);

            // Apply edge detection
            Bitmap edges = new SobelEdgeDetector().Apply(grayscale);

            // Apply thresholding to convert the image to binary
            Bitmap binary = new Threshold(pThresholdSensitivity).Apply(edges);

            // Extract contours
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinWidth = 20; // Adjust according to your needs
            blobCounter.MinHeight = 20; // Adjust according to your needs
            blobCounter.ProcessImage(binary);

            return blobCounter.GetObjectsRectangles();
        }

        /// <summary>
        /// This is to clear  up the output from GetEdges - it uses the SobelEdgeDector
        /// which gets edges within edges, rectangles within rectangles - so it only
        /// takes top level rectangles, which tend to be frams
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public static Rectangle[] GetRectanglesNotContained(Rectangle[] rectangles)
        {
            List<Rectangle> result = new List<Rectangle>();

            for (int i = 0; i < rectangles.Length; i++)
            {
                bool isContained = false;

                for (int j = 0; j < rectangles.Length; j++)
                {
                    if (i != j && rectangles[j].Contains(rectangles[i]))
                    {
                        isContained = true;
                        break;
                    }
                }

                if (!isContained)
                {
                    result.Add(rectangles[i]);
                }
            }

            return result.ToArray();
        }

    }
}
