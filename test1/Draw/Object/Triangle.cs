using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
    public class Triangle : ObjectBase
	{      
		public Triangle(PointD startPoint, PointD endPoint)
		{
            Init();
            CreatePoints(startPoint, endPoint);
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            ReconfigureCornerPoints();
		}

        protected override void CreatePoints(PointD startPoint, PointD endPoint)
        {
            points.Add(new PointD((startPoint.X + endPoint.X) / 2, startPoint.Y));
            points.Add(new PointD(endPoint.X, endPoint.Y));
            points.Add(new PointD(startPoint.X, endPoint.Y));
            Notify();
        }

        public override void Scale(PointD newPoint, int position)
        {
            if (position == ObjectConstants.OBJECT_CONTROL_BOTTOM_RIGHT)
            {
                RecreatePoints(startPoint, newPoint);
                endPoint = newPoint;
            }
        }
	}
}
