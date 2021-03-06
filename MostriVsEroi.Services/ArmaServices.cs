using MostriVsEroi.Core;
using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using MostriVsEroi.DbRepository;
using MostriVsEroi.MockRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public class ArmaServices
    {
        static IArmaRepository amr = new ArmaDbRepository();
        public static List<Arma> GetArmiEroe(string categoria)
        {
            return amr.FetchArmiEroe(categoria);
        }

        public static List<Arma> GetArmiMostro(string categoria)
        {
            return amr.FetchArmiMostro(categoria);
        }
    }
}
