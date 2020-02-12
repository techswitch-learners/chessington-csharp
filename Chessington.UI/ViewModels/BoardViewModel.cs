using System.Collections.ObjectModel;
using System.Linq;
using Chessington.GameEngine;
using Chessington.GameEngine.Pieces;
using Chessington.UI.Caliburn.Micro;
using Chessington.UI.Notifications;

namespace Chessington.UI.ViewModels
{
    public class BoardViewModel : IHandle<PieceSelected>, IHandle<SquareSelected>, IHandle<SelectionCleared>
    {
        private Piece currentPiece;

        public BoardViewModel()
        {
            Board = new Board();
            Board.PieceCaptured += BoardOnPieceCaptured;
            Board.CurrentPlayerChanged += BoardOnCurrentPlayerChanged;
            ChessingtonServices.EventAggregator.Subscribe(this);
        }
        
        public Board Board { get; private set; }

        public void PiecesMoved()
        {
            ChessingtonServices.EventAggregator.Publish(new PiecesMoved(Board));
        }

        public void Handle(PieceSelected message)
        {
            currentPiece = Board.GetPiece(message.Square);
            if (currentPiece == null) return;

            var moves = new ReadOnlyCollection<Square>(currentPiece.GetAvailableMoves(Board).ToList());
            ChessingtonServices.EventAggregator.Publish(new ValidMovesUpdated(moves));
        }

        public void Handle(SelectionCleared message)
        {
            currentPiece = null;
        }

        public void Handle(SquareSelected message)
        {
            var piece = Board.GetPiece(message.Square);
            if (piece != null && piece.Player == Board.CurrentPlayer)
            {
                ChessingtonServices.EventAggregator.Publish(new PieceSelected(message.Square));
                return;
            }

            if (currentPiece == null)
                return;

            var moves = currentPiece.GetAvailableMoves(Board);

            if (moves.Contains(message.Square))
            {
                currentPiece.MoveTo(Board, message.Square);
                
                ChessingtonServices.EventAggregator.Publish(new PiecesMoved(Board));
                ChessingtonServices.EventAggregator.Publish(new SelectionCleared());
            }
        }

        private static void BoardOnPieceCaptured(Piece piece)
        {
            ChessingtonServices.EventAggregator.Publish(new PieceTaken(piece));
        }

        private static void BoardOnCurrentPlayerChanged(Player player)
        {
            ChessingtonServices.EventAggregator.Publish(new CurrentPlayerChanged(player));
        }
    }
}