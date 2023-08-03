using Spectre.Console;
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
        private Move computerMove = new();


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
                computerMove = getRandomMove();
                do
                {
                    Console.WriteLine($"HMAC: {keyGenerator.GetHash(computerMove.Name)}");
                    drawMenu();
                    command = Console.ReadLine() ?? "";
                } while (!isValid(command));
                processCommand(command);
            } while (command != "0");
        }


        private void drawMenu()
        {
            AnsiConsole.MarkupLine(Painter.ChangeColor("Available moves:", Color.Yellow));
            for (int i = 0; i < rules.Moves.Count; ++i)
                AnsiConsole.MarkupLine($"{Painter.ChangeColor($"{i + 1}", Color.Yellow)} - {rules.Moves[i].Name}");
            AnsiConsole.MarkupLine(Painter.ChangeColor("0 - exit", Color.Red1));
            AnsiConsole.MarkupLine(Painter.ChangeColor("? - help", Color.Green));
            AnsiConsole.Markup(Painter.ChangeColor("Enter your move: ", Color.Yellow));
        }

        private Move getRandomMove() => rules.Moves[new Random().Next(0, rules.Moves.Count)];

        private bool isValid(string command) => validator.Validate(command).IsValid ? true : false;

        private void processCommand(string command)
        {
            if (command == "?") helper.PrintHelpInformation();
            else if (command != "0") makeMove(Int32.Parse(command) - 1);
        }

        private void makeMove(int moveNumber)
        {
            var playerMove = rules.Moves[moveNumber];
            AnsiConsole.MarkupLine($"Your move: {Painter.ChangeColor(playerMove.Name, Painter.UserColor)}");
            AnsiConsole.MarkupLine($"Computer move: {Painter.ChangeColor(computerMove.Name, Painter.ComputerColor)}");
            printResult(rules.GetResult(playerMove, computerMove));
        }

        private void printResult(GameResult result)
        {
            string message = result switch
            {
                GameResult.Win => Painter.ChangeColor("You win!", Painter.WinColor),
                GameResult.Lose => Painter.ChangeColor("You lose!", Painter.LoseColor),
                _ => Painter.ChangeColor("Draw!", Painter.DrawColor)
            };
            AnsiConsole.MarkupLine(message);
            Console.WriteLine($"HMAK key: {keyGenerator.Key}");
        }
    }
}