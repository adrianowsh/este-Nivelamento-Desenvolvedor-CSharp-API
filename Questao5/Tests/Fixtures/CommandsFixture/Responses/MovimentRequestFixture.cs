using Bogus;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Enumerators;

namespace Questao5.Tests.Fixtures.CommandsFixture.Requests
{
    public class MovimentRequestFixture
    {
        private readonly MovimentRequest _movimentRequest;
        private readonly Faker _faker = new("pt_BR");
        public MovimentRequestFixture()
        {
            _movimentRequest = new MovimentRequest()
            {
                Number = _faker.Random.Number(1, 999),
                MovimentType = MovimentType.Credito,
                Value = _faker.Random.Decimal(1, 9999),
                IdIdemPotence = Guid.NewGuid()
            };
        }

        public MovimentRequest Setup_Debito()
        {
            return new MovimentRequest()
            {
                Number = _faker.Random.Number(1, 999),
                MovimentType = MovimentType.Debito,
                Value = _faker.Random.Decimal(1, 9999),
                IdIdemPotence = Guid.NewGuid()
            };
        }

        public MovimentRequest Setup_IdemPotencia(Guid idIdemPotencia)
        {
            return new MovimentRequest()
            {
                Number = _faker.Random.Number(1, 999),
                MovimentType = MovimentType.Debito,
                Value = _faker.Random.Decimal(1, 9999),
                IdIdemPotence = idIdemPotencia
            };
        }

        public MovimentRequest New() => _movimentRequest;
    }
}
