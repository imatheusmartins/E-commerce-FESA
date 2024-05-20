namespace EcommerceLicenca.Models
{
    public class ItemLicencaViewModel : PadraoViewModel
    {
        public int IdLicenca { get; set; }
        public int IdFornecedor { get; set; }  
        public string ChaveAtivacao { get; set; }
    }
}
