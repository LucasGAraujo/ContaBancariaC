using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancaria.Conta;
using ContaBancaria.InMemory;

namespace ContaBancaria
{
    internal class Program
    {

        private static ContaManager manager = new ContaManager(new ContaInMemory());

        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao Sistema Bancário");

            bool exit = false;


            while (exit == false)
            {
                ExibeMenu();

                Console.WriteLine("Deseja sair? (Y/N)");
                var opcao = Console.ReadLine();

                if (opcao == "Y")
                    exit = true;
            }
        }

        private static void ExibeMenu()
        {
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Exibir Saldo");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Depositar");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarConta();
                    break;
                case "2":
                    ExibirSaldo();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Depositar();
                    break;

                default:
                    Console.WriteLine("Opção invalida, tente novamente");
                    break;
            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o cpf que contem as contas");
            var cpf = Console.ReadLine();

            Console.WriteLine("Qual valor que você deseja depositar?");
            var valor = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("De onde você deseja depositar o valor? (1 - Corrente / 2 - Poupança)");
            var opcao = Console.ReadLine();

            //Buscas as contas do usuário que deseja depositar o recurso;
            var contas = manager.ObterContas(cpf);

            var contaDeposito = contas.Where(x =>
            {
                if (opcao == "1" && x is ContaCorrente)
                    return true;
                else if (opcao == "2" && x is ContaPoupanca)
                    return true;
                return false;
            }).FirstOrDefault();

            contaDeposito.Depositar(valor);

            manager.Atualizar(contaDeposito);

        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o cpf que contem as contas");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite o cpf que irá receber a transferência");
            var cpfDestino = Console.ReadLine();

            Console.WriteLine("Qual valor que você deseja transferir?");
            var valor = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("De onde você deseja retirar o valor? (1 - Corrente / 2 - Poupança)");
            var opcao = Console.ReadLine();

            //Conta que irá receber o deposito
            var contaDestino = manager.ObterContas(cpfDestino).FirstOrDefault();

            //Buscas as contas do usuário que deseja transferir o recurso;
            var contas = manager.ObterContas(cpf);

            var contaOrigem = contas.Where(x =>
            {
                if (opcao == "1" && x is ContaCorrente)
                    return true;
                else if (opcao == "2" && x is ContaPoupanca)
                    return true;
                return false;
            }).FirstOrDefault();

            //Transfere da conta origem para conta destino
            contaOrigem.Transferir(contaDestino, valor);

            //Atualiza o saldo das contas
            manager.Atualizar(contaDestino);
            manager.Atualizar(contaOrigem);

        }

        private static void ExibirSaldo()
        {
            Console.WriteLine("Digite o cpf que contem as contas");
            var cpf = Console.ReadLine();

            var contas = manager.ObterContas(cpf);

            foreach (var item in contas)
            {
                var tipoConta = item is ContaCorrente ? "Conta Corrente" : "Conta Poupança";

                Console.WriteLine("===================================");
                Console.WriteLine($"Exibindo saldo da {tipoConta}");
                item.ExibirSaldo();
            }
            Console.WriteLine("===================================");

        }

        private static void CriarConta()
        {
            Console.WriteLine("Para criar conta, informe o seu CPF");
            var cpf = Console.ReadLine();

            Console.WriteLine("Informe o seu nome");
            var nome = Console.ReadLine();

            Console.WriteLine("Informe a Data de nascimento");
            var dt = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Qual tipo de conta voce deseja criar? (1 - Corrente / 2 - Poupança)");

            var opcao = Console.ReadLine();

            Conta.Conta conta;

            if (opcao == "1")
                conta = new ContaCorrente();
            else if (opcao == "2")
                conta = new ContaPoupanca();
            else
            {
                Console.WriteLine("Opcao invalida");
                return;
            }

            conta.Nome = nome;
            conta.DataNascimento = dt;
            conta.CPF = cpf;

            manager.Cadastrar(conta);

        }
    }
}