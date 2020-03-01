using _02_CouriersTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CouriersTask
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCarTrackingInfo();
        }

        private static void GetCarTrackingInfo()
        {
            List<Car> cars = new List<Car>();

            Console.WriteLine("Please enter a valid whole number: ");
            int.TryParse(Console.ReadLine(), out int carCount);

            for (int i = 0; i < carCount; i++)
            {
                //Car format input
                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>” 

                string[] lineInputArray = Console.ReadLine()
                                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string modelName = lineInputArray[0];
                int.TryParse(lineInputArray[1], out int engineSpeed);
                int.TryParse(lineInputArray[2], out int enginePower);
                int.TryParse(lineInputArray[3], out int cargoWeight);

                Enum.TryParse<CargoType>(lineInputArray[4], out CargoType cargoType);
                IList<Tire> tires = CreateTireCollection(lineInputArray);

                Engine engine = new Engine(enginePower, engineSpeed);

                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car car = new Car(modelName, engine, cargo, tires);
                cars.Add(car);
            }

            IList<Car> filteredCollection = FilterCarsCollectionByCargoType(Console.ReadLine(), cars);
            PrintCollection(filteredCollection);
        }

        private static void PrintCollection(IList<Car> cars)
        {
            if (cars.Count > 0) { 
                foreach (Car car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("No elements in the collection that satisy the condition!");
            }
        }

        private static List<Car> FilterCarsCollectionByCargoType(string cargoTypeStr, IList<Car> cars)
        {
            string CARGO_TYPE_FRAGILE = "fragile";
            int TIRE_MAX_PRESSURE = 1;
            int ENGINE_MIN_POWER = 250;

            return cargoTypeStr == CARGO_TYPE_FRAGILE ?
                    cars.Where(c => c.Cargo.Type == CargoType.fragile && c.Tires
                                                                    .Any(t => t.Pressure < TIRE_MAX_PRESSURE))
                            .ToList() :
                    cars.Where(c => c.Cargo.Type == CargoType.flamable && c.Engine.Power > ENGINE_MIN_POWER)
                            .ToList();
        }

        private static IList<Tire> CreateTireCollection(string[] lineInputArray)
        {
            List<Tire> tires = new List<Tire>(4);
            for (int j = 5; j < lineInputArray.Length; j += 2)
            {
                double.TryParse(lineInputArray[j], out double tirePressure);
                int.TryParse(lineInputArray[j + 1], out int tireAge);
                Tire tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }

            return tires;
        }
    }
}
