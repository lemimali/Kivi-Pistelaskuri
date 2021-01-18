using Rg.Plugins.Popup.Pages;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Popup page that shows app's instructions for score calculation
    /// and players scores after calculation is done.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KiviPopupWindow : PopupPage
    {
        /// <summary>
        /// Creates a popup that shows information about score calculation.
        /// </summary>
        public KiviPopupWindow()
        {
            // Creating main stacklayout.
            var mainStack = ScreenManager.CreateStackLayout(StackOrientation.Vertical,
                new Thickness(0), 10, (Color)Application.Current.Resources["PopupWindowColor"]);

            // Adding title for the popup.
            mainStack.Children.Add(ScreenManager.CreateTitle(AppResources.InfoTitle,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["TitleFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"]));

            // Creating a stacklayout that will later be put into a scrollview.
            var scrollStack = ScreenManager.CreateStackLayout(StackOrientation.Vertical,
                new Thickness(0), 10, (Color)Application.Current.Resources["LightBackground"]);
            scrollStack.Padding = new Thickness(DisplayCalculator.CalculateByWidth(
                (double)Application.Current.Resources["KiviStackPaddingX"]));

            // Adding instructions part 1 to the layout.
            scrollStack.Children.Add(ScreenManager.CreateLabel(AppResources.InstructionsPart1,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"], FontAttributes.None));

            // Adding an example title to the layout.
            scrollStack.Children.Add(ScreenManager.CreateLabel(AppResources.ExampleTitle,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"], FontAttributes.Bold));

            // Adding instructions part 2 to the layout.
            scrollStack.Children.Add(ScreenManager.CreateLabel(AppResources.InstructionsPart2,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"], FontAttributes.None));

            // Adding an info grid that has information about calculation. Has instruction parts 3-7 in it.
            scrollStack.Children.Add(new InfoGrid(DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                                         DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["InfoIconX"])));

            // Adding instructions part 8 to the layout.
            scrollStack.Children.Add(ScreenManager.CreateLabel(AppResources.InstructionsPart8,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["NormalFontX"]),
                (Color)Application.Current.Resources["PopupTextColor"], FontAttributes.None));

            // Adding an example image of a gameboard.
            scrollStack.Children.Add(new Image { Source = "example_gameboard.png",
                HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 0) });

            // Creating scrollview and adding stack in it.
            ScrollView scrollview = new ScrollView
            {
                Content = scrollStack
            };

            // Adding scroll view to the main stack.
            mainStack.Children.Add(scrollview);

            // Creating a close button.
            mainStack.Children.Add(ScreenManager.CreateButton(AppResources.Close,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]),
                new Thickness(DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]),
                    DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]))));

            // Creating a frame and adding main stack into it.
            Content = ScreenManager.CreateFrame(mainStack, 50, new Thickness(20),
                (Color)Application.Current.Resources["PopupWindowColor"]);
        }


        /// <summary>
        /// Creates a popup that shows players scores after calculation is done.
        /// </summary>
        /// <param name="players">List of players with scores that are shown.</param>
        public KiviPopupWindow(List<Player> players)
        {
            // Creating main stack layout.
            var mainStack = ScreenManager.CreateStackLayout(StackOrientation.Vertical, new Thickness(20, 0),
                10, (Color)Application.Current.Resources["PopupWindowColor"]);

            // Adding player icons and scores to the stack.
            AddPlayerScores(players, mainStack);

            // Creating an Ok button that closes the popup.
            var button = ScreenManager.CreateButton(AppResources.Ok,
                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["BoldFontX"]),
                new Thickness(DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["KiviButtonMarginX"]),
                                DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["KiviButtonTopMarginX"])));

            // Changing button to be smaller horizontally and adding it to main stack.
            button.WidthRequest = DisplayCalculator.DisplayWidth / 3;
            mainStack.Children.Add(button);

            // Creating a frame and adding main stack into it.
            Content = ScreenManager.CreateFrame(mainStack, 50, new Thickness(20),
                (Color)Application.Current.Resources["PopupWindowColor"]);
        }


        /// <summary>
        /// Method that adds player icons and scores to a stacklayout.
        /// </summary>
        /// <param name="players">Players that are added to the layout.</param>
        /// <param name="mainStack">Stacklayout where stuff is added.</param>
        private void AddPlayerScores(List<Player> players, StackLayout mainStack)
        {
            foreach (Player p in players)
            {
                // Players have been sorted so that player with the highest score appears first.
                // If a player's score is 0, then we know that that player and players after
                // haven't scored (are not part of the game).
                if (p.Score == 0) break;

                var stack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HeightRequest = DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["KiviPlayerIconSizeX"]),
                    Children =
                    {
                        new Image { Source = p.Icon },
                        new Label { Text = "= " + p.Score, VerticalOptions = LayoutOptions.Center,
                            FontFamily = "Lobster_1.3.otf#Lobster_1.3",
                            FontSize = DisplayCalculator.CalculateByWidth((double)Application.Current.Resources["TitleFontX"]),
                            FontAttributes = FontAttributes.Bold,
                            TextColor = (Color) Application.Current.Resources["PopupTextColor"] }
                    },
                    HorizontalOptions = LayoutOptions.Center
                };
                mainStack.Children.Add(stack);
            }
        }
    }
}