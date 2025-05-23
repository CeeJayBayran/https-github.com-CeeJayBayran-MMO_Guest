using System.Collections.Generic;
using ClassLibrary1;

namespace Business_Logic
{
    public static class DATAPROCESSING
    {
        public static void RegisterGuest(string guestName)
        {
            if (!string.IsNullOrWhiteSpace(guestName) && !GuestDataService.Exists(guestName))
            {
                var newGuest = new Guest(guestName);
                GuestDataService.AddGuest(newGuest);
            }
        }

        public static List<Guest> GetGuestList() => GuestDataService.GetAllGuests();

        public static bool RemoveGuest(string name) => GuestDataService.DeleteGuest(name);

        public static Guest SearchGuest(string name) => GuestDataService.FindGuest(name);
    }
}