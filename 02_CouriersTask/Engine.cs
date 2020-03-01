using System;
using System.Collections.Generic;
using System.Text;

namespace _02_CouriersTask
{
    public class Engine
    {
        public int Power { get; set; }

        public int Speed { get; set; }

        public Engine(int power, int speed)
        {
            this.Power = power;
            this.Speed = speed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"---- Engine Speed: {this.Speed}");
            sb.AppendLine($"---- Engine Power: {this.Power}");

            return sb.ToString();
        }
    }
}
