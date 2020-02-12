using Chessington.GameEngine;

namespace Chessington.UI.Notifications
{
    public class SquareSelected
    {
        public SquareSelected(Square square)
        {
            Square = square;
        }

        public Square Square { get; set; }
    }
}