using System;
using System.Collections.Generic;
using SistemVehicle.Services;
using SistemVehicle.Models;

namespace Program.SistemVehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceUser = new UsuarioService();
            var serviceVeiculo = new VeiculoService();

            Console.WriteLine("Bem-vindo ao Gerenciador de Veículos!");

            while (true)
            {
                Console.WriteLine("\nO que deseja fazer?");
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

                        Console.WriteLine("Digite a senha:");
                        string l_senha = Console.ReadLine();

                        var usuario = serviceUser.FazerLogin(l_email, l_senha);

                        if (usuario == null)
                        {
                            Console.WriteLine("Email ou senha inválidos.");
                            break;
                        }

                        Console.WriteLine($"Bem-vindo, {usuario.Nome}!");

                        while (true)
                        {
                            Console.WriteLine("\n1 - Ver dados\n2 - Cadastrar\n3 - Buscar Veiculo\n5 - Atualizar multas\n0 - Sair");

                            int opcao = int.Parse(Console.ReadLine());

                            switch (opcao)
                            {
                                case 1:
                                    Console.WriteLine($"\nNome: {usuario.Nome}");
                                    Console.WriteLine($"Email: {usuario.Email}");
                                    Console.WriteLine($"Telefone: {usuario.Telefone}");
                                    Console.WriteLine($"Data de nascimento: {usuario.DataNascimento.ToShortDateString()}\n'");
                                    break;
                                case 2:
                                    Console.WriteLine("\nTipo de veículo:");
                                    Console.WriteLine("1 - Carro\n2 - Moto");

                                    int tipo = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Marca:");
                                    string marca = Console.ReadLine();

                                    Console.WriteLine("Modelo:");
                                    string modelo = Console.ReadLine();

                                    Console.WriteLine("Ano:");
                                    int ano = int.Parse(Console.ReadLine());

                                    var veiculo = new Veiculo
                                    {
                                        Marca = marca,
                                        Modelo = modelo,
                                        Ano = ano,
                                        Tipo = tipo == 1 ? "Carro" : "Moto",
                                        UsuarioId = usuario.Id
                                    };

                                    serviceVeiculo.Cadastrar_Veiculo(veiculo);

                                    Console.WriteLine("Veículo cadastrado!");
                                    break;
                                case 3:
                                    Console.WriteLine("\nDigite o ID do veículo:");
                                    int id = int.Parse(Console.ReadLine());
                                    var veiculoEncontrado = serviceVeiculo.Buscar_Veiculo(id);
                                    if (veiculoEncontrado == null)
                                    {
                                        Console.WriteLine("Veículo não encontrado.");
                                        break;
                                    }
                                    Console.WriteLine($"\nID: {veiculoEncontrado.Id}");
                                    Console.WriteLine($"Marca: {veiculoEncontrado.Marca}");
                                    Console.WriteLine($"Modelo: {veiculoEncontrado.Modelo}");
                                    Console.WriteLine($"Ano: {veiculoEncontrado.Ano}");
                                    Console.WriteLine($"Tipo: {veiculoEncontrado.Tipo}");
                                    Console.WriteLine($"Multas: {veiculoEncontrado.Multas}\n");
                                    break;

                                case 0:
                                    goto MENU_PRINCIPAL;

                                default:
                                    Console.WriteLine("Opção inválida");
                                    break;
                            }
                        }

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            MENU_PRINCIPAL:;
            }
        }
    }
}