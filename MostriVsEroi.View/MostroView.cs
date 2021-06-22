using MostriVsEroi.Services;
using MostriVSEroi.Core;
using MostriVSEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.View
{
    public class MostroView
    {
        /* RECUPERO LE CATAGEORIE DEI MOSTRI */
        static readonly List<string> categorie = CategoriaServices.GetCategorieMostri();
        /* RECUPERO I LIVELLI DISPONIBILI */
        static readonly Dictionary<int, int> livelliPuntiVita = LivelloServices.GetLivelliVita();

        internal static void CreaMostro()
        {
            /* RICHIESTA NOME */
            string nome;
            do
            {
                Console.WriteLine("Inserisci nome mostro");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));

            /* RICHIETA CATEGORIA */
            bool conversione;
            int sceltaCategoria;
            do
            {
                int contaggio = 1;
                foreach (string s in categorie)
                {
                    Console.WriteLine($"Premi {contaggio++} per {s}");
                }
                conversione = int.TryParse(Console.ReadLine(), out sceltaCategoria);
            } while (!conversione || sceltaCategoria < 1 || sceltaCategoria > categorie.Count);
            // assegno la categoria tramite il numero inserito della lista  
            string categoriaSelezioanta = categorie[--sceltaCategoria];

            /* RICHIESTA ARMA*/
            /* RECUPERO LE ARMI DISPONIBILI PER LA CATEGORIA MOSTRO SELEZIONATA */
            List<Arma> armi = ArmaServices.GetArmiMostro(categoriaSelezioanta);
            int sceltaArma;
            do
            {
                // contatore lista armi 
                int count = 1;
                foreach (Arma a in armi)
                {
                    Console.WriteLine($"Premi {count++} per scelgliere l'arma {a.Nome} che ha {a.Danno} danno");
                }
                conversione = int.TryParse(Console.ReadLine(), out sceltaArma);
            } while (!conversione || sceltaArma < 1 || sceltaArma > armi.Count);

            // assegno ad arma l'arma scelta tramite index 
            Arma nuovaArma = armi[--sceltaArma];

            /* RICHIETA LIVELLO */
            int sceltaLivello;
            do
            {
                int contaggio = 1;
                foreach (int i in livelliPuntiVita.Keys)
                {
                    Console.WriteLine($"Premi {contaggio++} per LIV {i} con punti vita {livelliPuntiVita[i]}");
                }
                conversione = int.TryParse(Console.ReadLine(), out sceltaLivello);
            } while (!conversione || sceltaCategoria < 1 || sceltaCategoria > categorie.Count);

            /* CREO IL NUOVO MOSTRO */
            Mostro newMostro = new(nome, categoriaSelezioanta, sceltaLivello, nuovaArma, livelliPuntiVita[sceltaLivello]);

            /* AGGIUNGO MOSTRO AL DB*/
            MostroServices.AddMostro(newMostro);

            /*CONFERMO AGGIUNTA*/
            Console.WriteLine($"Mostro aggiunto correttamente : {newMostro.Nome} - {newMostro.Categoria}. " +
                $"Arma: {newMostro.Arma.Nome} con {newMostro.Arma.Danno} danno di {newMostro.Livello} con {newMostro.PuntiVita} punti vita. ");
        }
    }
}
