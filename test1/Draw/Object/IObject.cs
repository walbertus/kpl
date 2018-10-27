namespace test1.Draw.Object
{
	public interface IObject
	{
		void Draw(Gdk.Window window);
		void Translate(int x, int y);
		bool IsContain(Common.PointD point);
		void ChangeColor(int r, int g, int b);
		void ChangeColor(Cairo.Color color);
	}
}
