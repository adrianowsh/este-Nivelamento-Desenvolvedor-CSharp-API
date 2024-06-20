namespace Questao5.Domain.Entities
{
    public sealed class Movimento
    {
        private Movimento(string idContaCorrente, string dataMovimento, string tipoMovimento, decimal valor)
        {
            IdMovimento = Guid.NewGuid().ToString();
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
        public string IdMovimento { get; private set; }
        public string IdContaCorrente { get; private set; }
        public string DataMovimento { get; private set; }
        public string TipoMovimento { get; private set; }
        public decimal Valor { get; private set; }

        private Movimento()
        {
        }

        public static Movimento NovoMovimento(
            string idContaCorrente,
            string dataMovimento,
            string tipoMovimento,
            decimal valor
        )
        {
            var movimento = new Movimento(
                idContaCorrente,
                dataMovimento,
                tipoMovimento,
                valor);
            return movimento;
        }
    }
}