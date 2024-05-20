using System;
using System.Collections.Generic; // Adicionei esta linha para corrigir o tipo List

namespace EcommerceLicenca.Models
{
    public class FornecedorViewModel : PadraoViewModel
    {
        public string Nome { get; set; } // Para armazenar o nome do fornecedor
        public string Cnpj { get; set; }
		public string Email { get; set; }
		
    }
}
