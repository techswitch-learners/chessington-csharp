using Chessington.GameEngine;

namespace Chessington.UI.Notifications
{
    public class PieceSelected
    {
        public PieceSelected(Square square)
        {
            Square = square;
        }

        public Square Square { get; set; }
    }
}