using FluentValidation;

namespace Questao5.Application.Commands.Requests
{
    internal sealed class ConsultBalanceRequestValidator : AbstractValidator<ConsultBalanceRequest>
    {
        public ConsultBalanceRequestValidator()
        {
            RuleFor(c => c.Numero).GreaterThan(0);
        }
    }
}