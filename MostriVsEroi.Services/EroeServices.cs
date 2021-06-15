using MostriVSEroi.Core;
using MostriVSEroi.MockRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Services
{
    public static class EroeServices
    {
        static EroeMockRepository emr = new EroeMockRepository();

        public static List<Eroe> GetEroi(Utente utente)
        {
            return emr.FetchEroi(utente);
        }

        /* METODO PER CONTROLLARE SE IL NOME DELL'EROE è PRESENTE NELLA LISTA DI EROI DELL'UTENTE 
         * PER LA SCELTA EROE IN GIOCA VIEW */
        //public static Eroe FetchEroe(string nomeEroe, Utente utente)
        //{
        //    List<Eroe> eroi = GetEroi(utente);
        //    foreach (Eroe e in eroi)
        //    {
        //        if (e.Nome.Equals(nomeEroe, StringComparison.OrdinalIgnoreCase))
        //        {
        //            return e;
        //        }
        //    }
        //    return null;
        //}

        public static void AddEroe(Eroe newEroe, Utente utente)
        {
            emr.AddNewEroe(newEroe, utente);
        }

        public static void RemoveEroe(Utente utente, Eroe eroe)
        {
            emr.DeleteEroe(utente, eroe);
        }
    }
}
