using System;
using Microsoft.Data.SqlClient;
using SistemVehicle.Models;

namespace SistemVehicle.Repository
{
    class UsuarioRepository
    {
        private string connectionString =
                "Server=localhost;Database=VehicleSystem;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Cadastrar_User(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO Usuario
                               (Nome, DataNascimento, Telefone, Email, Senha)
                               VALUES 
                               (@Nome, @DataNascimento, @Telefone, @Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                    cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Usuario Login(string email, string senha)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT * FROM Usuario 
                       WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                DataNascimento = Convert.ToDateTime(reader["DataNascimento"])
                            };
                        }
                    }
                }
            }

            return null; // não encontrou
        }
    }
}