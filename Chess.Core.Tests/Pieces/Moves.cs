using System.Collections.Generic;
using System.Linq;

namespace Chess.Core.Tests.Pieces {
    public class Moves {
        private readonly IEnumerable<BoardCoordinate> _validMoves;
        private readonly BoardCoordinate _startingCoordinate;
        private readonly int _boardSize;

        public Moves(IEnumerable<BoardCoordinate> validMoves, BoardCoordinate startingCoordinate, int boardSize ) {
            _boardSize = boardSize;
            _startingCoordinate = startingCoordinate;
            _validMoves = validMoves;
        }

        public IEnumerable<object[]> GetValidMoves() {
            return _validMoves.ToMoves(_startingCoordinate);
        }

        public IEnumerable<object[]> GetInvalidMoves() {
            return GetAllBoardCoordinates().Except(_validMoves).ToMoves(_startingCoordinate);
        }

        private IEnumerable<BoardCoordinate> GetAllBoardCoordinates() {
            for (var x = 0; x <= _boardSize + 1; x++)
                for (var y = 0; y <= _boardSize + 1; y++)
                    yield return new BoardCoordinate(x, y);
        }
    }
}
