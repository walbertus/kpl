using Gdk;

namespace test1.Draw.Tool
{
	public class MoveTool: ToolBase
    {
		Object.ObjectBase activeObject;
		Common.PointD startPoint;
		
		public MoveTool(string name, string label, Canvas.DefaultCanvas canvas)
            : base(name, label, canvas)
        {
			activeObject = null;
        }

		public override void OnButtonMotionEvent(EventMotion eventArgs)
		{
            if (activeObject != null)
            {
                double x = eventArgs.X - startPoint.X;
                double y = eventArgs.Y - startPoint.Y;
                startPoint.X = eventArgs.X;
                startPoint.Y = eventArgs.Y;
                activeObject.Translate(x, y);
                Canvas.Update();
            }
        }

		public override void OnButtonPressEvent(EventButton eventArgs)
		{
			startPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
			foreach(Object.ObjectBase drawObject in Canvas.DrawObjects) {
				if (drawObject.IsContain(startPoint)) {
					activeObject = drawObject;
					break;
				}
			}
			if (activeObject != null) {
                activeObject.Select();
				// activeObject.ChangeColor(0, 0, 255);
				Canvas.Update();
			}
		}

		public override void OnButtonReleaseEvent(EventButton eventArgs)
		{
            if (activeObject != null)
            {
                activeObject.Deselect();
                Canvas.Update();
            }
            activeObject = null;
		}
	}
}
