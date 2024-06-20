using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.Responses
{
    public class ConsultIdemPotenceResponse
    {
        public Guid IdMovimentProcessed { get; set; }

        public ConsultIdemPotenceResponse() { }

        public static ConsultIdemPotenceResponse ConvertTo(IdemPotencia idemPotencia)
        {
            return new ConsultIdemPotenceResponse()
            {
                IdMovimentProcessed = new Guid(idemPotencia.Resultado)
            };
        }
    }
}
