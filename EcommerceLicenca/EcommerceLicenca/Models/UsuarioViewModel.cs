using System;

namespace EcommerceLicenca.Models
{

    public class UsuarioViewModel : PadraoViewModel
    {
		public string NomeUsuario { get; set; } // Para armazenar o nome de usuário
        public string PerfilUsuario { get; set;}
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } // Para armazenar o endereço de e-mail
        public string Senha { get; set; } // Para armazenar a senha
    }
}
