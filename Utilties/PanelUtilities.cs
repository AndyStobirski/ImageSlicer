using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ImageSlicer.Utilties
{
    /// <summary>
    /// Utilties for panel manipulation
    /// </summary>
    public static class PanelUtilities
    {
        /// <summary>
        /// Generate a series of regular panels
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pRows"></param>
        /// <param name="pCols"></param>
        /// <param name="pStartNum"></param>
        /// <param name="pPadVert"></param>
        /// <param name="pPadHor"></param>
        /// <returns></returns>
        public static List<ShapeBase> GeneratePanels(Bitmap pImage, int pRows, int pCols, int pStartNum, int pPadVert, int pPadHor)
        {
            var Panels = new List<ShapeBase>();

            int imageWidth = pImage.Width;
            int imageHeight = pImage.Height;

            int panelWidth = (imageWidth - pPadHor * (pCols + 1)) / pRows;
            int panelHeight = (imageHeight - pPadHor * (pRows + 1)) / pCols;

            for (int r = 1; r <= pRows; r++)
            {
                for (int c = 1; c <= pCols; c++)
                {

                    int x = c * pPadHor + panelWidth * (c - 1);
                    int y = r * pPadVert + panelHeight * (r - 1);

                    Debug.WriteLine($"Cell [{r},{c}]: ({x},{y}) - ({panelWidth},{panelHeight})");

                    Panels.Add(

                            new ShapeRectangle(x, y, panelWidth, panelHeight) { Order = pStartNum }

                        );

                    pStartNum++;

                    Panels.Last().Selected = false;

                }
            }
            return Panels;
        }

        /// <summary>
        /// Serialise the provided object the specified path
        /// </summary>
        /// <param name="pPanels"></param>
        /// <param name="pPath"></param>
        public static void SavePanels(ImageSave pImageSave, string pPath)
        {
            string json = JsonConvert.SerializeObject(pImageSave, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(pPath, json);
        }

        /// <summary>
        /// Load the provided file and return a deserialised object
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
        public static ImageSave LoadPanels(string pPath)
        {
            string json = File.ReadAllText(pPath);

            return JsonConvert.DeserializeObject<ImageSave>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
    }
}
