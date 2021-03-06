using MostriVsEroi.Core;
using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
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
            List<Arma> armi = new ();
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

        public List<Arma> FetchArmiEroe(string categoriaEroe)
        {
            throw new NotImplementedException();
        }

        public List<Arma> FetchArmiEroi()
        {
            throw new NotImplementedException();
        }

        public List<Arma> FetchArmiMostro(Mostro mostro)
        {
            throw new NotImplementedException();
        }

        public List<Arma> FetchArmiMostro(string categoriaMostro)
        {
            throw new NotImplementedException();
        }
    }
}
