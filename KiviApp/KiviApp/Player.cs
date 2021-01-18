using System;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Player of the game.
    /// </summary>
    public class Player : IComparable<Player>
    {
        /// <summary>
        /// Player's player number.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Player's icon that is shown on the gameboard.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Player's total amount of points after calculating is done.
        /// </summary>
        public int Score { get; set; }


        /// <summary>
        /// Constructor of player object.
        /// </summary>
        /// <param name="number">Player's player number.</param>
        /// <param name="icon">Player's icon that is shown on the gameboard.</param>
        public Player(int number, string icon)
        {
            Number = number;
            Icon = icon;
            Score = 0;
        }


        /// <summary>
        /// Adds points to player's score.
        /// </summary>
        /// <param name="points">Points that are added to score.</param>
        internal void AddPoints(int points)
        {
            Score += points;
        }


        /// <summary>
        /// Cleares player's current score.
        /// </summary>
        internal void ClearScore()
        {
            Score = 0;
        }


        /// <summary>
        /// Compares itself to another player object.
        /// Comparing is done by checking which player has bigger
        /// score.
        /// </summary>
        /// <param name="other">Other player that is being compared against.</param>
        /// <returns>1 if other player's score is higher, -1 if this player's score is higher,
        /// 0 if both scores are equal.</returns>
        public int CompareTo(Player other)
        {
            if (Score == other.Score) return 0;
            if (Score < other.Score) return 1;
            return -1;
        }
    }
}
