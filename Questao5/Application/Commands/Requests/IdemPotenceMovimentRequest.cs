namespace Questao5.Application.Commands.Requests
{
    public sealed record IdemPotenceMovimentRequest(
        Guid idempotenceKey,
        string Request,
        string Result
    );
}
