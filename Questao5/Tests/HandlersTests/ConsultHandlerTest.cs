using MediatR;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Questao5.Application.Handlers;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Constants;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Repositories.Queries;
using Questao5.Tests.Fixture.QueriesFixtures.Requests;
using Questao5.Tests.Fixtures.QueriesFixture.Responses;
using Questao5.Tests.Fixtures.QueriesFixtures.Requests;
using Questao5.Tests.Fixtures.QueriesFixtures.Responses;
using Xunit;

namespace Questao5.Tests.HandlersTests
{
    public class ConsultHandlerTest
    {
        private IConsultHandler _handlerMock;
        private IAccountQueriesRepository _repositoryMock = Substitute.For<IAccountQueriesRepository>();

        public ConsultHandlerTest()
        {
            _handlerMock = new ConsultHandler(_repositoryMock);
        }

        [Fact]
        public async Task SendCommand_Consult_MustCallHandlerCorrect()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var comando = new ConsultRequestFixture().New();

            // Act
            await mediator.Send(comando);

            // Assert
            await mediator.Received().Send(Arg.Is<ConsultRequest>(c => c.Number == comando.Number), default);
        }

        [Fact]
        public async Task Consult_ReturnConsultBalanceResponse_Success()
        {
            // Arrange
            var request = new ConsultRequestFixture().New();
            var responseConsultaDadosBancarios = new ConsultAccountResponseFixture(request.Number, AccountSituation.Ativa).New();
            var requestConsultaSaldoQuery = new ConsultBalanceQueryRequestFixture(responseConsultaDadosBancarios.IdAccount).New();
            var responseConsultaSaldoQuery = new ConsultBalanceQueryResponseFixture().New();
            var response = new ConsultBalanceResponseFixture(
                responseConsultaDadosBancarios.Number,
                responseConsultaDadosBancarios.Name,
                responseConsultaSaldoQuery.ValueBalance).New();

            _repositoryMock.ConsultAccountAsync(request.Number).Returns(responseConsultaDadosBancarios);
            _repositoryMock.ConsultBalanceAsync(Arg.Any<ConsultBalanceQueryRequest>()).Returns(responseConsultaSaldoQuery);

            // Act
            var handleResult = await _handlerMock.Handle(request);

            // Assert
            Assert.Equal(expected: response.Number, actual: handleResult.Number);
            Assert.Equal(expected: response.Name, actual: handleResult.Name);
            Assert.Equal(expected: response.ValueBalance, actual: handleResult.ValueBalance);
        }

        [Fact]
        public async Task Consult_Return_InactveAccount()
        {
            // Arrange
            var request = new ConsultRequestFixture().New();
            var responseConsultaDadosBancarios = new ConsultAccountResponseFixture(request.Number, AccountSituation.Inativa).New();
            var erroMessage = ErrorMessages.INACTIVE_ACCOUNT_CONSULT;
            var response = new ConsultBalanceResponseFixture(erroMessage).New();

            _repositoryMock.ConsultAccountAsync(request.Number).Returns(responseConsultaDadosBancarios);

            // Act
            var handleResult = await _handlerMock.Handle(request);

            // Assert
            Assert.Equal(expected: response.ErrorMessage, actual: handleResult.ErrorMessage);
        }

        [Fact]
        public async Task Consult_Return_InvalidAccount()
        {
            // Arrange
            var request = new ConsultRequestFixture().New();
            var erroMessage = ErrorMessages.INVALID_ACCOUNT_CONSULT;
            var response = new ConsultBalanceResponseFixture(erroMessage).New();

            _repositoryMock.ConsultAccountAsync(request.Number).ReturnsNull();

            // Act
            var handleResult = await _handlerMock.Handle(request);

            // Assert
            Assert.Equal(expected: response.ErrorMessage, actual: handleResult.ErrorMessage);
        }

        [Fact]
        public async Task Consult_Return_ErrorConsult()
        {
            // Arrange
            var request = new ConsultRequestFixture().New();
            var responseConsultaDadosBancarios = new ConsultAccountResponseFixture(request.Number, AccountSituation.Ativa).New();
            var erroMessage = ErrorMessages.ERROR_CONSULT;
            var response = new ConsultBalanceResponseFixture(erroMessage).New();

            _repositoryMock.ConsultAccountAsync(request.Number).Returns(responseConsultaDadosBancarios);
            _repositoryMock.ConsultBalanceAsync(Arg.Any<ConsultBalanceQueryRequest>()).ReturnsNull();

            // Act
            var handleResult = await _handlerMock.Handle(request);

            // Assert
            Assert.Equal(expected: response.ErrorMessage, actual: handleResult.ErrorMessage);
        }
    }
}
