using System;
using System.Collections.Generic;
using System.Text;

namespace SistemVehicle.Models
{
    internal class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int UsuarioId { get; set; }
        public int Id { get; private set; }
        public string Tipo { get; set; }

        public Veiculo() { }
        public Veiculo(string marca, string modelo, int ano, int usuarioId, string tipo)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            UsuarioId = 2004;
            Tipo = tipo;
        }

    }
}
