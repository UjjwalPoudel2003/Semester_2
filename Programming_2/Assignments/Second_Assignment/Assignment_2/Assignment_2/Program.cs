using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calling testMethod
            TestMethod();
            Console.ReadKey();
        }

        public static void TestMethod()
        {
            Console.WriteLine("Assignment 2 Output");

            Dealership dealership1 = new Dealership("D1_22_T501", "The Six Cars", "1 Main Street, Toronto");
            Console.WriteLine(dealership1.ToString());

            Dealership dealership2 = new Dealership("D2_22_B321", "Car Street", "5th avenue, Brampton");
            Console.WriteLine(dealership2.ToString());

            Console.WriteLine("\nToyota Cars available in Dealership 1");
            dealership1.ShowCars("Toyota");

            Console.WriteLine("\nToyota Cars available in Dealership 2");
            dealership2.ShowCars("Toyota");

            Car favCar = new Car("Hyundai", 2020, "Elantra", 30000.00, CarType.Sedan);
            Console.WriteLine($"\nCar to match : {favCar.ToString()}");

            Console.WriteLine("\nMatching car(s) from Dealership 1 : ");
            dealership1.ShowCars(favCar);

            Console.WriteLine("\nMatching car(s) from Dealership 2 : ");
            dealership2.ShowCars(favCar);

            //favCar = new Car("Honda", 2018, "Civic", 20000.00, CarType.SUV, CarSpecifications.FogLights | CarSpecifications.TintendGlasses);
            favCar = new Car("Honda", 2018, "Civic", 20000.00, CarType.SUV);

            Console.WriteLine($"\nCar to match : {favCar.ToString()}");

            Console.WriteLine("\nMatching car(s) from Dealership 1 : ");
            dealership1.ShowCars(favCar);

            Console.WriteLine("\nMatching car(s) from Dealership 2 : ");
            dealership2.ShowCars(favCar);

            Console.WriteLine("\nList of similiar car models available in both dealership : ");

            foreach (Car firstCar in dealership1.CarList)
            {
                foreach (Car secondsCar in dealership2.CarList)
                {
                    if (firstCar == secondsCar)
                    {
                        Console.WriteLine($"Dealership 1 : {firstCar.ToString()}");
                        Console.WriteLine($"Dealership 2 : {secondsCar.ToString()}");
                    }
                }
            }
        }
    } // Class Program Ends

    // Createing a enum for the car types
    public enum CarType
    {
        SUV = 1, Hatchback = 2, Sedan = 3, Truck = 4
    }

    public class Car
    {
        // Field variables
        public string Manufacturer { get; }
        public int Make { get; }
        public string Model { get; }

        //This is a static field help create unique Vehicle Identification Number for each car
        //object. This number should be automatically incremented by 100 each time the
        //constructor of this class is called.This field will be used to initialize the VIN field.
        private static int VI_NUMBER = 1021;
        private static int VIN_INCREMENT = 100;

        public int VIN;

        public double BasePrice { get; }

        public CarType CarType { get; }

        public Car(string manufacturer, int make, string model, double basePrice, CarType type)
        {
            this.Manufacturer = manufacturer;
            this.Make = make;
            this.Model = model;
            this.BasePrice = basePrice;
            this.CarType = type;
            VI_NUMBER += VIN_INCREMENT;
            this.VIN = VI_NUMBER;
        }

        // Overriding bool operator
        public static bool operator ==(Car car1, Car car2)
        {
            return car1.Manufacturer == car2.Manufacturer && car1.Model == car2.Model && car1.CarType == car2.CarType;
        }

        // Overriding bool operator
        public static bool operator !=(Car car1, Car car2)
        {
            return !(car1 == car2);
        }

        // Overriding string
        public override string ToString()
        {
            return $"{this.VIN}: {this.Manufacturer} {this.Make}, {this.Model}, {this.BasePrice}, {this.CarType}";
        }
    } // Class Car Ends

    class Dealership
    {
        public List<Car> CarList = new List<Car>();
        public string storeID { get; }
        public string storeName { get; }
        public string storeAddress { get; }

        public Dealership(string storeID, string storeName, string storeAddress)
        {
            this.storeID = storeID;
            this.storeName = storeName;
            this.storeAddress = storeAddress;

            using (StreamReader reader = new StreamReader("Dealership_Cars.txt"))
            {
                string dataLine;

                while((dataLine = reader.ReadLine()) != null)
                {
                    string[] data = dataLine.Split(',');
                    if (data[0] == this.storeID)
                    {
                        string manufacturer = data[1];
                        int make = Convert.ToInt32(data[2]);
                        string model = data[3];
                        double basePrice = Convert.ToDouble(data[4]);
                        CarType carType = (CarType)Enum.Parse(typeof(CarType), data[5]);

                        Car car1 = new Car(manufacturer, make, model, basePrice, carType);
                        CarList.Add(car1);
                    }
                }
                reader.Close();
            }  
        }

        public void ShowCars(string manufacutrer)
        {
            foreach (Car car in this.CarList)
            {
                if (car.Manufacturer == manufacutrer)
                {
                    Console.WriteLine(car);
                }
            }
        }

        public void ShowCars(Car carToBeSearched)
        {
            bool found = false;

            foreach (Car car in this.CarList)
            {
                if (car == carToBeSearched)
                {
                    Console.WriteLine(car);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No car found");
            }
        }

        public override string ToString()
        {
            string pillarshipDetails = $"\n{this.storeID}, {this.storeName}, {this.storeAddress}\n";
            foreach (Car car in this.CarList)
            {
                pillarshipDetails += $"\n{car}";
            }
            return pillarshipDetails;
        }
    }
}
