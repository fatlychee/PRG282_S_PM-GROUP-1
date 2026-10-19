using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2782_Project_2026.Models
{
    //SUMMARY: 
    //     Represents an animal record in the Baobab Ridge Wildlife Rehabilitation system.

    public class Animal
    {
        private string animalID;
        private string name;
        private string species;
        private int age;
        private int recoveryScore;
        private string status;
        private string housingUnit;

        public Animal(string animalID, string name, string species, int age, int recoveryScore, string status, string housingUnit)
        {
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
            Status = status;
            HousingUnit = housingUnit;
        }

        public string AnimalID { get => animalID; set => animalID = value; }
        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        public int Age { get => age; set => age = value; }
        public int RecoveryScore { get => recoveryScore; set => recoveryScore = value; }
        public string Status { get => status; set => status = value; }
        public string HousingUnit { get => housingUnit; set => housingUnit = value; }


        // Allows creating a blank Animal object so you can fill in its details later.
        public Animal()
        { 
        
        }


        //SUMMARY:
        //     Converts the animal record into a pipe-separated line for animals.txt storage.
        public string ToFileLine()
        { 
            return $"{AnimalID}|{Name}|{Species}|{Age}|{RecoveryScore}|{Status}|{HousingUnit}";
        }
    }
}
