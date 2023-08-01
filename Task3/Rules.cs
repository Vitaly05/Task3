namespace Task3
{
    internal class Rules
    {
        public List<Move> Moves { get; private set; } = new();


        public void ConfigureRules(List<string> moves, int amountInSemicircle)
        {
            foreach (var move in moves)
            {
                Moves.Add(new Move
                {
                    Current = move,
                    Strongers = getNextMoves(moves, move, amountInSemicircle),
                    Weakers = getPreviousMoves(moves, move, amountInSemicircle)
                });
            }
        }


        private List<string> getNextMoves(List<string> list, string current, int amount)
        {
            List<string> nextMoves = new();
            var index = list.IndexOf(current) + 1;

            while (amount-- > 0)
            {
                if (index == list.Count) index = 0;
                nextMoves.Add(list.ElementAt(index++));
            }

            return nextMoves;
        }
        private List<string> getPreviousMoves(List<string> list, string current, int amount)
        {
            List<string> prevMoves = new();
            var index = list.IndexOf(current) - 1;

            while (amount-- > 0)
            {
                if (index < 0) index = list.Count - 1;
                prevMoves.Add(list.ElementAt(index--));
            }

            return prevMoves;
        }
    }
}
