using SistemVehicle.Models;
using SistemVehicle.Repository;

namespace SistemVehicle.Services
{
    class UsuarioService
    {
        private UsuarioRepository repository = new UsuarioRepository();

        public void Cadastrar_User(Usuario usuario)
        {
            // validação simples
            if (string.IsNullOrEmpty(usuario.Email) ||
                string.IsNullOrEmpty(usuario.Senha))
            {
                return;
            }

            repository.Cadastrar_User(usuario);
        }
        public Usuario FazerLogin(string email, string senha)
        {
            return repository.Login(email, senha);
        }
    }
}
