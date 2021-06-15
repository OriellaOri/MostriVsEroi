using MostriVsEroi.Core;
using MostriVsEroi.MockRepository;
using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public class ArmaServices
    {
        static IArmaRepository amr = new ArmaMockRepository();
        public static List<Arma> GetArmi()
        {
            return amr.FetchArmi();
        }
    }
}
