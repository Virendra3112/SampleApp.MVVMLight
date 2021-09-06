using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {

        public ExtendedEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            UpdateBorders();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null) return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateBorders();
        }

        void UpdateBorders()
        {
            //GradientDrawable shape = new GradientDrawable();
            //shape.SetShape(ShapeType.Rectangle);
            //shape.SetCornerRadius(10);

            //shape.SetCornerRadii(new float[] { 8, 8, 8, 8, 0, 0, 0, 0 }); // set corner Radious 

            //if (((ExtendedEntry)this.Element).IsBorderErrorVisible)
            //{
            //    shape.SetStroke(3, ((ExtendedEntry)this.Element).BorderErrorColor.ToAndroid());
            //}
            //else
            //{
            //    shape.SetStroke(3, Android.Graphics.Color.LightGray);
            //    this.Control.SetBackground(shape);
            //}

            //this.Control.SetBackground(shape);
            Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.box_curved);

            Control.Gravity = GravityFlags.CenterVertical;
            Control.SetPadding(10, 0, 0, 0);
        }
    }

}

