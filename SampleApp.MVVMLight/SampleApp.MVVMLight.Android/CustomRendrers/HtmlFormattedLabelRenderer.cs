using Android.Content;
using Android.Text;
using Android.Widget;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(HtmlFormattedLabelRenderer))]
namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    public class HtmlFormattedLabelRenderer : LabelRenderer
    {
        public HtmlFormattedLabelRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (CustomLabel)Element;
            if (view == null) return;
            if (!string.IsNullOrEmpty(Control.Text))
            {
                if (Control.Text.Contains("<a"))
                {
                    var a = Control.Text.IndexOf("<a");
                    var b = Control.Text.IndexOf("</a>");
                    var d = Control.Text.Length;
                    var c = Control.Text.Length - Control.Text.IndexOf("</a>");
                    int length = b - a + 4;

                    string code = Control.Text.Substring(a, length);
                    Control.SetText(Html.FromHtml(view.Text.ToString().Replace(code, string.Empty)), TextView.BufferType.Spannable);
                }
                else
                    Control.SetText(Html.FromHtml(view.Text.ToString()), TextView.BufferType.Spannable);
            }
        }
    }
}