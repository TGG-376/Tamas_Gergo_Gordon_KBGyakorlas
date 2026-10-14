using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tamas_Gergo_Gordon_KBGyakorlas
{
   
    internal class Program
    {

        static List<Gaming> Jatekok = new List<Gaming>();
        static void Main(string[] args)
        {
            Adatbeolvas();


            Console.WriteLine("1. Feladat");
            Jatekok.Where(x => x.Rating >= 9.0).ToList().ForEach(y=> Console.WriteLine(y.Name));

            Console.WriteLine("\n\n2. Feladat");
            Jatekok.Where(x => x.Rating >= 8.0 && x.Release > 2015 && x.Platform == "Nintendo Switch").ToList().ForEach(y => Console.WriteLine(y.Name));

            Console.WriteLine("\n\n3. Feladat");
            Jatekok.OrderByDescending(x => x.Release).ToList().ForEach(y => Console.WriteLine(y.Name));

            Console.WriteLine("\n\n4. Feladat");
            Jatekok.OrderByDescending(x => x.Rating).Take(10).ToList().ForEach(y => Console.WriteLine($"{y.Name}, {y.Rating}"));

            Console.WriteLine("\n\n5. Feladat");
            Jatekok.GroupBy(x => x.Platform).Select(y => $"{y.Key} - {y.Count()}").ToList().ForEach(z => Console.WriteLine(z));

            Console.WriteLine("\n\n6. Feladat");
            Jatekok.GroupBy(x => x.Type).OrderByDescending(c=>(c.Count())).Take(1).Select(y => $"{y.Key} - {y.Count()}").ToList().ForEach(z => Console.WriteLine(z));

            Console.WriteLine("\n\n7. Feladat");
            Console.WriteLine(Jatekok.Average(x => x.Rating));

            Console.WriteLine("\n\n8. Feladat");
            Jatekok.GroupBy(x => x.Platform).OrderByDescending(c => (c.Count())).Take(1).Select(y => $"{y.Key} - {y.Average(u=> u.Rating)}").ToList().ForEach(z => Console.WriteLine(z));

            Console.WriteLine("\n\n9. Feladat");
            Jatekok.Where(x => x.Rating == Jatekok.Min(z => z.Rating)).ToList().ForEach(b => Console.WriteLine($"${b.Name}, {b.Rating}"));
            Jatekok.Where(x => x.Rating == Jatekok.Max(z => z.Rating)).ToList().ForEach(b => Console.WriteLine($"${b.Name}, {b.Rating}"));

            Console.WriteLine("\n\n10. Feladat");
            Jatekok.Select(x => x.Type).Distinct().ToList().ForEach(z => Console.WriteLine(z));

            Console.WriteLine("\n\n11. Feladat");
            Jatekok.Select(x =>$" {x.Name} - {x.Release}").ToList().ForEach(z => Console.WriteLine(z));

            Console.WriteLine("\n\n12. Feladat");
            Jatekok.Where(x => x.Type == "Action").OrderByDescending(y=>y.Rating).ToList().ForEach(z => Console.WriteLine($"{z.Name} - {z.Release} - {z.Rating}"));

            Console.WriteLine("\n\n13. Feladat");
            Jatekok.GroupBy(x => x.Type).Select(y => $"{y.Key} - {y.Average(u => u.Rating)}").ToList().ForEach(z => Console.WriteLine(z));

            Console.WriteLine("\n\n14. Feladat");
            Jatekok.Where(x => x.Release < 2005).Select(y => $"{y.Name} - {y.Platform}").ToList().ForEach(z => Console.WriteLine(z));


            Console.WriteLine("\n\n15. Feladat");
            Jatekok.OrderByDescending(y => y.Rating).GroupBy(x => x.Platform).FirstOrDefault().Select(j => Console.WriteLine($"{j.Name} - {j.Rating}")).ToList().ForEach(z => Console.WriteLine(z));

            Console.ReadKey();
        }

        private static void Adatbeolvas()
        {
            Jatekok = File.ReadAllLines("games_dataset.csv").Skip(1).Select(sor=>sor.Split(';')).Select(adat => new Gaming(
             adat[0], adat[1], adat[2],int.Parse(adat[3]), double.Parse(adat[4])
                )).ToList();
        }
    }
}
