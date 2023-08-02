using FluentValidation;

namespace Task3.Utils.Validators
{
    internal class MoveValidator : AbstractValidator<string>
    {
        public MoveValidator(int movesCount)
        {
            RuleFor(s => Convert.ToInt32(s)).InclusiveBetween(0, movesCount).When(s => Int32.TryParse(s, out _));
            RuleFor(s => s).Equal("?").When(s => !Int32.TryParse(s, out _));
        }
    }
}
