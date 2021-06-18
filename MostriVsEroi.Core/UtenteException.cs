using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core
{
    public class UtenteException : Exception
    {
        public UtenteException() { }

        public UtenteException(string msg)
            : base(msg) { }
        public UtenteException(string message, Exception innerException)
        : base(message, innerException) { }

        protected UtenteException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }
}
