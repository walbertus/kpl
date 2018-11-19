using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
    public class Rectangle : ObjectBase
	{
		PointD startPoint;
		PointD endPoint;

		public Rectangle(PointD startPoint, PointD endPoint)
		{
			points = new List<PointD>();
			color = new Cairo.Color(0, 0, 0);
			RecreatePoints(startPoint, endPoint);
			this.startPoint = startPoint;
			this.endPoint = endPoint;
			ReconfigureCornerPoints();
		}

        public override bool IsContain(PointD point)
		{
			return (point.X >= startPoint.X && point.X <= endPoint.X &&
                    point.Y >= startPoint.Y && point.Y <= endPoint.Y);
		}

		void RecreatePoints(PointD startPoint, PointD endPoint)
		{
			points.Clear();
			points.Add(new PointD(startPoint.X, startPoint.Y));
            points.Add(new PointD(endPoint.X, startPoint.Y));
            points.Add(new PointD(endPoint.X, endPoint.Y));
            points.Add(new PointD(startPoint.X, endPoint.Y));
		}

		public void ReconfigureCornerPoints()
		{
			double minX = System.Math.Min(startPoint.X, endPoint.X);
            double maxX = System.Math.Max(startPoint.X, endPoint.X);
            double minY = System.Math.Min(startPoint.Y, endPoint.Y);
            double maxY = System.Math.Max(startPoint.Y, endPoint.Y);
			this.startPoint = new PointD(minX, minY);
            this.endPoint = new PointD(maxX, maxY);
		}

        public override void Scale(PointD newPoint, int position)
		{
			if (position == ObjectConstants.OBJECT_CONTROL_BOTTOM_RIGHT) {
				RecreatePoints(startPoint, newPoint);
				endPoint = newPoint;
			}
		}

        public override void Translate(double x, double y)
        {
			foreach (PointD point in points) {
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
