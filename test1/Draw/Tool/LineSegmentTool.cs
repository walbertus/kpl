using System;
using Gdk;

namespace test1.Draw.Tool
{
	public class LineSegmentTool: ToolBase
    {
		Gdk.Point startPoint;
		
		public LineSegmentTool(string name, string label, Canvas.DefaultCanvas canvas)
			: base(name, label, canvas)
        {
        }

		public override void OnButtonPressEvent(EventButton eventArgs)
		{
			startPoint = new Gdk.Point((int)eventArgs.X, (int)eventArgs.Y);
		}

		public override void OnButtonReleaseEvent(EventButton eventArgs)
		{
			Gdk.Point endPoint = new Gdk.Point((int)eventArgs.X, (int)eventArgs.Y);
			Canvas.AddDrawObject(new Draw.Object.LineSegment(startPoint, endPoint));
		}
	}
}
