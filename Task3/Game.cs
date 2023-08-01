namespace Task3
{
    internal class Game
    {
        private readonly Rules rules = new();
        private int computerMoveNumber = 0;


        public Game(Rules rules)
        {
            this.rules = rules;
        }

        public void Start()
        {
            string command = "";
            do
            {
                computerMoveNumber = getRandomMove();

                drawMenu();
                command = Console.ReadLine() ?? "";
                processCommand(command);

            } while (command != "0");
        }


        private void drawMenu()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < rules.Moves.Count; ++i)
            {
                Console.WriteLine($"{i + 1} - {rules.Moves[i].Name}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }

        private int getRandomMove() => new Random().Next(0, rules.Moves.Count);

        private void processCommand(string command)
        {
            if (command == "?") return;
            else if (command != "0") makeMove(Int32.Parse(command) - 1);
        }

        private void makeMove(int moveNumber)
        {
            var playerMove = rules.Moves[moveNumber];
            var computerMove = rules.Moves[computerMoveNumber];

            Console.WriteLine($"Your move: {playerMove.Name}");
            Console.WriteLine($"Computer move: {computerMove.Name}");
            
            printResult(rules.GetResult(playerMove, computerMove));
        }

        private void printResult(GameResult result)
        {
            string message = result switch
            {
                GameResult.Win => "You win!",
                GameResult.Lose => "You lose!",
                GameResult.Draw => "Draw!",
                _ => ""
            };
            Console.WriteLine(message);
        }
    }
}