using Gdk;
using System.Collections.Generic;

namespace test1.Draw.Tool
{
	public class SelectTool: ToolBase
    {
        bool clicked;
        bool isControlKeyPressed;
        List<Object.ObjectBase> activeObjects;
		Common.PointD startPoint;
		
		public SelectTool(string name, string label, Canvas.DefaultCanvas canvas)
            : base(name, label, canvas)
        {
            activeObjects = new List<Object.ObjectBase>();
            clicked = false;
            isControlKeyPressed = false;
        }

		public override void OnButtonMotionEvent(EventMotion eventArgs)
		{
            if (clicked)
            {
                double x = eventArgs.X - startPoint.X;
                double y = eventArgs.Y - startPoint.Y;
                startPoint.X = eventArgs.X;
                startPoint.Y = eventArgs.Y;
                foreach (Object.ObjectBase obj in activeObjects)
                {
                    obj.Translate(x, y);
                }
                Canvas.Update();
            }
        }

		public override void OnButtonPressEvent(EventButton eventArgs)
		{
            clicked = true;
			startPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
            bool found = false;
			foreach(Object.ObjectBase drawObject in Canvas.DrawObjects) {
				if (drawObject.IsContain(startPoint)) {
                    found = true;
                    if (activeObjects.Find(obj => obj.ID == drawObject.ID) == null)
                    {
                        drawObject.Select();
                        activeObjects.Add(drawObject);
                    }
                    break;
				}
			}
            if (!found)
            {
                foreach (Object.ObjectBase obj in activeObjects)
                {
                    obj.Deselect();
                }
                activeObjects.Clear();
            }
            Canvas.Update();
        }

		public override void OnButtonReleaseEvent(EventButton eventArgs)
		{
            clicked = false;
		}

        public override void OnKeyPressEvent(EventKey eventArgs)
        {
            switch (eventArgs.Key)
            {
                case Key.Control_L:
                case Key.Control_R:
                    isControlKeyPressed = true;
                    break;
            }
        }

        public override void OnKeyReleaseEvent(EventKey eventArgs)
        {
            switch(eventArgs.Key)
            {
                case Key.Control_L:
                case Key.Control_R:
                    isControlKeyPressed = false;
                    break;
            }
        }
    }
}
