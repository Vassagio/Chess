using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class Rook : Piece {
        public Rook(IEnumerable<IMovement> movements) : base(movements) {}
    }
}