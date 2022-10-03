using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    internal class Clinic
    {
        public int Capacity { get; set; }
        public List<Pet> data = new List<Pet> ();
       
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet> ();
        }
        
        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.FirstOrDefault(n => n.Name == name);
            return this.data.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.FirstOrDefault(n => n.Name == name && n.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = (Pet)this.data.OrderByDescending(x => x.Age).First();
            return pet;
        }

        public int Count => this.data.Count;

        public string GetStatistics()
        {
            Console.WriteLine("The clinic has the following patients:");

            foreach (var item in data)
            {
                Console.WriteLine($"Pet {item.Name} with owner: {item.Owner}");
            }
            return "";
        }
    }
}
