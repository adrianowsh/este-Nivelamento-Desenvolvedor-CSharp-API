using Questao5.Domain.Enumerators;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public sealed record MovimentAccountCommandRequest(
        Guid IdAccount,
        MovimentType MovimetType,
        decimal Value
    );
}
