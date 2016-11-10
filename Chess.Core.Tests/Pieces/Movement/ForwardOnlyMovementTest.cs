using System.Collections.Generic;
using Chess.Core.Pieces.Movement;
using Xunit;

namespace Chess.Core.Tests.Pieces.Movement {
    public class ForwardOnlyMovementTest {
        private const int BOARD_SIZE = 8;
        public static IEnumerable<object[]> GetForwardData() {
            yield return new object[] {false , new List<BoardCoordinate> {
                new BoardCoordinate(2, 3),
                new BoardCoordinate(2, 4),
            }};

            yield return new object[] {true , new List<BoardCoordinate> {
                new BoardCoordinate(2, 3),
            }};
        }

        [Theory]
        [MemberData(nameof(GetForwardData))]
        public void Get_From_Builds_Coordinates_From_Forward_Data(bool hasMoved, IEnumerable<BoardCoordinate> expected) {
            var movement = new ForwardOnlyMovement(BOARD_SIZE, hasMoved);

            var moves = movement.GetCoordinates(new BoardCoordinate(2, 2));

            Assert.Equal(expected, moves);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Returns_Empty_List_When_Get_From_Builds_Coordinates_From_Unknown_Forward_Data(bool hasMoved) {
            var movement = new ForwardOnlyMovement(BOARD_SIZE, hasMoved);

            var moves = movement.GetCoordinates(new BoardCoordinate(BOARD_SIZE, BOARD_SIZE));

            Assert.Empty(moves);
        }
    }
}
