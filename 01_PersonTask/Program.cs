using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonTask_ConsoleApp
{
    class Program
    {
        private const int AGE_CONSTANT_VALUE = 30;
        static void Main(string[] args)
        {
            CreatePeople();
        }

        private static void CreatePeople()
        {
            Console.WriteLine("Please enter a valid whole number: ");
            int.TryParse(Console.ReadLine(), out int peopleCount);

            Family family = new Family();
            for (int i = 0; i < peopleCount; i++)
            {
                Console.Write("Enter a person's name: ");
                string personName = Console.ReadLine();

                Console.Write("Enter a person's age: ");
                int.TryParse(Console.ReadLine(), out int personAge);

                Person currentPerson = new Person(personAge, personName);
                family.AddPerson(currentPerson);
            }

            IList<Person> filteredPeople = family.GetAllPeopleOlderThan30();
            Console.WriteLine($"All people, older than {AGE_CONSTANT_VALUE} are: ");
            Console.WriteLine(string.Join(Environment.NewLine, filteredPeople));
        }
    }
}
