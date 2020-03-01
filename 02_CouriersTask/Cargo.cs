using _02_CouriersTask.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_CouriersTask
{
    public class Cargo
    {
        public CargoType Type { get; set; }

        public int Weight { get; set; }

        public Cargo(CargoType type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"---- Cargo Type: {this.Type}");
            sb.AppendLine($"---- Cargo Weight: {this.Weight}");

            return sb.ToString();
        }
    }
}
