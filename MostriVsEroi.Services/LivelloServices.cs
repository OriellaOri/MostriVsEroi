using MostriVsEroi.Core;
using MostriVsEroi.Core.Interfaces;
using MostriVsEroi.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public class LivelloServices
    {
        static ILivelloRepository lbr = new LivelloDbRepository();

        public static Dictionary<int, int> GetLivelliVita()
        {
            return lbr.GetLivelliConVita();
        }
    }
}
