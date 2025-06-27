using System.Collections.Generic;
using ClassLibrary1;
using DataLayer;
using DataMMO;
using DataMMO.DataLayer;

namespace Business_Logic
{
    public class BLMMO
    { //TO WO
        private readonly DLMMO data = new DLMMO();
        private readonly DBMillionaireOrg db = new DBMillionaireOrg();


        public bool Register(string name) => data.Register(name);
        public bool Exit(string name) => data.Exit(name);
        public Guest Search(string name) => data.Search(name);
        public bool Exists(string name) => data.Exists(name);
        public List<Guest> AllGuests() => data.GetAll();
    }
}
