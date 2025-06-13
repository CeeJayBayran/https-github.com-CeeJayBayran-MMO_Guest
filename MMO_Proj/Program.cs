using System;
using Business_Logic;
using ClassLibrary1;

class Program
{
    static void Main()
    {
        var system = new BLMMO();
        string choice;

        do
        {
            // This Section was for the actions!!! :)
            Console.WriteLine("\n=== MILLIONAIRE MINDS ORGRANIZATION ===");
            Console.WriteLine("[1] Register Guest");
            Console.WriteLine("[2] View All Guests");
            Console.WriteLine("[3] Search Guest");
            Console.WriteLine("[4] Exit Guest");
            Console.WriteLine("[0] Quit");
            Console.Write("Select: ");
            choice = Console.ReadLine();

            //Now Here is the Switch Statement for the actions !!!!

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    if (system.Register(name))
                        Console.WriteLine($": {name} registered.");
                    else
                        Console.WriteLine($" (x) Unauthorized or already registered.");
                    break;

                case "2":
                    Console.WriteLine("Current Guests:");
                    foreach (var guest in system.AllGuests())
                        Console.WriteLine($"  > {guest}");
                    break;

                case "3":
                    Console.Write("Search Name: ");
                    string search = Console.ReadLine();
                    var result = system.Search(search);
                    Console.WriteLine(result != null ? $"[/] {result}" : "!! Guest not found.!!");
                    break;

                case "4":
                    Console.Write("Exit Guest Name: ");
                    string exit = Console.ReadLine();
                    Console.WriteLine(system.Exit(exit) ? $"[-] {exit} exited." : "!! Guest not found.!!");
                    break;

                case "0":
                    Console.WriteLine("Exiting system...");
                    break;

                default:
                    Console.WriteLine("!! Invalid option.");
                    break;
            }

            Console.WriteLine();
        } while (choice != "0");
    }
}
