using System.Collections.Generic;
using System.Threading.Tasks;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Application's root object that handles squares and player scores.
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// List of all gameboard squares.
        /// </summary>
        private List<Square> _squares = new List<Square>();

        /// <summary>
        /// List of icon names that are used in the application.
        /// </summary>
        private List<string[]> _icons = new List<string[]>();

        /// <summary>
        /// Player scores that are used when points are calculated/modified.
        /// </summary>
        private static PlayerManager _playerManager;

        /// <summary>
        /// List of square lines. Used when scores are calculated.
        /// </summary>
        private List<SquareLine> _squareLines = new List<SquareLine>();

        /// <summary>
        /// Basic constructor used in CreateAsync method.
        /// </summary>
        public GameBoard() { }


        /// <summary>
        /// Async method to construct gameboard.
        /// </summary>
        /// <param name="altIcons">Value that determines if alternative icons are used when the app launches.</param>
        /// <returns>Task with a gameboard object.</returns>
        public static async Task<GameBoard> CreateAsync(bool altIcons)
        {
            var gameboard = new GameBoard();
            _playerManager = new PlayerManager(altIcons);

            List<Task> tasks = new List<Task>
            {
                Task.Run(() => gameboard.CreateSquares()),
                Task.Run(() => gameboard.CreateIcons())
            };

            await Task.WhenAll(tasks);
            return gameboard;
        }


        /// <summary>
        /// Method that creates all the squares when app launches.
        /// </summary>
        private void CreateSquares()
        {
            #region "Creating all the squares"
            Square v7h7 = new Square(1, null, null, "v7h7");
            Square v7h6 = new Square(2, v7h7, null, "v7h6");
            Square v7h5 = new Square(2, v7h6, null, "v7h5");
            Square v7h4 = new Square(1, v7h5, null, "v7h4");
            Square v7h3 = new Square(2, v7h4, null, "v7h3");
            Square v7h2 = new Square(2, v7h3, null, "v7h2");
            Square v7h1 = new Square(1, v7h2, null, "v7h1");
            _squares.Add(v7h7); _squares.Add(v7h6); _squares.Add(v7h5); _squares.Add(v7h4);
            _squares.Add(v7h3); _squares.Add(v7h2); _squares.Add(v7h1);

            Square v6h7 = new Square(2, null, v7h7, "v6h7");
            Square v6h6 = new Square(3, v6h7, v7h6, "v6h6");
            Square v6h5 = new Square(1, v6h6, v7h5, "v6h5");
            Square v6h4 = new Square(3, v6h5, v7h4, "v6h4");
            Square v6h3 = new Square(1, v6h4, v7h3, "v6h3");
            Square v6h2 = new Square(3, v6h3, v7h2, "v6h2");
            Square v6h1 = new Square(2, v6h2, v7h1, "v6h1");
            _squares.Add(v6h7); _squares.Add(v6h6); _squares.Add(v6h5); _squares.Add(v6h4);
            _squares.Add(v6h3); _squares.Add(v6h2); _squares.Add(v6h1);

            Square v5h7 = new Square(1, null, v6h7, "v5h7");
            Square v5h6 = new Square(2, v5h7, v6h6, "v5h6");
            Square v5h5 = new Square(2, v5h6, v6h5, "v5h5");
            Square v5h4 = new Square(2, v5h5, v6h4, "v5h4");
            Square v5h3 = new Square(3, v5h4, v6h3, "v5h3");
            Square v5h2 = new Square(2, v5h3, v6h2, "v5h2");
            Square v5h1 = new Square(1, v5h2, v6h1, "v5h1");
            _squares.Add(v5h7); _squares.Add(v5h6); _squares.Add(v5h5); _squares.Add(v5h4);
            _squares.Add(v5h3); _squares.Add(v5h2); _squares.Add(v5h1);

            Square v4h7 = new Square(2, null, v5h7, "v4h7");
            Square v4h6 = new Square(1, v4h7, v5h6, "v4h6");
            Square v4h5 = new Square(2, v4h6, v5h5, "v4h5");
            Square v4h4 = new Square(3, v4h5, v5h4, "v4h4");
            Square v4h3 = new Square(2, v4h4, v5h3, "v4h3");
            Square v4h2 = new Square(1, v4h3, v5h2, "v4h2");
            Square v4h1 = new Square(2, v4h2, v5h1, "v4h1");
            _squares.Add(v4h7); _squares.Add(v4h6); _squares.Add(v4h5); _squares.Add(v4h4);
            _squares.Add(v4h3); _squares.Add(v4h2); _squares.Add(v4h1);

            Square v3h7 = new Square(1, null, v4h7, "v3h7");
            Square v3h6 = new Square(2, v3h7, v4h6, "v3h6");
            Square v3h5 = new Square(3, v3h6, v4h5, "v3h5");
            Square v3h4 = new Square(2, v3h5, v4h4, "v3h4");
            Square v3h3 = new Square(2, v3h4, v4h3, "v3h3");
            Square v3h2 = new Square(2, v3h3, v4h2, "v3h2");
            Square v3h1 = new Square(1, v3h2, v4h1, "v3h1");
            _squares.Add(v3h7); _squares.Add(v3h6); _squares.Add(v3h5); _squares.Add(v3h4);
            _squares.Add(v3h3); _squares.Add(v3h2); _squares.Add(v3h1);

            Square v2h7 = new Square(2, null, v3h7, "v2h7");
            Square v2h6 = new Square(3, v2h7, v3h6, "v2h6");
            Square v2h5 = new Square(1, v2h6, v3h5, "v2h5");
            Square v2h4 = new Square(3, v2h5, v3h4, "v2h4");
            Square v2h3 = new Square(1, v2h4, v3h3, "v2h3");
            Square v2h2 = new Square(3, v2h3, v3h2, "v2h2");
            Square v2h1 = new Square(2, v2h2, v3h1, "v2h1");
            _squares.Add(v2h7); _squares.Add(v2h6); _squares.Add(v2h5); _squares.Add(v2h4);
            _squares.Add(v2h3); _squares.Add(v2h2); _squares.Add(v2h1);

            Square v1h7 = new Square(1, null, v2h7, "v1h7");
            Square v1h6 = new Square(2, v1h7, v2h6, "v1h6");
            Square v1h5 = new Square(2, v1h6, v2h5, "v1h5");
            Square v1h4 = new Square(1, v1h5, v2h4, "v1h4");
            Square v1h3 = new Square(2, v1h4, v2h3, "v1h3");
            Square v1h2 = new Square(2, v1h3, v2h2, "v1h2");
            Square v1h1 = new Square(1, v1h2, v2h1, "v1h1");
            _squares.Add(v1h7); _squares.Add(v1h6); _squares.Add(v1h5); _squares.Add(v1h4);
            _squares.Add(v1h3); _squares.Add(v1h2); _squares.Add(v1h1);
            #endregion

            // Reversing is done to make square ordering rigth.
            _squares.Reverse();
        }


        /// <summary>
        /// Method that tells playerScores to change icons.
        /// </summary>
        /// <param name="altIcons">Value that determines which icontype is going to be chosen.</param>
        internal void ChangePlayerIcons(bool altIcons)
        {
            _playerManager.ChangePlayerIcons(altIcons);
        }


        /// <summary>
        /// Creating icon names.
        /// </summary>
        public void CreateIcons()
        {
            string[] normalIcons = new string[] { "", "white_icon", "lightblue_icon", "green_icon", "darkblue_icon" };
            string[] alternativeIcons = new string[] { "", "p1_icon", "p2_icon", "p3_icon", "p4_icon" };
            _icons.Add(normalIcons);
            _icons.Add(alternativeIcons);
        }


        /// <summary>
        /// Changes square's icon depending on alternativeIcon boolean.
        /// Icons are either regular or alternative.
        /// </summary>
        /// <param name="squareName">Square that is being changed.</param>
        /// <param name="alternativeIcon">Tells which icon is going to be chosen. True => alternative, false => regular.</param>
        /// <returns>String that presents the icon.</returns>
        internal string ChangeIcon(string squareName, bool alternativeIcon)
        {
            Square square = FindSquare(squareName);
            return GiveNewSquareIcon(square, alternativeIcon);
        }


        /// <summary>
        /// Operates square when user touches it.
        /// Method first changes squares player number. After that it returns
        /// the new icon for the square.
        /// </summary>
        /// <param name="squareName">Square that is being operated.</param>
        /// <param name="alternativeIcon">Tells which version of icon is used. False => regular, true => alternative.</param>
        /// <returns>String that presents the icon after operating is done.</returns>
        public string OperateSquare(string squareName, bool alternativeIcon)
        {
            Square square = FindSquare(squareName);
            square.ChangePlayerNumber();
            return GiveNewSquareIcon(square, alternativeIcon);
        }


        /// <summary>
        /// Gives the right icon depending on alternativeIcon boolean.
        /// _icons[0] presents regular icons and _icons[1] alternative icons.
        /// </summary>
        /// <param name="square">Square that is being operated.</param>
        /// <param name="alternativeIcon">Tells which version of icon is used. False => regular, true => alternative.</param>
        /// <returns>String that presents the icon.</returns>
        public string GiveNewSquareIcon(Square square, bool alternativeIcon)
        {
            if (alternativeIcon) return _icons[1][square.PlayerNumber];
            return _icons[0][square.PlayerNumber];
        }


        /// <summary>
        /// Finds a square by name from _squares.
        /// </summary>
        /// <param name="name">Square to be found.</param>
        /// <returns></returns>
        public Square FindSquare(string name)
        {
            return _squares.Find(square => square.Name.Equals(name));
        }


        /// <summary>
        /// Calculates players' scores and returns list of players.
        /// </summary>
        /// <returns>List of players with calculated scores.</returns>
        public List<Player> CalculateScores()
        {
            // Creating new squarelines and clearing old scores.
            CreateSquareLines();
            _playerManager.ClearOldScores();

            // Calculating each squareline and adding points to player scores.
            foreach (SquareLine line in _squareLines)
            {
                var points = line.Calculate();
                var player = line.PlayerNumber();
                _playerManager.AddPointsToPlayer(points, player);
            }
            return _playerManager.SortPlayers();
        }


        /// <summary>
        /// Custom enum that is being used in methods below.
        /// </summary>
        public enum Direction
        {
            Horizontal,
            Vertical
        };


        /// <summary>
        /// Creates squarelines accordingly before calculating is done.
        /// </summary>
        public void CreateSquareLines()
        {
            // Clearing actions from previous executions. 
            _squareLines.Clear();
            ResetSquareStats();

            foreach (Square square in _squares)
            {
                // Checking if square actually has a player icon on it.
                if (square.PlayerNumber != 0)
                {
                    // Checking for three possible cases:
                    // 1) Square is not calculated horizontally AND square on it's right has the same icon.
                    if (!square.IsCalculatedHorizontally && square.SamePlayerNumber(square.SquareOnRight))
                    {
                        SquareLine line = new SquareLine();
                        line.Add(square);
                        square.IsCalculatedHorizontally = true;
                        Direction direction = Direction.Horizontal;
                        FinishSquareLine(line, square.SquareOnRight, direction);
                        _squareLines.Add(line);
                        square.IsIndividual = false;
                    }
                    // 2) Square is not calculated vertically AND square below it has the same icon.
                    if (!square.IsCalculatedVertically && square.SamePlayerNumber(square.SquareBelow))
                    {
                        SquareLine line = new SquareLine();
                        line.Add(square);
                        square.IsCalculatedVertically = true;
                        Direction direction = Direction.Vertical;
                        FinishSquareLine(line, square.SquareBelow, direction);
                        _squareLines.Add(line);
                        square.IsIndividual = false;
                    }
                    // 3) Square doesn't have same icon on it's right or below (aka it is "individual").
                    if (square.IsIndividual)
                    {
                        SquareLine line = new SquareLine();
                        line.Add(square);
                        _squareLines.Add(line);
                    }
                }
            }
        }


        /// <summary>
        /// Resets square statictics back to starting values.
        /// </summary>
        private void ResetSquareStats()
        {
            foreach (Square s in _squares)
            {
                s.IsCalculatedHorizontally = false;
                s.IsCalculatedVertically = false;
                s.IsIndividual = true;
            }
        }


        /// <summary>
        /// Finishes one line recursively by collecting all squares
        /// that are part of the line.
        /// </summary>
        /// <param name="line">Squareline that is being operated.</param>
        /// <param name="square">Square that is being added to line.</param>
        /// <param name="direction">Tells which direction line is moving.</param>
        public void FinishSquareLine(SquareLine line, Square square, Direction direction)
        {
            line.Add(square);
            square.IsIndividual = false;
            if (direction == Direction.Horizontal)
            {
                square.IsCalculatedHorizontally = true;
                if (square.SamePlayerNumber(square.SquareOnRight))
                {
                    FinishSquareLine(line, square.SquareOnRight, direction);
                }
            }
            else
            {
                square.IsCalculatedVertically = true;
                if (square.SamePlayerNumber(square.SquareBelow))
                {
                    FinishSquareLine(line, square.SquareBelow, direction);
                }
            }
        }


        /// <summary>
        /// Cleares all squares playernumbers.
        /// </summary>
        /// <returns></returns>
        internal async Task ClearAsync()
        {
            foreach (Square s in _squares)
            {
                s.ResetPlayerNumber();
            }
        }


        /// <summary>
        /// Gameboard's helper method that checks if gameboard is empty.
        /// </summary>
        /// <param name="players">List of players whose scores are being checked.</param>
        /// <returns>True if gameboard is empty, otherwise false.</returns>
        public bool IsEmpty(List<Player> players)
        {
            foreach (Player p in players)
            {
                if (p.Score != 0) return false;
            }
            return true;
        }
    }
}