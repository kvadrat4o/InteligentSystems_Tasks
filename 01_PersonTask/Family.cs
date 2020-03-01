using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonTask_ConsoleApp
{
   public class Family
    {
        private readonly IList<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestPerson()
        {
            return this.people.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public IList<Person> GetAllPeopleOlderThan30()
        {
            int minimumAge = 30;
            return this.people.Where(p => p.Age > minimumAge).ToList();
        }
    }
}
