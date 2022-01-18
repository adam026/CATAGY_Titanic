using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_Titanic
{
    public class Kategoria
    {
        public string KategoriaNeve { get; set; }
        public int Tulelok { get; set; }
        public int Eltunt { get; set; }

        public Kategoria(string sor)
        {
            var buffer = sor.Split(';');
            KategoriaNeve = buffer[0];
            Tulelok = int.Parse(buffer[1]);
            Eltunt = int.Parse(buffer[2]);
        }
    }
    internal class Program
    {
        public static List<Kategoria> kategoriak = new List<Kategoria>();
        public static Dictionary<string, int> talalatok = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            Beolvasas();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            Console.ReadKey();
        }

        private static void F07()
        {
            var legtobbTulelo = kategoriak.OrderBy(y => y.Tulelok).Last();
            Console.WriteLine($"7. Feladat: \n\t{legtobbTulelo.KategoriaNeve}");
        }

        private static void F06()
        {
            var tobbMint60 = new List<string>();
            foreach (var kategoria in kategoriak)
            {
                if ((kategoria.Eltunt * 100 / kategoria.Tulelok) > 60)
                {
                    tobbMint60.Add(kategoria.KategoriaNeve);
                }
            }
            Console.WriteLine("6. Feladat: ");
            foreach (var k in tobbMint60)
            {
                Console.WriteLine($"\t{k}");
            }
        }

        private static void F05()
        {
            Console.WriteLine("5. Feladat:");
            if (talalatok.Count == 0)
            {
                Console.WriteLine("\tMivel nem volt találat, a lista üres!");
            }
            else
            {
                foreach (var talalat in talalatok)
                {
                    Console.WriteLine($"\t{talalat.Key} - {talalat.Value} fő");
                }
            }
        }

        private static void F04()
        {
            Console.Write($"4. Feladat: Kérek egy kulcsszót: ");
            var kulcsszo = Console.ReadLine();
            var talalat = 0;
            foreach (var utas in kategoriak)
            {
                if (utas.KategoriaNeve.Contains(kulcsszo.ToLower()))
                {
                    if (!talalatok.ContainsKey(utas.KategoriaNeve))
                    {
                        talalatok.Add(utas.KategoriaNeve, utas.Tulelok + utas.Eltunt);
                    }
                    else
                    {
                        talalatok[utas.KategoriaNeve] += (utas.Tulelok + utas.Eltunt);
                    }
                    talalat++;
                }
                    
            }

            if (talalat != 0)
                Console.WriteLine("\tVan találat!");
            else
                Console.WriteLine("\tNincs találat!");
        }

        private static void F03()
        {
            Console.WriteLine($"3. Feladat: A kategóriákban összesen {kategoriak.Sum(x => x.Eltunt) + kategoriak.Sum(y => y.Tulelok)} személy tatlálható.");
        }

        private static void F02()
        {
            Console.WriteLine($"2. Feladat: Az állományban {kategoriak.Count} db kategória található.");
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader(@"..\..\RES\titanic.txt"))
            {
                while (!sr.EndOfStream)
                {
                    kategoriak.Add(new Kategoria(sr.ReadLine()));
                }
            }
        }
    }
}
