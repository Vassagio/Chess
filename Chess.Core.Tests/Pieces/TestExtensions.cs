using System.Collections.Generic;
using System.Linq;

namespace Chess.Core.Tests.Pieces {
    public static class TestExtensions {

        public static IEnumerable<object[]> ToMoves(this IEnumerable<BoardCoordinate> coordinates, BoardCoordinate startingCoordinate) {
            return coordinates.Select(boardCoordinate => new object[] { boardCoordinate, startingCoordinate });
        }
    }
}
