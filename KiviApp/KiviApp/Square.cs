/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// One square from the gameboard.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Square's point value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Name of the square that is used link square between visual
        /// gameboard and data.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tells which player's stone icon is on the square.
        /// Player numbers 1-4. Number 0 represents an empty square.
        /// </summary>
        public int PlayerNumber { get; set; }

        /// <summary>
        /// Tells if square is already calculated horizontally.
        /// This value is used in point calculation phase to make sure squares
        /// are not calculated multiple times.
        /// </summary>
        public bool IsCalculatedHorizontally { get; set; } = false;

        /// <summary>
        /// Tells if square is already calculated vertically.
        /// This value is used in point calculation phase to make sure squares
        /// are not calculated multiple times.
        /// </summary>
        public bool IsCalculatedVertically { get; set; } = false;

        /// <summary>
        /// Tells if a square is individual. Individual means that this square
        /// is not part of stone icon line. For example square has a white stone
        /// icon on it and squares next to it horizontally and vertically either dont
        /// have stones or have stones that are different in color.
        /// At start all squares are individual, because they don't have any icons 
        /// on them.
        /// </summary>
        public bool IsIndividual { get; set; } = true;

        /// <summary>
        /// Presents the square that is located right this square.
        /// </summary>
        public Square SquareOnRight { get; }

        /// <summary>
        /// Presents the square that is located below this square.
        /// </summary>
        public Square SquareBelow { get; }


        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="value">Numberic value that the square presents from 1 to 3.</param>
        /// <param name="right">Square right from this square.</param>
        /// <param name="down">Square below this square.</param>
        /// <param name="name">Name of the square.</param>
        public Square(int value, Square right, Square down, string name)
        {
            Value = value;
            SquareOnRight = right;
            SquareBelow = down;
            Name = name;
            PlayerNumber = 0;
        }


        /// <summary>
        /// Resets square's current playernumber back to zero.
        /// </summary>
        public void ResetPlayerNumber()
        {
            PlayerNumber = 0;
        }


        /// <summary>
        /// Changes squares playernumber from 0 to 4.
        /// </summary>
        public void ChangePlayerNumber()
        {
            if (PlayerNumber == 4) PlayerNumber = 0;
            else PlayerNumber++;
        }


        /// <summary>
        /// Checks if two squares have the same playernumber
        /// attached to them.
        /// </summary>
        /// <param name="square">The other square to be compared.</param>
        /// <returns></returns>
        public bool SamePlayerNumber(Square square)
        {
            if (square == null) return false;
            return PlayerNumber == square.PlayerNumber;
        }
    }
}