using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KiviApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Boolean that is saved when app is closed.
        /// User can change this value from app's settings.
        /// </summary>
        public static bool SkipStartingAnimations { get; set; }

        /// <summary>
        /// Boolean that indicates if app is resuming from background.
        /// </summary>
        public static bool AppResumed { get; private set; } = false;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            if (SkipStartingAnimations || AppResumed) Current.MainPage = new MainPage();
            else MainPage = new NavigationPage(new StartScreen());
        }

        protected override void OnSleep()
        {
            // Switching value to indicate that app has already started once
            // and is resuming after sleeping.
            AppResumed = true;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
