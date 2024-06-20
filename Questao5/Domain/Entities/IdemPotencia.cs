namespace Questao5.Domain.Entities
{
    public sealed class IdemPotencia
    {
        private IdemPotencia(string chaveIdemPotencia, string requisicao, string resultado)
        {
            ChaveIdemPotencia = chaveIdemPotencia;
            Requisicao = requisicao;
            Resultado = resultado;
        }
        public string ChaveIdemPotencia { get; private set; }
        public string Requisicao { get; private set; }
        public string Resultado { get; private set; }

        private IdemPotencia()
        {
        }

        public static IdemPotencia NovaIdemPotencia(string chave, string requisicao, string resultado)
        {
            var idemPotencia = new IdemPotencia(
                chaveIdemPotencia: chave,
                requisicao,
                resultado
            );
            return idemPotencia;
        }
    }
}