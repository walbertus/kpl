using System;
using test1.Draw.Canvas;

namespace test1.Draw.Tool
{
	public abstract class ToolBase
    {
		string _name, _label;
		Canvas.DefaultCanvas _canvas;

		protected ToolBase(string name, string label, Canvas.DefaultCanvas canvas) {
			Name = name;
			Label = label;
			_canvas = canvas;
		}

		public string Name { get => _name; set => _name = value; }
		public string Label { get => _label; set => _label = value; }
		public DefaultCanvas Canvas { get => _canvas; }

		public abstract void OnButtonPressEvent(Gdk.EventButton eventArgs);
		public abstract void OnButtonReleaseEvent(Gdk.EventButton eventArgs);
    }
}
