using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
    public class LineSegment: ObjectBase
    {	
		public LineSegment(PointD startPoint, PointD endPoint)
        {
            Init();
            CreatePoints(startPoint, endPoint);
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            ReconfigureCornerPoints();
        }

        protected override void CreatePoints(PointD startPoint, PointD endPoint)
        {
            points.Add(new PointD(startPoint.X, startPoint.Y));
            points.Add(new PointD(endPoint.X, endPoint.Y));        }

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
