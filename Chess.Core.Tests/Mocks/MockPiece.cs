using System.Collections.Generic;
using Chess.Core.Pieces;
using Chess.Core.Pieces.Movement;
using Moq;

namespace Chess.Core.Tests.Mocks {
    public class MockPiece : IPiece {
        private readonly Mock<IPiece> _mock;

        public MockPiece() {
            _mock = new Mock<IPiece>();
        }

        public IEnumerable<IMovement> Movements { get; }

        public IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate coordinate) {
            return _mock.Object.GetMovesFrom(coordinate);
        }

        public MockPiece GetMovesFromStubbedToReturn(IEnumerable<BoardCoordinate> coordinates) {
            _mock.Setup(m => m.GetMovesFrom(It.IsAny<BoardCoordinate>())).Returns(coordinates);
            return this;
        }

        public void VerifyGetMovesFromCalled(BoardCoordinate coordinate, int boardSize, int times = 1) {
            _mock.Verify(m => m.GetMovesFrom(coordinate), Times.Exactly(times));
        }

        public void VerifyGetMovesFromNotCalled() {
            _mock.Verify(m => m.GetMovesFrom(It.IsAny<BoardCoordinate>()), Times.Never);
        }
    }
}