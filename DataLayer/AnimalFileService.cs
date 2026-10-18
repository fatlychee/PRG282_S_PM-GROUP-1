using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PRG2782_Project_2026.Models;

namespace PRG2782_Project_2026.Services
{
    public static class AnimalFileService
    {
        private const string FILE_PATH = "animals.txt";

        public static List<Animal> LoadAnimals()
        {
            List<Animal> animals = new List<Animal>();

            try
            {
                if (!File.Exists(FILE_PATH))
                {
                    File.Create(FILE_PATH).Close();
                    return animals;
                }

                string[] lines = File.ReadAllLines(FILE_PATH);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length != 7)
                        continue;

                    Animal animal = new Animal
                    {
                        AnimalID = parts[0],
                        Name = parts[1],
                        Species = parts[2],
                        Age = int.Parse(parts[3]),
                        RecoveryScore = int.Parse(parts[4]),
                        Status = parts[5],
                        HousingUnit = parts[6]
                    };

                    animals.Add(animal);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading animals: " + ex.Message);
            }

            return animals;
        }

        public static void SaveAnimals(List<Animal> animals)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FILE_PATH))
                {
                    foreach (Animal animal in animals)
                    {
                       writer.WriteLine(animal.ToFileLine());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving animals: " + ex.Message);
            }
        }

        public static Animal FindAnimalByID(
            List<Animal> animals,
            string animalID)
        {
            return animals.FirstOrDefault(
                a => a.AnimalID.Equals(
                    animalID,
                    StringComparison.OrdinalIgnoreCase));
        }

        public static bool DeleteAnimal(
            List<Animal> animals,
            string animalID)
        {
            Animal animal =
                FindAnimalByID(animals, animalID);

            if (animal == null)
                return false;

            animals.Remove(animal);

            SaveAnimals(animals);

            return true;
        }

        public static bool UpdateAnimal(
            List<Animal> animals,
            Animal updatedAnimal)
        {
            Animal existingAnimal =
                FindAnimalByID(
                    animals,
                    updatedAnimal.AnimalID);

            if (existingAnimal == null)
                return false;

            existingAnimal.Name =
                updatedAnimal.Name;

            existingAnimal.Species =
                updatedAnimal.Species;

            existingAnimal.Age =
                updatedAnimal.Age;

            existingAnimal.RecoveryScore =
                updatedAnimal.RecoveryScore;

            existingAnimal.Status =
                updatedAnimal.Status;

            existingAnimal.HousingUnit =
                updatedAnimal.HousingUnit;

            SaveAnimals(animals);

            return true;
        }
    }
}