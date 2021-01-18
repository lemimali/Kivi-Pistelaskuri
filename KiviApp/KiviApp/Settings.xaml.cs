using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Popup page that shows app's settings.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : PopupPage
    {
        /// <summary>
        /// Constructor of settings popup.
        /// </summary>
		public Settings ()
		{
            // Creating main stacklayout.
            var stack = ScreenManager.CreateStackLayout(StackOrientation.Vertical,
                new Thickness(0), 10, (Color)Application.Current.Resources["PopupWindowColor"]);

            // Adding title to stacklayout.
            stack.Children.Add(ScreenManager.CreateTitle(AppResources.Settings,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["TitleFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"]));

            // Creating label and switch for the option to change gameboard icons.
            Label iconsSwitchLabel = ScreenManager.CreateLabel(AppResources.IconsChange,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"], FontAttributes.None);

            var iconsSwitch = new Switch
            {
                OnColor = (Color)Application.Current.Resources["GreenColor"],
                ThumbColor = (Color)Application.Current.Resources["ButtonBackgroundColor"],
                IsToggled = MainPage.AlternativeIcons,
                Scale = DisplayCalculator.CalculateSwitchScale((double)Application.Current.Resources["SettingsSwitchScaleX"]),
                HorizontalOptions = LayoutOptions.Center
            };
            iconsSwitch.Toggled += (sender, e) =>
            {
                MainPage.ChangeIcons();
            };

            // Creating label and switch for the option to skip application intro animations.
            Label introSwitchLabel = ScreenManager.CreateLabel(AppResources.IntroChange,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"], FontAttributes.None);

            var introSwitch = new Switch
            {
                OnColor = (Color)Application.Current.Resources["GreenColor"],
                ThumbColor = (Color)Application.Current.Resources["ButtonBackgroundColor"],
                IsToggled = App.SkipStartingAnimations,
                Scale = DisplayCalculator.CalculateSwitchScale((double)Application.Current.Resources["SettingsSwitchScaleX"]),
                HorizontalOptions = LayoutOptions.Center
            };
            introSwitch.Toggled += (sender, e) =>
            {
                App.SkipStartingAnimations = introSwitch.IsToggled;
            };

            // Creating a grid and adding earlier created labels and switches into it.
            Grid grid = new Grid();
            grid.RowSpacing = DisplayCalculator.CalculateByHeight((double)Application.Current.Resources["SettingsGridSpacingScaleX"]);
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(iconsSwitchLabel, 0, 0);
            grid.Children.Add(iconsSwitch, 1, 0);
            grid.Children.Add(introSwitchLabel, 0, 1);
            grid.Children.Add(introSwitch, 1, 1);

            stack.Children.Add(grid);

            // Creating a button that opens new popup that informs app user about score calculation.
            var infoButton = ScreenManager.CreateButton(AppResources.InfoButtonText,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]),
                new Thickness(DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["SettingsButtonWidthMarginX"]),
                    DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["SettingsButtonHeightMarginX"])));
            infoButton.Clicked += async (sender, args) => await ShowInformation();

            // Creating a button that closes this popup.
            var closeButton = ScreenManager.CreateButton(AppResources.Close,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]),
                new Thickness(DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["SettingsButtonWidthMarginX"]),
                    DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["SettingsButtonHeightMarginX"])));
            closeButton.Clicked += async (sender, args) =>
            {
                await PopupNavigation.Instance.PopAsync(true);
            };

            // Creating a button for gameboard clearing.
            var clearBoardButton = ScreenManager.CreateButton(AppResources.ClearGameBoard,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]),
                new Thickness(DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["SettingsButtonWidthMarginX"]),
                    DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["SettingsButtonHeightMarginX"])));
            clearBoardButton.Clicked += async (sender, args) =>
            {
                await MainPage.ClearGameBoard();
                await PopupNavigation.Instance.PopAsync(true);
            };

            // Adding buttons to stacklayout.
            stack.Children.Add(infoButton);
            stack.Children.Add(clearBoardButton);
            stack.Children.Add(closeButton);

            // Creates a frame with rounded corners and adds stacklayout into it.
            Content = ScreenManager.CreateFrame(stack, 50, new Thickness(20),
                (Color)Application.Current.Resources["PopupWindowColor"]);
        }


        /// <summary>
        /// Helper method that closes this popup window and opens popup about
        /// score calculation.
        /// </summary>
        /// <returns></returns>
        public async Task ShowInformation()
        {
            await PopupNavigation.Instance.PopAsync(true);
            KiviPopupWindow window = new KiviPopupWindow();
            await PopupNavigation.Instance.PushAsync(window);
        }
    }
}