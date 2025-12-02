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
    }
}