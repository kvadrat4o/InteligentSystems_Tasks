using System;
using System.Collections.Generic;
using System.Text;

namespace PersonTask_ConsoleApp
{
    public class Person
    {
        private const string NO_NAME_CONSTANT = "Без име";
        private const int NO_AGE_CONSTANT = 1;

        public int Age { get; }

        public string Name { get; }

        public Person()
        {
            this.Age = NO_AGE_CONSTANT;
            this.Name = NO_NAME_CONSTANT;
        }

        public Person(int age)
        {
            this.Age = age;
            this.Name = NO_NAME_CONSTANT;
        }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{this.Name}; {this.Age}";
        }
    }
}
