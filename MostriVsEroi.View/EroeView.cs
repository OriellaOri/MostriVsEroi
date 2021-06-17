﻿using MostriVsEroi.Services;
using MostriVSEroi.Core;
using MostriVSEroi.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.View
{
    public class EroeView
    {
        // RECUPERO LE CATEGORIE EROI DISPONIBILI DAL DB 
        static List<string> categorie = CategoriaServices.GetCategorieEroi();

        internal static void CreaEroe(Utente utente)
        {
            // conversione scelta 
            bool conversione;

            /* RICHIESTA NOME */
            string nome;
            do
            {
                Console.WriteLine("Inserisci nome del tuo eroe");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));

            /* RICHIETA CATEGORIA */
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

            /* RECUPERO LE ARMI DISPONIBILI PER LA CATEGORIA EROE SOPRA SELEZIONATA */
            List<Arma> armi = ArmaServices.GetArmiEroe(categoriaSelezioanta);

            /* RICHIESTA ARMA */
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

            // creo il nuovo eroe 
            Eroe eroeCreato = new Eroe(nome, categoriaSelezioanta, nuovaArma);

            // aggiungo l'eroe creato alla lista degli eroi del utente che poi sara nel DB
            EroeServices.AddEroe(eroeCreato, utente);

            Console.WriteLine($"Eroe aggiunto correttamente : {eroeCreato.Nome} - {eroeCreato.Categoria} - {eroeCreato.Arma.Nome} ");
        }

        internal static void EliminaEroe(Utente utente)
        {
            // CARICO GLI EROI CHE HA NEL SUO DB 
            List<Eroe> eroiUtente = EroeServices.GetEroi(utente);
            bool conversione = false;
            int eroeScelto;
            do
            {
                // contatore della lista
                int count = 1;
                foreach (Eroe eroe in eroiUtente)
                {
                    //Console.WriteLine(e);
                    Console.WriteLine($"Premi {count++} per ELIMINARE l'eroe {eroe.Nome}, di tipo {eroe.Categoria} " +
                        $"con arma {eroe.Arma.Nome} che ha {eroe.Arma.Danno} punti danno di Liv. {eroe.Livello}");
                }
                conversione = int.TryParse(Console.ReadLine(), out eroeScelto);
            } while (!conversione || eroeScelto < 1 || eroeScelto > eroiUtente.Count);
            // creo l'eroe effettivo da elimianre
            Eroe eroeElimanto = eroiUtente[--eroeScelto];

            // richiamo il serivices per eliminarlo 
            EroeServices.RemoveEroe(utente, eroeElimanto);
            Console.WriteLine($"Eroe {eroeElimanto.Nome} eliminato ");
        }

        internal static void MostraClassifica()
        {
            /* VISUALIZZARE I MILGIORI 10 EROI IN ORIDINE DI LIVELLO E PUNTI ACCUMULATI CON NICKNAME DEL GIOCATORE */
            List<Eroe> eroi = EroeServices.GetEroiClassifca();

        }
    }
}
