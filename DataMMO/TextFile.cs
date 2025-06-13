using System;
using System.Collections.Generic;
using System.IO;
using ClassLibrary1;

namespace DataLayer
{
    public class GuestTextFileService  //  The TextFile part po ehhehhehhe//
    {
        private readonly string textFilePath = "guestLog.txt";

        public void LogGuest(Guest guest)
        {
            var line = $"{guest.Name} - {guest.Role} entered at {guest.TimeIn}";
            File.AppendAllLines(textFilePath, new[] { line });
        }
        public void LogExit(Guest guest)
        {
            var line = $"{guest.Name} - {guest.Role} exited at {guest.TimeOut}";
            File.AppendAllLines(textFilePath, new[] { line });
        }

    }
}
