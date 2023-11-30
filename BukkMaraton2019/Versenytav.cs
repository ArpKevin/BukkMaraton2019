using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    class Versenytav
    {
        public string Rajtszam;
        public string Kategoria { get; set; }
        public string Nev { get; set; }
        public string Egyesulet { get; set; }
        public TimeSpan Ido { get; set; }
        public string Tav
        {
            get
            {
                switch (Rajtszam[0])
                {
                    case 'M': return "Mini";
                    case 'R': return "Rövid";
                    case 'K': return "Közép";
                    case 'H': return "Hosszú";
                    case 'E': return "Pedelec";
                }
                return "Hibás rajtszám";
            }
        }
        public Versenytav(string rajtszam, string kategoria, string nev, string egyesulet, string ido)
        {
            Rajtszam = rajtszam;
            Kategoria = kategoria;
            Nev = nev;
            Egyesulet = egyesulet;
            Ido = TimeSpan.Parse(ido);
        }
    }

}
