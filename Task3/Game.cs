using Task3.Data;
using Task3.Utils;
using Task3.Utils.Validators;

namespace Task3
{
    internal class Game
    {
        private readonly Rules rules;
        private readonly Helper helper;
        private MoveValidator validator;
        private KeyGenerator keyGenerator = new();
        private int computerMoveNumber = 0;


        public Game(Rules rules)
        {
            this.rules = rules;
            helper = new Helper(rules);
            validator = new MoveValidator(rules.Moves.Count);
        }

        public void Start()
        {
            string command;
            do
            {
                keyGenerator = new();
                computerMoveNumber = getRandomMove();
                do
                {
                    Console.WriteLine($"HMAC: {keyGenerator.GetHash(rules.Moves[computerMoveNumber].Name)}");
                    drawMenu();
                    command = Console.ReadLine() ?? "";
                } while (!isValid(command));
                processCommand(command);
            } while (command != "0");
        }


        private void drawMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Available moves:");

            Console.ResetColor();
            for (int i = 0; i < rules.Moves.Count; ++i)
            {
                Console.WriteLine($"{i + 1} - {rules.Moves[i].Name}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0 - exit");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("? - help");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your move: ");

            Console.ResetColor();
        }

        private int getRandomMove() => new Random().Next(0, rules.Moves.Count);

        private bool isValid(string command) => validator.Validate(command).IsValid ? true : false;

        private void processCommand(string command)
        {
            if (command == "?") helper.PrintHelpInformation();
            else if (command != "0") makeMove(Int32.Parse(command) - 1);
        }

        private void makeMove(int moveNumber)
        {
            var playerMove = rules.Moves[moveNumber];
            var computerMove = rules.Moves[computerMoveNumber];

            Console.WriteLine($"Your move: {ConsoleColors.ChoseColor(playerMove.Name, ConsoleColors.YellowColor)}");
            Console.WriteLine($"Computer move: {ConsoleColors.ChoseColor(computerMove.Name, ConsoleColors.BlueColor)}");
            
            printResult(rules.GetResult(playerMove, computerMove));
        }

        private void printResult(GameResult result)
        {
            string message = result switch
            {
                GameResult.Win => $"{ConsoleColors.GreenColor}You win!{ConsoleColors.DefaultColor}",
                GameResult.Lose => $"{ConsoleColors.RedColor}You lose!{ConsoleColors.DefaultColor}",
                GameResult.Draw => $"{ConsoleColors.YellowColor}Draw!{ConsoleColors.DefaultColor}",
                _ => ""
            };
            Console.WriteLine(message);
            Console.WriteLine($"HMAK key: {keyGenerator.Key}");
        }
    }
}