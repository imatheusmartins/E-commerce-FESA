namespace EcommerceLicenca.Models
{
    public class ItemLicencaViewModel : PadraoViewModel
    {
        public int IdLicenca { get; set; }
        public int FornecedorId { get; set; }  
        public string ChaveAtivacao { get; set; }
        public double ValorItemLicenca { get; set;}
    }
}
