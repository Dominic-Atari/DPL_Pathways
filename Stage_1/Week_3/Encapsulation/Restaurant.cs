using System;

namespace Encapsulation
{
    public class Restaurant
    {
        // Encasulation properties
        public string Name { get; set; }
        public string Rate { get; set; }
        public string Cuisine { get; set; }

        public string[] Update { get; set; } // to handle update for rate and delete functonality
        //public string[] DeleteData { get; set; }

        // Parameterless constructor
        public Restaurant(string name, string rate, string cuisine)
        {
            this.Name = name;
            this.Rate = rate;
            this.Cuisine = cuisine;
        }

        public Restaurant(string[] update)
        {
            this.Update = update;
        }
        // public Restaurant(string[] delete)
        // {
        //     this.DeleteData = delete;
        // }
        // public methods to set properties.
        // public void SetName(string name) { this.Name = name; }
        // public void SetRate(string rate) { this.Rate = rate; }
        // public void SetCuisine(string cuisine) { this.Cuisine = cuisine; }

        // // public methods to get property values
        // public string GetName() { return Name; }
        // public string GetRate() { return Rate; }
        // public string GetCuisine() { return Cuisine; }

        public override string ToString()
        {
            return $"name: {Name} rate: {Rate} cuisine: {Cuisine}";
        }
    }
}
