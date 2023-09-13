using CoreGraphics;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.iOS.CustomRendrers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace SampleApp.MVVMLight.iOS.CustomRendrers
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        //UITabBarController tabbedController;

        //private readonly Dictionary<Guid, int> _tabRealIndexByItemId =
        //   new Dictionary<Guid, int>();


        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            Cleanup(e.OldElement as TabbedPage);

            //if (e.NewElement != null)
            //{
            //    tabbedController = (UITabBarController)ViewController;
            //}
        }

        public override void ViewWillAppear(bool animated)
        {
            //if (TabBar?.Items == null)
            //    return;

            //// Go through our elements and change the icons
            //var tabs = Element as TabbedPage;
            //if (tabs != null)
            //{
            //    for (int i = 0; i < TabBar.Items.Length; i++)
            //    {
            //        UpdateTabBarItem(TabBar.Items[i], tabs.Children[i].Icon);
            //    }
            //    AddFonts();
            //    AddSelectedTabIndicator();
            //}

            base.ViewWillAppear(animated);

            // make sure we cleanup old event registrations
            Cleanup(Tabbed);

            for (var i = 0; i < TabBar.Items.Length; i++)
            {
                AddTabBadge(i);
            }

            Tabbed.ChildAdded += OnTabAdded;
            Tabbed.ChildRemoved += OnTabRemoved;
        }

        private void AddTabBadge(int tabIndex)
        {
            if (tabIndex == -1)
            {
                return;
            }

            var element = Tabbed.GetChildPageWithBadge(tabIndex);
            element.PropertyChanged += OnTabbedPagePropertyChanged;

            if (TabBar.Items.Length > tabIndex)
            {
                var tabBarItem = TabBar.Items[tabIndex];
                UpdateTabBadgeText(tabBarItem, element);
                UpdateTabBadgeColor(tabBarItem, element);
                UpdateTabBadgeTextAttributes(tabBarItem, element);
            }
        }

        private void UpdateTabBadgeText(UITabBarItem tabBarItem, Element element)
        {
            var text = TabBadge.GetBadgeText(element);

            tabBarItem.BadgeValue = string.IsNullOrEmpty(text) ? null : text;
        }

        private void UpdateTabBadgeTextAttributes(UITabBarItem tabBarItem, Element element)
        {
            if (!tabBarItem.RespondsToSelector(new ObjCRuntime.Selector("setBadgeTextAttributes:forState:")))
            {
                // method not available, ios < 10
                Console.WriteLine("Plugin.Badge: badge text attributes only available starting with iOS 10.0.");
                return;
            }

            var attrs = new UIStringAttributes();

            var textColor = TabBadge.GetBadgeTextColor(element);
            if (textColor != Color.Default)
            {
                attrs.ForegroundColor = textColor.ToUIColor();
            }

            var font = TabBadge.GetBadgeFont(element);
            if (font != Font.Default)
            {
                attrs.Font = font.ToUIFont();
            }

            tabBarItem.SetBadgeTextAttributes(attrs, UIControlState.Normal);
        }

        private void UpdateTabBadgeColor(UITabBarItem tabBarItem, Element element)
        {
            if (!tabBarItem.RespondsToSelector(new ObjCRuntime.Selector("setBadgeColor:")))
            {
                // method not available, ios < 10
                Console.WriteLine("Plugin.Badge: badge color only available starting with iOS 10.0.");
                return;
            }

            var tabColor = TabBadge.GetBadgeColor(element);
            if (tabColor != Color.Default)
            {
                tabBarItem.BadgeColor = tabColor.ToUIColor();
            }
        }

        private void OnTabbedPagePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var page = sender as Page;
            if (page == null)
                return;

            if (e.PropertyName == Page.IconImageSourceProperty.PropertyName)
            {
                // #65 update badge properties if icon changed
                if (CheckValidTabIndex(page, out int tabIndex))
                {
                    UpdateTabBadgeText(TabBar.Items[tabIndex], page);
                    UpdateTabBadgeColor(TabBar.Items[tabIndex], page);
                    UpdateTabBadgeTextAttributes(TabBar.Items[tabIndex], page);
                }

                return;
            }

            if (e.PropertyName == TabBadge.BadgeTextProperty.PropertyName)
            {
                if (CheckValidTabIndex(page, out int tabIndex))
                    UpdateTabBadgeText(TabBar.Items[tabIndex], page);
                return;
            }

            if (e.PropertyName == TabBadge.BadgeColorProperty.PropertyName)
            {
                if (CheckValidTabIndex(page, out int tabIndex))
                    UpdateTabBadgeColor(TabBar.Items[tabIndex], page);
                return;
            }

            if (e.PropertyName == TabBadge.BadgeTextColorProperty.PropertyName || e.PropertyName == TabBadge.BadgeFontProperty.PropertyName)
            {
                if (CheckValidTabIndex(page, out int tabIndex))
                    UpdateTabBadgeTextAttributes(TabBar.Items[tabIndex], page);
                return;
            }
        }

        protected bool CheckValidTabIndex(Page page, out int tabIndex)
        {
            tabIndex = Tabbed.Children.IndexOf(page);
            if (tabIndex == -1 && page.Parent != null)
                tabIndex = Tabbed.Children.IndexOf(page.Parent);
            return tabIndex >= 0 && tabIndex < TabBar.Items.Length;
        }

        private async void OnTabAdded(object sender, ElementEventArgs e)
        {
            //workaround for XF, tabbar is not updated at this point and we have no way of knowing for sure when it will be updated. so we have to wait ... 
            await Task.Delay(10);
            var page = e.Element as Page;
            if (page == null)
                return;

            var tabIndex = Tabbed.Children.IndexOf(page);
            AddTabBadge(tabIndex);
        }

        private void OnTabRemoved(object sender, ElementEventArgs e)
        {
            e.Element.PropertyChanged -= OnTabbedPagePropertyChanged;
        }

        protected override void Dispose(bool disposing)
        {
            Cleanup(Tabbed);

            base.Dispose(disposing);
        }

        private void Cleanup(TabbedPage tabbedPage)
        {
            if (tabbedPage == null)
            {
                return;
            }

            foreach (var tab in tabbedPage.Children.Select(c => c.GetPageWithBadge()))
            {
                tab.PropertyChanged -= OnTabbedPagePropertyChanged;
            }

            tabbedPage.ChildAdded -= OnTabAdded;
            tabbedPage.ChildRemoved -= OnTabRemoved;
        }
        //public override UIViewController SelectedViewController
        //{
        //    get
        //    {
        //        if (base.SelectedViewController != null)
        //        {
        //            AddFonts();

        //        }
        //        return base.SelectedViewController;
        //    }
        //    set
        //    {
        //        base.SelectedViewController = value;
        //        AddFonts();

        //    }
        //}

        //void AddFonts()
        //{
        //    UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes
        //    {
        //        TextColor = Color.FromHex("#757575").ToUIColor(),
        //        Font = UIFont.FromName("GillSans-UltraBold", 12)
        //    }, UIControlState.Normal);

        //    UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes
        //    {
        //        TextColor = Color.FromHex("#3C9BDF").ToUIColor(),
        //        Font = UIFont.FromName("GillSans-UltraBold", 12)
        //    }, UIControlState.Selected);

        //}


        //private void UpdateTabBarItem(UITabBarItem item, string icon)
        //{
        //    if (item == null || icon == null)
        //        return;

        //    // Set the font for the title.
        //    item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("GillSans-UltraBold", 12), TextColor = Color.FromHex("#757575").ToUIColor() }, UIControlState.Normal);
        //    item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("GillSans-UltraBold", 12), TextColor = Color.FromHex("#3C9BDF").ToUIColor() }, UIControlState.Selected);

        //}


        //protected override Task<Tuple<UIImage, UIImage>> GetIcon(Page page)
        //{
        //    UIImage image;
        //    if (page.Title == "App")
        //    {
        //        image = UIImage.FromBundle(page.Icon.File).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
        //    }
        //    else
        //    {
        //        image = UIImage.FromBundle(page.Icon.File).ImageWithRenderingMode(UIImageRenderingMode.Automatic);
        //    }

        //    return Task.FromResult(new Tuple<UIImage, UIImage>(image, image));
        //}

        //void AddSelectedTabIndicator()
        //{
        //    if (base.ViewControllers != null)
        //    {
        //        UITabBar.Appearance.SelectionIndicatorImage = GetImageWithColorPosition(Color.DarkGray.ToUIColor(), new CGSize(UIScreen.MainScreen.Bounds.Width / base.ViewControllers.Length, tabbedController.TabBar.Bounds.Size.Height + 4), new CGSize(UIScreen.MainScreen.Bounds.Width / base.ViewControllers.Length, 4));
        //    }

        //}
        //UIImage GetImageWithColorPosition(UIColor color, CGSize size, CGSize lineSize)
        //{
        //    var rect = new CGRect(0, 0, size.Width, size.Height);
        //    var rectLine = new CGRect(0, size.Height - lineSize.Height, lineSize.Width, lineSize.Height);
        //    UIGraphics.BeginImageContextWithOptions(size, false, 0);
        //    UIColor.Clear.SetFill();
        //    UIGraphics.RectFill(rect);
        //    color.SetFill();
        //    UIGraphics.RectFill(rectLine);
        //    var img = UIGraphics.GetImageFromCurrentImageContext();
        //    UIGraphics.EndImageContext();
        //    return img;

        //}


        //private void InitBadges()
        //{
        //    _tabRealIndexByItemId.Clear();
        //    if ( ShellItem?.Items == null)
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

        //private void UpdateBadge(ShellSection item, int index)
        //{
        //    if (index < 0)
        //        return;

        //    var text = Badge.GetText(item);
        //    var textColor = Badge.GetTextColor(item);
        //    var bg = Badge.GetBackgroundColor(item);
        //    ApplyBadge(index, text, bg, textColor);
        //}

        //private void ApplyBadge(int index, string text, Color bg, Color textColor)
        //{
        //    if (TabBar.Items.Any())
        //    {
        //        if (TabBar.Items.ElementAtOrDefault(index) is UITabBarItem currentTabBarItem)
        //        {
        //            int.TryParse(text, out var badgeValue);

        //            if (string.IsNullOrEmpty(text))
        //            {
        //                currentTabBarItem.BadgeValue = default;
        //                textColor = Color.Transparent;
        //                bg = Color.Transparent;
        //            }
        //            else if (badgeValue == 0)
        //            {
        //                currentTabBarItem.BadgeValue = "●";
        //                textColor = bg;
        //                bg = Color.Transparent;
        //            }
        //            else
        //            {
        //                currentTabBarItem.BadgeValue = text;
        //            }

        //            currentTabBarItem.BadgeColor = bg.ToUIColor();
        //            currentTabBarItem.SetBadgeTextAttributes(
        //                new UIStringAttributes
        //                {
        //                    ForegroundColor = textColor.ToUIColor()
        //                }, UIControlState.Normal);
        //        }
        //    }
        //}

    }

}
