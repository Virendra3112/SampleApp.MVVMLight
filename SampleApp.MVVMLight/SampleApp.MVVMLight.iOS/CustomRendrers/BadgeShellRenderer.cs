using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

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