using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Interfaces
{
    public interface IEroeRepository
    {
        public List<Eroe> FetchEroi(Utente utente);
        void AddNewEroe(Eroe newEroe, Utente utente);
        void DeleteEroe(Utente utente, Eroe eroe);
        void UpdateEsperienzaEroe(Utente utente, Eroe eroe);
        void UpdateEsperienzaLivelloEroe(Utente utente, Eroe eroe);
        Dictionary<Eroe, Utente> FetchEroiUtenti();
    }
}
