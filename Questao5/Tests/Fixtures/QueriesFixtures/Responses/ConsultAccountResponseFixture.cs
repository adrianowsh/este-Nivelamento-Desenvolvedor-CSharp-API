using Bogus;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Tests.Fixtures.QueriesFixture.Responses
{
    public class ConsultAccountResponseFixture
    {
        private readonly ConsultAccountResponse instance;
        private readonly Faker _faker = new("pt_BR");

        public ConsultAccountResponseFixture()
        {
            instance = new()
            {
                Number = _faker.Random.Number(1, 999),
                Name = _faker.Person.FullName,
                Active = AccountSituation.Ativa,
                IdAccount = Guid.NewGuid()
            };
        }

        public ConsultAccountResponseFixture(int numero, AccountSituation situacaoConta)
        {
            instance = new()
            {
                Number = numero,
                Name = _faker.Person.FullName,
                Active = situacaoConta,
                IdAccount = Guid.NewGuid()
            };
        }
        public ConsultAccountResponse Build() => instance;
    }
}
