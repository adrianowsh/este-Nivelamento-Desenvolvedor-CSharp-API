using Questao5.Application.Queries.Responses;

namespace Questao5.Tests.Fixtures.QueriesFixtures.Responses
{
    public sealed class ConsultIdemPotentResponseFixture
    {
        private readonly ConsultIdemPotentResponse instance;

        public ConsultIdemPotentResponseFixture()
        {
            instance = new ConsultIdemPotentResponse()
            {
                IdMovimentProcessed = Guid.NewGuid()
            };
        }

        public ConsultIdemPotentResponse Build() => instance;
    }
}
