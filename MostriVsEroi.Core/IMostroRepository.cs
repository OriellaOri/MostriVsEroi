using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Core
{
    public interface IMostroRepository
    {
        public List<Mostro> FetchMostri();
        void AddNewMostro(Mostro m);
    }
}
