using CoreGraphics;
using Foundation;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.iOS.CustomRendrers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace SampleApp.MVVMLight.iOS.CustomRendrers
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        UITabBarController tabbedController;

        private readonly Dictionary<Guid, int> _tabRealIndexByItemId =
           new Dictionary<Guid, int>();


        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                tabbedController = (UITabBarController)ViewController;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            if (TabBar?.Items == null)
                return;

            // Go through our elements and change the icons
            var tabs = Element as TabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateTabBarItem(TabBar.Items[i], tabs.Children[i].Icon);
                }
                AddFonts();
                AddSelectedTabIndicator();
            }

            base.ViewWillAppear(animated);
        }

        public override UIViewController SelectedViewController
        {
            get
            {
                if (base.SelectedViewController != null)
                {
                    AddFonts();

                }
                return base.SelectedViewController;
            }
            set
            {
                base.SelectedViewController = value;
                AddFonts();

            }
        }

        void AddFonts()
        {
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = Color.FromHex("#757575").ToUIColor(),
                Font = UIFont.FromName("GillSans-UltraBold", 12)
            }, UIControlState.Normal);

            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = Color.FromHex("#3C9BDF").ToUIColor(),
                Font = UIFont.FromName("GillSans-UltraBold", 12)
            }, UIControlState.Selected);

        }


        private void UpdateTabBarItem(UITabBarItem item, string icon)
        {
            if (item == null || icon == null)
                return;

            // Set the font for the title.
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("GillSans-UltraBold", 12), TextColor = Color.FromHex("#757575").ToUIColor() }, UIControlState.Normal);
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("GillSans-UltraBold", 12), TextColor = Color.FromHex("#3C9BDF").ToUIColor() }, UIControlState.Selected);

        }


        protected override Task<Tuple<UIImage, UIImage>> GetIcon(Page page)
        {
            UIImage image;
            if (page.Title == "App")
            {
                image = UIImage.FromBundle(page.Icon.File).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            else
            {
                image = UIImage.FromBundle(page.Icon.File).ImageWithRenderingMode(UIImageRenderingMode.Automatic);
            }

            return Task.FromResult(new Tuple<UIImage, UIImage>(image, image));
        }

        void AddSelectedTabIndicator()
        {
            if (base.ViewControllers != null)
            {
                UITabBar.Appearance.SelectionIndicatorImage = GetImageWithColorPosition(Color.DarkGray.ToUIColor(), new CGSize(UIScreen.MainScreen.Bounds.Width / base.ViewControllers.Length, tabbedController.TabBar.Bounds.Size.Height + 4), new CGSize(UIScreen.MainScreen.Bounds.Width / base.ViewControllers.Length, 4));
            }

        }
        UIImage GetImageWithColorPosition(UIColor color, CGSize size, CGSize lineSize)
        {
            var rect = new CGRect(0, 0, size.Width, size.Height);
            var rectLine = new CGRect(0, size.Height - lineSize.Height, lineSize.Width, lineSize.Height);
            UIGraphics.BeginImageContextWithOptions(size, false, 0);
            UIColor.Clear.SetFill();
            UIGraphics.RectFill(rect);
            color.SetFill();
            UIGraphics.RectFill(rectLine);
            var img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return img;

        }


        //private void InitBadges()
        //{
        //    _tabRealIndexByItemId.Clear();
        //    if (ShellItem?.Items == null)
        //        return;
        //    for (int index = 0, filteredIndex = 0; index < ShellItem.Items.Count; index++)
        //    {
        //        var item = ShellItem.Items.ElementAtOrDefault(index);
        //        if (item == null || !item.IsVisible)
        //            continue;
        //        _tabRealIndexByItemId[item.Id] = filteredIndex;
        //        UpdateBadge(item, filteredIndex);
        //        filteredIndex++;
        //    }
        //}

        private void UpdateBadge(ShellSection item, int index)
        {
            if (index < 0)
                return;

            var text = Badge.GetText(item);
            var textColor = Badge.GetTextColor(item);
            var bg = Badge.GetBackgroundColor(item);
            ApplyBadge(index, text, bg, textColor);
        }

        private void ApplyBadge(int index, string text, Color bg, Color textColor)
        {
            if (TabBar.Items.Any())
            {
                if (TabBar.Items.ElementAtOrDefault(index) is UITabBarItem currentTabBarItem)
                {
                    int.TryParse(text, out var badgeValue);

                    if (string.IsNullOrEmpty(text))
                    {
                        currentTabBarItem.BadgeValue = default;
                        textColor = Color.Transparent;
                        bg = Color.Transparent;
                    }
                    else if (badgeValue == 0)
                    {
                        currentTabBarItem.BadgeValue = "●";
                        textColor = bg;
                        bg = Color.Transparent;
                    }
                    else
                    {
                        currentTabBarItem.BadgeValue = text;
                    }

                    currentTabBarItem.BadgeColor = bg.ToUIColor();
                    currentTabBarItem.SetBadgeTextAttributes(
                        new UIStringAttributes
                        {
                            ForegroundColor = textColor.ToUIColor()
                        }, UIControlState.Normal);
                }
            }
        }

    }

}
