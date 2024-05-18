namespace N1.Models
{
    public abstract class PedidoItemViewModel : PadraoViewModel
    {
        public int PedidoId { get; set; }
        public int LicencaId { get; set; }
        public int Quantidade { get; set; }

    }
}
