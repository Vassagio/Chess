using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class Queen : Piece {
        public Queen(IEnumerable<IMovement> movements) : base(movements) {}
    }
}