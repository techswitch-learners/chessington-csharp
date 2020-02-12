using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void PawnCanBeAddedToBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(0, 0), pawn);

            board.GetPiece(Square.At(0, 0)).Should().BeSameAs(pawn);
        }

        [Test]
        public void PawnCanBeFoundOnBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            var square = Square.At(6, 4);
            board.AddPiece(square, pawn);

            var location = board.FindPiece(pawn);

            location.Should().Be(square);
        }
    }
}
