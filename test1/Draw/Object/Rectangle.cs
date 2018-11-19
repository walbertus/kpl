using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
    public class Rectangle : ObjectBase
	{
		public Rectangle(PointD startPoint, PointD endPoint)
		{
			points = new List<PointD>();
			color = new Cairo.Color(0, 0, 0);
			RecreatePoints(startPoint, endPoint);
			this.startPoint = startPoint;
			this.endPoint = endPoint;
			ReconfigureCornerPoints();
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
            startPoint = new PointD(minX, minY);
            endPoint = new PointD(maxX, maxY);
		}

        public override void Scale(PointD newPoint, int position)
		{
			if (position == ObjectConstants.OBJECT_CONTROL_BOTTOM_RIGHT) {
				RecreatePoints(startPoint, newPoint);
				endPoint = newPoint;
			}
		}
	}
}
