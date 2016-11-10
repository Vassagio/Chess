using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public interface IPiece {
        IEnumerable<IMovement> Movements { get; }
        IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate coordinate);
    }
}