using System.Collections.Generic;
using Chess.Core.Pieces.Movement;
using Xunit;

namespace Chess.Core.Tests.Pieces.Movement {
    public class RadialAdjacentMovementTest {
        public static IEnumerable<object[]> GetDiagonalData() {
            yield return new object[] {8, new List<BoardCoordinate> {
                new BoardCoordinate(5, 1),
                new BoardCoordinate(1, 5),
                new BoardCoordinate(5, 2),
                new BoardCoordinate(2, 5),
                new BoardCoordinate(5, 3),
                new BoardCoordinate(3, 5),
                new BoardCoordinate(5, 4),
                new BoardCoordinate(4, 5),
                new BoardCoordinate(5, 6),
                new BoardCoordinate(6, 5),
                new BoardCoordinate(5, 7),
                new BoardCoordinate(7, 5),
                new BoardCoordinate(5, 8),
                new BoardCoordinate(8, 5),
            }};

            yield return new object[] {5, new List<BoardCoordinate> {
                new BoardCoordinate(5, 1),
                new BoardCoordinate(1, 5),
                new BoardCoordinate(5, 2),
                new BoardCoordinate(2, 5),
                new BoardCoordinate(5, 3),
                new BoardCoordinate(3, 5),
                new BoardCoordinate(5, 4),
                new BoardCoordinate(4, 5),
            }};
        }

        [Theory]
        [MemberData(nameof(GetDiagonalData))]
        public void Get_From_Builds_Coordinates_From_Length(int boardSize, IEnumerable<BoardCoordinate> expected) {
            var movement = new RadialAdjacentMovement(boardSize) {Distance = boardSize};

            var moves = movement.GetCoordinates(new BoardCoordinate(5, 5));

            Assert.Equal(expected, moves);
        }

        [Fact]
        public void Returns_Empty_List_When_Get_From_Builds_Coordinates_From_Outside_Length() {
            var movement = new RadialAdjacentMovement(4);

            var moves = movement.GetCoordinates(new BoardCoordinate(5, 5));

            Assert.Empty(moves);
        }
    }
}