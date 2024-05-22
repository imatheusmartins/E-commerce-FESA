using Microsoft.AspNetCore.Http;
using System;

namespace EcommerceLicenca.Controllers
{
    public class HelperControllers
    {
        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Cliente");
            if (logado == null)
                return false;
            else
                return true;
        }

        public static Boolean VerificaAdminLogado(ISession session)
        {
            string logado = session.GetString("Administrador");
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
