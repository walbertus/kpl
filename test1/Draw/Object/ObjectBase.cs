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

        protected virtual void Init()
        {
            state = ObjectStatePreview.GetInstance();
        }

        public virtual void Draw(Window window)
        {
            state.Draw(this, window);
        }

        public virtual void Select()
        {
            state.Select(this);
        }

        public virtual void Deselect()
        {
            state.Deselect(this);
        }

        public virtual void DrawNormal(Window window)
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

        public virtual void DrawActive(Window window)
        {
            Cairo.Context g = CairoHelper.Create(window);
            g.LineWidth = 8;
            // g.SetDash(new double[] { 2, 2 }, 0);
            g.MoveTo(points[0].X, points[0].Y);
            foreach (PointD point in points)
            {
                g.LineTo(point.X, point.Y);
            }
            g.SetSourceColor(color);
            g.ClosePath();
            g.Stroke();
        }

        public virtual void DrawPreview(Window window)
        {
            Cairo.Context g = CairoHelper.Create(window);
            g.LineWidth = 3;
            g.SetDash(new double[] { 4, 4 }, 0);
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

        public virtual void Translate(double x, double y)
        {
            foreach (PointD point in points)
            {
                point.X += x;
                point.Y += y;
            }
            startPoint.X += x;
            endPoint.X += x;
            startPoint.Y += y;
            endPoint.Y += y;
        }

        public virtual bool IsContain(PointD point)
        {
            return (point.X >= startPoint.X && point.X <= endPoint.X &&
                    point.Y >= startPoint.Y && point.Y <= endPoint.Y);
        }

        public virtual void ReconfigureCornerPoints()
        {
            double minX = System.Math.Min(startPoint.X, endPoint.X);
            double maxX = System.Math.Max(startPoint.X, endPoint.X);
            double minY = System.Math.Min(startPoint.Y, endPoint.Y);
            double maxY = System.Math.Max(startPoint.Y, endPoint.Y);
            startPoint = new PointD(minX, minY);
            endPoint = new PointD(maxX, maxY);
        }

        protected virtual void RecreatePoints(PointD startPoint, PointD endPoint)
        {
            points.Clear();
            CreatePoints(startPoint, endPoint);
        }

        protected abstract void CreatePoints(PointD startPoint, PointD endPoint);
        public abstract void Scale(PointD newPoint, int position);

        public virtual void ChangeState(ObjectStateBase newState)
        {
            this.state = newState;
        }
    }
}
