using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boelle_bank //Navn på projektet
{
    class Konto //Klasse med navn "Konto"
    {
        string brugernavn = ""; //tekst brugernavn. Skriv dit brugernavn
        string kodeord = ""; // tekst kodeord. Skriv dit kodeord
        double saldo = 0.0; // Tal saldo: Viser hvad dit Saldo er


        public Konto(string brugernavn, string kodeord, double saldo) //Hvad en konto består af
        {
            this.brugernavn = brugernavn;//En konto skal have et brugernavn
            this.kodeord = kodeord;//En konto skal have et kodeord
            this.saldo = saldo;//En konto skal have en saldo(Hvilket sagtens kan være 0kr.)
        }

        public bool TjekLogIn(string brugernavn, string kodeord)//Er logind informertionerne rigtige?
        {
            if (this.brugernavn == brugernavn)//Findes denne brugernavn?
            {
                if (this.kodeord == kodeord)//Findes dette kodeord?
                {
                    return true;//Hvis de passer sammen godkend login
                }
            }
            return false;//Hvis de ikke passer sammen ikke godkend logind
        }
        public void SkrivSaldo()//Funktion som kender din saldo
        {
            Console.WriteLine("Din saldo er: " + saldo);//Skriver "Din saldo er" og viser hvad din saldo er
        }
        public void SaldoÆndring(double antal)//Hvis du skal hæve/indsætte penge
        {
            saldo += antal;//Beregner din ny saldo. 
        }
        public double Saldoen()//Ved hvad din ny saldo er
        {
            return this.saldo;//Viser din ny saldo, som vil være din gamle +/- ændringen
        }
    }
}
