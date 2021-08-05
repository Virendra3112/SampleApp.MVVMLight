using Android.Content.PM;
using SampleApp.MVVMLight.Services.Interface;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class OrientationHandler : BaseDependencyImplementation, IOrientationHandler
    {
        public void ForceLandscape()
        {
            GetActivity().RequestedOrientation = ScreenOrientation.Landscape;
        }

        public void ForcePortrait()
        {
            GetActivity().RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}