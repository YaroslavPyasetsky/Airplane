using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Flight : IEnumerable
    {
        public string flightNumber { get; set; }
        public List<Passenger> passangers { get; set; }

        public DateTime departureDateTime { get; set; }
        public string departureCity { get; set; }
        public string departureTerminal { get; set; }
        public string departureGate { get; set; }

        public DateTime arrivalDateTime { get; set; }
        public string arrivalCity { get; set; }
        public string arrivalTerminal { get; set; }
        public string arrivalGate { get; set; }

        public double Price_VIP { get; set; }
        public double Price_Business { get; set; }
        public double Price_Econom { get; set; }

        public Status aircraftStatus;

        public Flight()
        {
            passangers = new List<Passenger>();
            passangers.Add(new Passenger("fake001","initial","ukr","noPass000","yes", "vip",DateTime.Now));
        }
        public Flight(string flightNumber,
                        DateTime departureDateTime, string departureCity, string departureTerminal, string departureGate,
                        DateTime arrivalDateTime, string arrivalCity, string arrivalTerminal, string arrivalGate,
                        Status aircraftStatus, 
                        double price_VIP, double price_Business, double price_Econom)
        {
            passangers = new List<Passenger>();
            passangers.Add(new Passenger("fake001", "initial", "ukr", "noPass000", "yes", "vip", DateTime.Now));
            this.flightNumber = flightNumber;

            this.departureDateTime = departureDateTime;
            this.departureCity = departureCity;
            this.departureTerminal = departureTerminal;
            this.departureGate = departureGate;

            this.arrivalDateTime = arrivalDateTime;
            this.arrivalCity = arrivalCity;
            this.arrivalTerminal = arrivalTerminal;
            this.arrivalGate = arrivalGate;

            this.aircraftStatus = aircraftStatus;
            this.Price_VIP = price_VIP;
            this.Price_Business = price_Business;
            this.Price_Econom = price_Econom;
            
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in passangers)
            {
                yield return item;
            }
        }

        public void AddPassangerToFlight()
        {

            string name;
            string surname;
            string nationality;
            string sex;
            string passport;
            string classOfSeats;
            DateTime dateOfBirdth;

            Console.WriteLine("Add passengers info:");

            do
            {
                Console.WriteLine("Input name:");
                name = Console.ReadLine();    
            } while (name =="");

            do
            {
                Console.WriteLine("Input sirname:");
                surname = Console.ReadLine();
            } while (surname == "");

            do
            {
                Console.WriteLine("Input nationality:");
                nationality = Console.ReadLine();
            } while (nationality =="");

            do
            {
                Console.WriteLine("Input sex:");
                sex = Console.ReadLine();    
            } while (sex =="");

            do
            {
                Console.WriteLine("Input passport:");
                passport = Console.ReadLine();    
            } while (passport =="");

            do
            {
                Console.WriteLine("Input class of seats: vip business econom");
                classOfSeats = Console.ReadLine();    
            } while (classOfSeats == "");
            

            dateOfBirdth = new DateTime();
            bool ckeckDate = false;
            while (!ckeckDate)
            {
                try
                {
                    Console.WriteLine("Input date of birth in format dd/mm/yyyy");
                    dateOfBirdth = Convert.ToDateTime(Console.ReadLine());
                    ckeckDate = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("wrong format. please try again");
                }
            }

            this.passangers.Add(new Passenger(name, surname, nationality, passport, sex, classOfSeats, dateOfBirdth));
        }

        public void RemovePassanger(Passenger passenger)
        {
            //find Passenger and remove from array or list
        }
        public void EditPassangerInfo(Passenger passenger)
        {
            //select what info should be edited
        }


        
    }
}
