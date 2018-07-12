using Android.Graphics;
using Android.Graphics.Drawables;
using ClubeDoPedido.Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ClubeDoPedido.Mobile.Componentes;

[assembly: ExportRenderer(typeof(LineEntry), typeof(LineEntryRenderer))]
namespace ClubeDoPedido.Mobile.Droid.Renderers
{
    public class LineEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.White.ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;

                var element = e.NewElement as Entry;
                Control.Hint = element.Placeholder;
                Control.SetHintTextColor(Android.Graphics.Color.White);
            }
        }


    }
}