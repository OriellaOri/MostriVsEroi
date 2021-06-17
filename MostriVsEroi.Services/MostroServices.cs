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
    public class MostroServices
    {
        static IMostroRepository mmr = new MostroDbRepository();

        public static List<Mostro> GetMostri()
        {
            return mmr.FetchMostri();
        }

        public static Mostro SceltaMostro(Eroe eroe)
        {
            // carico la lista dei mostri dal DB
            List<Mostro> mostri = GetMostri();
            // creo una lista dei mostri con livello adeguato al eroe 
            List<Mostro> mostriLiv = new List<Mostro>();
            foreach (Mostro m in mostri)
            {
                if (m.Livello <= eroe.Livello)
                {
                    mostriLiv.Add(m);
                }
            }
            Random r = new Random();
            int index = r.Next(mostriLiv.Count);
            Mostro mostro = mostriLiv[index];

            return mostro;
        }

        public static void AddMostro(Mostro m)
        {
            mmr.AddNewMostro(m);
        }
    }

}
