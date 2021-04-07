using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class PomocneMetody
    {
        public static string NactiStringZKonzole(string dotaz)
        {
            Console.WriteLine(dotaz);
            string vstupUzivatele = Console.ReadLine();

            while (String.IsNullOrEmpty(vstupUzivatele))
            {
                Console.WriteLine(dotaz);
                vstupUzivatele = Console.ReadLine();

            }
            return vstupUzivatele;
        }

        public static int NactiCeleCisloZKonzole(string dotaz)
        {
        start:
            Console.WriteLine(dotaz);
            string pocetText = Console.ReadLine();
            bool vysledekPrevodu = int.TryParse(pocetText, out int cislo);
            while (!vysledekPrevodu || cislo <= 0)
            {
                Console.WriteLine("Tohle není celé kladné číslo");
                goto start;
            }

            return cislo;
        }
    }
}
