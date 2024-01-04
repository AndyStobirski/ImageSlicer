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

        protected int _handleSize = 12;
        public string ShapeType { get; protected set; }

        [Browsable(false)]
        public String Name => $"{ShapeType} {Order}";

        public int Order { get; set; }

        public bool Selected { get; set; }

        public Point Origin { get; set; }

        public abstract void Draw(Graphics g);

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
