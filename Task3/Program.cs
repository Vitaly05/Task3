using FluentValidation.Results;
using Task3.Utils.Validators;

namespace Task3
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> moves = new List<string>(args).Skip(1).ToList();
            validateMoves(moves);
            startGame(defineRules(moves));
        }

        private static void validateMoves(List<string> moves)
        {
            ArgsValidator validator = new ArgsValidator();
            ValidationResult results = validator.Validate(moves);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                    Console.WriteLine(error);
                return;
            }
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