using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(120,60);
            
            
            Flight flight1 = new Flight("bort 111", 
                                        new DateTime(2016, 11, 25, 12, 40, 00), "Kiev", "Terminal F", "gate1", 
                                        new DateTime(2016, 11, 25, 21, 20, 00), "New York", "Terminal 1", "Gate G1", 
                                        Status.unknown, 300, 200, 100);
            Flight flight2 = new Flight("bort 222",
                                        new DateTime(2016, 11, 25, 06, 45, 00), "Kiev", "Terminal F", "gate2",
                                        new DateTime(2016, 11, 25, 11, 00, 00), "London", "Terminal 2", "Gate G2",
                                        Status.unknown, 600, 500, 400);
            Flight flight3 = new Flight("bort 333", 
                                        new DateTime(2016, 11, 25, 11, 55, 00), "Kiev", "Terminal F", "gate3", 
                                        new DateTime(2016, 11, 25, 18, 35, 00), "New York", "Terminal 3", "Gate G3", 
                                        Status.unknown, 900, 800, 700);

            //List<Flight> flights = new List<Flight> {flight1, flight2, flight3};
            Airport wizair = new Airport(new List<Flight> { flight1, flight2, flight3 });

            Flight currentFlight = flight1;

            Console.WriteLine("Select Item you need (1-n) or exit\n");
            while (true)
            {
                Console.WriteLine("0: Select Plane");
                Console.WriteLine("1: Get current plane info");
                Console.WriteLine("2: Get current plane Price");
                Console.WriteLine("3: Show passengers on current flight");
                Console.WriteLine("4: Add new passenger to current flight");
                Console.WriteLine("5: Add new Plain");
                Console.WriteLine("6: Change Information of current flight");
                Console.WriteLine("7: Search for the info");

                Console.WriteLine("exit: Exit the program\n");
                
                string rez = Console.ReadLine();
                if (rez.ToLower()=="exit") { rez = "exit"; }

                switch (rez)
                {
                    case "0": { currentFlight = wizair.SelectAvailablePlain(); break; }
                    case "1": { wizair.ShowFlightInfo(currentFlight); break; }
                    case "2": { wizair.ShowPriceList(currentFlight); break; }
                    case "3": { wizair.ShowPassangersList(currentFlight); break; }
                    case "4": { currentFlight.AddPassangerToFlight(); break; }
                    case "5": { wizair.flights.Add(wizair.AddNewPlain()); break; }
                    case "6": { wizair.EditPlainInfo(currentFlight); break; }
                    case "7": { wizair.Search4Flight(); break; }
                    case "exit": { return; }
                    default:
                        break;
                }
            }

        }
    }
}
