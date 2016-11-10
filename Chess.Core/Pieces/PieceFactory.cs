using System;
using System.Collections.Generic;
using Chess.Core.Pieces.Movement;

namespace Chess.Core.Pieces {
    public class PieceFactory {
        private readonly int _boardSize;

        public PieceFactory(int boardSize) {
            _boardSize = boardSize;
        }
        public IPiece Create(PieceType pieceType) {
            var movements = new List<IMovement>();
            switch (pieceType) {
                case PieceType.Pawn:
                    movements.Add(new ForwardOnlyMovement(_boardSize, false));
                    return new Pawn(movements);
                case PieceType.Rook:
                    movements.Add(new RadialAdjacentMovement(_boardSize) { Distance = _boardSize });
                    return new Rook(movements);
                case PieceType.Bishop:
                    movements.Add(new RadialDiagonalMovement(_boardSize) { Distance = _boardSize });
                    return new Bishop(movements);
                case PieceType.Knight:
                    movements.Add(new QuandrantMovement(_boardSize));
                    return new Knight(movements);
                case PieceType.King:
                    movements.Add(new RadialDiagonalMovement(_boardSize) { Distance = 1 });
                    movements.Add(new RadialAdjacentMovement(_boardSize) { Distance = 1 });
                    return new King(movements);
                case PieceType.Queen:
                    movements.Add(new RadialDiagonalMovement(_boardSize) { Distance = _boardSize });
                    movements.Add(new RadialAdjacentMovement(_boardSize) { Distance = _boardSize });
                    return new King(movements);
            }
            throw new ArgumentException("invalid piece");
        }
    }
}
