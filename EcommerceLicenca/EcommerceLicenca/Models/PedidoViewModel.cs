using System;

namespace EcommerceLicenca.Models
{
    public class PedidoViewModel : PadraoViewModel
    {
        public int IdUsuario { get; set; }
        public double ValorPedido { get; set; }
        public string StatusPedido { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
