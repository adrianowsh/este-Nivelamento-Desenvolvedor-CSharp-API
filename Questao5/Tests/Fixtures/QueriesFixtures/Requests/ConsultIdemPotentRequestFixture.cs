using Questao5.Application.Queries.Requests;

namespace Questao5.Tests.Fixtures.QueriesFixtures.Requests
{
    public sealed class ConsultIdemPotentRequestFixture
    {
        private readonly ConsultIdemPotentRequest instance;

        public ConsultIdemPotentRequestFixture()
        {
            instance = new ConsultIdemPotentRequest()
            {
                IdIdemPotent = Guid.NewGuid()
            };
        }

        public ConsultIdemPotentRequestFixture(Guid id)
        {
            instance = new ConsultIdemPotentRequest()
            {
                IdIdemPotent = id
            };
        }

        public ConsultIdemPotentRequest Build() => instance;
    }
}
