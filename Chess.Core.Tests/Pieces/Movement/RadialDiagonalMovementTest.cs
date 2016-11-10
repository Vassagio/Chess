using System.Collections.Generic;
using Chess.Core.Pieces.Movement;
using Xunit;

namespace Chess.Core.Tests.Pieces.Movement {
    public class RadialDiagonalMovementTest {
        private const int BOARD_SIZE = 8;
        public static IEnumerable<object[]> GetDiagonalData() {
            yield return new object[] {8, new List<BoardCoordinate> {
                new BoardCoordinate(6, 6),
                new BoardCoordinate(6, 4),
                new BoardCoordinate(4, 6),
                new BoardCoordinate(4, 4),
                new BoardCoordinate(7, 7),
                new BoardCoordinate(7, 3),
                new BoardCoordinate(3, 7),
                new BoardCoordinate(3, 3),
                new BoardCoordinate(8, 8),
                new BoardCoordinate(8, 2),
                new BoardCoordinate(2, 8),
                new BoardCoordinate(2, 2),
                new BoardCoordinate(1, 1),
            }};

            yield return new object[] {5, new List<BoardCoordinate> {
                new BoardCoordinate(4, 4),
                new BoardCoordinate(3, 3),
                new BoardCoordinate(2, 2),
                new BoardCoordinate(1, 1),
            }};
        }

        [Theory]
        [MemberData(nameof(GetDiagonalData))]
        public void Get_From_Builds_Coordinates_From_Length(int boardSize, IEnumerable<BoardCoordinate> expected) {
            var movement = new RadialDiagonalMovement(boardSize) {Distance = boardSize};

            var moves = movement.GetCoordinates(new BoardCoordinate(5, 5));

            Assert.Equal(expected, moves);
        }

        [Fact]
        public void Returns_Empty_List_When_Get_From_Builds_Coordinates_From_Outside_Length() {
            var movement = new RadialDiagonalMovement(4);

            var moves = movement.GetCoordinates(new BoardCoordinate(20, 20));

            Assert.Empty(moves);
        }
    }
}