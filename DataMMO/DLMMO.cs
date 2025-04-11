using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public static class GuestDataService 
    {
        private static List<Guest> guests = new List<Guest>();

        public static void AddGuest(Guest guest)
        {
            guests.Add(guest);
        }

        public static bool DeleteGuest(string name)
        {
            var guest = guests.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (guest != null)
            {
                guests.Remove(guest);
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
