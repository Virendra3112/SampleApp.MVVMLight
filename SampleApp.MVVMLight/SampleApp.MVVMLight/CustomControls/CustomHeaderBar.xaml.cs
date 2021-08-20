
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomHeaderBar : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), returnType: typeof(string), declaringType: typeof(string), defaultValue: "");
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource BackgroundImage
        {
            get
            {
                return (ImageSource)GetValue(BackgroundImageProperty);
            }
            set
            {
                SetValue(BackgroundImageProperty, value);
            }
        }

        public static readonly BindableProperty LeftIconProperty = BindableProperty.Create(nameof(LeftIcon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        /// <summary>
        /// Left Icon is depricated.
        /// Replace the image in ValueConvertor to reflect in entire application.
        /// </summary>
        public ImageSource LeftIcon
        {
            get
            {
                return (ImageSource)GetValue(LeftIconProperty);
            }
            set
            {
                SetValue(LeftIconProperty, value);
            }
        }

        public static readonly BindableProperty LeftTappedCommandProperty = BindableProperty.Create(nameof(LeftTappedCommand), returnType: typeof(Command), declaringType: typeof(Command), defaultValue: null);
        public Command LeftTappedCommand
        {
            get
            {
                return (Command)GetValue(LeftTappedCommandProperty);
            }
            set
            {
                SetValue(LeftTappedCommandProperty, value);
            }
        }

        public static readonly BindableProperty LeftContentProperty = BindableProperty.Create(nameof(LeftContent), returnType: typeof(View), declaringType: typeof(View), defaultValue: null);
        public View LeftContent
        {
            get
            {
                return (View)GetValue(LeftContentProperty);
            }
            set
            {
                SetValue(LeftContentProperty, value);
            }
        }

        public static readonly BindableProperty RightIconProperty = BindableProperty.Create(nameof(RightIcon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource RightIcon
        {
            get
            {
                return (ImageSource)GetValue(RightIconProperty);
            }
            set
            {
                SetValue(RightIconProperty, value);
            }
        }

        public static readonly BindableProperty RightTappedCommandProperty = BindableProperty.Create(nameof(RightTappedCommand), returnType: typeof(Command), declaringType: typeof(Command), defaultValue: null);
        public Command RightTappedCommand
        {
            get
            {
                return (Command)GetValue(RightTappedCommandProperty);
            }
            set
            {
                SetValue(RightTappedCommandProperty, value);
            }
        }

        public static readonly BindableProperty RightContentProperty = BindableProperty.Create(nameof(RightContent), returnType: typeof(View), declaringType: typeof(View), defaultValue: null);
        public View RightContent
        {
            get
            {
                return (View)GetValue(RightContentProperty);
            }
            set
            {
                SetValue(RightContentProperty, value);
            }
        }
        public static readonly BindableProperty IsContentVisibleProperty = BindableProperty.Create(nameof(IsContentVisible), returnType: typeof(bool), declaringType: typeof(bool), defaultValue: true);
        public bool IsContentVisible
        {
            get
            {
                return (bool)GetValue(IsContentVisibleProperty);
            }
            set
            {
                SetValue(RightContentProperty, value);
            }
        }
        private int safeAreaTopInset;

        public int SafeAreaTopInset
        {
            get
            {
                return safeAreaTopInset;
            }
            set
            {
                safeAreaTopInset = value;
                OnPropertyChanged("SafeAreaTopInset");
            }
        }

        public CustomHeaderBar()
        {
            InitializeComponent();
            this.PropertyChanged += HeaderBar_PropertyChanged;
            //BaseView.AdjustIconEvent += UpdateCultureSpecifics;
        }

        public void UpdateCultureSpecifics(string culture)
        {
            backImg.Source = "arrowbackicon.png";
        }
        public void AdjustSafeAreaInsets()
        {
          
        }
        private void HeaderBar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == RightIconProperty.PropertyName)
            {
                RightContent = new Image() { Source = RightIcon };
            }           
        }
    }
}
