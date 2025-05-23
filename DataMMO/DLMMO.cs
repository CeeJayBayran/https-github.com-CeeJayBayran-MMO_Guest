using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClassLibrary1;

namespace DataLayer
{
    public class GuestDataService
    {
        private readonly string jsonFilePath = "guestData.json";
        private readonly string textFilePath = "guestData.txt";
        private List<Guest> guests = new();

        public GuestDataService()
        {
            LoadGuestsFromJson();
        }

        private void LoadGuestsFromJson()
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                guests = JsonSerializer.Deserialize<List<Guest>>(jsonData) ?? new List<Guest>();
            }
        }

        private void SaveGuestsToJson()
        {
            string jsonData = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonData);
        }

        private void SaveGuestsToTextFile()
        {
            File.WriteAllLines(textFilePath, guests.Select(g => g.Name));
        }

        public void AddGuest(Guest guest)
        {
            if (!Exists(guest.Name))
            {
                guests.Add(guest);
                SaveGuestsToJson();
                SaveGuestsToTextFile();
            }
        }

        public bool RemoveGuest(string name)
        {
            var guest = guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (guest != null)
            {
                guests.Remove(guest);
                SaveGuestsToJson();
                SaveGuestsToTextFile();
                return true;
            }
            return false;
        }

        public List<Guest> GetAllGuests() => new List<Guest>(guests);
        public Guest FindGuest(string name) => guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public bool Exists(string name) => guests.Any(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}