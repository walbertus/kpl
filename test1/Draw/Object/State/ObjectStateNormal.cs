using Gdk;

namespace test1.Draw.Object.State
{
    public class ObjectStateNormal : ObjectStateBase
    {
        static ObjectStateNormal instance;

        private ObjectStateNormal()
        {

        }

        public static ObjectStateNormal GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectStateNormal();
            }
            return instance;
        }

        public override void Draw(ObjectBase obj, Window window)
        {
            obj.DrawNormal(window);
        }

        public override void Select(ObjectBase obj)
        {
            obj.ChangeState(ObjectStateActive.GetInstance());
        }
    }
}
