using Questao5.Application.Commands.Responses;

namespace Questao5.Tests.Fixtures.CommandsBuilders.Responses
{
    public class MovimentResponseFixture
    {
        private readonly MovimentResponse instance;

        public MovimentResponseFixture()
        {
            instance = new MovimentResponse()
            {
                IdMoviment = Guid.NewGuid()
            };
        }

        public MovimentResponseFixture(Guid id)
        {
            instance = new MovimentResponse()
            {
                IdMoviment = id
            };
        }

        public MovimentResponseFixture(string erroMessage)
        {
            instance = new MovimentResponse()
            {
                ErrorMessage = erroMessage
            };
        }

        public MovimentResponse Build() => instance;
    }
}
