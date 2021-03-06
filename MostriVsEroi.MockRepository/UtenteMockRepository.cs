using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace MostriVSEroi.MockRepository
{
    public class UtenteMockRepository: IUtenteRepository
    {
        static List <Utente> utenti = new List<Utente>();

        public Utente GetUser(Utente utente)
        {
            // essendo un mock è sempre autenticato 
            // con DB controllo effettivo se presente 
            utente.IsAuthenticated = true; 
            return utente;
        }

        public void AddUser(Utente utente)
        {
            utenti.Add(utente);
        }

        public void UpdateAdmin(Utente utente)
        {
            throw new NotImplementedException();
        }

        public List<string> GetUtentiUsername()
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetUtenti()
        {
            throw new NotImplementedException();
        }
    }
}
