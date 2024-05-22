using System;
using Microsoft.AspNetCore.Http;


namespace EcommerceLicenca.Models
{

    public class LicencaViewModel : PadraoViewModel
    {
        public string NomeLicenca { get; set; }
        public double Valor { get; set; }
        public string RequisitosSistema { get; set; }
        public IFormFile Imagem { get; set; }
        /// <summary>
        /// Imagem em bytes pronta para ser salva
        /// </summary>
        public byte[] ImagemEmByte { get; set; }
        /// <summary>
        /// Imagem usada para ser enviada ao form no formato para ser exibida
        /// </summary>
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
    }
}
