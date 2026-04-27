using System;
using System.Collections.Generic;
using System.Text;
using SistemVehicle.Models;
using SistemVehicle.Repository;

namespace SistemVehicle.Services
{
    class VeiculoService
    {
        private VeiculoRepository repository = new VeiculoRepository();

        public void Cadastrar_Veiculo(Veiculo veiculo)
        {
            repository.Cadastrar_Veiculo(veiculo);
        }
    }
}
