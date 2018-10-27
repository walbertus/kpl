using System;
using Gdk;

namespace test1.Draw.Tool
{
	public class MoveTool: ToolBase
    {
		Object.IObject activeObject;
		Point startPoint;
		
		public MoveTool(string name, string label, Canvas.DefaultCanvas canvas)
            : base(name, label, canvas)
        {
			activeObject = null;
        }

		public override void OnButtonPressEvent(EventButton eventArgs)
		{
			startPoint = new Point((int)eventArgs.X, (int)eventArgs.Y);
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
				int x = (int)(eventArgs.X - startPoint.X);
				int y = (int)(eventArgs.Y - startPoint.Y);
				activeObject.Translate(x, y);
				activeObject.ChangeColor(0, 0, 0);
				Canvas.Update();
			}
			activeObject = null;
		}
	}
}
