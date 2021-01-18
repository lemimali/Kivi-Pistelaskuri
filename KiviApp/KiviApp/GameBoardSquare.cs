using Xamarin.Forms;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Class that used to create gameboard in MainPage XAML.
    /// </summary>
    public class GameBoardSquare : StackLayout
    {
        /// <summary>
        /// Tells if square has an icon on it.
        /// </summary>
        public bool IsEmpty { get; set; } = true;


        /// <summary>
        /// Constructor that adds a gesture recognizer.
        /// </summary>
        public GameBoardSquare() : base()
        {
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;

            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnSquareClicked()),
            });
        }


        /// <summary>
        /// Detects when an empty square is clicked and passes
        /// job to MainPage's SquareClicked method.
        /// </summary>
        private void OnSquareClicked()
        {
            if (IsEmpty)
            {
                var child = (ImageButtonWithName)Children[0];
                MainPage.SquareClicked(child);
                IsEmpty = false;
            }
        }
    }
}
