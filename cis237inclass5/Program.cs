using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            CarsWCurtisEntities carsEntities = new CarsWCurtisEntities();

            Console.WriteLine("Print the list");

            foreach(Car car in carsEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

            Car carToFind = carsEntities.Cars.Where(car => car.id == "V0LCD1814").First();

            Car otherCarToFind = carsEntities.Cars.Where(car => car.model == "Challenger").First();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Find 2 specific cars");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);
            Console.WriteLine(otherCarToFind.id + " " + otherCarToFind.make + " " + otherCarToFind.model);

            Car foundCar = carsEntities.Cars.Find("V0LCD1814");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Find 1 more car using the Find method and primary id");
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);

            Car newCarToAdd = new Car();
            newCarToAdd.id = "88888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2017";
            newCarToAdd.type = "Car";

            try
            {
                carsEntities.Cars.Add(newCarToAdd);

                carsEntities.SaveChanges();
            }
            catch(Exception ex)
            {
                carsEntities.Cars.Remove(newCarToAdd);

                Console.WriteLine("Can't add the record. Already have one with that primary key.");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Just added a new car. Going to fetch it and print it to verify");

            carToFind = carsEntities.Cars.Find("88888");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);

            Car carToFindForDelete = carsEntities.Cars.Find("88888");

            //Should check to see if null
            carsEntities.Cars.Remove(carToFindForDelete);

            carsEntities.SaveChanges();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleted the added car. Looking to see if it is still in the database");

            carToFindForDelete = carsEntities.Cars.Find("88888");
            if(carToFindForDelete == null)
            {
                Console.WriteLine("The model you're looking for doesn't exist");
            }
        }
    }
}
