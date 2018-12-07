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

        void GroupObjects()
        {
            Object.Group newObj = new Object.Group();
            foreach(Object.ObjectBase obj in activeObjects)
            {
                newObj.AddDrawObject(obj);
                Canvas.RemoveDrawObject(obj);
            }
            Canvas.AddDrawObject(newObj);
            activeObjects.Clear();
            activeObjects.Add(newObj);
        }

        void UngroupObjects()
        {
            Object.Group group = (Object.Group)activeObjects[0];
            activeObjects.Remove(group);
            group.Deselect();
            Canvas.RemoveDrawObject(group);
            foreach (Object.ObjectBase obj in group.ObjectList)
            {
                Canvas.AddDrawObject(obj);
            }
            Canvas.Update();
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
            System.Console.Out.WriteLine(eventArgs.Key);
            switch (eventArgs.Key)
            {
                case Key.Control_L:
                case Key.Control_R:
                    isControlKeyPressed = true;
                    break;
                case Key.g:
                case Key.G:
                    if (isControlKeyPressed && activeObjects.Count > 1)
                    {
                        GroupObjects();
                    }
                    break;
                case Key.B:
                case Key.b:
                    if (isControlKeyPressed && activeObjects.Count == 1 && activeObjects[0] is Object.Group)
                    {
                        UngroupObjects();
                    }
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
