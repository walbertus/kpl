using System.Collections.Generic;
using test1.Draw.Object;

namespace test1.Draw.Canvas
{
	public interface ICanvas
	{
		Gdk.Window DrawWindow{ get; set; }
        List<ObjectBase> DrawObjects { get; }
        void RemoveDrawObject(ObjectBase drawObject);
        void Update();
        void Draw();
        void AddDrawObject(ObjectBase drawObject);
    }
}