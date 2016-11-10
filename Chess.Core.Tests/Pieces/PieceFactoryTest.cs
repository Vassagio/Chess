using System;
using System.Linq;
using Chess.Core.Pieces;
using Chess.Core.Pieces.Movement;
using Xunit;

namespace Chess.Core.Tests.Pieces {
    public class PieceFactoryTest {
        private const int BOARD_SIZE = 8;
        [Fact]
        public void Throws_Exception_When_Piece_Does_Not_Exist() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            Assert.Throws<ArgumentException>(() => pieceFactory.Create(0));
        }

        [Fact]
        public void Creates_A_Pawn() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            var piece = pieceFactory.Create(PieceType.Pawn);

            Assert.IsType<Pawn>(piece);
            Assert.Equal(piece.Movements.Count(), 1);
            Assert.IsType<ForwardOnlyMovement>(piece.Movements.First());
        }

        [Fact]
        public void Creates_A_Rook() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            var piece = pieceFactory.Create(PieceType.Rook);

            Assert.IsType<Rook>(piece);
            Assert.Equal(piece.Movements.Count(), 1);
            Assert.IsType<RadialAdjacentMovement>(piece.Movements.First());
            Assert.Equal(BOARD_SIZE, piece.Movements.OfType<RadialAdjacentMovement>().First().Distance);
        }

        [Fact]
        public void Creates_A_Knight() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            var piece = pieceFactory.Create(PieceType.Knight);

            Assert.IsType<Knight>(piece);
            Assert.Equal(piece.Movements.Count(), 1);
            Assert.IsType<QuandrantMovement>(piece.Movements.First());
        }

        [Fact]
        public void Creates_A_Bishop() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            var piece = pieceFactory.Create(PieceType.Bishop);

            Assert.IsType<Bishop>(piece);
            Assert.Equal(piece.Movements.Count(), 1);
            Assert.IsType<RadialDiagonalMovement>(piece.Movements.First());
            Assert.Equal(BOARD_SIZE, piece.Movements.OfType<RadialDiagonalMovement>().First().Distance);
        }

        [Fact]
        public void Creates_A_King() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            var piece = pieceFactory.Create(PieceType.King);

            Assert.IsType<King>(piece);
            Assert.Equal(piece.Movements.Count(), 2);
            Assert.IsType<RadialDiagonalMovement>(piece.Movements.First());
            Assert.Equal(1, piece.Movements.OfType<RadialDiagonalMovement>().First().Distance);
            Assert.IsType<RadialAdjacentMovement>(piece.Movements.Last());
            Assert.Equal(1, piece.Movements.OfType<RadialAdjacentMovement>().Last().Distance);
        }

        [Fact]
        public void Creates_A_Queen() {
            var pieceFactory = new PieceFactory(BOARD_SIZE);

            var piece = pieceFactory.Create(PieceType.Queen);

            Assert.IsType<King>(piece);
            Assert.Equal(piece.Movements.Count(), 2);
            Assert.IsType<RadialDiagonalMovement>(piece.Movements.First());
            Assert.Equal(BOARD_SIZE, piece.Movements.OfType<RadialDiagonalMovement>().First().Distance);
            Assert.IsType<RadialAdjacentMovement>(piece.Movements.Last());
            Assert.Equal(BOARD_SIZE, piece.Movements.OfType<RadialAdjacentMovement>().Last().Distance);
        }
    }
}
