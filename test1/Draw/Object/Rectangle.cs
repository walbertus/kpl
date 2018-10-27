using Gdk;
using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
	public class Rectangle : IObject
	{
		Common.PointD startPoint;
		Common.PointD endPoint;
		Cairo.Color color;
		List<Common.PointD> points;

		public Rectangle(Common.PointD startPoint, Common.PointD endPoint)
		{
			points = new List<Common.PointD>();
			color = new Cairo.Color(0, 0, 0);
			this.startPoint = startPoint;
			this.endPoint = endPoint;
			points.Add(new Common.PointD(startPoint.X, startPoint.Y));
			points.Add(new Common.PointD(endPoint.X, startPoint.Y));
			points.Add(new Common.PointD(endPoint.X, endPoint.Y));
			points.Add(new Common.PointD(startPoint.X, endPoint.Y));
		}
       
		public void ChangeColor(int r, int g, int b)
        {
            color = new Cairo.Color(r, g, b);
        }

        public void ChangeColor(Cairo.Color color)
        {
            this.color = color;
        }

		public void Draw(Window window)
		{
			Cairo.Context g = CairoHelper.Create(window);
			g.LineWidth = 5;
			g.MoveTo(points[0].X, points[0].Y);
			foreach(Common.PointD point in points) {
				g.LineTo(point.X, point.Y);
			}
			g.SetSourceColor(color);
			g.ClosePath();
			g.Stroke();
		}

		public bool IsContain(Common.PointD point)
		{
			return (point.X >= startPoint.X && point.X <= endPoint.X &&
                    point.Y >= startPoint.Y && point.Y <= endPoint.Y);
		}

		public void Translate(double x, double y)
        {
			foreach (Common.PointD point in points) {
				point.X += x;
				point.Y += y;
			}
            startPoint.X += x;
            endPoint.X += x;
            startPoint.Y += y;
			endPoint.Y += y;
        }
	}
}
