using System;

namespace EcommerceLicenca.Models
{

    public class UsuarioViewModel : PadraoViewModel
    {
		public string NomeUsuario { get; set; } 
        public int NivelAcesso { get;set; } 
        public string PerfilUsuario { get; set;}
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } 
        public string Senha { get; set; } 
    }
}
