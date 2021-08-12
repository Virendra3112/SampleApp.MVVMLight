using System.Diagnostics;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.CustomControls
{
    public class FloatingContentView : ContentView
    {

        private double x, y;
        public FloatingContentView()
        {
            var panGesture = new PanGestureRecognizer();

            panGesture.PanUpdated += OnPanUpdated;
            this.GestureRecognizers.Add(panGesture);
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:

                    Debug.WriteLine("DEBUG: start dragging");
                    break;
                case GestureStatus.Running:

                    Content.TranslationX = x + e.TotalX;
                    Content.TranslationY = y + e.TotalY;

                    break;
                case GestureStatus.Completed:

                    x = Content.TranslationX;
                    y = Content.TranslationY;

                    Debug.WriteLine("DEBUG: drag ended");
                    break;
            }
        }
    }
}