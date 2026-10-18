using PRG2782_Project_2026.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2782_Project_2026.Services
{
    public class AnimalHandler
    {
        private readonly string filepath = @"";

        public static void Seed(string filepath)
        {
            if (File.Exists(filepath)) return;
            List<Animal> animals = new List<Animal>
            {
                    new Animal("1001", "Pingu", "frican Penguin", 3, 85, "Recovering", "Hous unit"),
                    new Animal("1002", "Ana", "Dog", 4, 55, "Recovering", "HU"),
                    new Animal("1003", "Pingu", "frican Penguin", 3, 85, "Recovering", "HU"),
                    new Animal("1004", "Pingu", "frican Penguin", 3, 85, "Recovering", "HU"),
                    new Animal("1005", "Pingu", "frican Penguin", 3, 85, "Recovering", "HU")
             };
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                // then here is where you use your "writer" the other person at the of the deal   .... i hope this makes sense

                foreach (var animal in animals)
                {
                    writer.WriteLine(animal.ToString());
                }
            }

        }

        public List<Animal> Load()
        {
            List<Animal> animals = new List<Animal>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    string read = reader.ReadLine();
                    animals.Add(Animal.FromFileString(read));
                }

                return animals;
            }
        }
    }
}
