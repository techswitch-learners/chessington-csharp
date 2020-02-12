﻿using System.Linq;
 using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class PawnTests
    {
        [Test]
        public void WhitePawns_CanMoveOneSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 0));
        }

        [Test]
        public void BlackPawns_CanMoveOneSquareDown()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 0));
        }
        
        [Test]
        public void WhitePawns_CannotMoveBackwards()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(5, 0));
        }
        
        [Test]
        public void BlackPawns_CannotMoveBackwards()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(3, 0));
        }

        [Test]
        public void WhitePawns_WhichHaveNeverMoved_CanMoveTwoSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(7, 5), pawn);

            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().HaveCount(2);
            moves.Should().Contain(Square.At(5, 5));
        }

        [Test]
        public void BlackPawns_WhichHaveNeverMoved_CanMoveTwoSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(1, 3), pawn);

            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().HaveCount(2);
            moves.Should().Contain(Square.At(3, 3));
        }

        [Test]
        public void WhitePawns_WhichHaveAlreadyMoved_CanOnlyMoveOneSquare()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(7, 2), pawn);

            pawn.MoveTo(board, Square.At(6, 2));
            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().HaveCount(1);
            moves.Should().Contain(square => square.Equals(Square.At(5, 2)));
        }

        [Test]
        public void BlackPawns_WhichHaveAlreadyMoved_CanOnlyMoveOneSquare()
        {
            var board = new Board(Player.Black);
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(5, 2), pawn);

            pawn.MoveTo(board, Square.At(6, 2));
            var moves = pawn.GetAvailableMoves(board).ToList();

            moves.Should().HaveCount(1);
            moves.Should().Contain(square => square.Equals(Square.At(7, 2)));
        }
    }
}