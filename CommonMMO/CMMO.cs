namespace ClassLibrary1
{
    public class Guest
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; } // Common po 
        public Guest() { }
        public Guest(string name, string role)
        {
            Name = name;
            Role = role;
            TimeIn = DateTime.Now;
        }

        public override string ToString()
        {
            string exitInfo = TimeOut.HasValue ? $" | Exited: {TimeOut}" : "";
            return $"{Name} - {Role} (Entered: {TimeIn}{exitInfo})";
        }
    }
}
