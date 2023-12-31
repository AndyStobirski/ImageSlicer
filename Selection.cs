using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Cropper
{

    public enum SelectionPartHit { body, dragTL, dragTR, dragBL, dragBR, none };

    public enum SelectedActivty { move, resize, none};

    /// <summary>
    /// Define a portion of the image we want to export
    /// </summary>
    public class Selection
    {
        public Selection(int x, int y, int w, int h) { 
            Location = new Point(x, y);
            Dimensions = new Size(w, h);
        }

        private Pen _outlinePen =>  new(panelColor, 5);

        [Browsable(false)]
        private SolidBrush _handleBrush => new(panelColor);

        [Browsable(false)]
        private Color panelColor => ItemHit == SelectionPartHit.none ? Color.Blue : Color.Red;

        public Color Colour = Color.Red;

        [Browsable(false)]
        public String Name => $"Selection {Order}";

        [Browsable(false)]
        public Point Location { get; set; }

        [Browsable(false)]
        public Size Dimensions { get; set; }

        [Browsable(false)]
        public Rectangle Bounds => new(Location, Dimensions);

        [Browsable(false)]
        public SelectionPartHit ItemHit { get; private set; }

        [Browsable(false)]
        public int Order { get; set; }  
        

        private const int HandleSize = 16;
        private Rectangle TopLeftHandle => new Rectangle(Location.X - HandleSize / 2, Location.Y - HandleSize / 2, HandleSize, HandleSize);
        private Rectangle TopRightHandle => new Rectangle(Location.X + Dimensions.Width - HandleSize / 2, Location.Y - HandleSize / 2, HandleSize, HandleSize);
        private Rectangle BottomLeftHandle => new Rectangle(Location.X - HandleSize / 2, Location.Y + Dimensions.Height - HandleSize / 2, HandleSize, HandleSize);
        private Rectangle BottomRightHandle => new Rectangle(Location.X + Dimensions.Width - HandleSize / 2, Location.Y + Dimensions.Height - HandleSize / 2, HandleSize, HandleSize);

        private Font _font = new Font("Arial", 12);
        private Brush _fontBrush = Brushes.Black;

        public void Unselect()
        {
            ItemHit = SelectionPartHit.none;
        }

        /// <summary>
        /// Check if the panel is hit
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsHit(int x, int y)
        {
            bool hit = true;

            if (TopLeftHandle.Contains(x, y))
            {
                ItemHit = SelectionPartHit.dragTL;
            }
            else if (TopRightHandle.Contains(x, y))
            {
                ItemHit = SelectionPartHit.dragTR;
            }
            else if (BottomRightHandle.Contains(x, y))
            {
                ItemHit = SelectionPartHit.dragBR;
            }
            else if (BottomLeftHandle.Contains(x, y))
            {
                ItemHit = SelectionPartHit.dragBL;
            }
     
            else if (Bounds.Contains(x, y))
            {
                ItemHit = SelectionPartHit.body;
            }
            else
            {
                ItemHit = SelectionPartHit.none;
                hit = false;
            }
            return hit;
        }



        // Detects if the mouse is over any handle
        public bool IsOverHandle(int x, int y)
        {
            return TopLeftHandle.Contains(x, y) || TopRightHandle.Contains(x, y)
                || BottomLeftHandle.Contains(x, y) || BottomRightHandle.Contains(x, y);
        }

        /// <summary>
        /// Move the shape
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DragShape(int x, int y)
        {
            Location = new Point(x, y);
        }


        // Determines which handle is being dragged and updates the rectangle's dimensions
        public void DragHandle(int x, int y, SelectionPartHit mouseDownLocation)
        {

                if (mouseDownLocation == SelectionPartHit.dragTL )
                {
                    int newWidth = Dimensions.Width - (x - Location.X);
                    int newHeight = Dimensions.Height - (y - Location.Y);
                    if (newWidth > 0 && newHeight > 0)
                    {
                        Location = new Point(x, y);
                        Dimensions = new Size(newWidth, newHeight);
                    }
                }
                else if (mouseDownLocation == SelectionPartHit.dragTR)
                {
                    int newWidth = x - Location.X;
                    int newHeight = Dimensions.Height - (y - Location.Y);
                    if (newWidth > 0 && newHeight > 0)
                    {
                        Dimensions = new Size(newWidth, newHeight);
                        Location = new Point(Location.X, y);
                    }
                }
            else if (mouseDownLocation == SelectionPartHit.dragBL)
            {
                    int newWidth = Dimensions.Width - (x - Location.X);
                    int newHeight = y - Location.Y;
                    if (newWidth > 0 && newHeight > 0)
                    {
                        Dimensions = new Size(newWidth, newHeight);
                        Location = new Point(x, Location.Y);
                    }
                }
            else if (mouseDownLocation == SelectionPartHit.dragBR)
            {
                    int newWidth = x - Location.X;
                    int newHeight = y - Location.Y;
                    if (newWidth > 0 && newHeight > 0)
                    {
                        Dimensions = new Size(newWidth, newHeight);
                    }
                }

        }

        /// <summary>
        /// Draw the selection panel
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            // Draw rectangle
            g.DrawRectangle(_outlinePen, Bounds);

            // Draw handles
            g.FillRectangle(_handleBrush, TopLeftHandle);
            g.FillRectangle(_handleBrush, TopRightHandle);
            g.FillRectangle(_handleBrush, BottomLeftHandle);
            g.FillRectangle(_handleBrush, BottomRightHandle);

            //draw its order number
            SizeF textSize = g.MeasureString(Order.ToString(), _font);
            RectangleF textBounds = new RectangleF(
                    new Point((Bounds.Left + Bounds.Width / 2) - Convert.ToInt32(textSize.Width / 2), (Bounds.Top + Bounds.Height / 2) - Convert.ToInt32(textSize.Height / 2))
                    , textSize
                );

            g.DrawString(Order.ToString(), _font, _fontBrush, textBounds);


        }

    }
}
