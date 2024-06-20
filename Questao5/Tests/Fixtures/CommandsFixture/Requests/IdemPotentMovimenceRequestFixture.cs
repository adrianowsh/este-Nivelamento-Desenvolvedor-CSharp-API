using Questao5.Application.Commands.Requests;

namespace Questao5.Tests.Fixtures.CommandsFixture.Requests
{
    public class IdemPotenceMovimentRequestFixture
    {
        private readonly IdemPotenceMovimentRequest _idemPotenceMovimentRequest;

        public IdemPotenceMovimentRequestFixture()
        {
            _idemPotenceMovimentRequest = new IdemPotenceMovimentRequest(
                Guid.NewGuid(),
                string.Empty,
                string.Empty
            );
        }
        public IdemPotenceMovimentRequestFixture(Guid IdMovimento)
        {
            _idemPotenceMovimentRequest = new IdemPotenceMovimentRequest(

              Guid.NewGuid(),
              string.Empty,
              IdMovimento.ToString()
            );
        }
        public IdemPotenceMovimentRequest New() => _idemPotenceMovimentRequest;
    }
}
