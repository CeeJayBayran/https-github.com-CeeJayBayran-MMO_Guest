using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibrary1
{
    public static class GuestTextFileService
    {
        private static readonly string textFilePath = "";
        private static List<Guest> guests = new List<Guest>();

        static GuestTextFileService()
        {
            LoadGuestsFromTextFile();
        }

        private static void LoadGuestsFromTextFile()
        {
            if (File.Exists(textFilePath))
            {
                var lines = File.ReadAllLines(textFilePath);
                guests = lines.Select(line => new Guest(line)).ToList();
            }
        }

        private static void SaveGuestsToTextFile()
        {
            var lines = guests.Select(g => g.Name).ToArray();
            File.WriteAllLines(textFilePath, lines);
        }

        public static void AddGuest(Guest guest)
        {
            guests.Add(guest);
            SaveGuestsToTextFile();
        }

        public static bool DeleteGuest(string name)
        {
            var guest = guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (guest != null)
            {
                guests.Remove(guest);
                SaveGuestsToTextFile();
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
