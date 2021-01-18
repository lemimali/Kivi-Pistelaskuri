using System.Threading.Tasks;
using Xamarin.Forms;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Starting screen that shows little intro animation with apps logo.
    /// </summary>
    public class StartScreen : ContentPage
    {
        /// <summary>
        /// App's logo.
        /// </summary>
        private Image _startImage;

        /// <summary>
        /// Image that is being used to make a flash effect in the animation.
        /// </summary>
        private Image _flashImage;


        /// <summary>
        /// Constructor of the screen before animation happens.
        /// </summary>
        public StartScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            var layout = new AbsoluteLayout();
            _startImage = new Image
            {
                Source = "kiviapp_icon.png",
                WidthRequest = DisplayCalculator.DisplayWidth / 1.5,
                HeightRequest = DisplayCalculator.DisplayWidth / 1.5,
                Opacity = 0,
                Scale = 0.05
            };
            _flashImage = new Image
            {
                Source = "flash.png",
                WidthRequest = DisplayCalculator.DisplayWidth / 4,
                HeightRequest = DisplayCalculator.DisplayWidth / 4,
                Opacity = 0,
                Scale = 0.1
            };

            AbsoluteLayout.SetLayoutFlags(_startImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutFlags(_flashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(_startImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutBounds(_flashImage, new Rectangle(0.65, 0.35, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            layout.Children.Add(_startImage);
            layout.Children.Add(_flashImage);
            BackgroundColor = (Color)Application.Current.Resources["BackgroundColor"];
            Content = layout;
        }


        /// <summary>
        /// Overriden OnAppearing() -method that includes the animation and
        /// transition to the app's main page.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.WhenAll(
                _startImage.ScaleTo(0.8, 1000, Easing.Linear),
                _startImage.FadeTo(1, 500),
                _startImage.RotateTo(1080, 1000, Easing.SinOut)
                );

            await Task.WhenAll(
                _startImage.ScaleTo(0.9, 1000, Easing.Linear),
                _flashImage.FadeTo(1, 1000, Easing.Linear),
                _flashImage.ScaleTo(1.5, 1000, Easing.Linear),
                _flashImage.RotateTo(90, 1000, Easing.Linear)
                );

            await Task.WhenAll(
                _startImage.ScaleTo(1, 1500, Easing.Linear),
                _startImage.FadeTo(0, 1500),
                _flashImage.FadeTo(0, 800, Easing.Linear),
                _flashImage.ScaleTo(0, 800, Easing.Linear),
                _flashImage.RotateTo(180, 1000, Easing.Linear)
                );

            Application.Current.MainPage = new MainPage();
        }
    }
}
