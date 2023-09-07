using System;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using Android.Graphics;
using Android.Support.Design.Internal;
using BottomNavigationItemView = Android.Support.Design.Internal.BottomNavigationItemView;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(ExtendedTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    public class ExtendedTabbedPageRenderer : TabbedPageRenderer
    {
        Xamarin.Forms.TabbedPage tabbedPage;
        BottomNavigationView bottomNavigationView;
        Android.Views.IMenuItem lastItemSelected;
        private bool firstTime = true;
        int lastItemId = -1;

        private TabLayout _topTabLayout;
        private LinearLayout _topTabStrip;
        private ViewGroup _bottomTabStrip;
        protected readonly Dictionary<Element, BadgeView> BadgeViews = new Dictionary<Element, BadgeView>();

        public ExtendedTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                tabbedPage = e.NewElement as ExtendedTabbedPage;
                bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected += BottomNavigationView_NavigationItemSelected;

                //Call to remove animation
                SetShiftMode(bottomNavigationView, false, false);

                //Call to change the font
                ChangeFont();
            }

            if (e.OldElement != null)
            {
                bottomNavigationView.NavigationItemSelected -= BottomNavigationView_NavigationItemSelected;
            }

            var tabCount = InitLayout();
            for (var i = 0; i < tabCount; i++)
            {
                AddTabBadge(i);
            }
            Element.ChildAdded += OnTabAdded;
            Element.ChildRemoved += OnTabRemoved;

        }

        //Change Tab font
        void ChangeFont()
        {
            var fontFace = Typeface.CreateFromAsset(Context.Assets, "gilsansultrabold.ttf");
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                var itemTitle = item.GetChildAt(1);

                var smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
                var largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));

                lastItemId = bottomNavMenuView.SelectedItemId;

                smallTextView.SetTypeface(fontFace, TypefaceStyle.Bold);
                largeTextView.SetTypeface(fontFace, TypefaceStyle.Bold);

                //Set text color
                var textColor = (item.Id == bottomNavMenuView.SelectedItemId) ? tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarSelectedItemColor().ToAndroid() : tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarItemColor().ToAndroid();
                smallTextView.SetTextColor(textColor);
                largeTextView.SetTextColor(textColor);
            }
        }
        private int InitLayout()
        {
            switch (this.Element.OnThisPlatform().GetToolbarPlacement())
            {
                case ToolbarPlacement.Default:
                case ToolbarPlacement.Top:
                    _topTabLayout = ViewGroup.FindChildOfType<TabLayout>();
                    if (_topTabLayout == null)
                    {
                        Console.WriteLine("Plugin.Badge: No TabLayout found. Badge not added.");
                        return 0;
                    }

                    _topTabStrip = _topTabLayout.FindChildOfType<LinearLayout>();
                    return _topTabLayout.TabCount;
                case ToolbarPlacement.Bottom:
                    _bottomTabStrip = ViewGroup.FindChildOfType<BottomNavigationView>()?.GetChildAt(0) as ViewGroup;
                    if (_bottomTabStrip == null)
                    {
                        Console.WriteLine("Plugin.Badge: No bottom tab layout found. Badge not added.");
                        return 0;
                    }

                    return _bottomTabStrip.ChildCount;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (bottomNavigationView != null)
            {
                bottomNavigationView.ItemIconTintList = null;
            }

            if (firstTime && bottomNavigationView != null)
            {
                for (int i = 0; i < Element.Children.Count; i++)
                {
                    var item = bottomNavigationView.Menu.GetItem(i);
                    if (bottomNavigationView.SelectedItemId == item.ItemId)
                    {
                        SetupBottomNavigationView(item);
                        break;
                    }
                }
                firstTime = false;
            }

        }

        void BottomNavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;
            var normalColor = tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarItemColor().ToAndroid();
            var selectedColor = tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarSelectedItemColor().ToAndroid();

            if (lastItemSelected != null)
            {
                lastItemSelected.Icon.SetColorFilter(normalColor, PorterDuff.Mode.SrcIn);

            }

            if ($"{e.Item}" != "Home")
            {
                e.Item.Icon.SetColorFilter(selectedColor, PorterDuff.Mode.SrcIn);
                lastItemSelected = e.Item;
            }

            if (lastItemId != -1)
            {
                SetTabItemTextColor(bottomNavMenuView.GetChildAt(lastItemId) as BottomNavigationItemView, normalColor);
            }

            SetTabItemTextColor(bottomNavMenuView.GetChildAt(e.Item.ItemId) as BottomNavigationItemView, selectedColor);


            SetupBottomNavigationView(e.Item);
            this.OnNavigationItemSelected(e.Item);

            lastItemId = e.Item.ItemId;

        }


        void SetTabItemTextColor(BottomNavigationItemView bottomNavigationItemView, Android.Graphics.Color textColor)
        {
            var itemTitle = bottomNavigationItemView.GetChildAt(1);
            var smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
            var largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));

            smallTextView.SetTextColor(textColor);
            largeTextView.SetTextColor(textColor);
        }


        //Adding line view
        void SetupBottomNavigationView(IMenuItem item)
        {
            int lineBottomOffset = 8;
            int lineWidth = 4;
            int itemHeight = bottomNavigationView.Height - lineBottomOffset;
            int itemWidth = (bottomNavigationView.Width / Element.Children.Count);
            int leftOffset = item.ItemId * itemWidth;
            int rightOffset = itemWidth * (Element.Children.Count - (item.ItemId + 1));
            GradientDrawable bottomLine = new GradientDrawable();
            bottomLine.SetShape(ShapeType.Line);
            bottomLine.SetStroke(lineWidth, Xamarin.Forms.Color.DarkGray.ToAndroid());

            var layerDrawable = new LayerDrawable(new Drawable[] { bottomLine });
            layerDrawable.SetLayerInset(0, leftOffset, itemHeight, rightOffset, 0);

            bottomNavigationView.SetBackground(layerDrawable);
        }


        //Remove animation
        public void SetShiftMode(BottomNavigationView bottomNavigationView, bool enableShiftMode, bool enableItemShiftMode)
        {
            try
            {
                var menuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;
                if (menuView == null)
                {
                    System.Diagnostics.Debug.WriteLine("Unable to find BottomNavigationMenuView");
                    return;
                }
                var shiftMode = menuView.Class.GetDeclaredField("mShiftingMode");
                shiftMode.Accessible = true;
                shiftMode.SetBoolean(menuView, enableShiftMode);
                shiftMode.Accessible = false;
                shiftMode.Dispose();
                for (int i = 0; i < menuView.ChildCount; i++)
                {
                    var item = menuView.GetChildAt(i) as BottomNavigationItemView;
                    if (item == null)
                        continue;
                    //item.SetShiftingMode(enableItemShiftMode);
                    item.SetChecked(item.ItemData.IsChecked);
                }
                menuView.UpdateMenuView();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to set shift mode: {ex}");
            }
        }


        private void AddTabBadge(int tabIndex)
        {
            if (tabIndex == -1)
            {
                return;
            }

            var page = Element.GetChildPageWithBadge(tabIndex);

            var placement = Element.OnThisPlatform().GetToolbarPlacement();
            var targetView = placement == ToolbarPlacement.Bottom
                ? _bottomTabStrip?.GetChildAt(tabIndex)
                : _topTabLayout?.GetTabAt(tabIndex).CustomView
                ?? _topTabStrip?.GetChildAt(tabIndex);
            if (!(targetView is ViewGroup targetLayout))
            {
                Console.WriteLine("Plugin.Badge: Badge target cannot be null. Badge not added.");
                return;
            }

            var badgeView = targetLayout.FindChildOfType<BadgeView>();

            if (badgeView == null)
            {
                var imageView = targetLayout.FindChildOfType<ImageView>();
                if (placement == ToolbarPlacement.Bottom)
                {
                    // create for entire tab layout
                    badgeView = BadgeView.ForTargetLayout(Context, imageView);
                }
                else
                {
                    //create badge for tab image or text
                    badgeView = BadgeView.ForTarget(Context, imageView?.Drawable != null
                        ? (Android.Views.View)imageView
                        : targetLayout.FindChildOfType<TextView>());
                }
            }

            BadgeViews[page] = badgeView;
            badgeView.UpdateFromElement(page);

            page.PropertyChanged -= OnTabbedPagePropertyChanged;
            page.PropertyChanged += OnTabbedPagePropertyChanged;
        }

        protected virtual void OnTabbedPagePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!(sender is Element element))
                return;

            if (BadgeViews.TryGetValue(element, out var badgeView))
            {
                badgeView.UpdateFromPropertyChangedEvent(element, e);
            }
        }

        private void OnTabRemoved(object sender, ElementEventArgs e)
        {
            e.Element.PropertyChanged -= OnTabbedPagePropertyChanged;
            BadgeViews.Remove(e.Element);
        }

        private async void OnTabAdded(object sender, ElementEventArgs e)
        {
            await Task.Delay(50);

            if (!(e.Element is Page page))
                return;

            AddTabBadge(Element.Children.IndexOf(page));
        }
    }
}