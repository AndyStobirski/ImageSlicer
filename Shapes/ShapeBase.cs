using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSlicer
{
    public abstract class ShapeBase
    {
        public string ID { get; private set; }

        public ShapeBase()
        {
            ID = Guid.NewGuid().ToString();
        }

        public Color LineColour { get; set; } = Color.Blue;

        protected int _handleSize = 12;

        /// <summary>
        /// String description of the shAPE
        /// </summary>
        public string ShapeType { get; protected set; }

        [Browsable(false)]
        public String Name => $"{ShapeType} {Order}";

        public int Order { get; set; }

        public bool Selected { get; set; }

        public Point Origin { get; set; }

        public virtual void Draw(Graphics g)
        {
            var Bounds = GetBoundingRectangle();

            //draw its order number
            SizeF textSize = g.MeasureString(Order.ToString(), _font);
            RectangleF textBounds = new RectangleF(
                    new Point((Bounds.Left + Bounds.Width / 2) - Convert.ToInt32(textSize.Width / 2), (Bounds.Top + Bounds.Height / 2) - Convert.ToInt32(textSize.Height / 2))
                    , textSize
                );

            g.DrawString(Order.ToString(), _font, _fontBrush, textBounds);
        }

        #region font defintions

        private Font _font = new Font("Arial", 24);
        private SolidBrush _fontBrush => new SolidBrush(LineColour);

        #endregion

        public abstract bool HitTest(int pX, int pY);

        public abstract bool Drag(int pX, int pY);

        protected abstract Rectangle[] Handles();

        public abstract Rectangle GetBoundingRectangle();

        public abstract void MoveHandle(int pX, int pY);

        /// <summary>
        /// Portion of the poly hit
        /// </summary>
        public SelectionPartHit ItemHit { get;  set; }

    }
}
