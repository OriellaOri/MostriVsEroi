using MostriVsEroi.Core.Entities;
using System;

namespace MostriVSEroi.ViewServices
{
    public static class UtenteViewServices
    {
        public static Utente GetUtente(string username, string password)
        {            
            return new Utente(username, password);
        }
    }
}
