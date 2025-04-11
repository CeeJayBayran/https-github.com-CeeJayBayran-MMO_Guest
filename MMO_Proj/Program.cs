
using System;
using ClassLibrary1;  
using System.Collections.Generic;
using Business_Logic;

namespace MMOGuestManager
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Millionaire Minds Org Guest Event:");

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
            if (!string.IsNullOrWhiteSpace(guestName))
            {
                DATAPROCESSING.RegisterGuest(guestName);
                string timeOfArrival = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                Console.WriteLine($"Guest '{guestName}' Registered! Time of Arrival: {timeOfArrival}");
            }//Registered Action of the System 
            else
            {
                Console.WriteLine("Invalid name. Please try again.");
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
                    Console.WriteLine(guest.ToString());  //Viewing Action of the System
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
            //Searching Action of the System
            if (guest != null)//Also yung Searching action is used to find and check is ang isang 
                              //sa naturang program ay nandoon pa or wala na sya.
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
