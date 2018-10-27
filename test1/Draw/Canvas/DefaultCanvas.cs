using System;
using Gdk;
using System.Collections.Generic;
using test1.Draw.Object;

namespace test1.Draw.Canvas
{
	public class DefaultCanvas : CanvasBase
	{
		Gdk.Window _drawWindow;
		readonly List<Object.IObject> _drawObjects;

		public DefaultCanvas(Gdk.Window window)
			: base(window)
		{
			_drawObjects = new List<Object.IObject>();
			_drawWindow = window;
		}

		public override Gdk.Window DrawWindow
		{
			get => _drawWindow;
			set => _drawWindow = value;
		}

		public List<IObject> DrawObjects => _drawObjects;

		public void AddDrawObject(Object.IObject drawObject)
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
			foreach (Object.IObject drawObject in _drawObjects)
			{
				drawObject.Draw(DrawWindow);
			}
		}
	}
}
