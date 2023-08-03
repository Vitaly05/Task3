using FluentValidation;

namespace Task3.Utils.Validators
{
    internal class ArgsValidator : AbstractValidator<List<string>>
    {
        public ArgsValidator()
        {
            RuleFor(l => l.Count).GreaterThanOrEqualTo(3)
                .WithMessage("The number of arguments must be greater than or equal to 3. Please, enter more arguments.");
            RuleFor(l => l.Count % 2).Equal(1)
                .WithMessage("The number of arguments must be odd. Please, add or delete one argument.");
            RuleFor(l => l).Must(l => l.Distinct().Count() == l.Count())
                .WithMessage("Arguments must be unique. Please, enter unique arguments.");
        }
    }
}