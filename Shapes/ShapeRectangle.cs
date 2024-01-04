using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSlicer
{
    public class ShapeRectangle : ShapePolygonBase
    {
        public ShapeRectangle(int pX, int pY, int width, int height) : base()
        {
            IsPolygon = false;
            ShapeType = "Rectangle";

            //specify TL, TR, BR, TL
            Points = new List<PointF> { new Point(pX, pY), new Point(pX + width, pY), new Point(pX + width, pY + height), new Point(pX, pY + height) };
    
        }


        public int Width { get; set; }

        public int Height { get; set; }
    }
}
