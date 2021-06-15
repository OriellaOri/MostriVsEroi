using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Core
{
    public interface IUtenteRepository
    {
        Utente GetUser(Utente utente);
        void AddUser(Utente utente);
    }
}
