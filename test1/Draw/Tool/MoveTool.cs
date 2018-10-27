using Gdk;

namespace test1.Draw.Tool
{
	public class MoveTool: ToolBase
    {
		Object.IObject activeObject;
		Common.PointD startPoint;
		
		public MoveTool(string name, string label, Canvas.DefaultCanvas canvas)
            : base(name, label, canvas)
        {
			activeObject = null;
        }

		public override void OnButtonPressEvent(EventButton eventArgs)
		{
			startPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
			foreach(Object.IObject drawObject in Canvas.DrawObjects) {
				if (drawObject.IsContain(startPoint)) {
					activeObject = drawObject;
					break;
				}
			}
			if (activeObject != null) {
				activeObject.ChangeColor(0, 0, 255);
				Canvas.Update();
			}
		}

		public override void OnButtonReleaseEvent(EventButton eventArgs)
		{
			if (activeObject != null) {
				double x = eventArgs.X - startPoint.X;
				double y = eventArgs.Y - startPoint.Y;
				activeObject.Translate(x, y);
				activeObject.ChangeColor(0, 0, 0);
				Canvas.Update();
			}
			activeObject = null;
		}
	}
}
