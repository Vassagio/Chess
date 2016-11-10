using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Core.Pieces.Movement {
    public class QuandrantMovement : IMovement {
        private readonly int _boardSize;

        public QuandrantMovement(int boardSize) {
            _boardSize = boardSize;
        }

        private const int MIN_QUADRANT = 1;
        private const int MAX_QUADRANT = 4;
        public IEnumerable<BoardCoordinate> GetCoordinates(BoardCoordinate startingLocation) {
            var quadrantsFromASquare = Enumerable.Range(1, 4);
            var allPotentialMoves = quadrantsFromASquare.SelectMany(q => GetQuadrantFrom(q, startingLocation));

            return allPotentialMoves.Where(bc => bc.IsCoordinateValidForBoardSize(_boardSize));
        }

        private IEnumerable<BoardCoordinate> GetQuadrantFrom(int quadrant, BoardCoordinate startingLocation) {
            if (quadrant < MIN_QUADRANT || quadrant > MAX_QUADRANT)
                yield break;

            var xMultiplier = quadrant == MIN_QUADRANT || quadrant == MAX_QUADRANT ? 1 : -1;
            var yMultiplier = quadrant == MIN_QUADRANT || quadrant == 2 ? 1 : -1;
            yield return new BoardCoordinate(startingLocation.X + 2 * xMultiplier, startingLocation.Y + yMultiplier * 1);
            yield return new BoardCoordinate(startingLocation.X + 1 * xMultiplier, startingLocation.Y + yMultiplier * 2);
        }
    }
}
