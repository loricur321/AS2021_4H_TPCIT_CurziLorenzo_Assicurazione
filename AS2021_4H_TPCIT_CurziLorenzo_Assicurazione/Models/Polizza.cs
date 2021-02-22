using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_TPCIT_CurziLorenzo_Assicurazione.Models
{
    class Polizza
    {
        //generalità del cliente
        string _nome;
        string _cognome;
        string _codiceFiscale;
        int _classeMerito;

        //informazioni sulla polizza
        int _codice;
        string _tipologia;
        DateTime _scadenza;
        double _premio;
        bool _pagata;

        public Polizza () { }

        public Polizza (string nome, string cognome, string cf, int classeMerito, int codice, string tipo, DateTime scadenza, double premio, bool pagata)
        {
            _nome = nome;
            _cognome = cognome;
            _codiceFiscale = cf;
            _classeMerito = classeMerito;
            _codice = codice;
            _tipologia = tipo;
            _scadenza = scadenza;
            _premio = premio;
            _pagata = pagata;
        }

        public string Nome
        {
            get => _nome;
        }

        public string Cognome
        {
            get => _cognome;
        }

        public string CodiceFiscale
        {
            get => _codiceFiscale;
        }

        public int ClasseMerito
        {
            get => _classeMerito;
        }

        public int Codice
        {
            get => _codice;
        }

        public string Tipologia
        {
            get => _tipologia;
        }

        public DateTime Scadenza
        {
            get => _scadenza;
        }

        public double Premio
        {
            get => _premio;
        }

        public bool Pagata
        {
            get => _pagata;
        }

        public override string ToString()
        {
            string retVal = "";
            retVal =  $"\nPolizza con codice: \t{_codice}" +
                    $"\nCliente: \t\t{_nome} {_cognome}" +
                    $"\nClasse di merito: \t{_classeMerito}" +
                    $"\nTipologia: \t\t{_tipologia}" +
                    $"\nScadenza: \t\t{_scadenza}";

            if (_pagata)
                retVal += "\nIl premio assicurativo è stato pagato correttamente.";
            else
                retVal += "\nLa polizza risulta essere non pagata.";

            return retVal;
            
        }
    }
}
