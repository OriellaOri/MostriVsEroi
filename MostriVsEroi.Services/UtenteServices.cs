using MostriVSEroi.Core;
using MostriVSEroi.MockRepository;
using System;
using System.Collections.Generic;

namespace MostriVSEroi.Services
{
    public class UtenteServices
    {
        static UtenteMockRepository umr = new UtenteMockRepository();
        public static Utente VerifyAuthentication(Utente utente)
        {
            return umr.GetUser(utente);
        }
       
    }
}
