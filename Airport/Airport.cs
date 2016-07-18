using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    enum Status 
    { 
        check_in,
        gate_closed,
        arrived,
        departed_at,
        unknown,
        canceled,
        expected_at,
        delayed,
        in_flight
    }   

    interface IAirport
    {
        void ShowFlightInfo(Flight someFlight);
        void ShowPriceList(Flight someFlight);
        void ShowPassangersList(Flight someFlight);
        void EditPlainInfo(Flight someFlight);
        void Search4Flight();
        Flight AddNewPlain();
        Flight SelectAvailablePlain();
    }

    class Airport : IAirport, IEnumerable, IComparer
    {
        public List<Flight> flights;// { get; set; }

        public Airport(List<Flight> flights)
        {
            this.flights = flights;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in flights)
            {
                yield return item;
            }
        }

        public int Compare(object x, object y)
        {
            if (x.Equals(y))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public void ShowPassangersList(Flight someFlight)
        {
            Console.WriteLine("---- passengers on flight: " + someFlight.flightNumber+" ----");
            if (someFlight.passangers.Count == 0 )
            {
                Console.WriteLine(" - no registered passangers on flight \n");
            }
            foreach (var item in someFlight.passangers)
            {
                if (item == null)
                {
                    break;
                }
                Console.WriteLine("Name        : " + item.PassName);
                Console.WriteLine("Sirname     : " + item.PassSirname);
                Console.WriteLine("Passport    : " + item.Passport);
                Console.WriteLine("Nationality : " + item.Nationality);
                Console.WriteLine("Sex         : " + item.Sex);
                Console.WriteLine("DateOfBirth : " + item.DateOfBirth.ToString("dd MMMM yyyy"));
                Console.WriteLine("ClassOfSeat : " + item.ClassOfSeat);
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine();
        }

        public void ShowFlightInfo(Flight someFlight)
        {
            Console.WriteLine("----plane info------");
            Console.WriteLine("flightNumber     : " + someFlight.flightNumber);

            Console.WriteLine("departureCity    : " + someFlight.departureCity);
            Console.WriteLine("departureDateTime: " + someFlight.departureDateTime);
            Console.WriteLine("departureTerminal: " + someFlight.departureTerminal);
            Console.WriteLine("departureGate    : " + someFlight.departureGate);

            Console.WriteLine("arrivalCity      : " + someFlight.arrivalCity);
            Console.WriteLine("arrivalDateTime  : " + someFlight.arrivalDateTime);
            Console.WriteLine("arrivalTerminal  : " + someFlight.arrivalTerminal);
            Console.WriteLine("arrivalGate      : " + someFlight.arrivalGate);

            Console.WriteLine("aircraftStatus   : " + someFlight.aircraftStatus);
            Console.WriteLine("VIP price        : " + someFlight.Price_VIP);
            Console.WriteLine("business price   : " + someFlight.Price_Business);
            Console.WriteLine("econom price     : " + someFlight.Price_Econom);
            Console.WriteLine("--------------------\n");
        }

        public Flight SelectAvailablePlain()
        {
            Flight currentFlight = null;
            Console.WriteLine("Select your Plain:");
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + flights[i].flightNumber);
            }
            bool checkPlaneAvailable = false;
            while (!checkPlaneAvailable)
            {
                try
                {
                    currentFlight = flights[Convert.ToInt32(Console.ReadLine()) - 1];
                    checkPlaneAvailable = true;
                }
                catch (ArgumentOutOfRangeException ) { Console.WriteLine("try another ... available 1 - {0}.", flights.Count); }
            }
            return currentFlight;
        }

        public void ShowPriceList(Flight someFlight)
        {
            Console.WriteLine("----Price info------");
            Console.WriteLine("Plane : "+ someFlight.flightNumber);
            Console.WriteLine("Vip: {0}$ Business: {1}$ Econom: {2}$", someFlight.Price_VIP, someFlight.Price_Business, someFlight.Price_Econom);
            Console.WriteLine("--------------------");
        }

        public Flight AddNewPlain()
        {
            //Flight flight1 = new Flight("bort 111",
            //                            new DateTime(2016, 11, 25, 12, 40, 00), "Kiev", "Terminal F", "gate1",
            //                            new DateTime(2016, 11, 25, 21, 20, 00), "New York", "Terminal 1", "Gate G1",
            //                            Status.unknown, 300, 200, 100);

            Flight newFlight = new Flight();
            
            do
            {
                Console.WriteLine("Input Flight name (e.g. bort 123)");
                newFlight.flightNumber = Console.ReadLine();
            } while (newFlight.flightNumber == "");
            


            bool checkDateDeparture = false;
            while (!checkDateDeparture)
            {
                try
                {
                    Console.WriteLine("Input departure Date/Time in format dd/mm/yyyy hh:mm");
                    newFlight.departureDateTime = Convert.ToDateTime(Console.ReadLine());
                    checkDateDeparture = true;
                }
                catch (Exception )
                {
                    Console.WriteLine("wrong format. please try again");
                }
            }

            do
            {
                Console.WriteLine("Input Departure City");
                newFlight.departureCity = Console.ReadLine();
            } while (newFlight.departureCity == "");

            do
            {
                Console.WriteLine("Input Departure Terminal (e.g. B)");
                newFlight.departureTerminal = "Terminal " + Console.ReadLine();
            } while (newFlight.departureTerminal =="");

            bool checkDateArrival = false;
            while (!checkDateArrival)
            {
                try
                {
                    Console.WriteLine("Input arrival Date/Time in format dd/mm/yyyy hh:mm");
                    newFlight.arrivalDateTime = Convert.ToDateTime(Console.ReadLine());
                    checkDateArrival = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("wrong format. please try again");
                }
            }

            do
            {
                Console.WriteLine("Input Arrival City");
                newFlight.arrivalCity = Console.ReadLine();
            } while (newFlight.arrivalCity == "");

            do
            {
                Console.WriteLine("Input Arrival Terminal (e.g. B)");
                newFlight.arrivalTerminal = "Terminal " + Console.ReadLine();
            } while (newFlight.arrivalTerminal == "");

            do
            {
                Console.WriteLine("Input Arrival Gate (e.g. 21)");
                newFlight.arrivalGate = "Gate " + Console.ReadLine();
            } while (newFlight.arrivalGate == "");
            

            newFlight.aircraftStatus = Status.unknown;

            bool checkVipPrice = false;
            while (!checkVipPrice)
            {
                try
                {
                    Console.WriteLine("Input VIP Price");
                    newFlight.Price_VIP = Convert.ToInt32(Console.ReadLine());
                    checkVipPrice = true;
                }
                catch (Exception){ Console.WriteLine("wrong format: expecting integer value. try again"); }
            }
            bool checkBusinessPrice = false;
            while (!checkBusinessPrice)
            {
                try
                {
                    Console.WriteLine("Input business Price");
                    newFlight.Price_Business = Convert.ToInt32(Console.ReadLine());
                    checkBusinessPrice = true;
                }
                catch (Exception){ Console.WriteLine("wrong format: expecting integer value. try again"); }
            }
            bool checkEconomPrice = false;
            while (!checkEconomPrice)
            {
                try
                {
                    Console.WriteLine("Input econom Price");
                    newFlight.Price_Econom = Convert.ToInt32(Console.ReadLine());
                    checkEconomPrice = true;
                }
                catch (Exception) { Console.WriteLine("wrong format: expecting integer value. try again"); }
            }

            return newFlight;
        }

        public void EditPlainInfo(Flight currentFlight)
        {
            Console.WriteLine("What info you want to edit?");
            Console.WriteLine("1: flightNumber");

            //Console.WriteLine("2: departureCity");
            //Console.WriteLine("3: departureDateTime");
            //Console.WriteLine("4: departureTerminal");
            //Console.WriteLine("5: departureGate");

            //Console.WriteLine("6: arrivalCity");
            //Console.WriteLine("7: arrivalDateTime");
            //Console.WriteLine("8: arrivalTerminal");
            //Console.WriteLine("9: arrivalGate");

            //Console.WriteLine("10: aircraftStatus");
            //Console.WriteLine("11: VIP price");
            //Console.WriteLine("12: business price");
            //Console.WriteLine("13: econom price");

            Console.WriteLine("back: Back to main menu\n");


            string rez = Console.ReadLine();
            if (rez.ToLower() == "back")
            {
                rez = "back";
            }
            switch (rez)
            {
                case "1":{ Console.WriteLine("Input new name for the flight: "); currentFlight.flightNumber = Console.ReadLine(); break; }
                case "2":  { break; }
                case "3":  { break; }
                case "4":  { break; }
                case "5":  { break; }
                case "6":  { break; }
                case "7":  { break; }
                case "8":  { break; }
                case "9":  { break; }
                case "10": { break; }
                case "11": { break; }
                case "12": { break; }
                case "13": { break; }

                case "back": { break; }

                default:
                    break;
            }

            
        }


        public void Search4Flight()
        {
            //–search by the flight number, price, first and second name, passport, arrival (departure) port of and information output in the specified format
            //–IComplarable, IComparer, IEnumerable in searching
            //throw new NotImplementedException();

            Console.WriteLine("Input field to search?");
            Console.WriteLine("1: flightNumber");
            Console.WriteLine("2: firstname");
            Console.WriteLine("3: lastname");
            Console.WriteLine("4: passport");
            Console.WriteLine("back: Exit the search");
            string rez = Console.ReadLine();
            switch (rez)
            {
                case "1":
                {
                    Console.WriteLine("input flight number to find");
                    string searchTarget = Console.ReadLine();
                    foreach (Flight item in this)
                    {
                        if (Compare(item.flightNumber.ToLower(), searchTarget.ToLower()) == 0)
                        {
                            Console.WriteLine("\nFlight with number \"{0}\" was found ", searchTarget);
                            ShowFlightInfo(item);
                        }
                    }
                    break;
                }
                case "2":
                {
                    Console.WriteLine("input passenger's name to find");
                    string searchTarget = Console.ReadLine();
                    foreach (Flight item in this)
                    {
                        foreach (Passenger passanger in item)
                        {
                            if (Compare(passanger.PassName.ToLower(), searchTarget.ToLower()) == 0)
                            {
                                Console.WriteLine("\nPassanger with name \"{0}\" was found on flight \"{1}\"", searchTarget, item.flightNumber);
                                ShowFlightInfo(item);
                            }    
                        }
                    }
                    break;
                }
                case "3":
                {
                    Console.WriteLine("input passenger's lastname to find");
                    string searchTarget = Console.ReadLine();
                    foreach (Flight item in this)
                    {
                        foreach (Passenger passanger in item)
                        {
                            if (Compare(passanger.PassSirname.ToLower(), searchTarget.ToLower()) == 0)
                            {
                                Console.WriteLine("\nPassanger with surname \"{0}\" was found on flight \"{1}\"", searchTarget, item.flightNumber);
                                ShowFlightInfo(item);
                            }
                        }
                    }
                    break;
                }
                case "4":
                {
                    Console.WriteLine("input passenger's passport to find");
                    string searchTarget = Console.ReadLine();
                    foreach (Flight item in this)
                    {
                        foreach (Passenger passanger in item)
                        {
                            if (Compare(passanger.Passport.ToLower(), searchTarget.ToLower()) == 0)
                            {
                                Console.WriteLine("\nPassanger with passport \"{0}\". Fullname is \"{1} {2}\" was found on flight \"{3}\"", searchTarget, passanger.PassSirname, passanger.PassName, item.flightNumber);
                                ShowFlightInfo(item);
                            }
                        }
                    }
                    break;
                }


                case "back": {Console.WriteLine(); return; }
                default:
                    break;
            }
            Console.WriteLine("Press 'Enter' to continue\n");
            Console.ReadLine();

           
            
        }






    }
}
