using Questao5.Application;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Services
{
    public static class AccountServices
    {
        public static decimal SumMoviments(IList<Movimento> moviments, MovimentType movimentType)
        {
            var movimentTypeChar = MovimentTypeConvert.ConvertToChar(movimentType);
            return moviments.Where(x => x.TipoMovimento == movimentTypeChar.ToString()).Sum(x => x.Valor);
        }
    }
}
