using Bogus;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Tests.Fixtures.QueriesFixture.Responses
{
    public class ConsultBalanceQueryResponseFixture
    {
        private readonly ConsultBalanceQueryResponse instance;
        private readonly Faker _faker = new("pt_BR");

        public ConsultBalanceQueryResponseFixture()
        {
            instance = new ConsultBalanceQueryResponse(
                _faker.Random.Decimal(1, 9999.99m)
            );
        }

        public ConsultBalanceQueryResponse Build() => instance;
    }
}
