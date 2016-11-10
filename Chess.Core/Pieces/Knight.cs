using System.Collections.Generic;
using System.Linq;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class Knight: Piece {
        public Knight(IEnumerable<IMovement> movements) : base(movements) {}
    }
}