using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core
{
    public interface IArmaRepository
    {
        // mi da tutte le armi presenti in DB
        public List<Arma> FetchArmi();

        //mi da solo le armi associate all'eroe
        public List<Arma> FetchArmi(Eroe eroe);

        // mi da solo le armi associate al mostro
        //public List<Arma> FetchArmi(Mostro mostro;
    }
}
