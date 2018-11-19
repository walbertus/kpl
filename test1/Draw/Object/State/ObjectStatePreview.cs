using Gdk;
namespace test1.Draw.Object.State
{
    public class ObjectStatePreview : ObjectStateBase
    {
        static ObjectStatePreview instance;

        private ObjectStatePreview()
        {

        }

        public static ObjectStatePreview GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectStatePreview();
            }
            return instance;
        }

        public override void Draw(ObjectBase obj, Window window)
        {
            obj.DrawPreview(window);
        }

        public override void Deselect(ObjectBase obj)
        {
            obj.ChangeState(ObjectStateNormal.GetInstance());
        }
    }
}
