using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class Bishop : Piece {
        public Bishop(IEnumerable<IMovement> movements) : base(movements) {}
    }
}