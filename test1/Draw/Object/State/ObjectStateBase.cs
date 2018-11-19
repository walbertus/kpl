using Gdk;
namespace test1.Draw.Object.State
{
    public abstract class ObjectStateBase
    {
        public abstract void Draw(ObjectBase obj, Window window);

        public virtual void Select(ObjectBase obj)
        {

        }

        public virtual void Deselect(ObjectBase obj)
        {

        }
    }
}
