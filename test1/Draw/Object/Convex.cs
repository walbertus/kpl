using System;
using test1.Common;
using System.Collections.Generic;

namespace test1.Draw.Object
{
    public class Convex: ObjectBase
    {
        const int COLINEAR = 0;
        const int CLOCKWISE = 1;
        const int COUNTERCLOKWISE = 2;

        public Convex(List<PointD> points)
        {
            Init();
            this.points = CreateConvexHull(points);
            ReconfigureCornerPoints();
        }

        int OrientationHelper(PointD p, PointD q, PointD r)
        {
            double val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (Math.Abs(val) < double.Epsilon)
            {
                return COLINEAR;
            }
            return val > 0 ? CLOCKWISE : COUNTERCLOKWISE;
        }

        List<PointD> CreateConvexHull(List<PointD> inputPoints)
        {
            if (inputPoints.Count < 3)
                return inputPoints;
            List<PointD> ans = new List<PointD>();
            int left = 0;
            for (int i = 0; i< inputPoints.Count; i++)
            {
                if (inputPoints[i].X < inputPoints[left].X)
                    left = i;
            }

            int p = left, q;
            do
            {
                ans.Add(inputPoints[p]);

                q = (p + 1) % inputPoints.Count;

                for (int i = 0; i < inputPoints.Count; i++)
                {
                    if (OrientationHelper(inputPoints[p], inputPoints[q], inputPoints[i]) == COUNTERCLOKWISE)
                    {
                        q = i;
                    }
                }

                p = q;
            } while (p != left);

            return ans;
        }

        public override void Scale(PointD newPoint, int position)
        {

        }

        protected override void CreatePoints(PointD startPoint, PointD endPoint)
        {

        }

        public override void ReconfigureCornerPoints()
        {
            double minx = points[0].X;
            double miny = points[0].Y;
            double maxx = minx;
            double maxy = miny;
            foreach(PointD point in points)
            {
                maxx = Math.Max(maxx, point.X);
                maxy = Math.Max(maxy, point.Y);
                minx = Math.Min(minx, point.X);
                miny = Math.Min(miny, point.Y);
            }
            startPoint = new PointD(minx, miny);
            endPoint = new PointD(maxx, maxy);
        }
    }
}
