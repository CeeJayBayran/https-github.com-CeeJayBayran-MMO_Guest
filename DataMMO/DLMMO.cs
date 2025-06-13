using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace DataLayer
{
    public class DLMMO
    {
        private readonly InMemoryGuestStorage inMemory = new();
        private readonly GuestDataService json = new();
        private readonly GuestTextFileService textFile = new();

        public bool Register(string name)
        {
            bool added = inMemory.AddGuest(name);
            if (added)
            {
                var guest = inMemory.FindGuest(name);
                json.LogGuest(guest);
                textFile.LogGuest(guest);
            }
            return added;
        }

        public bool Exit(string name)
        {
            var guest = inMemory.FindGuest(name);
            if (guest != null)
            {
                guest.TimeOut = DateTime.Now;
                bool removed = inMemory.RemoveGuest(name);
                if (removed)
                {
                    json.LogExit(guest);     
                    textFile.LogExit(guest); 
                }
                return removed;
            }
            return false;
        }

        public Guest Search(string name) => inMemory.FindGuest(name);
        public bool Exists(string name) => inMemory.Exists(name);
        public List<Guest> GetAll() => inMemory.GetAllGuests();
    }
}
