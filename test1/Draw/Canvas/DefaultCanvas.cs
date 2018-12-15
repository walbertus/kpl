using Gdk;
using System.Collections.Generic;
using test1.Draw.Object;
using test1.Common;

namespace test1.Draw.Canvas
{
	public class DefaultCanvas : ICanvas
	{
        Window _drawWindow;
		readonly List<ObjectBase> _drawObjects;

		public DefaultCanvas(Window window)
		{
			_drawObjects = new List<ObjectBase>();
			_drawWindow = window;
		}

		public Window DrawWindow
		{
			get => _drawWindow;
			set => _drawWindow = value;
		}

		public List<ObjectBase> DrawObjects => _drawObjects;

		public void AddDrawObject(ObjectBase drawObject)
		{
			_drawObjects.Add(drawObject);
		}

        public void RemoveDrawObject(ObjectBase drawObject)
        {
            _drawObjects.Remove(drawObject);
        }

        public void Update()
		{
			DrawWindow.Clear();
			Draw();
		}

		public void Draw()
		{
			foreach (ObjectBase drawObject in _drawObjects)
			{
				drawObject.Draw(DrawWindow);
			}
		}
	}
}
