using System.Collections.Generic;
using test1.Draw.Object;
using test1.Common;

namespace test1.Draw.Canvas
{
	public interface ICanvas: IObserver
	{
		Gdk.Window DrawWindow{ get; set; }
        List<ObjectBase> DrawObjects { get; }
        void RemoveDrawObject(ObjectBase drawObject);
        void Draw();
        void AddDrawObject(ObjectBase drawObject);
    }
}