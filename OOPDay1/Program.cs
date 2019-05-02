using System;
using System.Collections.Generic;


namespace OOPDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Passenger = new Person("Tom");
            Car NextCar = new Car("Blue", 4);
            Garage smallGarage = new Garage(2);
            
            NextCar.SeatPerson(Passenger, 0);
            Console.WriteLine(NextCar.People);

            smallGarage.ParkCar(NextCar, 0);
            Console.WriteLine(smallGarage.Cars);
        }
    }

    public class Person
    {
    // Constructor creates an instance of a Person
        public Person(string initialGender)
        {
            gender = initialGender;
        }
        
        public string gender { get; private set; }
    }

    class Car
    {
        private Person[] persons;
        
    // Constructor creates an instance of a Car with attributes of Size (seats) and Color
        public Car(String initialColor, int initialSize)
        {
            Color = initialColor;
            Size = initialSize;
            this.persons = new Person[initialSize];
        }
        
            public String Color;
            public int Size { get; private set; }

        
    // Method to get an instance of a person and place that person in a seat (index) of the "persons" array
        public void SeatPerson (Person person, int seat)
        {
            persons[seat] = person;
        }
        
    // Method prints out where each instance of People is sitting in a car (seat) and the color of the car
        public string People {
            get {
                for (int i = 0; i < persons.Length; i++)
                {
                    if (persons[i] != null) {
                        Console.WriteLine(String.Format("Passenger {0} is in seat {1} of the {2} car", persons[i].gender, i+1, Color));
                    }
                }
                return "Where is it parked?";
            }
        }    
	}
    class Garage
    {
        private Car[] cars;
        
    // Constructor creates an instance a garage with attributes of number of parking spaces (Space)
        public Garage(int initialSpace)
        {
            Space = initialSpace;
            this.cars = new Car[initialSpace];
        }
        
        public int Space { get; private set; }
        
    // Method to get an instance of a Car and place that car in a parking spot (index) of the "cars" array
        public void ParkCar (Car car, int spot)
        {
            cars[spot] = car;
        }
        
       // Method prints out where each instance of Car is parked in a Garage (spot) in the Small Garage
        public string Cars {
            get
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i] != null) {
                        Console.WriteLine(String.Format("The {0} car is in spot {1} of the Small Garage.", cars[i].Color, i+1));
                    }
                }
                return "That's all!";
            }
        }
	}
}