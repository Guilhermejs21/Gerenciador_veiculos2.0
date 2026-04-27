using System;
using System.Collections.Generic;
using System.Linq;
using SistemVehicle.Services;
using SistemVehicle.Models;
using SistemVehicle.Repository;
using System.Security.Cryptography.X509Certificates; 

namespace Program.SistemVehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceUser = new UsuarioService();
            var serviceVeiculo = new VeiculoService();

            Console.WriteLine("Bem-vindo ao Sistema de Gerenciamento de Veículos!");
            Console.WriteLine("Digite a Operação!!");
            while (true)
            {
                Console.WriteLine("1 - Cadastro \n2 - Login \n0 - Sair");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("\nNome:");
                        string cd_nome = Console.ReadLine();

                        Console.WriteLine("Email:");
                        string cd_email = Console.ReadLine();

                        Console.WriteLine("Telefone:");
                        string cd_telefone = Console.ReadLine();

                        Console.WriteLine("Data de nascimento:");
                        DateTime cd_data = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Senha:");
                        string cd_senha = Console.ReadLine();

                        var cd_usuario = new Usuario
                        {
                            Nome = cd_nome,
                            DataNascimento = cd_data,
                            Telefone = cd_telefone,
                            Email = cd_email,
                            Senha = cd_senha
                        };
                        serviceUser.Cadastrar_User(cd_usuario);

                        break;
                    case 2:

                        Console.WriteLine("\nDigite o email:");
                        string l_email = Console.ReadLine();

                        Console.WriteLine("Digite a senha:\n");
                        string l_senha = Console.ReadLine();

                        var usuario = serviceUser.FazerLogin(l_email, l_senha);

                        if (usuario != null)
                        {
                            Console.WriteLine($"Bem-vindo, {usuario.Nome}!");
                            Console.WriteLine("Cadastre seu veiculo.\n");

                            Console.WriteLine("Marca:");
                            string cd_marca = Console.ReadLine();

                            Console.WriteLine("Modelo:");
                            string cd_modelo = Console.ReadLine();

                            Console.WriteLine("Ano:");
                            int cd_ano = int.Parse(Console.ReadLine());

                            Console.WriteLine("Tipo:");
                            string cd_tipo = (Console.ReadLine());

                            var cd_veiculo = new Veiculo
                            {
                                Marca = cd_marca,
                                Modelo = cd_modelo,
                                Ano = cd_ano,
                                Tipo = cd_tipo,
                                UsuarioId = 2004
                            };
                            serviceVeiculo.Cadastrar_Veiculo(cd_veiculo);

                        }
                        else
                        {
                            Console.WriteLine("Email ou senha inválidos.");
                        }
                        break;
                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Digite novamente.");
                        break;
                }
            }
        }
    }  
}