using System;
using System.Collections.Generic;
using System.Linq;
using SistemVehicle.Services;
using SistemVehicle.Models;
using System.Security.Cryptography.X509Certificates; 
namespace Program.SistemVehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new UsuarioService();
            Console.WriteLine("Bem-vindo ao Sistema de Gerenciamento de Veículos!");
            Console.WriteLine("Digite a Operação!!");
            while (true)
            {
                Console.WriteLine("1 - Cadastro \n2 - Login \n0 - Sair");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Nome:");
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
                        service.Cadastrar_User(cd_usuario);

                        break;
                    case 2:

                        Console.WriteLine("Digite o email:");
                        string l_email = Console.ReadLine();

                        Console.WriteLine("Digite a senha:");
                        string l_senha = Console.ReadLine();

                        var usuario = service.FazerLogin(l_email, l_senha);

                        if (usuario != null)
                        {
                            Console.WriteLine($"Bem-vindo, {usuario.Nome}!");
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