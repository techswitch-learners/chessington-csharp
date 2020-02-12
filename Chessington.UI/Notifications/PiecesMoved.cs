using Chessington.GameEngine;

namespace Chessington.UI.Notifications
{
    public class PiecesMoved
    {
        public PiecesMoved(Board board)
        {
            Board = board;
        }

        public Board Board { get; set; }
    }
}