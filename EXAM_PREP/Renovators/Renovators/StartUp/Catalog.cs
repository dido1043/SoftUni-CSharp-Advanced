using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public List<Renovator> Renovators { get; private set; }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }

        public int Count => this.Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {

            if (renovator.Name == null || renovator.Name == " ")
            {
                return "Invalid renovator's information.";
            }
            if (this.NeededRenovators == this.Renovators.Count)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = this.Renovators.FirstOrDefault(n => n.Name == name);
            return this.Renovators.Remove(renovator);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = this.Renovators.RemoveAll(x => x.Type == type);
            return count;

        }

        public Renovator HireRenovator(string name)
        {
            Renovator ren = this.Renovators.FirstOrDefault(x => x.Name == name);
            if (ren == null)
            {
                return null;
            }
            ren.Hired = true;
            return ren;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = this.Renovators.Where(n => n.Days > days).ToList();
            return renovators;

        }

        public string Report()
        {
            var notHired = this.Renovators.Where(x => x.Hired == false).ToList();
            return $"Renovators available for Project {this.Project}: \n" +
                $"{String.Join("\n", notHired)} ";
        }
    }
}
