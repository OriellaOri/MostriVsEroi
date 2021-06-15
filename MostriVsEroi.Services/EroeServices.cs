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
        // TODO : valutare se tenere
        public static Eroe RecuperaEroe(string nomeEroe, Utente utente)
        {
            List<Eroe> eroi = GetEroi(utente);
            foreach (Eroe e in eroi)
            {
                if (e.Nome.Equals(nomeEroe, StringComparison.OrdinalIgnoreCase))
                {
                    return e;
                }
            }
            return null;
        }
    }
}
