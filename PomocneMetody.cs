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
            int cislo = 0;
            bool vysledekPrevodu = false;

            while (vysledekPrevodu == false || cislo < 1)
            {
                Console.WriteLine(dotaz);
                string pocetText = Console.ReadLine();
                vysledekPrevodu = int.TryParse(pocetText, out cislo);

                if (vysledekPrevodu == false || cislo < 1)
                {
                    Console.WriteLine("Tohle není celé kladné číslo");
                }
            }

            return cislo;
        }
    }
}
