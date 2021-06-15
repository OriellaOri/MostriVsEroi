using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Core
{
    public interface IEroeRepository
    {
        public List<Eroe> FetchEroi(Utente utente)
    }
}
