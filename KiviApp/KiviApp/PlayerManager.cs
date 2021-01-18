using System.Collections.Generic;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Class that handles all the operations that involve players.
    /// </summary>
    public class PlayerManager
    {
        /// <summary>
        /// List of players that are being used in the app.
        /// </summary>
        private Player[] _players;


        /// <summary>
        /// Constructor of manager.
        /// Icons are chosen according to 'altIcons' value.
        /// </summary>
        /// <param name="altIcons">Value that tells which icons are being chosen.</param>
        public PlayerManager(bool altIcons)
        {
            if (altIcons)
            {
                _players = new Player[] { new Player(1, "p1_icon"), new Player(2, "p2_icon"),
                        new Player(3, "p3_icon"), new Player(4, "p4_icon") };
            }
            else
            {
                _players = new Player[] { new Player(1, "white_icon"), new Player(2, "lightblue_icon"),
                        new Player(3, "green_icon"), new Player(4, "darkblue_icon") };
            }
        }


        /// <summary>
        /// Changes player icons according to 'altIcons' value.
        /// </summary>
        /// <param name="altIcons">Value that tells which icons are being chosen.</param>
        internal void ChangePlayerIcons(bool altIcons)
        {
            if (altIcons)
            {
                _players[0].Icon = "p1_icon";
                _players[1].Icon = "p2_icon";
                _players[2].Icon = "p3_icon";
                _players[3].Icon = "p4_icon";
            }
            else
            {
                _players[0].Icon = "white_icon";
                _players[1].Icon = "lightblue_icon";
                _players[2].Icon = "green_icon";
                _players[3].Icon = "darkblue_icon";
            }
        }


        /// <summary>
        /// Adds points to player that has the right player number.
        /// </summary>
        /// <param name="points">How many points are being added to player's score.</param>
        /// <param name="playerNumber">Player number of the right player.</param>
        internal void AddPointsToPlayer(int points, int playerNumber)
        {
            foreach (Player p in _players)
            {
                if (p.Number == playerNumber)
                {
                    p.AddPoints(points);
                    break;
                }
            }
        }


        /// <summary>
        /// Clears all the player scores.
        /// </summary>
        public void ClearOldScores()
        {
            foreach (Player p in _players)
            {
                p.ClearScore();
            }
        }


        /// <summary>
        /// Sorts players in order where player with highest score
        /// appears first.
        /// </summary>
        /// <returns>List of sorted players.</returns>
        public List<Player> SortPlayers()
        {
            var players = new List<Player>(_players);
            players.Sort();

            return players;
        }
    }
}
