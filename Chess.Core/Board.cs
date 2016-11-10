using System;
using Chess.Core.Pieces;

namespace Chess.Core {
    public class Board {
        private readonly IPiece[,] _pieces;
        public int BoardSize { get; }

        public Board(int boardSize = 8) {
            BoardSize = boardSize;
            _pieces = new IPiece[boardSize, boardSize];
        }

        public void AddPiece(IPiece piece, BoardCoordinate coordinate) {
            if (!coordinate.IsCoordinateValidForBoardSize(BoardSize))
                throw new ArgumentException("invalid coordinate");

            if (IsCoordinateOccupied(coordinate))
                throw new ArgumentException("coordinate occupied");

            _pieces[coordinate.X, coordinate.Y] = piece;
        }

        public IPiece GetPiece(BoardCoordinate coordinate) {
            return _pieces[coordinate.X, coordinate.Y];
        }

        private bool IsCoordinateOccupied(BoardCoordinate coordinate) {
            return _pieces[coordinate.X, coordinate.Y] != null;
        }
    }
}