using Bogus;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Tests.Fixtures.QueriesFixture.Responses
{
    public class ConsultAccountResponseFixture
    {
        private readonly ConsultAccountResponse _consultAccountResponse;
        private readonly Faker _faker = new("pt_BR");

        public ConsultAccountResponseFixture()
        {
            _consultAccountResponse = new()
            {
                Number = _faker.Random.Number(1, 999),
                Name = _faker.Person.FullName,
                Active = AccountSituation.Ativa,
                IdAccount = Guid.NewGuid()
            };
        }

        public ConsultAccountResponseFixture(int numero, AccountSituation situacaoConta)
        {
            _consultAccountResponse = new()
            {
                Number = numero,
                Name = _faker.Person.FullName,
                Active = situacaoConta,
                IdAccount = Guid.NewGuid()
            };
        }
        public ConsultAccountResponse New() => _consultAccountResponse;
    }
}
