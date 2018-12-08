using System;
using Gtk;

public partial class MainWindow : Window
{
	test1.Draw.Canvas.ICanvas canvas;
	test1.Draw.Tool.Toolbar toolbar;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
		canvas = new test1.Draw.Canvas.DefaultCanvas(drawingarea.GdkWindow);
		toolbar = new test1.Draw.Tool.Toolbar(canvas);
		AttachToolbar();
    }

    void AttachToolbar()
	{
		foreach (Button button in toolbar.Buttons)
        {
			hbox1.Add(button);
            global::Gtk.Box.BoxChild w = ((global::Gtk.Box.BoxChild)(this.hbox1[button]));
            w.Position = 0;
            w.Expand = false;
            w.Fill = false;
			button.Clicked += this.OnButtonToolbarClicked;
            button.Show();
        }
	}

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

	protected void OnButtonToolbarClicked(object sender, EventArgs e)
	{
		toolbar.ChangeTool(((Gtk.Button)sender).Name);
	}

	protected void OnDrawingareaButtonPressEvent(object o, ButtonPressEventArgs args)
	{
		toolbar.OnButtonPressEvent(args.Event);
	}
   
	protected void OnDrawingareaButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
	{
		toolbar.OnButtonReleaseEvent(args.Event);
	}

	protected void OnDrawingareaMotionNotifyEvent(object o, MotionNotifyEventArgs args)
	{
		toolbar.OnButtonMotionEvent(args.Event);
	}

    protected void OnDrawingAreaKeyPressEvent(object o, KeyPressEventArgs args)
    {
        toolbar.OnKeyPressEvent(args.Event);
    }

    protected void OnDrawingAreaKeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
        toolbar.OnKeyReleaseEvent(args.Event);
    }
}
