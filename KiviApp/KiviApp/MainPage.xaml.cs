using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Application's main page that has the gameboard grid and object.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Gameboard object that handles most of the app's operations.
        /// </summary>
        private static GameBoard _gameBoard;

        /// <summary>
        /// Gameboard's visual grid.
        /// </summary>
        private static Grid _gameBoardGrid;

        /// <summary>
        /// Booolean value that tells if alternative icons are being used.
        /// </summary>
        public static bool AlternativeIcons { get; set; }


        /// <summary>
        /// Constructor of MainPage.
        /// Handles launching of some of the starting methods.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            _gameBoardGrid = GameBoardGrid;

            if (!App.AppResumed && !App.SkipStartingAnimations) HideObjects();
            SetScreenMetrics();
        }


        /// <summary>
        /// Overriden method to add animations and create gameboard.
        /// </summary>
        protected override async void OnAppearing()
        {
            _gameBoard = await Task.Run(() => GameBoard.CreateAsync(AlternativeIcons));
            base.OnAppearing();

            // Showing animations unless user has chosen to skip starting animations
            // from the app's settings or app is resuming.
            if (!App.AppResumed && !App.SkipStartingAnimations)
            {
                await Task.WhenAll(
                    _gameBoardGrid.FadeTo(1, 1000, Easing.Linear),
                    _gameBoardGrid.RotateTo(360, 1500, Easing.CubicOut),
                    _gameBoardGrid.ScaleTo(1.1, 1500, Easing.Linear)
                    );
                await Task.WhenAny(
                    _gameBoardGrid.ScaleTo(1, 2000, Easing.Linear),
                    AppTitle.FadeTo(1, 1500),
                    AppTitle.ScaleTo(1, 1500, Easing.SinInOut)
                    );
                await Task.WhenAll(
                    SettingsIcon.FadeTo(1, 1000),
                    SettingsIcon.ScaleTo(1, 1500, Easing.SpringOut),
                    SettingsIcon.RotateTo(720, 2000, Easing.SinOut),
                    CalculateButton.FadeTo(1, 1000),
                    CalculateButton.ScaleTo(1, 1500, Easing.SpringOut)
                    );

                // Rotating icon back to 0, so that further animations work as intended.
                SettingsIcon.Rotation = 0;
            }
        }


        /// <summary>
        /// Method that hides objects from the view so that animation can show them.
        /// </summary>
        private void HideObjects()
        {
            _gameBoardGrid.Opacity = 0;
            _gameBoardGrid.Scale = 0.25;
            AppTitle.Opacity = 0;
            AppTitle.Scale = 0.75;
            SettingsIcon.Opacity = 0;
            SettingsIcon.Scale = 0.5;
            CalculateButton.Opacity = 0;
            CalculateButton.Scale = 0.5;
        }


        /// <summary>
        /// Changes all the "kivi" icons to alternative icons or back to normal icons.
        /// Icons are changed on the gameboard and score window.
        /// </summary>
        internal static void ChangeIcons()
        {
            if (AlternativeIcons) AlternativeIcons = false;
            else AlternativeIcons = true;

            // Changes icons that are used in Score window.
            _gameBoard.ChangePlayerIcons(AlternativeIcons);

            // Changes icons on the gameboard object and grid.
            Device.BeginInvokeOnMainThread(() =>
            {
                var children = _gameBoardGrid.Children;
                foreach (GameBoardSquare child in children)
                {
                    var button = (ImageButtonWithName)child.Children[0];
                    var newIcon = _gameBoard.ChangeIcon(button.ImageName, AlternativeIcons);
                    if (newIcon != "")
                    {
                        button.Source = newIcon;
                    }
                }
            });
        }


        /// <summary>
        /// Handles clearing of the gameboard.
        /// Gameboard is cleared visually and points from players are removed.
        /// </summary>
        /// <returns></returns>
        internal async static Task ClearGameBoard()
        {
            await _gameBoard.ClearAsync();

            var children = _gameBoardGrid.Children;
            foreach (GameBoardSquare child in children)
            {
                var button = (ImageButtonWithName)child.Children[0];
                button.Source = null;
            }
        }


        /// <summary>
        /// Method that handles when user taps a square on the gameboard.
        /// Square is first operated in GameBoard class. After that visual
        /// presentation is updated for the user to see.
        /// </summary>
        /// <param name="button">ImageButtonWithName that presents the icon on gameboard.</param>
        internal static void SquareClicked(ImageButtonWithName button)
        {
            // Operating square in gameboard class.
            var newIcon = _gameBoard.OperateSquare(button.ImageName, AlternativeIcons);

            // Changing the appearance of the icon accordingly.
            if (newIcon == "")
            {
                button.Source = null;
                var square = (GameBoardSquare)button.Parent;
                square.IsEmpty = true;
            }
            else button.Source = newIcon;
        }


        /// <summary>
        /// Method that is launched when icon on gameboard is tapped.
        /// Notice that this method is not activated, when user taps an empty square!
        /// </summary>
        /// <param name="sender">ImageButtonWithName object (icon on gameboard) that is being pressed.</param>
        /// <param name="args">Event args, not used.</param>
        public void ButtonClick(object sender, EventArgs args)
        {
            ImageButtonWithName button = (ImageButtonWithName)sender;
            SquareClicked(button);
        }


        /// <summary>
        /// Calculates players' scores when button (sender) is pressed.
        /// Calculating happens in GameBoard class. Points are then shown
        /// in a score window.
        /// </summary>
        /// <param name="sender">Button that is pressed to activate this method.</param>
        /// <param name="args">Event args, not used.</param>
        public void CalculateScores(object sender, EventArgs args)
        {
            var players = _gameBoard.CalculateScores();
            if (_gameBoard.IsEmpty(players))
            {
                // None of the players have scored OR user didn't give
                // any values to gameboard. Alert is shown to inform user.
                DependencyService.Get<IMessage>().ShowAlert(AppResources.GameboardEmpty);
            }
            else
            {
                // If even one player has scored we show score window that
                // presents scores.
                KiviPopupWindow window = new KiviPopupWindow(players);
                PopupNavigation.Instance.PushAsync(window);
            }
        }


        /// <summary>
        /// Method that opens a popup window that explains how points are calculated
        /// in KIVI boardgame.
        /// </summary>
        public async void ShowInformation()
        {
            KiviPopupWindow window = new KiviPopupWindow();
            await PopupNavigation.Instance.PushAsync(window);
        }


        /// <summary>
        /// Method that opens app settings window.
        /// </summary>
        /// <param name="sender">Button, when clicked launced this metdod.</param>
        /// <param name="args">Event args, not used.</param>
        public async void OpenSettings(object sender, EventArgs args)
        {
            AnimateSettingsIconAsync();
            Settings settings = new Settings();
            await PopupNavigation.Instance.PushAsync(settings);
        }


        /// <summary>
        /// Animating settings icon, when icon is pressed.
        /// </summary>
        /// <returns></returns>
        public async void AnimateSettingsIconAsync()
        {
            await Task.WhenAll(
                    SettingsIcon.ScaleTo(1.2, 500, Easing.Linear),
                    SettingsIcon.RotateTo(180, 500, Easing.SinOut)
                    );
            await Task.WhenAll(
                    SettingsIcon.ScaleTo(1.0, 500, Easing.Linear),
                    SettingsIcon.RotateTo(0, 500, Easing.SinOut)
                    );
        }


        /// <summary>
        /// Method that is executed when app starts.
        /// Scales all objects on the screen using DisplayCalculator.
        /// </summary>
        private void SetScreenMetrics()
        {
            // Setting gameboard's height to be the same as device's width.
            MainGrid.RowDefinitions[1].Height = DisplayCalculator.DisplayWidth;

            // Using DisplayCalculator to calculate next values.
            // Resources are found from MainPage.xaml.
            AppTitle.FontSize = DisplayCalculator.CalculateByWidth((double)Resources["AppTitleX"]);
            CalculateButton.FontSize = DisplayCalculator.CalculateByWidth((double)Resources["ButtonFontSizeX"]);
            CalculateButton.Margin = new Thickness(DisplayCalculator.CalculateByWidth((double)Resources["ButtonMarginX"]), 10);
            CalculateButton.HeightRequest = DisplayCalculator.CalculateByHeight((double)Resources["ButtonHeightRequestX"]);
            CalculateButton.CornerRadius = (int)Math.Ceiling(CalculateButton.HeightRequest);
            SettingsIcon.HeightRequest = DisplayCalculator.CalculateByWidth((double)Resources["SettingsIconX"]);
        }
    }
}
