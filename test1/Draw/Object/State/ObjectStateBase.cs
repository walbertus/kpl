using System;
namespace test1.Draw.Object.State
{
    public abstract class ObjectStateBase
    {
        protected ObjectStateBase instance;

        public abstract void Draw(ObjectBase obj);

        public virtual void Select(ObjectBase obj)
        {

        }

        public virtual void Deselect(ObjectBase obj)
        {

        }
    }
}
