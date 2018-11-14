namespace test1.Draw.Object
{
	public abstract class ObjectBase
	{
		public abstract void Draw(Gdk.Window window);
        public abstract void Translate(double x, double y);
        public abstract bool IsContain(Common.PointD point);
        public abstract void ChangeColor(int r, int g, int b);
        public abstract void ChangeColor(Cairo.Color color);
        public abstract void Scale(Common.PointD newPoint, int position);
	}
}
