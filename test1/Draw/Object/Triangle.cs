using Gdk;

namespace test1.Draw.Object
{
	public class Triangle : IObject
	{
		Common.PointD endPoint;
		Common.PointD startPoint;
		Cairo.Color color;
      
		public Triangle(Common.PointD startPoint, Common.PointD endPoint)
		{
			color = new Cairo.Color(0, 0, 0);
			this.startPoint = startPoint;
			this.endPoint = endPoint;
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
			g.MoveTo((startPoint.X + endPoint.X) / 2, startPoint.Y);
			g.LineTo(endPoint.X, endPoint.Y);
			g.LineTo(startPoint.X, endPoint.Y);
			g.ClosePath();
			g.SetSourceColor(color);
			g.Stroke();
		}

		public bool IsContain(Common.PointD point)
		{
			return (point.X >= startPoint.X && point.X <= endPoint.X &&
                    point.Y >= startPoint.Y && point.Y <= endPoint.Y);
		}

		public void Translate(double x, double y)
        {
            startPoint.X += x;
            endPoint.X += x;
            startPoint.Y += y;
            endPoint.Y += y;
        }
	}
}
