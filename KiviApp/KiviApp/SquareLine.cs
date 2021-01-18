using System.Collections.Generic;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Line of multiple squares that have the same stone icon / playernumber on them.
    /// </summary>
    public class SquareLine
    {
        /// <summary>
        /// Squares that are part of this line.
        /// </summary>
        private List<Square> _squares = new List<Square>();


        /// <summary>
        /// Adds a square to a line.
        /// </summary>
        /// <param name="square">Square to be added.</param>
        public void Add(Square square)
        {
            _squares.Add(square);
        }


        /// <summary>
        /// Gives the playernumber of this line.
        /// </summary>
        /// <returns></returns>
        public int PlayerNumber()
        {
            if (_squares.Count == 0) return 0;
            return _squares[0].PlayerNumber;
        }


        /// <summary>
        /// Calculates the points from this line.
        /// Points are calculated by first adding all square values and
        /// then multiplying with the count of squares.
        /// </summary>
        /// <returns></returns>
        public int Calculate()
        {
            var result = 0;
            foreach (Square s in _squares)
            {
                result += s.Value;
            }
            return result * _squares.Count;
        }
    }
}
