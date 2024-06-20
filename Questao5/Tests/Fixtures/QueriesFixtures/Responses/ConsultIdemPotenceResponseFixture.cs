using Questao5.Application.Queries.Responses;

namespace Questao5.Tests.Fixtures.QueriesFixtures.Responses
{
    public sealed class ConsultIdemPotenceResponseFixture
    {
        private readonly ConsultIdemPotenceResponse _consultIdemPotenceResponse;

        public ConsultIdemPotenceResponseFixture()
        {
            _consultIdemPotenceResponse = new ConsultIdemPotenceResponse()
            {
                IdMovimentProcessed = Guid.NewGuid()
            };
        }
        public ConsultIdemPotenceResponse New() => _consultIdemPotenceResponse;
    }
}
