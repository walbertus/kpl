using System;
namespace test1.Common
{
    public class PointD
    {
		double _x, _y;
		
		public PointD(double x, double y)
        {
			X = x;
			Y = y;
        }

		public double X { get => _x; set => _x = value; }
		public double Y { get => _y; set => _y = value; }
	}
}
