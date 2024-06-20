using Bogus;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.CommandStore.Requests;

namespace Questao5.Tests.Fixtures.CommandsFixture.Requests
{
    public sealed class MovimentAccountCommandRequestFixture
    {
        private readonly MovimentAccountCommandRequest instance;
        private readonly Faker _faker = new("pt_BR");

        public MovimentAccountCommandRequestFixture()
        {
            instance = new MovimentAccountCommandRequest(
                 Guid.NewGuid(),
                 MovimentType.Credito,
                _faker.Random.Decimal(1, (decimal)9999.99)
            );
        }

        public MovimentAccountCommandRequestFixture(Guid idContaCorrente, MovimentType tipoMovimento)
        {
            instance = new MovimentAccountCommandRequest(

                idContaCorrente,
                tipoMovimento,
                _faker.Random.Decimal(1, (decimal)9999.99)
            );
        }

        public MovimentAccountCommandRequest Buid() => instance;
    }
}