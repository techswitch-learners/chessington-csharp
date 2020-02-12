using Chessington.GameEngine.Pieces;

namespace Chessington.UI.Notifications
{
    public class PieceTaken
    {
        public PieceTaken(Piece piece)
        {
            Piece = piece;
        }

        public Piece Piece { get; set; }
    }
}