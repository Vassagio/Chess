using System.Collections.Generic;

namespace Chess.Core.Pieces.Movement {
    public interface IMovement {
        IEnumerable<BoardCoordinate> GetCoordinates(BoardCoordinate startingLocation);
    }
}
