using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boelle_bank
{
    class Konto
    {
        string brugernavn = "";
        string kodeord = "";
        double saldo = 0.0;


        public Konto(string brugernavn, string kodeord, double saldo)
        {
            this.brugernavn = brugernavn;
            this.kodeord = kodeord;
            this.saldo = saldo;
        }

        public bool TjekLogIn(string brugernavn, string kodeord)
        {
            if (this.brugernavn == brugernavn)
            {
                if (this.kodeord == kodeord)
                {
                    return true;
                }
            }
            return false;
        }
        public void SkrivSaldo()
        {
            Console.WriteLine("Din saldo er: " + saldo);
        }
        public void SaldoÆndring(double antal)
        {
            saldo += antal;
        }
        public double Saldoen()
        {
            return this.saldo;
        }
    }
}
