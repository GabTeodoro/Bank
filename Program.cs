using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        TransferirConta();
                        break;
                    case "4":
                        SacarConta();
                        break;
                    case "5":
                        DepositarConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por usar o nosso serviços!");
        }

        private static string ObterOpcaoUsuario()
        {

            System.Console.WriteLine();
            System.Console.WriteLine("DIO Bank ao seu dispor!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1. Listar contas");
            System.Console.WriteLine("2. Inserir nova conta");
            System.Console.WriteLine("3. Transferir");
            System.Console.WriteLine("4. Sacar");
            System.Console.WriteLine("5. Depositar");
            System.Console.WriteLine("C. Limpar Tela");
            System.Console.WriteLine("X. Sair");

            System.Console.WriteLine();
            String opcaoUsuario = Console.ReadLine().ToUpper();


            return opcaoUsuario;
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir nova conta");

            System.Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Nome da Conta: ");
            var nome = Console.ReadLine();

            System.Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            System.Console.Write("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta conta = new Conta(nome, saldo, credito, (TipoConta)tipoConta);
            listContas.Add(conta);
        }

        private static void ListarConta()
        {
            System.Console.WriteLine("Listar Contas:");

            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma lista cadastrada.");
            }
            else
            {
                var i = 0;
                foreach (Conta conta in listContas)
                {
                    System.Console.Write($"#{i} - ");
                    System.Console.WriteLine(conta.ToString());
                    i++;
                }
            }

        }

        private static void SacarConta()
        {
            System.Console.WriteLine("Sacar valor:");
            System.Console.Write("Digite o número da conta: ");
            int conta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[conta].Sacar(valor);
        }

        private static void DepositarConta()
        {
            System.Console.WriteLine("Deposita valor:");

            System.Console.Write("Digite o número da conta: ");
            int conta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[conta].Depositar(valor);
        }

        private static void TransferirConta()
        {
            System.Console.WriteLine("Transferir valor para outra conta: ");

            System.Console.Write("Digite o número da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o número da conta de destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[contaOrigem].Transfarir(valor, listContas[contaDestino]);
        }
    }
}
