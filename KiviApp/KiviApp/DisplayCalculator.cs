using System;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Calculates numeric values for objects on screen to make
    /// them fit on device's screen.
    /// </summary>
    public class DisplayCalculator
    {
        /// <summary>
        /// Device's display width that is calculated when app starts.
        /// </summary>
        public static double DisplayWidth { get; set; }

        /// <summary>
        /// Device's display height that is calculated when app starts.
        /// </summary>
        public static double DisplayHeight { get; set; }


        /// <summary>
        /// Calculates a value using device display's width and
        /// a given percent value.
        /// </summary>
        /// <param name="value">A percent value that is given.</param>
        /// <returns>Int value representing what given percent value is on device screen.</returns>
        public static int CalculateByWidth(double value)
        {
            return (int) Math.Ceiling((value * DisplayWidth));
        }


        /// <summary>
        /// Calculates a value using device display's height and
        /// a given percent value.
        /// </summary>
        /// <param name="value">A percent value that is given.</param>
        /// <returns>Int value representing what given percent value is on device screen.</returns>
        public static int CalculateByHeight(double value)
        {
            return (int)Math.Ceiling((value * DisplayHeight));
        }


        /// <summary>
        /// Calculates a value for switch scaling.
        /// Calculating is done a bit differently compared to upper methods,
        /// because the scaling number is more precise.
        /// </summary>
        /// <param name="value">A percent value that is given.</param>
        /// <returns>Double value representing value for switch scale.</returns>
        public static double CalculateSwitchScale(double value)
        {
            return Math.Round(value * DisplayWidth, 3, MidpointRounding.AwayFromZero);
        }
    }
}
