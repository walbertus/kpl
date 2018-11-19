using Gdk;
using test1.Draw.Object.State;
using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
    public abstract class ObjectBase
    {
        protected ObjectStateBase state;
        protected List<PointD> points;
        protected Cairo.Color color;
        protected PointD startPoint;
        protected PointD endPoint;

        public virtual void Draw(Window window)
        {
            Cairo.Context g = CairoHelper.Create(window);
            g.LineWidth = 5;
            g.MoveTo(points[0].X, points[0].Y);
            foreach (PointD point in points)
            {
                g.LineTo(point.X, point.Y);
            }
            g.SetSourceColor(color);
            g.ClosePath();
            g.Stroke();
        }

        public virtual void ChangeColor(int r, int g, int b)
        {
            color = new Cairo.Color(r, g, b);
        }

        public abstract void Translate(double x, double y);
        public abstract bool IsContain(PointD point);
        public abstract void Scale(PointD newPoint, int position);

        public virtual void ChangeState(ObjectStateBase newState)
        {
            this.state = newState;
        }
    }
}
