﻿using Gdk;
using test1.Draw.Canvas;

namespace test1.Draw.Tool
{
    public class TriangleTool : ITool
    {
        string _name, _label;
        ICanvas _canvas;
        Object.Triangle activeObject;

        public TriangleTool(string name, string label, Canvas.ICanvas canvas)
        {
            Name = name;
            Label = label;
            Canvas = canvas;
        }

        public string Name { get => _name; set => _name = value; }
        public string Label { get => _label; set => _label = value; }
        ICanvas Canvas { get => _canvas; set => _canvas = value; }

        public void OnButtonMotionEvent(EventMotion eventArgs)
		{
            if (activeObject != null)
            {
                Common.PointD newPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
                activeObject.Scale(newPoint, Object.ObjectConstants.OBJECT_CONTROL_BOTTOM_RIGHT);
            }
        }

		public void OnButtonPressEvent(EventButton eventArgs)
        {
            Common.PointD startPoint = new Common.PointD(eventArgs.X, eventArgs.Y);
            Common.PointD endPoint = new Common.PointD(eventArgs.X + 1, eventArgs.Y + 1);
            activeObject = new Object.Triangle(startPoint, endPoint);
            activeObject.Attach(Canvas);
            Canvas.AddDrawObject(activeObject);
            Canvas.Update();
        }

        public void OnButtonReleaseEvent(EventButton eventArgs)
        {
            activeObject.ReconfigureCornerPoints();
            activeObject.Deselect();
            activeObject = null;
        }

        public void OnKeyPressEvent(EventKey eventArgs)
        {

        }

        public void OnKeyReleaseEvent(EventKey eventArgs)
        {

        }
    }
}
