using System.Collections.Generic;
using ClassLibrary1;
namespace DataMMO. DataLayer
{
    public interface IMMO
    {
        List<Guest> GetAllGuests();
        Guest SearchGuest(string name);
        bool Register(string name , string role);
        bool ExitGuest(string name);
        bool Exists(string name);
    }
}
