using System;
using System.Collections.Generic;
using Business_Logic;

namespace MMOGuestManager
{
    internal class Program
    {
        // Allowed MMO member names lang dito, hindi sila auto-registered.
        static readonly List<string> dummyNames = new List<string>()
        {
            "Barney Ross", "Lee Christmas", "Gunner Jensen", "Yin Yang", "Toll Road",
            "Hale Caesar", "Gustavo Hernandez", "Galan Galgo", "Sammy Collins", "Trench Mauser"
            //Just a few names that i get from a movie,,
            //i cant think of any specific names that sounds manly except for this ... :((
        };

        static void Main()
        {
            Console.WriteLine("Millionaire Minds Org Guest Event:");
            // Hindi muna ireregistered if indi part ng Org

            while (true)
            {
                ListActions();
                int userInput = CollectUserInput();

                switch (userInput)
                {
                    case 1:
                        RegisterGuestUI();
                        break;
                    case 2:
                        ViewGuestsUI();
                        break;
                    case 3:
                        RemoveGuestUI();
                        break;
                    case 4:
                        SearchGuestUI();
                        break;
                    case 5:
                        Exit();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ListActions()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("GUEST MMO MENU");
            Console.WriteLine("[1] Register Guest");
            Console.WriteLine("[2] View Guest List");
            Console.WriteLine("[3] Remove Guest");
            Console.WriteLine("[4] Search Guest");
            Console.WriteLine("[5] Exit");
        }

        static int CollectUserInput()
        {
            Console.Write("Enter Action: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                return userInput;
            }
            return 0;
        }

        static void RegisterGuestUI()
        {
            Console.Write("Enter guest name: ");
            string guestName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(guestName))
            {
                Console.WriteLine("Invalid name. Please try again.");
                return;
            }

            // Check if guest is allowed member
            bool isAllowed = dummyNames.Exists(name => name.Equals(guestName, StringComparison.OrdinalIgnoreCase));
            if (!isAllowed)
            {
                Console.WriteLine("Error: Guest name not recognized as MMO member. Registration denied.");
                return;
            }

            // Check if guest already registered
            if (!DATAPROCESSING.GetGuestList().Exists(g => g.Name.Equals(guestName, StringComparison.OrdinalIgnoreCase)))
            {
                DATAPROCESSING.RegisterGuest(guestName);
                string timeOfArrival = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                Console.WriteLine($"Guest '{guestName}' Registered! Time of Arrival: {timeOfArrival}");
            }
            else
            {
                Console.WriteLine("Guest already registered.");
            }
        }

        static void ViewGuestsUI()
        {
            var guests = DATAPROCESSING.GetGuestList();
            Console.WriteLine("List of Guests:");
            if (guests.Count == 0)
            {
                Console.WriteLine("No guests registered yet.");
            }
            else
            {
                foreach (var guest in guests)
                {
                    Console.WriteLine(guest.ToString());
                }
            }
        }

        static void RemoveGuestUI()
        {
            Console.Write("Enter guest name to remove: ");
            string nameToRemove = Console.ReadLine();

            if (DATAPROCESSING.RemoveGuest(nameToRemove))
            {
                string timeOfExit = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                Console.WriteLine($"Guest '{nameToRemove}' exited at {timeOfExit}");
            }
            else
            {
                Console.WriteLine("Guest not found.");
            }
        }

        static void SearchGuestUI()
        {
            Console.Write("Enter guest name to search: ");
            string nameToSearch = Console.ReadLine();

            var guest = DATAPROCESSING.SearchGuest(nameToSearch);

            if (guest != null)
            {
                Console.WriteLine($"Guest found: {guest.ToString()}");
            }
            else
            {
                Console.WriteLine($"Guest '{nameToSearch}' not found.");
            }
        }

        static void Exit()
        {
            Console.Write("Confirm exit (press enter): ");
            string exit = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(exit))
            {
                Console.WriteLine("Exiting... Goodbye!");
            }
            else
            {
                Console.WriteLine("Exiting without confirmation.");
            }
        }
    }
}
