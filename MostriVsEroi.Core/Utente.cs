using System;

namespace MostriVSEroi.Core
{
    public class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAuthenticated { get; set; }
        public Utente(string user, string pass)
        {
            Username = user;
            Password = pass;
            IsAdmin = false;
            IsAuthenticated = false;
        }
        public Utente(string user)
        {
            Username = user;
        }
    }
}
