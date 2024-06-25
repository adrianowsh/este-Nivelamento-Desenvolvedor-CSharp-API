namespace Questao5.Domain.Constants
{
    public static class ErrorMessages
    {
        public const string ERROR_CONSULT = "Saldo inválido.";
        public const string VALUE_REQUIDED = "Campo obrigatório.";
        public const string INVALID_VALUE = "Somente valores positivos podem ser recebidos";
        public const string INVALID_TYPE = "Somente os tipos “Débito” ou “Crédito” podem ser permitidos.";
        public const string INVALID_ACCOUNT_MOVEMENT = "Somente contas correntes cadastradas podem receber movimentação.";
        public const string INACTIVE_ACCOUNT_MOVIMENT = "Somente contas correntes ativas podem receber movimentação.";
        public const string INVALID_ACCOUNT_CONSULT = "Somente contas correntes cadastradas podem consultar o saldo.";
        public const string INACTIVE_ACCOUNT_CONSULT = "Somente contas correntes ativas podem consultar o saldo.";
    }
}
