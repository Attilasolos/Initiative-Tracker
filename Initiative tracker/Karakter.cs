using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Initiative_tracker
{
    internal class Karakter
    {
        public string Nev { get; set; }
        public int HP { get; set; }
        public int Bonusz { get; set; }
        public int Rendezesi_Ertek { get; set; }
        public bool Akcio { get; set; }
        public bool Bonusz_Akcio { get; set; }
        public bool Reakcio { get; set; }
        public DateTime Szuletesi_Datum { get; set; }
        Random rnd = new Random();


        public Karakter(string Sor)
        {
            var Data = Sor.Split(';');
            Nev = Data[0];
            HP = int.Parse(Data[1]);
            Bonusz = int.Parse(Data[2]);

            if (int.Parse(Data[3]) == 0)
            {
                Akcio = false;
            }
            else
            {
                Akcio = true;
            }
            if (int.Parse(Data[4]) == 0)
            {
                Bonusz_Akcio = false;
            }
            else
            {
                Bonusz_Akcio = true;
            }
            if (int.Parse(Data[5]) == 0)
            {
                Reakcio = false;
            }
            else
            {
                Reakcio = true;
            }
            Szuletesi_Datum = DateTime.Parse(Data[6]);

            Rendezesi_Ertek = rnd.Next(1, 20);
        }


        public static List<Karakter> Read(string filename = "karakterek.txt") {
            var list = new List<Karakter>();
            using (var sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream) {
                    var row = sr.ReadLine()!;
                    var karakter = new Karakter(row);
                    list.Add(karakter);
                }
                }
            return list;
            }
    }
}
