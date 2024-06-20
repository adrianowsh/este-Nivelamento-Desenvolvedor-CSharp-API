namespace Questao1
{
   class ContaBancaria
   {
      const double TaxaDeSaque = 3.50d;
      public string Titular { get; private set; }
      public int Numero { get; private set; }
      public double DepositoInicial { get; private set; }
      public double Saldo { get; private set; }

      public ContaBancaria(int nUmero, string titular)
      {
         Titular = titular;
         Numero = nUmero;
         Saldo = 0.0d;
      }

      public ContaBancaria(int nUmero, string titular, double deposito)
      {
         Titular = titular;
         Numero = nUmero;
         Saldo = deposito;
      }

      public void Deposito(double quantia)
      {
         Saldo += quantia;
      }

      public void Saque(double quantia)
      {
         Saldo -= quantia;
         DescontarTaxaDeSaque(TaxaDeSaque);
      }

      public void MudarNomeTitular(string novoNome)
      {
         Titular = novoNome;
      }

      public void DescontarTaxaDeSaque(double valorDaTaxa)
      {
         Saldo -= valorDaTaxa;
      }

      public double ObterSaldo()
      {
         return Saldo;
      }

      public override string ToString()
      {
         return $"Conta {Numero}, Titular: {Titular}, Saldo: {Saldo:C2}";
      }
   }
}
