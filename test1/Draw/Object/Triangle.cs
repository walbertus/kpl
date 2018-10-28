using Gdk;
using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
	public class Triangle : IObject
	{
		PointD endPoint;
		PointD startPoint;
		Cairo.Color color;
		List<PointD> points;
      
		public Triangle(PointD startPoint, PointD endPoint)
		{
			points = new List<PointD>();
			points.Add(new PointD((startPoint.X + endPoint.X) / 2, startPoint.Y));
			points.Add(new PointD(endPoint.X, endPoint.Y));
			points.Add(new PointD(startPoint.X, endPoint.Y));
			color = new Cairo.Color(0, 0, 0);
            double minX = System.Math.Min(startPoint.X, endPoint.X);
            double maxX = System.Math.Max(startPoint.X, endPoint.X);
            double minY = System.Math.Min(startPoint.Y, endPoint.Y);
            double maxY = System.Math.Max(startPoint.Y, endPoint.Y);
            this.startPoint = new PointD(minX, minY);
            this.endPoint = new PointD(maxX, maxY);
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
            foreach (PointD point in points)
            {
                g.LineTo(point.X, point.Y);
            }
            g.SetSourceColor(color);
            g.ClosePath();
            g.Stroke();
		}

		public bool IsContain(PointD point)
		{
			return (point.X >= startPoint.X && point.X <= endPoint.X &&
                    point.Y >= startPoint.Y && point.Y <= endPoint.Y);
		}

		public void Scale(PointD newPoint, int position)
        {
            if (position == ObjectConstants.OBJECT_CONTROL_BOTTOM_RIGHT)
            {
                double xScale = (newPoint.X - startPoint.X) / (endPoint.X - startPoint.X);
                double yScale = (newPoint.Y - startPoint.Y) / (endPoint.Y - startPoint.Y);
                foreach (PointD point in points)
                {
                    point.X = startPoint.X + (xScale * (point.X - startPoint.X));
                    point.Y = startPoint.Y + (yScale * (point.Y - startPoint.Y));
                }
            }
        }

		public void Translate(double x, double y)
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
	}
}
