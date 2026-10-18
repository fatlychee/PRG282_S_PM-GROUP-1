using System.Collections.Generic;
using System.Linq;
using PRG2782_Project_2026.Models;

namespace PRG2782_Project_2026.Services
{
    public class UpdateDeleteController
    {
        private readonly List<Animal> animals;

        public UpdateDeleteController(List<Animal> animals)
        {
            this.animals = animals;
        }

        public Animal FindAnimal(string animalId)
        {
            return animals.FirstOrDefault(a =>a.AnimalID == animalId);
        }

        public bool DeleteAnimal(string animalId)
        {
            Animal animal = FindAnimal(animalId);

            if (animal == null)
                return false;

            animals.Remove(animal);

            AnimalFileService.SaveAnimals(animals);

            return true;
        }

        public bool UpdateAnimal(
            string animalId,
            string name,
            string species,
            int age,
            int recoveryScore)
        {
            Animal animal = FindAnimal(animalId);

            if (animal == null)
                return false;

            animal.Name = name;
            animal.Species = species;
            animal.Age = age;
            animal.RecoveryScore = recoveryScore;

            AnimalFileService.SaveAnimals(animals);

            return true;
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }
    }
}