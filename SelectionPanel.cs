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

    public enum SelectionPartHit { body, dragTL, dragTR, dragBL, dragBR, none, deletebutton };

    /// <summary>
    /// Define a portion of the image we want to export
    /// </summary>
    public class SelectionPanel
    {
        public SelectionPanel(int x, int y, int w, int h) { 
            Location = new Point(x, y);
            PanelSize = new Size(w, h);
        }

        [Browsable(false)]
        public Guid ID { get; private set; } = Guid.NewGuid();

        #region Panel Drawing Properties

        private Pen _drawPen => new Pen(panelColor, 5) ;

        private Color _fillColour =>Color.FromArgb(128, Color.White);

        SolidBrush _fillBrush => new SolidBrush(_fillColour);

        private Pen _outlinePen =>  new(panelColor, 5);
        
        private SolidBrush _handleBrush => new(panelColor);

        private Color panelColor => ItemHit == SelectionPartHit.none ? Color.Blue : Color.Red;

        #endregion

        [Browsable(false)]
        public String Name => $"Selection {Order}";

        /// <summary>
        /// Panel top left
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Size of shape
        /// </summary>
        public Size PanelSize { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Rectangle which defines the panel
        /// </summary>
        [Browsable(false)]
        public Rectangle Bounds => new(Location, PanelSize);

        /// <summary>
        /// Location the panel is hit by the mouse
        /// </summary>
        [Browsable(false)]
        public SelectionPartHit ItemHit { get;  set; }



        #region drag handles definitions

        private const int HandleSize = 16;
        private Rectangle TopLeftHandle => new Rectangle(Location.X - HandleSize / 2, Location.Y - HandleSize / 2, HandleSize, HandleSize);
        private Rectangle TopRightHandle => new Rectangle(Location.X + PanelSize.Width - HandleSize / 2, Location.Y - HandleSize / 2, HandleSize, HandleSize);
        private Rectangle BottomLeftHandle => new Rectangle(Location.X - HandleSize / 2, Location.Y + PanelSize.Height - HandleSize / 2, HandleSize, HandleSize);
        private Rectangle BottomRightHandle => new Rectangle(Location.X + PanelSize.Width - HandleSize / 2, Location.Y + PanelSize.Height - HandleSize / 2, HandleSize, HandleSize);

        private Rectangle DeleteButton => new Rectangle((Location.X + PanelSize.Width - HandleSize / 2) - (1 * HandleSize), (Location.Y - HandleSize / 2) + (1 * HandleSize), HandleSize, HandleSize);

        #endregion

        #region font defintions

        private Font _font = new Font("Arial", 24);
        private SolidBrush _fontBrush => new SolidBrush(panelColor);

        #endregion

        /// <summary>
        /// Unselect the shape
        /// </summary>
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
            else if (DeleteButton.Contains(x, y))
            {
                ItemHit = SelectionPartHit.deletebutton;
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

        /// <summary>
        /// Move the shape
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DragShape(int x, int y)
        {
            Location = new Point(x, y);
        }


        /// <summary>
        /// Determines which handle is being dragged and updates the rectangle's dimensions
        /// </summary>
        /// <param name="x">New x location</param>
        /// <param name="y">New y location</param>
        /// <param name="mouseDownLocation">Part of the panel the mouse is hitting</param>
        public void DragHandle(int x, int y, SelectionPartHit mouseDownLocation)
        {

                if (mouseDownLocation == SelectionPartHit.dragTL )
                {
                    int newWidth = PanelSize.Width - (x - Location.X);
                    int newHeight = PanelSize.Height - (y - Location.Y);
                    if (newWidth > 0 && newHeight > 0)
                    {
                        Location = new Point(x, y);
                        PanelSize = new Size(newWidth, newHeight);
                    }
                }
                else if (mouseDownLocation == SelectionPartHit.dragTR)
                {
                    int newWidth = x - Location.X;
                    int newHeight = PanelSize.Height - (y - Location.Y);
                    if (newWidth > 0 && newHeight > 0)
                    {
                        PanelSize = new Size(newWidth, newHeight);
                        Location = new Point(Location.X, y);
                    }
                }
            else if (mouseDownLocation == SelectionPartHit.dragBL)
            {
                    int newWidth = PanelSize.Width - (x - Location.X);
                    int newHeight = y - Location.Y;
                    if (newWidth > 0 && newHeight > 0)
                    {
                        PanelSize = new Size(newWidth, newHeight);
                        Location = new Point(x, Location.Y);
                    }
                }
            else if (mouseDownLocation == SelectionPartHit.dragBR)
            {
                    int newWidth = x - Location.X;
                    int newHeight = y - Location.Y;
                    if (newWidth > 0 && newHeight > 0)
                    {
                        PanelSize = new Size(newWidth, newHeight);
                    }
                }

        }

        /// <summary>
        /// Draw the selection panel
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            // Draw rectangle fill;
            g.FillRectangle(_fillBrush, Bounds);

            // Draw rectangle outline
            g.DrawRectangle(_outlinePen, Bounds);

            // Draw handles
            g.FillRectangle(_handleBrush, TopLeftHandle);
            g.FillRectangle(_handleBrush, TopRightHandle);
            g.FillRectangle(_handleBrush, BottomLeftHandle);
            g.FillRectangle(_handleBrush, BottomRightHandle);

            //delete button
           // g.FillRectangle(_handleBrush, DeleteButton);

            g.DrawLine(_drawPen, new Point(DeleteButton.Left, DeleteButton.Top), new Point(DeleteButton.Right, DeleteButton.Bottom));
            g.DrawLine(_drawPen, new Point(DeleteButton.Left, DeleteButton.Bottom), new Point(DeleteButton.Right, DeleteButton.Top));

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
