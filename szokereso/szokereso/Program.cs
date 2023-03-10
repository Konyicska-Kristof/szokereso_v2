using System.Text;
namespace szokereso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Feladvany> feladvanyok = new();
            
            using StreamReader sr = new(@"..\..\..\src\szavak.txt", Encoding.Latin1);

            while (!sr.EndOfStream)
            {
                feladvanyok.Add(new Feladvany(sr.ReadLine()));
            }

            Console.WriteLine($"1. Feladat - Szavak száma: {feladvanyok.Count} db");

            /*
            int im = 0;
           int max = int.MinValue;
           while (im<feladvanyok.Count)
           {
               if (feladvanyok[im].Szo.Length>max)
               {
                   max = feladvanyok[im].Szo.Length;
               }
               im++;
           }
            */

            int max = feladvanyok.Max(x => x.Szo.Length);

           Console.WriteLine($"2. Feladat - Leghosszabb szó hossza: {max} db karakter");

           Console.WriteLine("3. Feladat - Leghosszabb szó/szavak:");

            for (int i = 0; i < feladvanyok.Count; i++)
            {
                if (feladvanyok[i].Szo.Length==max)
                {
                    Console.Write($"\t{feladvanyok[i].Szo}\n");
                }
            }

            Console.Write("5. Feladat - Szavak kiírása\n\t");

            Tabla tabla = new(feladvanyok);
            tabla.Megjelenit();

        }
    }
}