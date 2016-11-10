using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class King : Piece {
        public King(IEnumerable<IMovement> movements) : base(movements) {}
    }
}