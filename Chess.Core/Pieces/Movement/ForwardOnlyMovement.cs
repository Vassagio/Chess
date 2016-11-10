using System;
using System.Collections.Generic;

namespace Chess.Core.Pieces.Movement {
    public class ForwardOnlyMovement: IMovement {
        private readonly int _boardSize;
        private readonly bool _hasMoved;

        public ForwardOnlyMovement(int boardSize, bool hasMoved) {
            _hasMoved = hasMoved;
            _boardSize = boardSize;
        }
        public IEnumerable<BoardCoordinate> GetCoordinates(BoardCoordinate startingLocation) {
            if (startingLocation.Y >= _boardSize)
                yield break;

            yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 1);
            if (!_hasMoved)
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 2);
        }
    }
}
