using MostriVSEroi.Core;
using System;
using System.Collections.Generic;

namespace MostriVSEroi.MockRepository
{
    public class UtenteMockRepository: IUtenteRepository
    {
        static List <Utente> utenti = new List<Utente>();

        public Utente GetUser(Utente utente)
        {
            // essendo un mokc è sempre autenticato 
            // con DB controllo effettivo se presente 
            utente.IsAuthenticated = true; 
            return utente;
        }

        public void AddUser(Utente utente)
        {
            utenti.Add(utente);
        }
    }
}
