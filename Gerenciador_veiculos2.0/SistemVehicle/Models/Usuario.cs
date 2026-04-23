using System;
using System.Collections.Generic;
using System.Text;

namespace SistemVehicle.Models
{
    internal class Usuario
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Id { get; private set; }
        public string Tipo { get; private set; }

        public Usuario() { }
        public Usuario(string email, string senha) { }

        public Usuario(string nome, DateTime dataNascimento, string telefone, string email, string senha)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Senha = senha;
        }

    }
}
