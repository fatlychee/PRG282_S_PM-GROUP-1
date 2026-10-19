using PRG2782_Project_2026.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG2782_Project_2026.Services
{
    public class AnimalReaderFile
    {       // Gets the path of animals.txt beside the running application.
        private readonly string filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Animal.txt");

        // Stores how many records were skipped during the last load.
        public int SkippedRecords { get; private set; }

        // Loads valid animal records from the text file.
        public List<Animal> LoadAnimals()
        {
            List<Animal> animals = new List<Animal>();
            SkippedRecords = 0;

            try
            {
                // Create an empty file if it does not exist.
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath))
                    {
                    }

                    return animals;
                }

                // Read the file using UTF-8 encoding.
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);


                // Check every line separately so one bad record
                // does not prevent the other records from loading.
                foreach (string line in lines)
                {
                    Animal animal = ParseAnimal(line);

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }
                    else
                    {
                        SkippedRecords++;
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException(
                    "The animal records file could not be read. Check whether it is being used by another program.",
                    ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(
                    "The application does not have permission to read the animal records file.",
                    ex);
            }

            return animals;
        }

        // Converts one line of text into an Animal object.
        // Returns null if the line does not contain a valid record.
         
            private Animal ParseAnimal(string line)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    return null;
                }

                string[] parts = line.Split('|');

                // Every record must contain exactly seven fields.
                if (parts.Length != 7)
                {
                    return null;
                }

                // Remove spaces around the values.
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();

                    if (string.IsNullOrWhiteSpace(parts[i]))
                    {
                        return null;
                    }
                }

                // Age and recovery score must be numbers.
                if (!int.TryParse(parts[3], out int age))
                {
                    return null;
                }

                if (!int.TryParse(parts[4], out int recoveryScore))
                {
                    return null;
                }

                // The animal ID must look like WR-1234.
                if (!IsValidAnimalID(parts[0]))
                {
                    return null;
                }

                return new Animal(
                    parts[0],
                    parts[1],
                    parts[2],
                    age,
                    recoveryScore,
                    parts[5],
                    parts[6]);
            }

        // Checks whether an ID contains WR- followed by four digits.
        private bool IsValidAnimalID(string animalID)
        {
            if (animalID == null || animalID.Length != 7)
            {
                return false;
            }

            if (!animalID.StartsWith("WR-"))
            {
                return false;

            }
            else 
            {
                for (int i = 3; i < animalID.Length; i++)
                {
                    if (!char.IsDigit(animalID[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}



