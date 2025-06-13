using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;

namespace DataLayer
{
    public class InMemoryGuestStorage
    {
        private readonly List<Guest> allowedGuests = new()
        {
            new Guest("Trench Mauser", "MMO Member!"),
            new Guest("Sammy Collins", "MMO Member!"),
            new Guest("Galan Galgo", "MMO Member!"), //Fun Fact this was a bunch of Characters po from a movie
            new Guest("Gustavo Hernandez", "MMO Member!"),
            new Guest("Hale Caesar", "MMO Member!"),
            new Guest("Toll Road", "MMO Member!"),
            new Guest("Yin Yang", "MMO Member!"),
            new Guest("Gunner Jensen", "MMO Member!"),
            new Guest("Lee Christmas", "MMO Member!"),
            new Guest("Barney Ross", "MMO Member!")
        };

        private readonly List<Guest> currentGuests = new();

        public bool AddGuest(string name)
        {
            var allowed = allowedGuests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (allowed != null && !Exists(name))
            {
                var newGuest = new Guest(allowed.Name, allowed.Role);
                currentGuests.Add(newGuest);
                return true;
            }
            return false;
        }

        public bool RemoveGuest(string name)
        {
            var guest = currentGuests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (guest != null)
            {
                guest.TimeOut = DateTime.Now; // ← Mark exit time
                currentGuests.Remove(guest);
                return true;
            }
            return false;
        }


        public Guest FindGuest(string name) =>
            currentGuests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public List<Guest> GetAllGuests() => new(currentGuests);

        public bool Exists(string name) =>
            currentGuests.Any(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
