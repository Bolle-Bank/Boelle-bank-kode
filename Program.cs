using Boelle_bank;
using System.Runtime.InteropServices;

internal class Program
{
    static List<Konto> konti = new List<Konto>();

    static Konto? nuværendeKonto;

    private static void Main(string[] args)
    {
        if (konti.Count == 0)
        {
            konti.Add(new Konto("Albert", "AAlbert", 100));
            konti.Add(new Konto("Bente", "BBente", 200));
            konti.Add(new Konto("Cirkus", "CCirkus", 300));
            konti.Add(new Konto("Dennis", "DDennis", 400));
            konti.Add(new Konto("Emil", "EEmil", 500));
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Fuck dig og velkommen i vores bølle bank. Sig mig kammerat, har du en konto?('Ja', 'Nej')");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string valg = Console.ReadLine()!;
            Console.ForegroundColor = ConsoleColor.White;
            if (valg == "Ja")
            {
                break;
            }
            else if (valg == "Nej")
            {
                Console.WriteLine("Jamen så vil du gerne have en konto");
                Console.WriteLine("Hvad skal dit brugernavn være?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string brugernavn = Console.ReadLine()!;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Sikke et dumt navn, har du en endnu dummere kode?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string kode = Console.ReadLine()!;
                Console.ForegroundColor = ConsoleColor.White;
                konti.Add(new Konto(brugernavn, kode, 0));
                break;
            }
            Console.WriteLine("Øhhh? Kan du ikke stave? Ordblinde cunt");
        }

        Konto? fundetKonto = null;
        while (fundetKonto == null)
        {
            Console.WriteLine("Brugernavn?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string navn = Console.ReadLine()!;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Kodeord?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string kode = Console.ReadLine()!;
            Console.ForegroundColor = ConsoleColor.White;
            fundetKonto = TjekKonti(navn, kode);
        }
        Console.WriteLine("Konto fundet!");
        nuværendeKonto = fundetKonto;
        nuværendeKonto.SkrivSaldo();

        while (true)
        {
            Console.WriteLine("Hvad vil du gøre? ('Logud', 'Ændre saldo')");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string valg = Console.ReadLine()!;
            Console.ForegroundColor = ConsoleColor.White;
            if (valg == "Logud")
            {
                Console.WriteLine("Du har valgt at skride");
                nuværendeKonto = null;
                Main(args);
                return;
            }
            else if (valg == "Ændre saldo")
            {
                Console.WriteLine("Hvor meget vil du hæve/indsætte på konto?");
                double antal = 0;
                while (!double.TryParse(Console.ReadLine()!, out antal))
                {
                    Console.WriteLine("Skriv et rigtigt tal, dumbass");
                }
                if (antal + nuværendeKonto!.Saldoen() < 0)
                {
                    Console.WriteLine("Du er fucking fattig klaphat!");
                }
                else
                {
                    Console.WriteLine("Hæver/indsætter: " + antal);
                    nuværendeKonto.SaldoÆndring(antal);
                    nuværendeKonto.SkrivSaldo();
                }
            }
        }
    }
    private static Konto? TjekKonti(string brugernavn, string kodeord)
    {
        foreach (Konto konto in konti)
        {
            if (konto.TjekLogIn(brugernavn, kodeord))
                return konto;
        }
        Console.WriteLine("Du er dum");
        return null;

    }
}