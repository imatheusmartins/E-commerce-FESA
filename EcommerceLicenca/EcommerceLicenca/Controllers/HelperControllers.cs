using Microsoft.AspNetCore.Http;
using System;

namespace N1.Controllers
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
    }

}
