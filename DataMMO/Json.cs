using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ClassLibrary1
{
    public static class GuestDataService
    {
        private static List<Guest> guests = new List<Guest>();
        private static readonly string jsonFilePath = "guestData.json";

        static GuestDataService()
        {
            LoadGuestsFromJson();
        }

        private static void LoadGuestsFromJson()
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                guests = JsonSerializer.Deserialize<List<Guest>>(jsonData) ?? new List<Guest>();
            }
        }

        private static void SaveGuestsToJson()
        {
            string jsonData = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonData);
        }

        public static void AddGuest(Guest guest)
        {
            guests.Add(guest);
            SaveGuestsToJson();
        }

        public static bool DeleteGuest(string name)
        {
            var guest = guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (guest != null)
            {
                guests.Remove(guest);
                SaveGuestsToJson();
                return true;
            }
            return false;
        }

        public static List<Guest> GetAllGuests()
        {
            return new List<Guest>(guests);
        }

        public static Guest FindGuest(string name)
        {
            return guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static bool Exists(string name)
        {
            return guests.Any(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
