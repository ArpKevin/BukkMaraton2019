using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var versenyzok = new List<Versenytav>();

            using var sr = new StreamReader(@"..\..\..\src\bukkm2019.txt", encoding: Encoding.UTF8);

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var sor = sr.ReadLine().Split(";");
                versenyzok.Add(new(sor[0], sor[1], sor[2], sor[3], sor[4]));
            }

            Console.WriteLine($"4. feladat: Versenytávot nem teljesítők: {100 - ((double)versenyzok.Count / 691 * 100)}%");

            Console.WriteLine($"5. feladat: Női versenyzők száma a rövidtávú versenyen: {versenyzok.Count(v => v.Tav == "Rövid" && v.Kategoria.EndsWith('n'))}fő");

            bool voltIlyen = versenyzok.Any(v => v.Ido > TimeSpan.Parse("6:00:00"));

            Console.WriteLine($"6. feladat: {(voltIlyen ? "Volt ilyen versenyző" : "Nem volt ilyen versenyző")}");

            Console.WriteLine("7. feladat: A felnőtt férfi (ff) kategória győztese rövid távon");

            var gyoztesFerfiFF = versenyzok.Where(v => v.Tav == "Rövid" && v.Kategoria == "ff").MinBy(v => v.Ido);

            Console.WriteLine($"\tRajtszám: {gyoztesFerfiFF.Rajtszam}");
            Console.WriteLine($"\tNév: {gyoztesFerfiFF.Nev}");
            if (gyoztesFerfiFF.Egyesulet != string.Empty)
            {
                Console.WriteLine($"\tEgyesület: {gyoztesFerfiFF.Egyesulet}");
            }
            Console.WriteLine($"\tIdő: {gyoztesFerfiFF.Ido}");

            var ferfiVersenyzok = versenyzok.Where(v => v.Kategoria.EndsWith('f'));

            var kategoriak = ferfiVersenyzok.GroupBy(v => v.Kategoria).ToDictionary(k => k.Key, v => v.Count());

            foreach (var v in kategoriak)
            {
                Console.WriteLine($"{v.Key} - {v.Value}fő");
            }


            Console.ReadKey();
        }
    }
}