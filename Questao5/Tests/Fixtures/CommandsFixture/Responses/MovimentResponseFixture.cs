using Questao5.Application.Commands.Responses;

namespace Questao5.Tests.Fixtures.CommandsBuilders.Responses
{
    public class MovimentResponseFixture
    {
        private readonly MovimentResponse _movimentResponse;

        public MovimentResponseFixture()
        {
            _movimentResponse = new MovimentResponse()
            {
                IdMoviment = Guid.NewGuid()
            };
        }

        public MovimentResponseFixture(Guid id)
        {
            _movimentResponse = new MovimentResponse()
            {
                IdMoviment = id
            };
        }

        public MovimentResponseFixture(string erroMessage)
        {
            _movimentResponse = new MovimentResponse()
            {
                ErrorMessage = erroMessage
            };
        }

        public MovimentResponse New() => _movimentResponse;
    }
}
