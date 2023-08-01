namespace Task3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Rules rules = defineRules(retrieveMoves(args));

            Game game = new Game(rules);
            game.Start();

            /*foreach (var move in rules.Moves)
                Console.WriteLine($"Move: {move.Current}\t" +
                    $"Strongers: {String.Join(' ', move.Strongers)}\t" +
                    $"Weakers: {String.Join(' ', move.Weakers)}");*/
        }


        private static List<string> retrieveMoves(string[] args)
        {
            List<string> moves = new List<string>(args);
            moves.RemoveAt(0);
            return moves;
        }

        private static Rules defineRules(List<string> moves)
        {
            Rules rules = new();
            rules.ConfigureRules(moves, moves.Count / 2);
            return rules;
        }
    }
}
