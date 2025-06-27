using System;
using Business_Logic;
using ClassLibrary1;

class MMO_Proj //PROGRAM IF EVER THERES SOEMTHING NOT WORKED//
{
    static void Main()
    {
        BLMMO mmo = new BLMMO();
        string choice;

        do
        {
            Console.WriteLine("\n=== MILLIONAIRE MINDS ORGANIZATION TEAM EVENT!!===");
            Console.WriteLine("[1] Register Guest");
            Console.WriteLine("[2] View All Guests");
            Console.WriteLine("[3] Search Guest");
            Console.WriteLine("[4] Exit Guest");
            Console.WriteLine("[0] Quit");
            Console.Write("Select: ");
            choice = Console.ReadLine();
            //LIST OF ACTIONS !!//
            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    bool registered = mmo.Register(name);
                    if (registered)
                    {
                        var regGuest = mmo.Search(name);
                        Console.WriteLine("[Name :] " + regGuest.Name + " registered as " + regGuest.Role);
                    }
                    else
                    {
                        Console.WriteLine("(x) Unauthorized or already registered.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Current Guests:");
                    foreach (var g in mmo.AllGuests())
                    {
                        Console.WriteLine("  > " + g);
                    }
                    break;

                case "3":
                    Console.Write("Search Name: ");
                    string search = Console.ReadLine();
                    var foundGuest = mmo.Search(search); 
                    if (foundGuest != null)
                    {
                        Console.WriteLine(" Name : " + foundGuest);
                    }
                    else
                    {
                        Console.WriteLine("!! Guest not found.");
                    }
                    break;

                case "4":
                    Console.Write("Exit Guest Name: ");
                    string exitName = Console.ReadLine();

                    bool exited = mmo.Exit(exitName);
                    if (exited)
                    {
                        Console.WriteLine("[Name :] " + exitName + " exited.");
                    }
                    else
                    {
                        Console.WriteLine("!! Guest not found or already exited.");
                    }
                    break;

                case "0":
                    Console.WriteLine("System exiting...");
                    break;

                default:
                    Console.WriteLine("!! Invalid option.");
                    break;
            }

        } while (choice != "0");
    }
}
