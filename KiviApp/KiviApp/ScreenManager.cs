using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Helper class that handles creating content on screen.
    /// </summary>
    public class ScreenManager
    {
        /// <summary>
        /// Creates a custom button that closes a popup.
        /// </summary>
        /// <param name="message">Message that is being shown on the button.</param>
        /// <param name="fontSize">Text font size.</param>
        /// <param name="margin">Button's margin.</param>
        /// <returns>A custom button used in popups.</returns>
        public static Button CreateButton(string message, double fontSize, Thickness margin)
        {
            var button = new Button
            {
                Text = message,
                FontSize = fontSize,
                Margin = margin,
                HeightRequest = DisplayCalculator.CalculateByHeight(
                    (double)Application.Current.Resources["SettingsButtonHeightRequestX"]),
                WidthRequest = DisplayCalculator.CalculateByWidth(
                    (double)Application.Current.Resources["SettingsButtonWidthRequestX"]),
            };
            button.CornerRadius = (int)Math.Ceiling(button.HeightRequest);
            button.Clicked += async (sender, args) => await PopupNavigation.Instance.PopAsync(true);
            return button;
        }


        /// <summary>
        /// Creates a bold title label.
        /// </summary>
        /// <param name="message">Label's text.</param>
        /// <param name="fontSize">Label's font size.</param>
        /// <param name="textColor">Label's text color.</param>
        /// <returns>A title label.</returns>
        public static Label CreateTitle(string message, double fontSize, Color textColor)
        {
            return new Label
            {
                Text = message,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontFamily = "Lobster_1.3.otf#Lobster_1.3",
                FontSize = fontSize,
                FontAttributes = FontAttributes.Bold,
                TextColor = textColor
            };
        }


        /// <summary>
        /// Creates a normal label.
        /// </summary>
        /// <param name="message">Label's text.</param>
        /// <param name="fontSize">Label's font size.</param>
        /// <param name="textColor">Label's text color.</param>
        /// <returns>A normal label.</returns>
        public static Label CreateLabel(string message, double fontSize, Color textColor, FontAttributes attributes)
        {
            return new Label
            {
                Text = message,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = fontSize,
                TextColor = textColor,
                FontAttributes = attributes
            };
        }


        /// <summary>
        /// Creates a custom stacklayout.
        /// </summary>
        /// <param name="orientation">Defines stacklayout's orientation.</param>
        /// <param name="margin">Stacklayout's margin.</param>
        /// <param name="spacing">Stacklayout's spacing.</param>
        /// <param name="bgColor">Stacklayout's background color.</param>
        /// <returns>A custom stacklayout.</returns>
        public static StackLayout CreateStackLayout(StackOrientation orientation, Thickness margin, double spacing, Color bgColor)
        {
            return new StackLayout
            {
                Orientation = orientation,
                Margin = margin,
                Spacing = spacing,
                BackgroundColor = bgColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }


        /// <summary>
        /// Creates a custom frame for an existing layout.
        /// </summary>
        /// <param name="layout">Layout that is framed.</param>
        /// <param name="cornerRadius">Float value that represents frame's corner radius.</param>
        /// <param name="thickness">Thickness used in frame margin.</param>
        /// <param name="bgColor">Frame's background color.</param>
        /// <returns>A custom frame that has a layout inside it.</returns>
        public static Frame CreateFrame(Layout layout, float cornerRadius, Thickness thickness, Color bgColor)
        {
            return new Frame
            {
                CornerRadius = cornerRadius,
                Margin = thickness,
                BackgroundColor = bgColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HasShadow = true,
                IsClippedToBounds = true,
                Content = layout
            };
        }
    }
}
