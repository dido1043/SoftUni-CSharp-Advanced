using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; private set; }


        public Airfield( string name, int capacity, double landingStrip)
        {

            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }
        //Solution
        //-----------------------------------------
        //Count
        public int Count => this.Drones.Count;

        //Adding drone
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.Capacity <= this.Count)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        //Remove drone

        public bool RemoveDrone(string name)
        {
            this.Drones.RemoveAll(n => n.Name == name);
            return Count < 0;
        }
        //Remove by brand

        public int RemoveDroneByBrand (string brand)
        {
            int count = this.Drones.RemoveAll(x => x.Brand == brand);

            return count;
        }
        //Fly drone
        public Drone FlyDrone(string name)
        {
            Drone d = this.Drones.FirstOrDefault(n => n.Name == name);
            if (d == null)
            {
                return null;
            }
            d.Available = false;
           return d;
        }
        //List<Drone> FlyDronesByRange(int range)

        public List<Drone> FlyDronesByRange(int range)
        {            
           List<Drone> drones = this.Drones.Where(x => x.Range >= range).ToList();
            foreach (var item in drones)
            {
                item.Available = false;
            }
            return drones;

        }
        //	Report
        public string Report()
        {
            var available = this.Drones.Where (x => x.Available == true);
            return $"Drones available at {this.Name}" +
                $"{string.Join("\n",available)}";

        }

    }
}
