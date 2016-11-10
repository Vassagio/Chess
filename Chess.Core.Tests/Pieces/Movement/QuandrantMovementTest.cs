using System.Collections.Generic;
using Chess.Core.Pieces.Movement;
using Xunit;

namespace Chess.Core.Tests.Pieces.Movement {
    public class QuandrantMovementTest {
        private const int BOARD_SIZE = 8;
        public static IEnumerable<object[]> GetQuadrantData() {
            yield return new object[] {new List<BoardCoordinate> {
                new BoardCoordinate(7, 6),
                new BoardCoordinate(6, 7),
                new BoardCoordinate(3, 6),
                new BoardCoordinate(4, 7),
                new BoardCoordinate(3, 4),
                new BoardCoordinate(4, 3),
                new BoardCoordinate(7, 4),
                new BoardCoordinate(6, 3)
            }};
        }

        [Theory]
        [MemberData(nameof(GetQuadrantData))]
        public void Get_From_Builds_Coordinates_From_Quandrant(IEnumerable<BoardCoordinate> expected) {
            var movement = new QuandrantMovement(BOARD_SIZE);

            var moves = movement.GetCoordinates(new BoardCoordinate(5, 5));
            
            Assert.Equal(expected, moves);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(100)]
        public void Returns_Empty_List_When_Get_From_Builds_Coordinates_From_Unknown_Quandrant(int quadrant) {
            var movement = new QuandrantMovement(2);

            var moves = movement.GetCoordinates(new BoardCoordinate(5, 5));

            Assert.Empty(moves);
        }
    }
}