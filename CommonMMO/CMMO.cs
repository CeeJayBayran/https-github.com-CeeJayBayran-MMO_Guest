namespace ClassLibrary1
{
    public class Guest
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public Guest() { }

        public Guest(string name, string role)
        {
            Name = name;
            Role = role;
        }
        //THis thing is just only for case that if the date and time did not worked//
        public override string ToString()
        {
            string exit = TimeOut.HasValue ? $" | Exited: {TimeOut}" : "";
            return $"{Name} - {Role} (Entered: {TimeIn}{exit})";
        }
    }
}
