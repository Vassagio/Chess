using System.Collections.Generic;
using Chess.Core.Pieces.Movement;
using Moq;

namespace Chess.Core.Tests.Mocks {
    public class MockMovement : IMovement {
        private readonly Mock<IMovement> _mock;

        public MockMovement() {
            _mock = new Mock<IMovement>();
        }

        public IEnumerable<BoardCoordinate> GetCoordinates(BoardCoordinate startingLocation) {
            return _mock.Object.GetCoordinates(startingLocation);
        }

        public MockMovement GetCoordinatesStubbedToReturn(IEnumerable<BoardCoordinate> coordinates) {
            _mock.Setup(m => m.GetCoordinates(It.IsAny<BoardCoordinate>())).Returns(coordinates);
            return this;
        }

        public void VerifyGetCoordinatesCalled(BoardCoordinate startingLocation, int times = 1) {
            _mock.Verify(m => m.GetCoordinates(startingLocation), Times.Exactly(times));
        }

        public void VerifyGetCoordinatesNotCalled() {
            _mock.Verify(m => m.GetCoordinates(It.IsAny<BoardCoordinate>()), Times.Never);
        }
    }
}
