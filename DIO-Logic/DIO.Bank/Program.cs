using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Conta minhaConta = new(TipoConta.PessoaFisica, 0, 0, "Ettore");
            System.Console.WriteLine(minhaConta.ToString());

            string opcaoUsuario = "";

            do
            {
                opcaoUsuario  = ObterOpcaoUsuario();
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        break;
                }
            } while (opcaoUsuario.ToUpper() != "X");
        }

        private static void Depositar()
        {
            System.Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Digite a conta de origem");
            int indiceConta = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite conta destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite valor a ser transferido");
            double valorTransferencia = Double.Parse(Console.ReadLine());
            listaContas[indiceConta].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Insira nova conta");
            Console.WriteLine("Digite 1 para Conta física ou 2 para Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaCredito, credito: entradaCredito, nome: entradaNome);
            listaContas.Add(novaConta);
        }

        private static void Sacar()
        {
            System.Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser sacado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorDeposito);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar Contas");
            if(listaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                System.Console.Write("#{0} ", i);
                System.Console.WriteLine(conta);
            }
        }
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"MRSPACE BANK a seu dispor!\nInforme opção desejada");
            System.Console.WriteLine($"\n1 - Listar contas\n2 - Inserir nova conta\n3 - Transferir\n4 - Sacar\n5 - Depositar\nC - Limpar Tela\nX - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }

    }
}