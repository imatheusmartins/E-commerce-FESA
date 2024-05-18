namespace N1.Models
{
    public abstract class CarrinhoViewModel : PadraoViewModel
    {
        public int LicencaId { get; set; }
        public int Quantidade { get; set; }
        public string NomeLicenca { get; set; }
        public string ImagemEmBase64 { get; set; }
    }
}
