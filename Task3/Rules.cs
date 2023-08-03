using Task3.Data;

namespace Task3
{
    internal class Rules
    {
        public List<Move> Moves { get; private set; } = new();

        public void ConfigureRules(List<string> moves, int movesAmountInSemicircle)
        {
            foreach (var move in moves)
            {
                Moves.Add(new Move
                {
                    Name = move,
                    Strongers = getNextMoves(moves, move, movesAmountInSemicircle),
                    Weakers = getPreviousMoves(moves, move, movesAmountInSemicircle)
                });
            }
        }

        public GameResult GetGameResult(Move playerMove, Move computerMove) => playerMove.GetResult(computerMove);

        private List<string> getNextMoves(List<string> moves, string currentMove, int amount)
        {
            List<string> nextMoves = new();
            var index = moves.IndexOf(currentMove) + 1;
            while (amount-- > 0)
            {
                if (index == moves.Count) index = 0;
                nextMoves.Add(moves.ElementAt(index++));
            }
            return nextMoves;
        }

        private List<string> getPreviousMoves(List<string> moves, string currentMove, int amount)
        {
            List<string> previousMoves = new();
            var index = moves.IndexOf(currentMove) - 1;
            while (amount-- > 0)
            {
                if (index < 0) index = moves.Count - 1;
                previousMoves.Add(moves.ElementAt(index--));
            }
            return previousMoves;
        }
    }
}