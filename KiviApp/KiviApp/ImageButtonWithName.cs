using Xamarin.Forms;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Custom ImageButton class that also includes 
    /// </summary>
    public class ImageButtonWithName : ImageButton
    {
        /// <summary>
        /// Coefficient value that is used to calculate button size on different sized devices.
        /// </summary>
        private readonly static double _buttonCoefficient = 0.12;

        /// <summary>
        /// Button size calculated by DisplayCalculator class.
        /// </summary>
        private readonly static int _buttonSize = DisplayCalculator.CalculateByWidth(_buttonCoefficient);

        /// <summary>
        /// ImageButton name.
        /// </summary>
        public string ImageName { get; set; }


        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public ImageButtonWithName() : base()
        {
            Aspect = Aspect.Fill;
            BackgroundColor = Color.Transparent;
            HeightRequest = _buttonSize;
            WidthRequest = _buttonSize;
        }
    }
}