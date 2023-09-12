using SampleApp.MVVMLight.iOS.CustomRendrers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(BadgeShellRenderer))]
namespace SampleApp.MVVMLight.iOS.CustomRendrers
{
    public class BadgeShellRenderer : ShellRenderer
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item) =>
            new BadgeShellItemRenderer(this) { ShellItem = item };
    }
}