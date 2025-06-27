using System;
using System.Collections.Generic;
using ClassLibrary1;
using DataLayer;
using DataMMO.DataLayer;

namespace DataLayer
{
    public class DLMMO
    { // AND IT HAS THIS IN MEMORY LINE BECAUSE THIS WILL HELP TO GET THE INFO OF THOSE DATA OR MEMBERS THAT ARE ALLOWEED//
        private readonly InMemoryService inMemory = new();
        private readonly Json json = new();       
        private readonly TextFile text = new();     
        private readonly DBMillionaireOrg db = new();
        //AGAIN THIS IS ALSO FOR JSON DATABSE SQL AND TEXFILE TO WORK AND THIS MUST BE HERE DEFINITELY//
        public bool Register(string name)
        {
            bool added = inMemory.AddGuest(name);
            if (added)
            {
                var guest = inMemory.FindGuest(name);
                json.Register(guest.Name, guest.Role); 
                text.Register(guest.Name, guest.Role); 
                db.Register(guest.Name, guest.Role);  
            }
            return added;
        }

        public bool Exit(string name)
        {
            var guest = inMemory.FindGuest(name);
            if (guest == null) return false;

            guest.TimeOut = DateTime.Now;

            if (inMemory.RemoveGuest(name))
            {
                json.ExitGuest(name);
                text.ExitGuest(name);
                db.ExitGuest(name);
                return true;
            }

            return false;
        }

        public Guest Search(string name) => inMemory.FindGuest(name);
        public bool Exists(string name) => inMemory.Exists(name);
        public List<Guest> GetAll() => inMemory.GetAllGuests();
    }
}
