using System;
using System.Collections.Generic;
using System.Text;

namespace Renovators
{
    public class Renovator
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public int Days { get; set; }
        public bool Hired { get; set; } = false;

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
        }

        public override string ToString()
        {
            return $"-Renovator: {this.Name} \r\n" +
                   $"--Specialty: {this.Type}\r\n" +
                   $"--Rate per day: {this.Rate} BGN";
        }
    }
}
