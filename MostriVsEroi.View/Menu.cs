using MostriVsEroi.View;
using MostriVSEroi.Core;
using System;

namespace MostriVSEroi.View
{
    public static class Menu
    {
        public static void MainMenu()
        {
            bool vuoiContinuare = true;
            do
            {
                Console.WriteLine("Bentornato\n\n");
                Console.WriteLine("Cosa vuoi fare?\n\n");

                Console.WriteLine("1 x accedere");
                Console.WriteLine("2 x registrati");
                Console.WriteLine("0 x uscire\n\n");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        AccediView.Accedi();
                        break;
                    case "2":
                        RegistraView.Registra(); 
                        break;
                    case "0":
                        Console.WriteLine("Ciao alla prossima");
                        vuoiContinuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata... riprova");
                        break;
                }

            } while (vuoiContinuare);
        }

        internal static void MenuNonAdmin(Utente utente)
        {
            bool vuoiContinuare = true;
            Console.WriteLine($"Bentornato {utente.Username}\n");
            do
            {
                Console.WriteLine("Cosa vuoi fare?\n");
                Console.WriteLine("1 x GIOCARE");
                Console.WriteLine("2 x CREA EROE");
                Console.WriteLine("3 x ELIMINA EROE");
                Console.WriteLine("0 x ESCI\n\n");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        // GIOCA
                        GiocaView.Gioca(utente);
                        break;
                    case "2":
                        // CREA EROE
                        EroeView.CreaEroe(utente);
                        break;
                    case "3":
                        // ELIMINA EROE
                        EroeView.EliminaEroe(utente);
                        break;
                    case "0":
                        MainMenu();
                        vuoiContinuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata... riprova");
                        break;
                }

            } while (vuoiContinuare);

        }
    }
}
