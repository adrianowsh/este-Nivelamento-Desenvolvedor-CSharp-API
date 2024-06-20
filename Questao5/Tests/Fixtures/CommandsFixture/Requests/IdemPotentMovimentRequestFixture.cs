using Questao5.Application.Commands.Requests;

namespace Questao5.Tests.Fixtures.CommandsFixture.Requests
{
    public class IdemPotentMovimentRequestFixture
    {
        private readonly IdemPotentMovimentRequest instance;

        public IdemPotentMovimentRequestFixture()
        {
            instance = new IdemPotentMovimentRequest()
            {
                Chave_IdemPotencia = Guid.NewGuid(),
                Request = string.Empty,
                Result = string.Empty
            };
        }

        public IdemPotentMovimentRequestFixture(Guid IdMovimento)
        {
            instance = new IdemPotentMovimentRequest()
            {
                Chave_IdemPotencia = Guid.NewGuid(),
                Request = string.Empty,
                Result = IdMovimento.ToString()
            };
        }

        public IdemPotentMovimentRequest Build() => instance;
    }
}
