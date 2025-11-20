using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initiative_tracker
{
    internal class Karakter
    {
        public string Nev { get; set; }
        public int HP { get; set; }
        public int Bonusz { get; set; }
        public int Rendezesi_Ertek { get; set; }
        public bool Akcio {  get; set; }
        public bool Bonusz_Akcio { get; set; }
        public bool Reakcio {get; set;}
        public DateTime Szuletesi_Datum {  get; set; }
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
                Akcio=true;
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
        }
        public void Sorba_Rakás()
        {
            Rendezesi_Ertek = rnd.Next(1,20);
        }
    }
}
