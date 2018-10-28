﻿using Gdk;

namespace test1.Draw.Tool
{
    public class TriangleTool : ToolBase
    {
		Common.PointD startPoint;

        public TriangleTool(string name, string label, Canvas.DefaultCanvas canvas)
            : base(name, label, canvas)
        {
        }

		public override void OnButtonMotionEvent(EventMotion eventArgs)
		{
			
		}

		public override void OnButtonPressEvent(EventButton eventArgs)
        {
			startPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
        }

        public override void OnButtonReleaseEvent(EventButton eventArgs)
        {
			Common.PointD endPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
			Canvas.AddDrawObject(new Draw.Object.Triangle(startPoint, endPoint));
        }
    }
}
