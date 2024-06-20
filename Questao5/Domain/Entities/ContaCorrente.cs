namespace Questao5.Domain.Entities
{
    public sealed class ContaCorrente
    {
        private ContaCorrente(string numero, string nome, int ativo)
        {
            IdContaCorrente = Guid.NewGuid().ToString();
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
        }

        private ContaCorrente()
        {
        }
        public string IdContaCorrente { get; private set; }
        public string Numero { get; private set; }
        public string Nome { get; private set; }
        public int Ativo { get; private set; }


        public static ContaCorrente NovaContaCorrente(string numero, string nome, int ativo)
        {
            var contaCorrente = new ContaCorrente(
                numero,
                nome,
                ativo
            );
            return contaCorrente;
        }
    }
}