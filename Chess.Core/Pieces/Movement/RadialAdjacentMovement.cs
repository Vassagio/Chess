using System.Collections.Generic;
using System.Linq;

namespace Chess.Core.Pieces.Movement {
    public class RadialAdjacentMovement : IMovement {
        private readonly int _boardSize;
        public int Distance { get; set; }

        public RadialAdjacentMovement(int boardSize) {
            _boardSize = boardSize;
        }
        public IEnumerable<BoardCoordinate> GetCoordinates(BoardCoordinate startingLocation) {
            var allDistancesFromStart = Enumerable.Range(1, Distance);
            var allPotentialMoves = allDistancesFromStart.SelectMany(d => GetLinearFrom(d, startingLocation));
            return allPotentialMoves.Where(m => m.IsCoordinateValidForBoardSize(_boardSize) && !m.Equals(startingLocation));
        }

        private IEnumerable<BoardCoordinate> GetLinearFrom(int distance, BoardCoordinate startingLocation) {
            yield return new BoardCoordinate(startingLocation.X, distance);
            yield return new BoardCoordinate(distance, startingLocation.Y);
        }
    }
}
