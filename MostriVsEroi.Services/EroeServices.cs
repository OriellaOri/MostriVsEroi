using MostriVsEroi.DbRepository;
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
        static IEroeRepository emr = new EroeDbRepository();

        public static List<Eroe> GetEroi(Utente utente)
        {
            return emr.FetchEroi(utente);
        }    

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
