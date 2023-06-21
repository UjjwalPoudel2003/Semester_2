using System;
using System.Collections.Generic;
using System.IO;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestReservation();
        }

        // Test method
        static void TestReservation()
        {
            Console.WriteLine($"{new string('-', 26)}Reservation Application{new string('-', 26)}");
            ReservationManager branch1 = new ReservationManager(729);
            ReservationManager branch2 = new ReservationManager(498);

            branch1.ReservationList.Add(new Reservation(546, "Alex Du", PassType.DayPass));
            branch2.ReservationList.Add(new Reservation(576, "Dale", PassType.SeasonPass));

            branch1.ShowAll();
            branch1.AddReservation(921, "Dolly Lively", PassType.SeasonPass);
            branch1.ReservationList[0].UpdatePassStatus(false);
            branch1.ShowAll();
            branch1.ShowAll(PassType.SeasonPass);

            Console.WriteLine();
            branch2.ShowAll();
            branch2.AddReservation(847, "Jack Gibbs", PassType.DayPass);
            branch2.ReservationList[1].UpdatePassStatus(false);
            branch2.ShowAll();
            branch2.ShowAll(PassType.DayPass);
            Console.WriteLine($"{new string('-', 75)}");
            Console.ReadKey();
        }

    }

    // This enumeration represents the possible types of pass user can reserve.
    public enum PassType
    {
        LifetimePass, DayPass, SeasonPass
    }


    // Creating Reservation class
    class Reservation
    {
        // Integer property to store Reservation ID number
        public int ReservationID { get; }

        // String property to store the name of the person who made the reservation
        public string ReservationName { get; }

        // Enum property to store the type of pass the user wants to reserve
        public PassType PassType { get; }

        // boolean property to indicate if reservation pass is activated (true) or not (false)
        public bool PassStatus { get; set; }

        // String property to store the status of the pass
        public string statusName;

        // double property to find out and return the price of reservation
        public double ReservationPrice
        {
            get
            {
                if (PassType == PassType.LifetimePass)
                {
                    return 750;
                }
                else if (PassType == PassType.DayPass)
                {
                    return 50;
                }
                else if (PassType == PassType.SeasonPass)
                {
                    return 200;
                }
                else
                {
                    return 0;
                }
            }
        }

        // This constructor will assign received parameters to the respective class properties
        public Reservation(int id, string name, PassType type)
        {
            // Assigning received parameters to the respective class properties
            this.ReservationID = id;
            this.ReservationName = name;
            this.PassType = type;
            this.PassStatus = true;
        }

        // this method sets the PassStatus property
        public void UpdatePassStatus(bool activationStatus)
        {
            // Assigning received parameter to the PassStatus property
            this.PassStatus = activationStatus;

            // Giving active and inactive status to the pass
            if (activationStatus == true)
            {
                this.statusName = "active";
            }
            else
            {
                this.statusName = "inactive";
            }

            // Displaying updated reservation information
            Console.WriteLine($"Successfully added reservation for {this.ReservationName} to the list");
        }

        // String override method to display reservation information
        public override string ToString()
        {
            // Displays all the Reservation details in appropriate format.
            return $"{this.ReservationID,1}{this.ReservationName,8}{this.PassType,8}{this.statusName,8}{this.ReservationPrice,8}";
        }
    }

    // Creating Reservation Manager class
    class ReservationManager
    {
        //  Int property to store ID of each Manager
        public int ManagerID { get; }

        // Property to hold a list of Reservation objects that the Manager will help.
        public List<Reservation> ReservationList { get; set; }

        // Constructor to assign received parameter to the ManagerID property
        public ReservationManager(int ID)
        {
            this.ManagerID = ID;

            // String form of ManagerID
            string stringManagerID = Convert.ToString(this.ManagerID);

            // Initializing the ReservationList with empty List by default.
            this.ReservationList = new List<Reservation>();

            // read file named “Manager_Reservation.txt”
            try
            {
                using (StreamReader reader = new StreamReader("Manager_Reservation.txt"))
                {
                    string dataLine;

                    while ((dataLine = reader.ReadLine()) != null)
                    {
                        string[] data = dataLine.Split(',');
                        if (data[0] == stringManagerID)
                        {
                            int managerID = Convert.ToInt32(data[1]);
                            int reservationID = Convert.ToInt32(data[2]);
                            string reserver = data[3];
                            PassType passType = (PassType)Enum.Parse(typeof(PassType), data[5]);

                            Reservation reservation = new Reservation(reservationID, reserver, passType);
                            ReservationList.Add(reservation);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry the file couldn't be read check the file again");
                Console.WriteLine(e.Message);
            }
        }

        // this method will create an object of the Reservation class with the help of provided
        // parameters and add the object to ReservationList.
        public void AddReservation(int id, string name, PassType passType)
        {
            // Creating an object of Reservation class with the help of provided parameters
            Reservation reservation = new Reservation(id, name, passType);

            // Adding the object to ReservationList
            ReservationList.Add(reservation);

            // It should also print the newly created object values

            Console.WriteLine($"Successfully added reservation for {name} to the list");
        }

        // This method will display all the reservations in the ReservationList
        public void ShowAll()
        {
            // Displaying all the reservations in the ReservationList
            foreach (Reservation reservation in ReservationList)
            {
                Console.WriteLine(reservation);
            }
        }

        public void ShowAll(PassType type)
        {
            // Displaying all the reservations in the ReservationList
            foreach (Reservation reservation in ReservationList)
            {
                if (reservation.PassType == type)
                {
                    Console.WriteLine(reservation);
                }
            }
        }
    }
}
