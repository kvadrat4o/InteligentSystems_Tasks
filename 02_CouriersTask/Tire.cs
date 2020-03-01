using System;
using System.Collections.Generic;
using System.Text;

namespace _02_CouriersTask
{
    public class Tire
    {
        public double Pressure { get; set; }

        public int Age { get; set; }

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"    ++++ Tire Pressure: {this.Pressure}");
            sb.AppendLine($"    ++++ Tire Age: {this.Age}");

            return sb.ToString();
        }
    }
}
