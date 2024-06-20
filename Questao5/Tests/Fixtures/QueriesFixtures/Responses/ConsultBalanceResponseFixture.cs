using Bogus;
using Questao5.Application.Queries.Responses;

namespace Questao5.Tests.Fixtures.QueriesFixtures.Responses
{
    public sealed class ConsultBalanceResponseFixture
    {
        private readonly ConsultBalanceResponse _consultBalanceResponse;
        private readonly Faker _faker = new("pt_BR");

        public ConsultBalanceResponseFixture()
        {
            _consultBalanceResponse = new ConsultBalanceResponse()
            {
                Number = _faker.Random.Number(1, 999).ToString(),
                Name = _faker.Person.FullName,
                DateTimeConsult = DateTime.Now,
                ValueBalance = _faker.Random.Decimal(0, 99999)
            };
        }

        public ConsultBalanceResponseFixture(int number, string nome, decimal valorSaldo)
        {
            _consultBalanceResponse = new ConsultBalanceResponse()
            {
                Number = number.ToString(),
                Name = nome,
                DateTimeConsult = DateTime.Now,
                ValueBalance = valorSaldo
            };
        }

        public ConsultBalanceResponseFixture(string errorMessage)
        {
            _consultBalanceResponse = new ConsultBalanceResponse()
            {
                ErrorMessage = errorMessage
            };
        }
        public ConsultBalanceResponse New() => _consultBalanceResponse;
    }
}
