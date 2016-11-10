using System.Collections.Generic;
using Chess.Core.Pieces;
using Chess.Core.Pieces.Movement;
using Chess.Core.Tests.Mocks;
using Xunit;

namespace Chess.Core.Tests.Pieces {
    public class KingTest {
        [Fact]
        public void Creates_A_New_King() {
            var king = new King(new List<IMovement>());

            Assert.IsAssignableFrom<Piece>(king);
        }

        [Fact]
        public void Returns_Possible_Moves_When_King_One_Movement() {
            var expected = new BoardCoordinate(10, 10);
            var startingLocation = new BoardCoordinate(6, 6);
            var coordinates = new List<BoardCoordinate> {
                expected
            };
            var mockMovement = new MockMovement().GetCoordinatesStubbedToReturn(coordinates);
            var movements = new List<IMovement> {
                mockMovement
            };
            var king = new King(movements);

            var moves = king.GetMovesFrom(startingLocation);

            Assert.Contains(expected, moves);
            mockMovement.VerifyGetCoordinatesCalled(startingLocation);
        }

        [Fact]
        public void Returns_Possible_Moves_When_King_Multiple_Movements() {
            var coordinate1 = new BoardCoordinate(10, 10);
            var coordinate2 = new BoardCoordinate(1, 22);
            var startingLocation = new BoardCoordinate(6, 6);
            var coordinates1 = new List<BoardCoordinate> { coordinate1 };
            var coordinates2 = new List<BoardCoordinate> { coordinate2 };
            var mockMovement1 = new MockMovement().GetCoordinatesStubbedToReturn(coordinates1);
            var mockMovement2 = new MockMovement().GetCoordinatesStubbedToReturn(coordinates2);
            var movements = new List<IMovement> { mockMovement1, mockMovement2, };
            var king = new King(movements);

            var moves = king.GetMovesFrom(startingLocation);

            Assert.Equal(new List<BoardCoordinate> { coordinate1, coordinate2 }, moves);
            mockMovement1.VerifyGetCoordinatesCalled(startingLocation);
            mockMovement2.VerifyGetCoordinatesCalled(startingLocation);
        }
    }
}
