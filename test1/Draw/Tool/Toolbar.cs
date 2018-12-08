using System;
using System.Collections.Generic;
using Gtk;

namespace test1.Draw.Tool
{
	public class Toolbar
	{
		Canvas.ICanvas Canvas;
		System.Collections.IDictionary ToolDictionary;
		List<Button> _buttons;
		ITool ActiveTool;

		public Toolbar(Canvas.ICanvas canvas)
		{
			ToolDictionary = new Dictionary<string, ITool>();
			Canvas = canvas;
			_buttons = new List<Button>();
			CreateTools();
		}

		public List<Button> Buttons { get => _buttons; }

		void CreateTools()
		{
            AddTool(ToolFactory.CreateTool(ToolFactory.TYPE_RECTANGLE, "rectangleTool", "Rectangle", Canvas));
            AddTool(ToolFactory.CreateTool(ToolFactory.TYPE_TRIANGLE, "triangleTool", "Triangle", Canvas));
            AddTool(ToolFactory.CreateTool(ToolFactory.TYPE_LINE_SEGMENT, "lineSegmentTool", "Line", Canvas));
            AddTool(ToolFactory.CreateTool(ToolFactory.TYPE_SELECT, "selectTool", "Select", Canvas));
		}

		void AddTool(ITool tool)
		{
			ToolDictionary[tool.Name] = tool;
			Button button = new Button
			{
				CanFocus = true,
				Name = tool.Name,
				UseUnderline = true,
				Label = tool.Label
			};
			Buttons.Add(button);
		}

		public void ChangeTool(string name)
		{
			ActiveTool = (ITool)ToolDictionary[name];
			Console.Out.WriteLine("Tool change to " + name);
		}

		public void OnButtonMotionEvent(Gdk.EventMotion eventArgs)
        {
			if (ActiveTool != null) {
				ActiveTool.OnButtonMotionEvent(eventArgs);
			}
        }

		public void OnButtonPressEvent(Gdk.EventButton eventArgs)
        {
			if (ActiveTool != null) {
				ActiveTool.OnButtonPressEvent(eventArgs);
			}
        }

		public void OnButtonReleaseEvent(Gdk.EventButton eventArgs)
        {
			if (ActiveTool != null)
            {
				ActiveTool.OnButtonReleaseEvent(eventArgs);
            }
        }

        public void OnKeyPressEvent(Gdk.EventKey eventArgs)
        {
            if (ActiveTool != null)
            {
                ActiveTool.OnKeyPressEvent(eventArgs);
            }
        }

        public void OnKeyReleaseEvent(Gdk.EventKey eventArgs)
        {
            if (ActiveTool != null)
            {
                ActiveTool.OnKeyReleaseEvent(eventArgs);
            }
        }

    }
}
