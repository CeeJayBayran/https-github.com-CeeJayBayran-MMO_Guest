using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClassLibrary1;
using DataMMO.DataLayer;

namespace DataLayer
{
    public class Json : IMMO
    {
        private readonly string filePath = "guestData.json";
        private List<Guest> guests = new();

        private void LoadGuests()
        {
           if (File.Exists(filePath))
            {
           string content = File.ReadAllText(filePath);
           var data = JsonSerializer.Deserialize<List<Guest>>(content);
           if (data != null)
           guests = data;
            }
        }

        private void SaveGuests()
        {
            string content = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, content);
        }

        public bool Register(string name, string role)
        {
            LoadGuests();

            var guest = new Guest
            {
                Name = name,
                Role = role,
                TimeIn = DateTime.Now
            };

            guests.Add(guest);
            SaveGuests();
            return true;
        }

        public bool ExitGuest(string name)
        {
            LoadGuests();

            var guest = guests.LastOrDefault(g => g.Name == name && g.TimeOut == null);
            if (guest != null)
            {
           guest.TimeOut = DateTime.Now;
           SaveGuests();
           return true;
            }

            return false;
        }

        public bool Exists(string name)
        {
            LoadGuests();
            return guests.Any(g => g.Name == name);
        }

        public Guest? SearchGuest(string name)
        {
            LoadGuests();
            return guests.LastOrDefault(g => g.Name == name);
        }

        public List<Guest> GetAllGuests()
        {
            LoadGuests();
            return guests;
        }
    }
}
