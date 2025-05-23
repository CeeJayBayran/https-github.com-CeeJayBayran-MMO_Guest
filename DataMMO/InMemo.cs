using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;

namespace DataLayer
{
    public class InMemoryGuestStorage
    {
        private readonly List<Guest> guests = new List<Guest>(); 

        public void AddGuest(Guest guest)
        {
            guests.Add(guest);
        }

        public bool RemoveGuest(string name)
        {
            var guest = guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (guest != null)
            {
                guests.Remove(guest);
                return true;
            }
            return false;
        }

        public List<Guest> GetAllGuests()
        {
            return new List<Guest>(guests); 
        }

        public Guest FindGuest(string name)
        {
            return guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(string name)
        {
            return guests.Any(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}