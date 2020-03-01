using _02_CouriersTask.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_CouriersTask
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public IList<Tire> Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, IList<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Engine: ");
            sb.AppendLine($"{this.Engine}");
            sb.AppendLine($"Cargo: ");
            sb.AppendLine($"{this.Cargo}");

            sb.AppendLine("Tires: ");
            foreach (Tire tire in this.Tires)
            {
                sb.AppendLine(tire.ToString());
            }

            return sb.ToString();
        }
    }
}
