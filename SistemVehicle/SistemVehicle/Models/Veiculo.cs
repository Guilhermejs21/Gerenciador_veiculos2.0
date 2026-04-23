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
        public string Categoria { get; set; }

        public Veiculo() { }

        public Veiculo(string marca, string modelo, int ano, int usuarioId, string categoria)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            UsuarioId = usuarioId;
            Categoria = categoria;
        }

    }
}
