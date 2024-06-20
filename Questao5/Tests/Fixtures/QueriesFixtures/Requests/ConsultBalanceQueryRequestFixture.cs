using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Tests.Fixtures.QueriesFixtures.Requests
{
    public sealed class ConsultBalanceQueryRequestFixture
    {
        private readonly ConsultBalanceQueryRequest instance;

        public ConsultBalanceQueryRequestFixture()
        {
            instance = new ConsultBalanceQueryRequest()
            {
                IdAccount = Guid.NewGuid()
            };
        }

        public ConsultBalanceQueryRequestFixture(Guid id)
        {
            instance = new ConsultBalanceQueryRequest()
            {
                IdAccount = id
            };
        }

        public ConsultBalanceQueryRequest Build() => instance;
    }
}
