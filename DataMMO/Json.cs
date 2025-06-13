using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClassLibrary1;
                           // Malaking ipikto sa buston siltiks ang pagkawala ni jison titum //
namespace DataLayer
{
    public class GuestDataService  // This is my Json Part po hehhhehe//
    {
        private readonly string jsonFilePath = "guestData.json";
        private List<Guest> guests = new();

        public void LogGuest(Guest guest)
        {
            LoadFromFile();
            guests.Add(guest);
            SaveToFile();
        }

        private void LoadFromFile()
        {
            if (File.Exists(jsonFilePath))
            {
                var json = File.ReadAllText(jsonFilePath);
                guests = JsonSerializer.Deserialize<List<Guest>>(json) ?? new();
            }
        }
        public void LogExit(Guest guest)
        {
            LoadFromFile();
            guests.Add(new Guest(guest.Name, guest.Role)
            {
                TimeIn = guest.TimeIn, //Time In Time Out
                TimeOut = guest.TimeOut
            });
            SaveToFile();
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
