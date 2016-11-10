using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class Pawn : Piece {
        public Pawn(IEnumerable<IMovement> movements) : base(movements) {}
    }
}