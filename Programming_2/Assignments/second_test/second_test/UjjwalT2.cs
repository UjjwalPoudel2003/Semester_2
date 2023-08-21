using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace second_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestLINQ();
        }

        static void TestLINQ()
        {
            Console.WriteLine($"\n\nTask 1 Output {new String('-', 30)}");


            Console.WriteLine("\nQuery 1 : Display all the non electric camping sites numbers");
            // Displaying all the non-electric camping sites
            var nonElectricSites = from site in CampingSite.SiteList
                                   where site.Type == "Non-Electric"
                                   select site.SiteNumber;

            Console.WriteLine($"{string.Join("\n", nonElectricSites)}");

            Console.WriteLine("\nQuery 2 : Display all available camping sites that has capacity of more than 6 people");
            // Displaying all available camping sites that has capacity of more than 6 people
            var availableSites = from site in CampingSite.SiteList
                                 where site.Available == true && site.Capacity > 6
                                 select site;

            Console.WriteLine($"{string.Join("\n", availableSites)}");

            Console.WriteLine("\nQuery 3 : Display all the camping sites by descending order of their capacity and increasing order of their cost");
            // Displaying all the camping sites by descending order of their capacity and increasing order of their cost
            var orderedSites = from site in CampingSite.SiteList
                               orderby site.Capacity descending, site.Cost ascending
                               select site;

            Console.WriteLine($"{string.Join("\n", orderedSites)}");

            Console.WriteLine("\nQuery 4 : Display all the electric camping sites having capacity more than 6 people ordered by park name.");
            // Displaying all the electric camping sites having capacity more than 6 people ordered by park name.
            var electricSites = from site in CampingSite.SiteList
                                where site.Type == "Electric" && site.Capacity > 6
                                orderby site.ParkName
                                select site;

            Console.WriteLine($"{string.Join("\n", electricSites)}");


            Console.WriteLine("\nQuery 5 : Display all the camping sites grouped by park name only if the group has more than 2 available sites");
            List<CampingSite> sites = CampingSite.SiteList;

            var groupedSites = sites.GroupBy(site => site.ParkName)
                .Where(group => group.Count() > 2)
                .Select(group => group);

            foreach (var group in groupedSites)
            {
                Console.WriteLine($"Site Name: {group.Key}");
                foreach (var site in group)
                {
                    Console.WriteLine($"{site}");
                }
            }

            Dictionary<string, ServiceProvider> providerList = new Dictionary<string, ServiceProvider>
            {
                { "C101", new Chiropractor("C101", "Kao", "Progress Ave", 95.00, "Neck Pain", 15) },
                { "C102", new Chiropractor("C102", "Mendy", "Spadina Ave", 110.00, "Spine", 30) },
                { "M101", new MassageTherapist("M101", "Suzzane", "Brimly", 85.00, MassageType.HotStoneMassage) },
                { "M102", new MassageTherapist("M102", "Zeal", "Bellamy Road", 115.00, MassageType.DeepTissueMassage) } 
            };

            Patient patient1 = new Patient("Ujjwal");

            List<string> idList = new List<string> { "C102", "M101", "J102", "M102" };

            // Checking if the id are present in the dictionary
            foreach (string id in idList)
            {
                if (providerList.ContainsKey(id))
                {
                    // Calling the submit booking method to add the booking to the list
                    Console.WriteLine($"Trying to Book an appointment with provider ");
                    patient1.SubmitBooking(providerList[id]);
                }
                else
                {
                    Console.WriteLine($"Provider with id {id} is not available in the list");
                }
            }

            Console.ReadKey();
        }
    }

    class CampingSite
    {
        public string ParkName { get; }
        public int SiteNumber { get; }
        public string Type { get; } //Electric or Non-Electric
        public bool Available { get; }
        public int Capacity { get; }
        public double Cost { get; } //price per night

        public CampingSite(string parkName, int siteNumber, string type, bool available, int capacity, double cost)
        {
            ParkName = parkName;
            SiteNumber = siteNumber;
            Type = type;
            Available = available;
            Capacity = capacity;
            Cost = cost;
        }


        public static List<CampingSite> SiteList = new List<CampingSite>
            {
                new CampingSite("Silent Lake", 101, "Electric", true, 6, 42.00),
                new CampingSite("Silent Lake", 102, "Electric", false, 6, 38.00),
                new CampingSite("Silent Lake", 103, "Electric", false, 20, 40.00),
                new CampingSite("Craighleith", 14, "Non-Electric", true, 8, 38.00),
                new CampingSite("Craighleith", 15, "Electric", true, 12, 128.00),
                new CampingSite("Craighleith", 17, "Non-Electric", true, 6, 45.00),
                new CampingSite("Arrow Head", 23, "Non-Electric", false, 12, 37.00),
                new CampingSite("Arrow Head", 24, "Electric", true, 6, 138.00),
                new CampingSite("Arrow Head", 25, "Non-Electric", false, 8, 42.00),
                new CampingSite("Arrow Head", 26, "Electric", true, 6, 40.00),
            };

        public override string ToString()
        {
            return $"-- {this.ParkName,-25}  {this.SiteNumber,5}  {this.Type,-15}  {(this.Available ? "Available" : "Unavailable"),-15}  {this.Capacity,3} People  {this.Cost,4:c}";
        }
    } // CampingSite class ends here

    //internal class ServiceProvider
    internal class ServiceProvider
    {
        public string Id { get; }
        public string Name { get; }
        public string Address { get; }
        public double PricePerSession { get; }

        public ServiceProvider(string id, string name, string address, double pricePerSession)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.PricePerSession = pricePerSession;
        }

        public override string ToString()
        {
            return $" {this.Id,-5}  {this.Name,-15}  {this.Address,-20}  {this.PricePerSession,4:c}";
        }
    } // ServiceProvider class ends here

    //internal class Chiropractor : ServiceProvider
    internal class Chiropractor : ServiceProvider
    {
        public string Specilization { get; }
        public int SessionDuration { get; }

        public Chiropractor(string id, string name, string address, double pricePerSession, string specilization, int sessionDuration) : base(id, name, address, pricePerSession)
        {
            this.Specilization = specilization;
            this.SessionDuration = sessionDuration;
        }

        public override string ToString()
        {
            return $" {base.ToString()}  {this.Specilization,-15}  {this.SessionDuration,3} Minutes";
        }
    } // Chiropractor class ends here

    public enum MassageType
    {
        HotStoneMassage,
        HotCupMassage,
        DeepTissueMassage
    }

    //internal class MassageTherapist : ServiceProvider
    internal class MassageTherapist : ServiceProvider
    {
        public MassageType MassageType { get; }

        public MassageTherapist(string id, string name, string address, double pricePerSession, MassageType massageType) : base(id, name, address, pricePerSession)
        {
            this.MassageType = massageType;
        }

        public override string ToString()
        {
            return $" {base.ToString()}  {this.MassageType}";
        }
    } // MassageTherapist class ends here

    //Internal Class Patient
    internal class Patient
    {
        public string Name { get; }
        public Dictionary<string, ServiceProvider> Bookings { get; }

        public Patient(string name)
        {
            this.Name = name;
            this.Bookings = new Dictionary<string, ServiceProvider>();
        }

        public void showBookings()
        {
            // check either the booking is empty or not
            if (this.Bookings.Count == 0)
            {
                Console.WriteLine("No Booking Found");
            }
            else
            {
                // Display the booking details in the booking dictionary
                foreach (KeyValuePair<string, ServiceProvider> booking in this.Bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.Key}  {booking.Value}");
                }
            }
        }

        public void SubmitBooking(ServiceProvider provider)
        {
            // Check if the booking is already in the bookings dictionary 
            if (this.Bookings.ContainsKey(provider.Id))
            {
                // Display provide name and id
                Console.WriteLine($"You already have appointment with: {provider.Id} : {provider.Name}");
            }
            else
            {
                // check if the patient has 2 or less bookings in the booking dictonary
                if (this.Bookings.Count < 2)
                {
                    // Add the booking to the booking dictionary
                    this.Bookings.Add(provider.Id, provider);
                    Console.WriteLine($"Booking with {provider.Id} : {provider.Name} is confirmed");
                }
                else
                {
                    Console.WriteLine($"Trying to book an appointment with {provider.Name}");
                    Console.WriteLine("You can not book more than 2 appointments");
                }
            }
        }
    } // Patient class ends here
}
