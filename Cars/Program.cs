using System;
using System.Collections.Generic;

namespace Cars 
{

    public class Program 
    {
        public static void Main(String[] args) 
        {
            // Instantiates instances of CarLot, each is an empty List (instance name: inventory) based on Class Vehicle
            CarLot edsSouth = new CarLot("South Lot");
            CarLot edsNorth = new CarLot("North Lot");

           // Instantiates instances of Car (using base Class Vehicle). Passes the parameters cooresponding to the Class parameters
            Car Escort = new Car("Ford", "Escort", "Tx-123", 8000, "Hatchback", 4);
            Car Mustang = new Car("Ford", "Mustang", "Tx-654", 15000, "Coupe", 4);

            // Instantiates instances of Truck (using base Class Vehicle). Passes the parameters cooresponding to the Class parameters
            Truck SuperDuty = new Truck("Ford", "SuperDuty", "Tx-987", 20000, "LongBed");
            Truck Ram = new Truck("Dodge", "Ram", "Tx-456", 10000, "LongBed");

            // Method Call chained to CarLot Class list variable - passes through a Class Vehicle parameter
            // Calls Class Object (which is either a Car:Vehicle or Truck:Vehicle) and ads it to the CarLot list
            // The "return" of either Class is the object added to the CarLot list
            edsSouth.addCar(Escort);
            edsSouth.addCar(Ram);

            edsNorth.addCar(Mustang);
            edsNorth.addCar(SuperDuty);

            // Method Call chained to CarLot Class list variable - method is void, no parameter     
            edsSouth.PrintInventory();
            edsNorth.PrintInventory();

            Console.ReadLine();           
        }
    }

    public class CarLot 
    {
        // Field defines a List called inventory (variable) with a (Class: Vehicle) value
        List<Vehicle> inventory;
        String name;

        // Paremeterized Constructor - when called it creates a blank instance of a List
        // It takes in a string passed in from the instance call (ex: "South Lot")
        public CarLot(string Lname)
        {
            //Constructor - when called it creates an empty instance of CarLot List called "this.inventory"
            this.inventory = new List<Vehicle>();
            //Constructor parameter - takes parameter and sets it to this.name instance variable (ex: "South Lot")
            this.name = Lname;
        }

        // Method addCar - takes in a Class: Vehicle type and sets it to the object variable "vehicle"
        public void addCar(Vehicle vehicle)
        {
        // Method - when called it adds a vehicle according to the vehicle class and parameters passed in
           this.inventory.Add(vehicle);
        }

        // Method PrintInventory - Void - takes in no parameters
        public void PrintInventory()
        {
            // Prints the current instance Car Lot "this.name" and the count of objects in the list (cars)
            Console.WriteLine("Eds Cars Lot: {0} Car Count: {1}", this.name, this.inventory.Count);

            // loops through each object in the current instance of CarLot list and prints the contents, each vehicle
            for(int i = 0; i < this.inventory.Count; i++) 
            {
            Console.WriteLine("Vehicle Inventory: {0}", this.inventory[i]);
            }
            Console.WriteLine();
        }
    }

    public abstract class Vehicle 
    {
        public string make;
        public string model;
        public string license;
        public int price;
        public Vehicle(string Tmake, string Tmodel, string Tlicense, int Tprice)
        {
            make = Tmake;
            model = Tmodel;
            license = Tlicense;
            price = Tprice;
        }

    }

    // Class Car : Vehicle - takes in parameters accorting to its Constructor - instance generator must match
    // Car : Vehicle - returns the string value in the ToString (override) Method
    public class Car : Vehicle
    {
        public string Ctype;
        public int Cdoors;
        public Car(string Tmake, string Tmodel, string Tlicense, int Tprice, string type, int doors) : base (Tmake, Tmodel, Tlicense, Tprice)
        {
            Ctype = type;
            Cdoors = doors;
        }

        override public String ToString()
        {
            String s = "";
            s = (" Car Make: " +make +"  Model: " +model +"  License: " +license +"  Type: " +Ctype +"  Doors: " +Cdoors +"  Price: " +price);
            return s;
        }
    }   

    // Class Truck : Vehicle - takes in parameters accorting to its Constructor - instance generator must match
    // Truck : Vehicle - returns the string value in the ToString (override) Method
    public class Truck : Vehicle 
    {
        public string Tbed;

        public Truck(string Tmake, string Tmodel, string Tlicense, int Tprice, string bed) : base (Tmake, Tmodel, Tlicense, Tprice)
        {
            Tbed = bed;
        }

        override public String ToString()
        {
            String s = "";
            s = ("  Truck Make: " +make +"  Model: " +model +"  Bed Size: " +Tbed +"  License: " +license  +"  Price: " +price);
            return s;
        }
    }   
}