using Questao5.Domain.Enumerators;

namespace Questao5.Application
{
    public static class MovimentTypeConvert
    {
        public static char ConvertToChar(MovimentType movimentType)
        {
            return movimentType switch
            {
                MovimentType.Credito => 'C',
                MovimentType.Debito => 'D',
                _ => 'E',
            };
        }

        public static MovimentType ConvertToEnum(char movimentType)
        {
            return movimentType switch
            {
                'C' => MovimentType.Credito,
                'D' => MovimentType.Debito,
                _ => throw new Exception(),
            };
        }
    }
}
