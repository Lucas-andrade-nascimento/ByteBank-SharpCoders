﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Reflection;

namespace AndradeBank
{
    public class Program
    {
        public static void CadastroCliente(List<string> cpfs, List<string> nomes, List<string> senhas, List<double> saldos)
        {
            string cpf = null;
            Console.Write("Digite o cpf: ");
            cpf = Console.ReadLine();
            cpfs.Add(cpf);
            Console.Write("Digite o nome: ");
            nomes.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);

            Console.Clear();
            Console.WriteLine("Cliente cadastrado com sucesso!");
            int indexCpf = cpfs.FindIndex(cpfs => cpfs == cpf);
            DadosConta(indexCpf, cpfs, nomes, saldos);
            Console.WriteLine();


        }
        static void DadosConta(int index, List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Write($"CPF = {cpfs[index]} | Titular = {nomes[index]} ");
        }
        static void DeletarCliente(List<string> cpfs, List<string> nomes, List<string> senhas, List<double> saldos)
        {

            char opcaoDel = ' ';
            Console.Clear();
            Console.WriteLine("DELETAR CONTA");

            Console.Write("Digite o cpf da conta a ser deletada: ");
            String cpfDel = Console.ReadLine();
            int indexDel = cpfs.FindIndex(cpf => cpf == cpfDel);

            while (indexDel == -1 && opcaoDel != 'S' && opcaoDel != 'N')
            {
                Console.WriteLine($"Conta do CPF {cpfDel} nao encontrada.");
                Console.WriteLine("Não foi possivel realizar a operação.\n");
                Console.WriteLine("Tentar novamente? (S/N):");
                opcaoDel = char.ToUpper(char.Parse(Console.ReadLine()));



                if (opcaoDel == 'S')
                {
                    Console.Write("Digite o CPF da conta a ser deletada: ");
                    cpfDel = Console.ReadLine();
                    indexDel = cpfs.FindIndex(cpf => cpf == cpfDel);

                }
                else if (opcaoDel == 'N')
                {
                    Console.Clear();
                    Console.WriteLine("Retornando ao menu:");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Desculpe, '{opcaoDel}' não é uma opção invalida. Tente novamente  ");

                }


            }
            cpfs.Remove(cpfDel);
            nomes.RemoveAt(indexDel);
            senhas.RemoveAt(indexDel);
            saldos.RemoveAt(indexDel);
            Console.Clear();
            Console.WriteLine($"Conta do CPF {cpfDel} deletada com sucesso");
        }
        static void ListarContas(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("LISTA DE CONTAS:");
            for (int i = 0; i < cpfs.Count; i++)
            {
                DadosConta(i, cpfs, nomes, saldos);

            }
        }
        static void ContaDetalhes(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("DETALHAMENTO DE CONTA");

            Console.Write("Digite o CPF da conta desejada:");
            string indexCpf = Console.ReadLine();
            int indexConta = cpfs.FindIndex(cpf => cpf == indexCpf);
            DadosConta(indexConta, cpfs, nomes, saldos);
            Console.Write($"| Saldo = R${saldos[indexConta]:F2}");
            Console.WriteLine();
        }
        static void SaldoCliente(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("CONSULTA SALDO");
            Console.Write("Digite o CPF da conta:");
            String cpfConta = Console.ReadLine();
            int indexConta = cpfs.FindIndex(cpf => cpf == cpfConta);
            Console.WriteLine($"Saldo na conta do CPF {cpfConta}: ");
            Console.WriteLine($"R${saldos[indexConta]:F2}");

        }
        static void DepositoCliente(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("DEPOSITO EM CONTA");
            Console.Write("Digite o CPF da conta:");
            String cpfConta = Console.ReadLine();
            Console.Write("Digite o valor a ser depositado: ");
            double deposito = double.Parse(Console.ReadLine());
            int indexConta = cpfs.FindIndex(cpf => cpf == cpfConta);
            saldos[indexConta] += deposito;
            Console.WriteLine($"Saldo Atualiazdo na conta do CPF {cpfConta}: ");
            Console.WriteLine($"R${saldos[indexConta]:F2}");
        }
        static void SaqueCliente(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("SAQUE EM CONTA");
            Console.Write("Digite o CPF da conta:");
            String cpfConta = Console.ReadLine();
            Console.Write("Digite o valor a ser depositado: ");
            double saque = double.Parse(Console.ReadLine());
            int indexConta = cpfs.FindIndex(cpf => cpf == cpfConta);
            saldos[indexConta] -= saque;
            Console.WriteLine($"Saldo Atualiazdo na conta do CPF {cpfConta}: ");
            Console.WriteLine($"R${saldos[indexConta]:F2}");
        }
        public static void Transferencia(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("TRANSFERENCIA ENTRE CONTAS");
            Console.Write("Digite o CPF da primeira conta:");
            String cpfEnvia = Console.ReadLine();
            Console.Write("Digite o CPF da primeira conta:");
            String cpfRecebe = Console.ReadLine();
            Console.WriteLine("Digite o valor da transferencia: ");
            double valor = double.Parse(Console.ReadLine());

            int indexEnvia = cpfs.FindIndex(cpf => cpf == cpfEnvia);
            int indexRecebe = cpfs.FindIndex(cpf => cpf == cpfRecebe);

            saldos[indexEnvia] -= valor;
            saldos[indexRecebe] += valor;
            Console.WriteLine("Saldo Atualiazdo nas contas: ");
            Console.WriteLine($"Emissor CPF {cpfEnvia}: R${saldos[indexEnvia]:F2}");
            Console.WriteLine($"Receptor CPF {cpfRecebe}: R${saldos[indexRecebe]:F2}");

        }
        public static void Menu()
        {
            Console.WriteLine("1 - Login cliente");
            Console.WriteLine("2 - Cadastrar novo cliente");
            Console.WriteLine("3 - Deletar um cliente");
            Console.WriteLine("4 - Listar todas as contas");
            Console.WriteLine("5 - Detalhes de uma conta");
            Console.WriteLine("6 - Saldo");
            Console.WriteLine("7 - Deposito");
            Console.WriteLine("8 - Saque");
            Console.WriteLine("9 - Transferencia");
            Console.WriteLine("0 - Para deslogar da sua conta");
            Console.Write("Digite a opção desejada: ");
        }

        public static void LoginCliente(List<string> cpfs, List<string> senhas)
        {
            Console.Write("Digite o cpf:");
            string loginCpf = Console.ReadLine();
            int indexConta = cpfs.FindIndex(cpf => cpf == loginCpf);
            string senha = null;
            do
            {
                Console.WriteLine("Digite a senha:");
                senha = Console.ReadLine();
                Console.WriteLine("senha incorreta");

            } while (senhas[indexConta] != senha);

            Console.WriteLine("Login realizado com sucesso.");

        }
        public static void Main(string[] args)
        {
            List<string> cpfs = new List<string>();
            List<string> nomes = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int opcaoMenu;
            do
            {
                Menu();
                opcaoMenu = int.Parse(Console.ReadLine());
                Console.WriteLine("\n-----------------");

                switch (opcaoMenu)
                {
                    case 0:
                        Console.WriteLine("Muito obrigado por utilizar nosso banco. Volte sempre!");
                        break;
                    case 1:
                        Console.WriteLine("Vamos la:");
                        LoginCliente(cpfs, senhas);
                        break;
                    case 2:
                        CadastroCliente(cpfs, nomes, senhas, saldos);

                        break;
                    case 3:
                        DeletarCliente(cpfs, nomes, senhas, saldos);

                        break;
                    case 4:
                        ListarContas(cpfs, nomes, saldos);

                        break;
                    case 5:
                        ContaDetalhes(cpfs, nomes, saldos);

                        break;
                    case 6:
                        SaldoCliente(cpfs, nomes, saldos);
                        break;
                    case 7:
                        DepositoCliente(cpfs, nomes, saldos);
                        break;
                    case 8:
                        SaqueCliente(cpfs, nomes, saldos);
                        break;
                    case 9:
                        Transferencia(cpfs, cpfs, saldos);

                        break;

                }
                Console.WriteLine("-----------------");

            } while (opcaoMenu != 0);

            Console.Clear();
            Console.Write("Deseja realizar login novamente? (S/N):");
            char login = char.ToUpper(char.Parse(Console.ReadLine()));
            if (login == 'S')
                LoginCliente(cpfs, senhas);
            else if (login == 'N')
            {
                Console.WriteLine("Obrigado, volte sempre");
            }
            else
                Console.WriteLine("Opção nao encontrada. Entre no programa novamente.");

        }


    }
}
