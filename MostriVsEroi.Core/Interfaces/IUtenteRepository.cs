using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Interfaces
{
    public interface IUtenteRepository
    {
        Utente GetUser(Utente utente);
        void AddUser(Utente utente);
        void UpdateAdmin(Utente utente);
        List<Utente> GetUtenti();
    }
}
