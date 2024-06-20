using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application;
using Questao5.Application.Commands.Requests;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.SqlStatements;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories.Commands
{
    public sealed class AccountCommandsRepository : IAccountCommandsRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public AccountCommandsRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task AddIdemPotentMovimentAsync(IdemPotenceMovimentRequest request)
        {
            try
            {
                using var connection = new SqliteConnection(_databaseConfig.Name);
                {
                    await connection.ExecuteAsync(AccountStatements.SQL_INSERT_IDEMPOTENT_MOVIMENT,
                        new
                        {
                            Chave_Idempotencia = request.idempotenceKey.ToString(),
                            Requisicao = request.Request,
                            Resultado = request.Result
                        });
                }
            }
            catch
            {
                throw; //preserve stackstrace
            }
        }

        public async Task<Guid> MovimentAccountAsync(MovimentAccountCommandRequest request)
        {
            try
            {
                using var connection = new SqliteConnection(_databaseConfig.Name);
                {
                    var idMoviment = Guid.NewGuid();
                    char movimentType = MovimentTypeConvert.ConvertToChar(request.MovimetType);
                    await connection.ExecuteAsync(AccountStatements.SQL_INSERT_MOVIMENT,
                        new
                        {
                            IdMoviment = idMoviment.ToString(),
                            request.IdAccount,
                            MovimentType = movimentType,
                            request.Value
                        });

                    return idMoviment;
                }
            }
            catch
            {
                throw; //preserve stackstrace
            }
        }
    }
}
