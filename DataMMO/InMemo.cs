using System;
using System.Collections.Generic;
using ClassLibrary1;
using DataLayer;
using DataMMO.DataLayer;

namespace DataLayer
{
    public class InMemoryService
    {
        private readonly Dictionary<string, string> authorizedGuests = new()
        { //LIST OF THE PEOPLES WHO ONLY HAVE AUTHORIZATION OR BELONG TO THE ORGANIZATION//
            { "Trench Mauser", "CEO, Mauser Global Logistics" },
            { "Galan Galgo", "CEO, Galgo World Mobility" },
            { "Hale Caesar", "CEO, Caesar Mineral Industries" },
            { "Toll Road", "CEO, Roadchain Digital Core" },
            { "Yin Yang", "CEO, Yang Discipline Systems" },
            { "Gunner Jensen", "CEO, Jensen IronWorks" },
            { "Lee Christmas", "CEO, Christmas Global Protection" },
            { "Barney Ross", "Supreme Chairman, Ross Legacy Holdings" },
            { "James Munroe", "CEO, Munroe Risk Authority" },
            { "Jean Vilain", "CEO, Vilain Prestige Holdings" },
            { "Conrad Stonebanks", "CEO, Stonebanks Shadow Trade" },
            { "Dan Paine", "CEO, Paine Property Dominion" },
            { "Billy Timmons", "CEO, Timmons Nexus Systems" },
            { "General Garza", "CEO, Garza Influence Bureau" },
            { "Easy Day", "CEO, DayHaul Global Freight" },
            { "Charisma Carpenter", "CEO, Charisma Echo PR" },
            { "Maggie Chan", "CEO, Chan CyberBlack Division" },
            { "Mr Church", "CEO, Church Phantom Affairs" },
            { "Max Drummer", "CEO, Drummer Aerial Systems Inc" },
            { "Sylvester Stallone", "Honorary Founder, Stallone Legacy Fund" }
        };

        private List<Guest> activeGuests = new();
        private readonly Json json = new();       
        private readonly TextFile text = new();    
        private readonly DBMillionaireOrg db = new();
        //FOR THE JSON DATABASE AND TEXTFILE TO WORK NOT  JUST FOR FATABSE OR NOT JUST FOR JSON AND TEXTFILE //
        public InMemoryService()
        {
            activeGuests = json.GetAllGuests().FindAll(g => g.TimeOut == null);
        }

        public bool AddGuest(string name)
        {
            if (!authorizedGuests.ContainsKey(name) || activeGuests.Exists(g => g.Name == name))
                return false;

            var guest = new Guest(name, authorizedGuests[name])
            {
                TimeIn = DateTime.Now
            };

            activeGuests.Add(guest);

            return true;
        }

        public bool RemoveGuest(string name)
        {
            var guest = activeGuests.Find(g => g.Name == name);
            if (guest == null) return false;

            guest.TimeOut = DateTime.Now;

            activeGuests.Remove(guest);
            return true;
        }

        public Guest FindGuest(string name) => activeGuests.Find(g => g.Name == name);
        public bool Exists(string name) => authorizedGuests.ContainsKey(name);
        public List<Guest> GetAllGuests() => new(activeGuests);
    }
}
