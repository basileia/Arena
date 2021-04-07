using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Arena
{
    class Bojovnik
    {
        public string Jmeno { get; private set; }
        public int Sila { get; private set; }
        public Zbran Zbran { get; set; }
        
        private int brneni;
        public int Brneni
        {
            get
            {
                return brneni;
            }
            private set
            {
                brneni = ZkontrolujANastavHodnotuVlastnosti(value, 0, 50);
            }
        }

        private int zivot;
        public int Zivot 
        {
		    get
		{
			return zivot;
		}
            private set
		{
			zivot = ZkontrolujANastavHodnotuVlastnosti(value, 0, 100);
            }
	    }
        public bool JeZivy => Zivot > 0;

        public Bojovnik(string jmeno, int sila, Zbran zbran, int zivot = 100, int brneni = 50)
		{
			Jmeno = jmeno;
            Sila = sila <= 10 ? 10 : sila;
            Zivot = zivot;
            Brneni = brneni;
            Zbran = zbran;
        }

        private int ZkontrolujANastavHodnotuVlastnosti(int hodnotaVlastnosti, int minimalniHodnota, int maximalniHodnota)
        {
            if (hodnotaVlastnosti <= minimalniHodnota)
            {
                return minimalniHodnota;
            }
            else if (hodnotaVlastnosti >= maximalniHodnota)
            {
                return maximalniHodnota;
            }
            else
            {
                return hodnotaVlastnosti;
            }
        }

        public void UtocNa(Bojovnik obet)
        {
            switch (Zbran)
            {
                case Zbran.Mec:

                    obet.Brneni -= (obet.Brneni - (Sila / 10)) >= 0 ? (Sila / 10) : obet.Brneni;
                    obet.Zivot -= obet.Brneni == 0 ? Sila : (Sila - obet.Brneni) >= 0 ? (Sila - obet.Brneni) : 0;
                    break;
                case Zbran.Palcat:
                    obet.Brneni -= (obet.Brneni - (Sila / 4)) >= 0 ? (Sila / 4) : obet.Brneni;
                    obet.Zivot -= obet.Brneni == 0 ? (Sila / 4) : 0;
                    break;
                case Zbran.Sekera:
                    obet.Brneni -= (obet.Brneni - (Sila / 8)) >= 0 ? (Sila / 8) : obet.Brneni;
                    obet.Zivot -= obet.Brneni == 0 ? Sila : (Sila - obet.Brneni) >= 0 ? (Sila - obet.Brneni) : 0;
                    break;
                default:
                    break;
            }
            
        }

        public override string ToString()
        {
            return $"{Jmeno}\t Zbran: {Zbran}\t Zivot: {Zivot}\t Brneni: {Brneni}";
        }

    }
}
