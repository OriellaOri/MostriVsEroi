using MostriVsEroi.Core;
using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.MockRepository
{
    public class ArmaMockRepository : IArmaRepository
    {
        public List<Arma> FetchArmi()
        {
            /* LISTA DI ARMI CHE SARANNO POI UNA TABELLA E FILTARE CON QUERY A SECONDA DEL EROE*/
            List<Arma> armi = new List<Arma>();
            Arma a = new Arma("Alabarda", 15);
            Arma a1 = new Arma("Bacchetta", 5);
            armi.Add(a1);
            armi.Add(a);

            return armi;
        }

        public List<Arma> FetchArmi(Eroe eroe)
        {
            throw new NotImplementedException();
        }
    }
}
