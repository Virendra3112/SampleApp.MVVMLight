using SampleApp.MVVMLight.Models;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.CustomControls
{
    public class CameraPreview : View
    {
        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
            propertyName: "Camera",
            returnType: typeof(CameraOptions),
            declaringType: typeof(CameraPreview),
            defaultValue: CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }
    }

    public enum CameraOptions
    {
        Rear,
        Front
    }
}
