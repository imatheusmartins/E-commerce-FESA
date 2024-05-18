using System;

namespace EcommerceLicenca.Models
{

    public class LicencaViewModel : PadraoViewModel
    {
        public string NomeLicenca { get; set; }
        public int FornecedorId { get; set; }
        public double ValorMensal { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataValidade { get; set; } // Data de validade da licença
        public string VersaoLicenca { get; set; } // Versão do software
        public string TipoLicenca { get; set; } // Tipo de licença (por exemplo, individual, empresarial, educacional)
        public string Plataforma { get; set; } // Plataforma suportada pelo software (por exemplo, Windows, macOS, Linux)
        public string RequisitosSistema { get; set; } // Requisitos mínimos do sistema para o software
        public string Funcionalidades { get; set; } // Lista de funcionalidades do software
        public string ChaveAtivacao { get; set; } // Chave de ativação da licença
    }
}
