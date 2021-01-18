using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Grid that is used in application's settings where KIVI game's
    /// score calculation is explained to the user.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoGrid : ContentView
	{
		public InfoGrid(double fontSize, double imageHeight)
		{
            InitializeComponent();

            Grid grid = MainGrid;
            grid.Children.Add(new Label { Text = AppResources.InstructionsPart3, FontSize = fontSize }, 0, 0);
            grid.Children.Add(new Image { Source = "example_purple.png", HeightRequest = imageHeight }, 1, 0);
            grid.Children.Add(new Label { Text = AppResources.InstructionsPart4, FontSize = fontSize }, 0, 1);
            grid.Children.Add(new Image { Source = "example_grey.png", HeightRequest = imageHeight }, 1, 1);
            grid.Children.Add(new Label { Text = AppResources.InstructionsPart5, FontSize = fontSize }, 0, 2);
            grid.Children.Add(new Image { Source = "example_orange.png", HeightRequest = imageHeight }, 1, 2);
            grid.Children.Add(new Label { Text = AppResources.InstructionsPart6, FontSize = fontSize }, 0, 3);
            grid.Children.Add(new Image { Source = "example_red.png", HeightRequest = imageHeight }, 1, 3);
            grid.Children.Add(new Label { Text = AppResources.InstructionsPart7, FontSize = fontSize }, 0, 4);
            grid.Children.Add(new Image { Source = "example_blue.png", HeightRequest = imageHeight }, 1, 4);
        }
	}
}