﻿using System;
using Microsoft.AspNetCore.Http;


namespace EcommerceLicenca.Models
{

    public class LicencaViewModel : PadraoViewModel
    {
        public string NomeLicenca { get; set; }
        public double Valor { get; set; }
        public string RequisitosSistema { get; set; } // Requisitos mínimos do sistema para o software
        //public string ImagemEmBase64 { get; set; }
    }
}
