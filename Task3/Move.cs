namespace Task3
{
    internal class Move
    {
        public string Name { get; init; } = "";

        public List<string> Strongers { get; init; } = new();
        public List<string> Weakers { get; init; } = new();


        public GameResult GetResult(Move move)
        {
            if (Strongers.Contains(move.Name)) return GameResult.Lose;
            else if (Weakers.Contains(move.Name)) return GameResult.Win;
            return GameResult.Draw;
        }
    }
}
