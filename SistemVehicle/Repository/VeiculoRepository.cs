using System;
using Microsoft.Data.SqlClient;
using SistemVehicle.Models;

namespace SistemVehicle.Repository
{
    class VeiculoRepository
    {
        private string connectionString =
                "Server=localhost;Database=VehicleSystem;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Cadastrar_Veiculo(Veiculo veiculo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO Veiculo
                               (Marca, Modelo, Ano, Tipo, UsuarioId)
                               VALUES 
                               (@Marca, @Modelo, @Ano, @Tipo, @UsuarioId)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Marca", veiculo.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                    cmd.Parameters.AddWithValue("@Ano", veiculo.Ano);
                    cmd.Parameters.AddWithValue("@Tipo", veiculo.Tipo);
                    cmd.Parameters.AddWithValue("@UsuarioId", veiculo.UsuarioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}