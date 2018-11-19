using Gdk;

namespace test1.Draw.Tool
{
	public class LineSegmentTool: ToolBase
    {
        Object.LineSegment activeObject;

        public LineSegmentTool(string name, string label, Canvas.DefaultCanvas canvas)
			: base(name, label, canvas)
        {
        }

        public override void OnButtonMotionEvent(EventMotion eventArgs)
        {
            if (activeObject != null)
            {
                Common.PointD newPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
                activeObject.Scale(newPoint, Object.ObjectConstants.OBJECT_CONTROL_BOTTOM_RIGHT);
                Canvas.Update();
            }
        }

        public override void OnButtonPressEvent(EventButton eventArgs)
        {
            Common.PointD startPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
            Common.PointD endPoint = new Common.PointD(eventArgs.X + 1, eventArgs.Y + 1);
            activeObject = new Object.LineSegment(startPoint, endPoint);
            Canvas.AddDrawObject(activeObject);
        }

        public override void OnButtonReleaseEvent(EventButton eventArgs)
        {
            activeObject.ReconfigureCornerPoints();
            activeObject = null;
        }
    }
}
