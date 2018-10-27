using System;
namespace test1.Draw.Canvas
{
	public abstract class CanvasBase
	{
		public CanvasBase(Gdk.Window window)
		{

		}

		public abstract Gdk.Window DrawWindow
        {
			get;
            set;
        }
	}
}