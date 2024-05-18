using System;
using System.Collections.Generic; // Adicionei esta linha para corrigir o tipo List

namespace EcommerceLicenca.Models
{
    public class FornecedorViewModel : PadraoViewModel
    {
        public string NomeFornecedor { get; set; } // Para armazenar o nome do fornecedor
        public List<LicencaViewModel> SoftwareDisponiveis { get; set; } // Corrigi o tipo List e o nome da propriedade
        public DateTime DataRegistro { get; set; } = DateTime.Now; // Corrigi a sintaxe de inicialização
    }
}
