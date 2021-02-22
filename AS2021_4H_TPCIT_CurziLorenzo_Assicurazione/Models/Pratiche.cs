using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AS2021_4H_TPCIT_CurziLorenzo_Assicurazione.Models
{
    class Pratiche
    {
        List<Polizza> _pratiche = new List<Polizza>();

        //stipulazione di una nuova polizza
        public void Stipulazionepolizza(string nome, string cognome, string cf, int classeMerito, int codice, string tipo, DateTime scadenza, double premio, bool pagata)
        {
            _pratiche.Add(new Polizza(nome, cognome, cf, classeMerito, codice, tipo, scadenza, premio, pagata));
        }

        //Ricerca di una polizza per codice
        public string RicercaPolizza(int codice)
        {
            string retVal = "Polizza non trovata.";

            foreach (var p in _pratiche)
            {
                if (p.Codice == codice)
                    retVal = p.ToString();
            }

            return retVal;
        }

        //Ricerca di più polizze data la loro tipologia
        public string RicercaPolizza(string tipo)
        {
            string retVal = "";

            foreach(var p in _pratiche)
            {
                if(p.Tipologia == tipo)
                {
                    retVal += p.ToString();
                    retVal += "\n----------------------------------------";
                }
            }

            return retVal;
        }

        //Ricerca di polizze eventualmente scadute
        public string RicercapolizzeScadute()
        {
            string retVal = "Le polizze scadute sono:";

            foreach(var p in _pratiche)
            {
                //confronto la data di scadenza con il giorno odierno usando il metodo compare della classe DateTime
                //in caso la polizza sia scaduta il metodo dovrebbe ritornare un valore minore di 0 (es -1)
                int compare = DateTime.Compare(p.Scadenza, DateTime.Now); 

                if(compare < 0)
                {
                    retVal += p.ToString();
                }
            }

            //se la stringa non è variata segnalo che non vi era alcuna polizza scaduta
            if(retVal == "Le polizze scadute sono:")
            {
                retVal = "Non vi è alcuna polizza scaduta.";
            }

            return retVal;
        }

        //Metodo che consente di visualizza i nominativi di tutti i clienti della compagnia assicurativa
        public string VisualizzaClienti()
        {
            string retVal = "";

            foreach (var p in _pratiche)
            {
                retVal += $"\n{p.Nome} {p.Cognome}";
            }

            return retVal;
        }

        //Metodo per visualizzare se una polizza è stata pagata o meno
        public bool VerificaPagamento(int codice)
        {
            bool retVal = false;

            foreach(var p in _pratiche)
            {
                if (p.Codice == codice)
                    retVal = p.Pagata;
            }

            return retVal;
        }

        //Metodo che stampa tutte le polizze intestate a un cliente dato il suo codice fiscale
        public string VisualizzaPolizzeCliente(string cf)
        {
            string retVal = "Le polizze del cliente cercato sono:";

            foreach(var p in _pratiche)
            {
                if (p.CodiceFiscale == cf)
                    retVal += p.ToString();
            }

            if (retVal == "Le polizze del cliente cercato sono:")
                retVal = "Cliente non trovato.";

            return retVal;
        }

        //Rimozione dalla lista di una polizza dato il suo codice
        public bool EliminazionePolizza(int codice)
        {
            bool retVal = false;
            int postion = -1; //variabile in cui salvero la posizione della polizza da eliminare
            
            for(int i = 0; i < _pratiche.Count; i++)
            {
                if (_pratiche[i].Codice == codice)
                    postion = i;
            }

            if(postion != -1)
            {
                retVal = true;
                _pratiche.RemoveAt(postion);
            }

            return retVal;
        }

        //Salvataggio dati su file di testo
        public bool Salvataggio()
        {
            string salvataggio = $"\n\nSalvataggio {DateTime.Now}";

            foreach (var p in _pratiche)
            {
                salvataggio += $"\n{p.ToString()}";
            }

            try
            {
                File.AppendAllText("Salvataggio.txt", salvataggio);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
