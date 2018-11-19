using Gdk;
namespace test1.Draw.Object.State
{
    public class ObjectStateActive : ObjectStateBase
    {
        static ObjectStateActive instance;

        private ObjectStateActive()
        {

        }

        public static ObjectStateActive GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectStateActive();
            }
            return instance;
        }

        public override void Draw(ObjectBase obj, Window window)
        {
            obj.DrawActive(window);
        }

        public override void Deselect(ObjectBase obj)
        {
            obj.ChangeState(ObjectStateNormal.GetInstance());
        }

    }
}
