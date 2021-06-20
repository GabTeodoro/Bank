namespace Bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                System.Console.WriteLine("Saldo insuficiente!");
                return false;

            }
            else
            {
                Saldo -= valorSaque;
                System.Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
                return true;
            }

        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            System.Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
        }

        public void Transfarir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                System.Console.WriteLine("Transferência realizada com sucesso!");
            }
        }

        public override string ToString()
        {
            var retorno = $"Nome: {Nome} | Saldo: {Saldo} | Crédito: {Credito} | TipoConta: {TipoConta}";
            return retorno;
        }
    }
}