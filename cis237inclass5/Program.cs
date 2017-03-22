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
        }
    }
}
