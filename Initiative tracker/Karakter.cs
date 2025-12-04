using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

        // Empty constructor needed for JSON deserialization
        public Karakter() { }

        public Karakter(string nev, int hP, int bonusz, int rendezesi_Ertek, bool akcio, bool bonusz_Akcio, bool reakcio, DateTime szuletesi_Datum)
        {
            Nev = nev;
            HP = hP;
            Bonusz = bonusz;
            Rendezesi_Ertek = rendezesi_Ertek;
            Akcio = akcio;
            Bonusz_Akcio = bonusz_Akcio;
            Reakcio = reakcio;
            Szuletesi_Datum = szuletesi_Datum;
        }

        /// <summary>
        /// Loads and parses karakterek.json into a List<Karakter>.
        /// </summary>
        public static List<Karakter> LoadFromJson(string filename = "karakterek.json")
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"JSON file not found: {filename}");

            string json = File.ReadAllText(filename);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Karakter>>(json)!;
        }
        public static void SaveToJson(List<Karakter> karakterek, string filename = (@".\karakterek.json"))
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(karakterek, options);
            File.WriteAllText(filename, json);
        }
    }
}