using Bogus;
using Questao5.Application.Queries.Requests;

namespace Questao5.Tests.Fixture.QueriesFixtures.Requests
{
    public sealed class ConsultRequestFixture
    {
        private readonly ConsultRequest _consultRequest;
        private readonly Faker _faker = new("pt_BR");

        public ConsultRequestFixture()
        {
            _consultRequest = new ConsultRequest()
            {
                Number = _faker.Random.Number(0, 999)
            };
        }

        public ConsultRequest New() => _consultRequest;
    }
}
