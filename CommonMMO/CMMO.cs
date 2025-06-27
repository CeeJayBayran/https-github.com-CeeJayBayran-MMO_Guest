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
        //JUST PUT THIS JUST IN CASE THE DATE TIME IN AND TIME OUT IN THE UPPER PART DID NOT WORKED WELL//
        public override string ToString()
        {
            string exit = TimeOut.HasValue ? $" | Exited: {TimeOut}" : "";
            return $"{Name} - {Role} (Entered: {TimeIn}{exit})";
        }
    }
}
