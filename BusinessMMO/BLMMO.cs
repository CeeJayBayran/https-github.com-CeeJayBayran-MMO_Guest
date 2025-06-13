using System.Collections.Generic;
using ClassLibrary1;
using DataLayer;

namespace Business_Logic
{
    public class BLMMO
    {
        private readonly DLMMO data = new();

        public bool Register(string name) => data.Register(name);
        public bool Exit(string name) => data.Exit(name);
        public Guest Search(string name) => data.Search(name);
        public bool Exists(string name) => data.Exists(name);
        public List<Guest> AllGuests() => data.GetAll();
    }
}
