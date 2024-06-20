using Questao5.Application.Queries.Requests;

namespace Questao5.Tests.Fixtures.QueriesFixtures.Requests
{
    public sealed class ConsultIdemPotenceRequestFixture
    {
        private readonly ConsultIdemPotenceRequest _consultIdemPotenceRequest;

        public ConsultIdemPotenceRequestFixture()
        {
            _consultIdemPotenceRequest = new ConsultIdemPotenceRequest()
            {
                IdIdemPotence = Guid.NewGuid()
            };
        }

        public ConsultIdemPotenceRequestFixture(Guid id)
        {
            _consultIdemPotenceRequest = new ConsultIdemPotenceRequest()
            {
                IdIdemPotence = id
            };
        }

        public ConsultIdemPotenceRequest New() => _consultIdemPotenceRequest;
    }
}
