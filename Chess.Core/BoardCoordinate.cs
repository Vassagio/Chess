namespace Chess.Core {
    public struct BoardCoordinate {
        public int X { get; }
        public int Y { get; }
        public BoardCoordinate(int x, int y) {
            X = x;
            Y = y;
        }

        public bool IsCoordinateValidForBoardSize(int boardSize) {
            return IsValidDimension(X, boardSize) && IsValidDimension(Y, boardSize);
        }

        private bool IsValidDimension(int dimension, int boardSize) {
            return (dimension > 0) && (dimension <= boardSize);
        }

        public override string ToString() {
            return $"({X}, {Y})";
        }
    }
}
