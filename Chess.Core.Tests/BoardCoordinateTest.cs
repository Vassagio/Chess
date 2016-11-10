using Xunit;

namespace Chess.Core.Tests {
    public class BoardCoordinateTest {
        [Theory]
        [InlineData(1, 1, 8)]
        [InlineData(8, 8, 8)]
        [InlineData(5, 5, 8)]
        [InlineData(12, 12, 12)]
        [InlineData(20, 1, 20)]
        [InlineData(1, 20, 20)]
        public void Coordinate_Is_Within_Board_Size(int x, int y, int boardSize) {
            var coordinate = new BoardCoordinate(x, y);

            Assert.True(coordinate.IsCoordinateValidForBoardSize(boardSize));
        }

        [Theory]
        [InlineData(0, 5, 8)]
        [InlineData(-12, 2, 8)]
        [InlineData(9, 5, 6)]
        [InlineData(5, 0, 8)]
        [InlineData(6, -23, 10)]
        [InlineData(7, 20, 9)]
        public void Coordinate_Is_Not_Within_Board_Size(int x, int y, int boardSize) {
            var coordinate = new BoardCoordinate(x, y);

            Assert.False(coordinate.IsCoordinateValidForBoardSize(boardSize));
        }
    }
}
