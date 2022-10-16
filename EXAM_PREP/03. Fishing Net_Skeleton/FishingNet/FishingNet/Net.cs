using System;
using System.Collections.Generic;
using System.Linq;
namespace FishingNet
{
    public class Net  
    {
        private readonly List<Fish> fish;
        public string Material { get; set; }
        public int Capacity { get; set; }

        public List<Fish> Fish { get { return this.fish; } }

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) ||
                fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.Fish.Count == this.Capacity)
            {
                return "Fishing net is full.";
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = this.Fish.FirstOrDefault(x => x.Weight == weight);
            return this.Fish.Remove(fish);
        }
        public Fish GetFish(string fishType)
        {
            Fish fish = this.Fish.FirstOrDefault(x => x.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            double biggestFish = this.Fish.Max(x => x.Length);
            Fish fish = this.Fish.FirstOrDefault(n => n.Length == biggestFish);
            return fish;
        }

        public string Report()
        {
            return $"Into the {this.Material} :" +  Environment.NewLine + string.Join(Environment.NewLine, this.Fish);
        }
    }
}
