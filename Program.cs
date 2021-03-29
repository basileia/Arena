using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            int pocetBojovniku = PomocneMetody.NactiCeleCisloZKonzole("Kolik chcete zaregistrovat bojovníků?");

            for (int i = 0; i < pocetBojovniku; i++)
            {
                arena.RegistrujBojovnika();
                
            }

            arena.ZiviBojovnici = new List<Bojovnik>(arena.SeznamBojovniku);
            arena.Boj();

            Console.ReadLine();
                        
        }

        
    }

}

