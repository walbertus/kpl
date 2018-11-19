using test1.Draw.Object.State;
using System.Collections.Generic;
using test1.Common;

namespace test1.Draw.Object
{
    public abstract class ObjectBase
    {
        protected ObjectStateBase state;
        protected List<PointD> points;

        public abstract void Draw(Gdk.Window window);
        public abstract void Translate(double x, double y);
        public abstract bool IsContain(Common.PointD point);
        public abstract void ChangeColor(int r, int g, int b);
        public abstract void Scale(Common.PointD newPoint, int position);

        public virtual void ChangeState(ObjectStateBase newState)
        {
            this.state = newState;
        }
    }
}
