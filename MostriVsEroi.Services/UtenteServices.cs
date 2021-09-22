using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using MostriVsEroi.DbRepository;
using MostriVSEroi.MockRepository;
using System;
using System.Collections.Generic;

namespace MostriVSEroi.Services
{
    public class UtenteServices
    {
        static IUtenteRepository umr = new UtenteDbRepository();
        public static Utente VerifyAuthentication(Utente utente)
        {
            return umr.GetUser(utente);
        }
        public static void AddUtente(Utente utente)
        {
            umr.AddUser(utente);
        }

        public static List<Utente> GetUtenti()
        {
            return umr.GetUtenti();
        }

        internal static void UpdateAdmin(Utente utente)
        {
            utente.IsAdmin = true;
            umr.UpdateAdmin(utente);
        }
    }
}
