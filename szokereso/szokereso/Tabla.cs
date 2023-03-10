using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szokereso
{
    internal class Tabla
    {
        public char[,] CharMatrix { get; set; } = new char[16, 16];

        public void Megjelenit()
        {
            for (int s = 0; s < CharMatrix.GetLength(0); s++)
            {
                for (int o = 0; o < CharMatrix.GetLength(1); o++)
                {
                    Console.Write(CharMatrix[s,o] == '\0' ? '#' : CharMatrix[s,o]);
                }
                Console.Write('\n');
            }
        }
        
        private static (int s, int o) IranybaTesz(Irany irany, int s, int o)
        {
            return irany switch
            {
                /*Irany.Jobb => (s,o++),
                Irany.Jobb => (s, o++),
                Irany.Jobb => (s, o++),
                Irany.Jobb => (s, o++),
                Irany.Jobb => (s, o++),
                Irany.Jobb => (s, o++),
                Irany.Jobb => (s, o++),
                Irany.Jobb => (s, o++),*/
            };
        }
        
        public Tabla(List<Feladvany> feladvanyok)
        {
            foreach (var f in feladvanyok)
            {
                int s = f.Hely.Sor;
                int o = f.Hely.Oszlop;

                foreach (var c in f.Szo)
                {
                    CharMatrix[s, o] = c;
                    switch (f.Irany)
                    {
                        case Irany.Jobb:
                            o++;
                            break;
                        case Irany.JobbFel:
                            o++;
                            s--;
                            break;
                        case Irany.Fel:
                            s--;
                            break;
                        case Irany.BalFel:
                            o--;
                            s--;
                            break;
                        case Irany.Bal:
                            o--;
                            break;
                        case Irany.BalLe:
                            o--;
                            s++;
                            break;
                        case Irany.Le:
                            s++;
                            break;
                        case Irany.JobbLe:
                            s++;
                            o++;
                            break;
                    }
                }
            }
        }
    }
}