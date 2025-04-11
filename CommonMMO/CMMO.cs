using System;

namespace ClassLibrary1
{
    public class Guest
    {
        public string Name { get; set; }
        public DateTime TimeIn { get; set; }

        public Guest(string name)
        {
            Name = name;
            TimeIn = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Name} (Entered: {TimeIn})";
        }
    }
}
