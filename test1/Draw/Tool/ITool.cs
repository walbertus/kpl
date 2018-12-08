namespace test1.Draw.Tool
{
	public interface ITool
    {
		string Name { get; set; }
		string Label { get; set; }

		void OnButtonPressEvent(Gdk.EventButton eventArgs);
		void OnButtonReleaseEvent(Gdk.EventButton eventArgs);
		void OnButtonMotionEvent(Gdk.EventMotion eventArgs);
        void OnKeyPressEvent(Gdk.EventKey eventArgs);
        void OnKeyReleaseEvent(Gdk.EventKey eventArgs);
    }
}
