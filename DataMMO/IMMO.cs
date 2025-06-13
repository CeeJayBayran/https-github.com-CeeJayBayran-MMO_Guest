using System;
using System.Collections.Generic;
using ClassLibrary1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMMO
{
    public  interface IMMO
    {
        List <Guest> GetAllGuests();
        void RegisterGuest(Guest guest);
        void ExitGuest(Guest guest);
    }
}
