using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Constants;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Repositories.Commands;
using Questao5.Infrastructure.Repositories.Queries;
using System.Text;

namespace Questao5.Application.Handlers
{
    public sealed class MovimentHandler : IMovimentHandler
    {
        private readonly IAccountCommandsRepository _repositoryCommands;
        private readonly IAccountQueriesRepository _repositoryQueries;

        public MovimentHandler(IAccountCommandsRepository repository, IAccountQueriesRepository repositoryQueries)
        {
            _repositoryCommands = repository;
            _repositoryQueries = repositoryQueries;
        }

        public async Task<MovimentResponse> Handle(MovimentRequest command)
        {
            ConsultIdemPotenceResponse? idemPotent = await CheckIdemPotent(command);
            if (idemPotent is not null)
                return new MovimentResponse() { IdMoviment = idemPotent.IdMovimentProcessed };

            var account = await _repositoryQueries.ConsultAccountAsync(command.Number);
            if (account is null)
                return new MovimentResponse() { ErrorMessage = ErrorMessages.INVALID_ACCOUNT_MOVEMENT };

            if (account.Active == AccountSituation.Inativa)
                return new MovimentResponse() { ErrorMessage = ErrorMessages.INACTIVE_ACCOUNT_MOVIMENT };

            var idMovimento = await _repositoryCommands.MovimentAccountAsync(
                new MovimentAccountCommandRequest
                (
                    IdAccount: account.IdAccount,
                    MovimetType: command.MovimentType,
                    Value: command.Value
                ));

            await AddIdemPotence(command, account, idMovimento);

            return new MovimentResponse() { IdMoviment = idMovimento };
        }

        private async Task AddIdemPotence(MovimentRequest command, ConsultAccountResponse? account, Guid idMovimento)
        {
            var requestMovimento = new StringBuilder();
            requestMovimento.Append(account!.IdAccount);
            requestMovimento.Append(" | ");
            requestMovimento.Append(command.MovimentType.ToString());
            requestMovimento.Append(" | ");
            requestMovimento.Append(command.Value.ToString());
            requestMovimento.Append(" | ");
            requestMovimento.Append(DateTime.Now.ToString());
            await _repositoryCommands.AddIdemPotentMovimentAsync(
                new IdemPotenceMovimentRequest
                (
                    command.IdIdemPotence,
                    requestMovimento.ToString(),
                    idMovimento.ToString()
                )
            );
        }
        private async Task<ConsultIdemPotenceResponse?> CheckIdemPotent(MovimentRequest command)
            => await _repositoryQueries.ConsultIdemPotentMovimentAsync(
                    new ConsultIdemPotenceRequest { IdIdemPotence = command.IdIdemPotence }
            );
    }
}
