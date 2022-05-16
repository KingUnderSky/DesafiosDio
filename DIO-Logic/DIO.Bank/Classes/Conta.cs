namespace DIO.Bank
{
    public class Conta
    {
        private string Nome { get; set; }
        
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }
        
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque) 
        {
            //  Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                System.Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            System.Console.WriteLine("O saldo atual da conta é de {0} é R$ {1}",this.Nome, this.Saldo);
            
            return true;
        }      

        public void Depositar(double valorDeposito) 
        {
            this.Saldo += valorDeposito;
            System.Console.WriteLine("O saldo atual da conta é de {0} é R$ {1}",this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);
        }
        public override string ToString()
        {
            return $"TipoConta: {this.TipoConta} | Nome: {this.Nome} | Saldo: {this.Saldo} | Crédito: {this.Credito}";
        }
    }
}