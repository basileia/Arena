using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Arena
    {

        public List<Bojovnik> SeznamBojovniku { get; set; }
        public List<Bojovnik> ZiviBojovnici { get; set; }
        private Random rand;
        public Dictionary<Bojovnik, Bojovnik> Rivalove { get; set; }

        public Arena()
        {
            Console.WriteLine("VÍTEJTE V ONLINE ARÉNĚ\n");
            SeznamBojovniku = new List<Bojovnik>();
            rand = new Random();
            Rivalove = new Dictionary<Bojovnik, Bojovnik>();
            ZiviBojovnici = new List<Bojovnik>(SeznamBojovniku);
        }

        public void ZobrazStavBojovniku(List<Bojovnik> vsichniBojovnici)
        {
            VytvorTiskovouOzdobu();            
                        
            foreach (Bojovnik bojovnik in vsichniBojovnici)
            {
                bojovnik.ZobrazStavBojovnika();
            }

            VytvorTiskovouOzdobu();
        }

        private void VytvorTiskovouOzdobu()
        {
            string result = new String('=', 70);
            Console.WriteLine(result);
        }

        public void Boj()
        {
            Console.WriteLine("\nZAČÍNÁ BOJ");
            bool jeCekatel = false;
            Bojovnik cekatel = ZiviBojovnici.Last();
            
            while (ZiviBojovnici.Count > 1)
            {
                Console.WriteLine("\nStav bojovníků před bojem");
                ZobrazStavBojovniku(ZiviBojovnici.OrderBy(o => o.Jmeno).ToList());
                
                if (ZiviBojovnici.Count % 2 == 0)
                {
                    Rivalove = VytvorDvojice(ZiviBojovnici);
                    jeCekatel = false;
                }
                else
                {
                    cekatel = ZiviBojovnici.Last();
                    jeCekatel = true;
                    ZiviBojovnici.RemoveAt(ZiviBojovnici.Count - 1);
                    Rivalove = VytvorDvojice(ZiviBojovnici);
                }

                foreach (Bojovnik utocnik in Rivalove.Keys)
                {
                    SoubojDvojice(utocnik, Rivalove[utocnik]);
                }

                if (jeCekatel)
                    {
                        ZiviBojovnici.Insert(0, cekatel);
                    }
              }
            Console.WriteLine("\nVÍTĚZNÝM BOJOVNÍKEM SE STÁVÁ");
            ZobrazStavBojovniku(ZiviBojovnici);
            
        }

        public void RegistrujBojovnika()
        {
            string jmeno;
            int sila;
            Zbran zbran;
            int zivot;
            int brneni;

            jmeno = PomocneMetody.NactiStringZKonzole("Zadejte jméno bojovníka");
            sila = VylosujNahodneCislo(10, 30);
            zbran = (Zbran)VylosujNahodneCislo(0, 3);
            zivot = VylosujNahodneCislo(11, 100);
            brneni = VylosujNahodneCislo(1, 50);

            SeznamBojovniku.Add(new Bojovnik(jmeno, sila, zbran, zivot, brneni));           

        }

        private int VylosujNahodneCislo(int minCislo, int maxCislo)
        {
            return rand.Next(minCislo, maxCislo);

        }

        private Dictionary<Bojovnik, Bojovnik> VytvorDvojice(List<Bojovnik> seznamBojovniku)
        {
            seznamBojovniku = seznamBojovniku.OrderBy(a => Guid.NewGuid()).ToList();

            for (int i = 0; i < seznamBojovniku.Count; i += 2)
            {
                Rivalove[seznamBojovniku[i]] = seznamBojovniku[i + 1];
            }

            return Rivalove;

        }

        private void SoubojDvojice(Bojovnik bojovnik1, Bojovnik bojovnik2)
        {

            while (bojovnik1.JeZivy && bojovnik2.JeZivy)
            {
               bojovnik1.UtocNa(bojovnik2);
               bojovnik2.UtocNa(bojovnik1);
               
            }
            
            if (!bojovnik2.JeZivy)
            {
                ZiviBojovnici.Remove(ZiviBojovnici.Find(item => item.Jmeno == bojovnik2.Jmeno));
            }
            
            else if (!bojovnik1.JeZivy)
            {
                ZiviBojovnici.Remove(ZiviBojovnici.Find(item => item.Jmeno == bojovnik1.Jmeno));
            }
 
        }
    }
}
