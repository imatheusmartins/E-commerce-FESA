using Microsoft.AspNetCore.Http;
using System;

namespace EcommerceLicenca.Controllers
{
    public class HelperControllers
    {
        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Logado");
            if (logado == null)
                return false;
            else
                return true;
        }

        public static void LimparCarrinho(ISession session)
        {
            session.Remove("carrinho");
        }
    }

}
