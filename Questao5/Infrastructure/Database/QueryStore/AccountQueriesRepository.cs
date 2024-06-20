using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Database.SqlStatements;
using Questao5.Infrastructure.Services;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories.Queries
{
    public sealed class AccountQueriesRepository : IAccountQueriesRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public AccountQueriesRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<ConsultIdemPotenceResponse> ConsultIdemPotentMovimentAsync(ConsultIdemPotenceRequest request)
        {
            try
            {
                using var connection = new SqliteConnection(_databaseConfig.Name);
                {
                    var idemPotencia = (await connection.QueryAsync<IdemPotencia>(
                        AccountStatements.SQL_SELECT_IDEMPOTENT_BY_KEY,
                        new { Chave_Idempotencia = request.IdIdemPotence.ToString() })).FirstOrDefault();

                    ConsultIdemPotenceResponse? response = idemPotencia is null ? null : ConsultIdemPotenceResponse.ConvertTo(idemPotencia);

                    return response!;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ConsultAccountResponse> ConsultAccountAsync(int numero)
        {
            try
            {
                using var connection = new SqliteConnection(_databaseConfig.Name);
                {
                    var account = (await connection.QueryAsync<ContaCorrente>(
                        AccountStatements.SQL_SELECT_ACCOUNT_BY_NUMBER,
                        new { Number = numero.ToString() })).FirstOrDefault();

                    ConsultAccountResponse? response = account is null ? null : ConsultAccountResponse.ConvertTo(account);
                    return response!;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ConsultAccountResponse> ConsultAccountAsync(Guid idContaCorrente)
        {
            try
            {
                using var connection = new SqliteConnection(_databaseConfig.Name);
                {
                    var conta = (await connection.QueryAsync<ContaCorrente>(
                       AccountStatements.SQL_SELECT_ACCOUNT_BY_ID,
                       new { IdAccount = idContaCorrente.ToString() })).FirstOrDefault();

                    ConsultAccountResponse? response = conta is null ? null : ConsultAccountResponse.ConvertTo(conta);
                    return response!;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ConsultBalanceQueryResponse> ConsultBalanceAsync(ConsultBalanceQueryRequest request)
        {
            try
            {
                using var connection = new SqliteConnection(_databaseConfig.Name);
                {
                    List<Movimento> movimentos = (await connection.QueryAsync<Movimento>(
                        AccountStatements.SQL_SELECT_MOVIMENTS,
                        new { IdAccount = request.IdAccount }))
                        .ToList();

                    decimal credits = AccountServices.SumMoviments(movimentos, MovimentType.Credito);
                    decimal debits = AccountServices.SumMoviments(movimentos, MovimentType.Debito);

                    return new ConsultBalanceQueryResponse(credits - debits);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
