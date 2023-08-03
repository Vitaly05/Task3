using FluentValidation.Results;
using Task3.Utils.Validators;

namespace Task3
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> moves = extractMoves(args);
            validateMoves(moves, out bool isValid);
            if (!isValid) return;
            startGame(defineRules(moves));
        }

        private static List<string> extractMoves(string[] args) => 
            args.Length == 0 ? new List<string>() : new List<string>(args).Skip(1).ToList();

        private static void validateMoves(List<string> moves, out bool isValid)
        {
            ArgsValidator validator = new ArgsValidator();
            ValidationResult results = validator.Validate(moves);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                    Console.WriteLine(error);
                isValid = false;
            }
            else isValid = true;
        }

        private static Rules defineRules(List<string> moves)
        {
            Rules rules = new();
            rules.ConfigureRules(moves, moves.Count / 2);
            return rules;
        }

        private static void startGame(Rules rules)
        {
            Game game = new Game(rules);
            game.Start();
        }
    }
}