using Gdk;
using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Tool
{
	public class SelectTool: ITool
    {
        string _name, _label;
        Canvas.ICanvas _canvas;
        bool clicked;
        bool isControlKeyPressed;
        List<Object.ObjectBase> activeObjects;
		Common.PointD startPoint;
		
		public SelectTool(string name, string label, Canvas.ICanvas canvas)
        {
            Name = name;
            Label = label;
            Canvas = canvas;
            activeObjects = new List<Object.ObjectBase>();
            clicked = false;
            isControlKeyPressed = false;
        }

        public string Name { get => _name; set => _name = value; }
        public string Label { get => _label; set => _label = value; }
        Canvas.ICanvas Canvas { get => _canvas; set => _canvas = value; }

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

        void CreateConvex()
        {
            List<PointD> points = new List<PointD>();
            foreach(Object.ObjectBase obj in activeObjects)
            {
                points.AddRange(obj.Points);
                Canvas.RemoveDrawObject(obj);
            }
            Object.Convex convex = new Object.Convex(points);
            Canvas.AddDrawObject(convex);
            convex.Deselect();
            convex.Select();
            activeObjects.Clear();
            activeObjects.Add(convex);
            Canvas.Update();
        }

        public void OnButtonMotionEvent(EventMotion eventArgs)
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

		public void OnButtonPressEvent(EventButton eventArgs)
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
                        break;
                    }
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

		public void OnButtonReleaseEvent(EventButton eventArgs)
		{
            clicked = false;
		}

        public void OnKeyPressEvent(EventKey eventArgs)
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
                case Key.X:
                case Key.x:
                    if (isControlKeyPressed && activeObjects.Count > 0)
                    {
                        CreateConvex();
                    }
                    break;
            }
        }

        public void OnKeyReleaseEvent(EventKey eventArgs)
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
