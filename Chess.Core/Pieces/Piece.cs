using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public abstract class Piece : IPiece {
        public IEnumerable<IMovement> Movements { get; protected set; }

        protected Piece(IEnumerable<IMovement> movements) {
            Movements = movements;
        }
        public IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate coordinate) {
            foreach (var movement in Movements)
                foreach (var move in movement.GetCoordinates(coordinate))
                    yield return move;
        }
    }
}