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
        static MostroMockRepository mmr = new MostroMockRepository();

        public static List<Mostro> GetMostri()
        {
            return mmr.FetchMostri();
        }

        public static Mostro SceltaMostro()
        {
            // carico la lista dei mostri dell'utente 
            List<Mostro> mostri = MostroServices.GetMostri();
            Random r = new Random();
            int index = r.Next(mostri.Count);
            Mostro mostro = mostri[index];

            return mostro;
        }
    }

}
