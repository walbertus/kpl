using System;
using Gdk;
using System.Collections.Generic;
using test1.Draw.Object;

namespace test1.Draw.Canvas
{
	public class DefaultCanvas : CanvasBase
	{
		Gdk.Window _drawWindow;
		readonly List<Object.ObjectBase> _drawObjects;

		public DefaultCanvas(Gdk.Window window)
			: base(window)
		{
			_drawObjects = new List<Object.ObjectBase>();
			_drawWindow = window;
		}

		public override Gdk.Window DrawWindow
		{
			get => _drawWindow;
			set => _drawWindow = value;
		}

		public List<ObjectBase> DrawObjects => _drawObjects;

		public void AddDrawObject(Object.ObjectBase drawObject)
		{
			_drawObjects.Add(drawObject);
			DrawWindow.Clear();
			Draw();
		}

		public void Update()
		{
			DrawWindow.Clear();
			Draw();
		}

		public void Draw()
		{
			foreach (Object.ObjectBase drawObject in _drawObjects)
			{
				drawObject.Draw(DrawWindow);
			}
		}
	}
}
