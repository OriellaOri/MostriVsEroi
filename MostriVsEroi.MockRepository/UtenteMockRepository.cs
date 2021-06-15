using MostriVSEroi.Core;
using System;
using System.Collections.Generic;

namespace MostriVSEroi.MockRepository
{
    public class UtenteMockRepository: IUtenteReporisotry
    {
        public Utente GetUser(Utente utente)
        {
            utente.IsAuthenticated = true; 
            return utente;
        }
    }
}
