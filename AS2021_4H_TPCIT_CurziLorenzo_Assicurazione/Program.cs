using AS2021_4H_TPCIT_CurziLorenzo_Assicurazione.Models;
using System;

namespace AS2021_4H_TPCIT_CurziLorenzo_Assicurazione
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma assicurazione di Lorenzo Curzi 4H, 22/01/2021");

            Pratiche polizze = new Pratiche();
            var now = DateTime.Now;

            polizze.Stipulazionepolizza("Mario", "Rossi", "AAA3", 14, 1, "RC Auto", now.AddYears(1), 500, true);
            polizze.Stipulazionepolizza("Mario", "Rossi", "AAA3", 14, 2, "RC Auto", now.AddYears(1), 1000, false);
            polizze.Stipulazionepolizza("Antonio", "Rossi", "AAA5", 14, 3, "Vita", now.AddYears(10), 1500, true);
            polizze.Stipulazionepolizza("Giuseppe", "Verdi", "AAA6", 14, 4, "Altro tipo", now.AddYears(5), 5000, true);


            Console.WriteLine("Ricerca polizza per codice");
            Console.WriteLine(polizze.RicercaPolizza(4));

            Console.WriteLine("\nRicerca polizze per tipologia");
            Console.WriteLine(polizze.RicercaPolizza("RC Auto"));

            Console.WriteLine("\nRicerca polizze scadute");
            Console.WriteLine(polizze.RicercapolizzeScadute());

            Console.WriteLine("\nLista di tutti i clienti");
            Console.WriteLine(polizze.VisualizzaClienti());

            Console.WriteLine("\nVerifica del pgamento della polizza vente codice 3");
            if (polizze.VerificaPagamento(2))
                Console.WriteLine("Polizza pagata.");
            else
                Console.WriteLine("Polizza non pagata");

            Console.WriteLine("\nVisualizzazione di tutte le polizze di Mario Rossi");
            Console.WriteLine(polizze.VisualizzaPolizzeCliente("AAA3"));

            Console.WriteLine("\nEliminazione della polizza con codice 4");
            if (polizze.EliminazionePolizza(4))
                Console.WriteLine("Operazione riusicta.");
            else
                Console.WriteLine("Operazione non riusicta.");

            Console.WriteLine("\nSalvataggio su file");
            if (polizze.Salvataggio())
                Console.WriteLine("Operazione riusicta.");
            else
                Console.WriteLine("Operazione non riusicta.");

        }
    }
}
