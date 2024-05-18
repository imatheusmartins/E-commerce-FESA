using System;

namespace N1.Models
{

    public class UsuarioViewModel : PadraoViewModel
    {
        public string NomeUsuario { get; set; } // Para armazenar o nome de usuário
        private bool TipoUsuario { get; set;}
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        // Novos atributos adicionados
        public string Rua { get; set; } // Para armazenar o nome da rua
        public string Numero { get; set; } // Para armazenar o número do endereço
        public string Bairro { get; set; } // Para armazenar o bairro
        public string Cep { get; set; } // Para armazenar o CEP
        public string TelefoneCelular { get; set; } // Para armazenar o número de telefone celular
        public string Email { get; set; } // Para armazenar o endereço de e-mail
        public string Senha { get; set; } // Para armazenar a senha
        public DateTime DataRegistro { get; set;} = DateTime.Now;
    }
}
