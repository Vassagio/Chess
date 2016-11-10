using System;
using Chess.Core.Pieces;
using Chess.Core.Tests.Mocks;
using Xunit;

namespace Chess.Core.Tests {
    public class BoardTest {
        [Fact]
        public void Creates_A_New_Board() {
            var board = BuildBoard();

            Assert.IsType<Board>(board);
        }

        public class AddPiece : BoardTest {
            [Fact]
            public void Does_Not_Throw_Exception_When_Adding_A_Piece_To_An_Unoccupied_Square() {
                var board = BuildBoard();
                var piece = new MockPiece();

                Assert.Null(Record.Exception(() => board.AddPiece(piece, new BoardCoordinate(2, 1))));
            }

            [Fact]
            public void Throws_Exception_When_Adding_A_Piece_To_An_Occupied_Square() {
                var board = BuildBoard();
                var piece1 = new MockPiece();
                var piece2 = new MockPiece();
                var boardCoordinate = new BoardCoordinate(2, 1);

                board.AddPiece(piece1, boardCoordinate);

                Assert.Throws<ArgumentException>(() => board.AddPiece(piece2, boardCoordinate));
            }

            [Theory]
            [InlineData(0, 5, 8)]
            [InlineData(-12, 2, 8)]
            [InlineData(9, 5, 8)]
            [InlineData(5, 0, 8)]
            [InlineData(6, -23, 8)]
            [InlineData(7, 20, 8)]
            public void Throws_Exception_When_BoardCoordinate_Is_Not_Within_Limits(int x, int y, int boardSize) {
                var board = BuildBoard(boardSize);
                var piece = new MockPiece();

                Assert.Throws<ArgumentException>(() => board.AddPiece(piece, new BoardCoordinate(x, y)));
            }
        }

        public class GetPiece : BoardTest {
            [Fact]
            public void Retrieves_Piece_Added_To_Location() {
                var board = BuildBoard();
                var piece = new MockPiece();
                var boardCoordinate = new BoardCoordinate(2, 1);
                board.AddPiece(piece, boardCoordinate);

                var actual = board.GetPiece(boardCoordinate);

                Assert.Equal(piece, actual);
            }
        }

        private static Board BuildBoard(int boardSize = 8) {
            return new Board(boardSize);
        }
    }
}
