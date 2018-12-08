using System;
namespace test1.Draw.Tool
{
    public static class ToolFactory
    {
        public const string TYPE_SELECT = "select_tool";
        public const string TYPE_RECTANGLE = "rectangle_tool";
        public const string TYPE_TRIANGLE = "triangle_tool";
        public const string TYPE_LINE_SEGMENT = "line_segment_tool";

        public static ITool CreateTool(string type, string name,string label, Canvas.ICanvas canvas)
        {
            switch (type)
            {
                case TYPE_SELECT:
                    return new SelectTool(name, label, canvas);
                case TYPE_TRIANGLE:
                    return new TriangleTool(name, label, canvas);
                case TYPE_RECTANGLE:
                    return new RectangleTool(name, label, canvas);
                case TYPE_LINE_SEGMENT:
                    return new LineSegmentTool(name, label, canvas);
                default:
                    throw new Exception("Wrong factory type");
            }
        }
    }
}
