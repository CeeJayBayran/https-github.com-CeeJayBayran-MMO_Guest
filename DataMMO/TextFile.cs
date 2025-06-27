using System;
using System.Collections.Generic;
using System.IO;
using ClassLibrary1;
using DataMMO.DataLayer;

namespace DataLayer
{//TEXTFILE//
    public class TextFile : IMMO
    {
        private readonly string logFile = "guestLog.txt";

        public bool Register(string name, string role)
        {
            DateTime timeIn = DateTime.Now;
            string logEntry = $"{name} - {role} entered at {timeIn}";
            File.AppendAllLines(logFile, new[] { logEntry });
            return true;
        }

        public bool ExitGuest(string name)
        {
            DateTime timeOut = DateTime.Now;
            string logExit = $"{name} exited at {timeOut}";
            File.AppendAllLines(logFile, new[] { logExit });
            return true;
        }

        public bool Exists(string name)
        {
            
            return false;
        }

        public Guest? SearchGuest(string name)
        {
           
            return null;
        }

        public List<Guest> GetAllGuests()
        {
        
            return new List<Guest>();
        }
    }
}
