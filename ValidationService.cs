using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2782_Project_2026.Services
{
    //SUMMARY:
    //     Enforces input validation rules for animal records.
    public static class ValidationService
    {
        //SUMMARY:
        //     Validates field formats, lengths, and numerical ranges.
        //     Returns an error message string if invalid or is an empty string.
        public static string ValidateFields(string animalID, string name, string species, string age, string score)
        {
            //Clean up whitespace from inputs
            string cleanedID = animalID != null ? animalID.Trim().ToUpper() : "";
            string cleanedName = name != null ? name.Trim() : "";
            string cleanedSpecies = species != null ? species.Trim() : "";
            string cleanedAge = age != null ? age.Trim() : "";
            string cleanedScore = score != null ? score.Trim() : "";

            //1. Validate Animal ID
            if (string.IsNullOrWhiteSpace(cleanedID) || cleanedID.Length != 7 || !cleanedID.StartsWith("WR-") || !int.TryParse(cleanedID.Substring(3), out _))
            {
                return "Animal ID is required and must start with 'WR-' followed by 4 digits (e.g., WR-0000)."; 
            }

            //2. Validate Name
            if (string.IsNullOrWhiteSpace(cleanedName) || cleanedName.Length > 30 || cleanedName.Contains("|"))
            {
                return "Name is required, must not exceed 30 characters, and cannot contain '|'.";
            }

            //3. Validate Species
            if (string.IsNullOrWhiteSpace(cleanedSpecies) || cleanedSpecies.Length > 30 || cleanedSpecies.Contains("|"))
            {
                return "Species is required, must not exceed 30 characters, and cannot contain '|'.";
            }

            //4. Validate Age
            if (!int.TryParse(cleanedAge, out int parsedAge) || parsedAge < 0 || parsedAge > 100)
            {
                return "Age must be a whole number between 0 and 100.";
            }

            //5. Validate Score
            if (!int.TryParse(cleanedScore, out int parsedScore) || parsedScore < 0 || parsedScore > 100)
            {
                return "Score must be a whole number between 0 and 100.";
            }

            //Return an empty string if no validation errors occurred
            return string.Empty;
        }
        //SUMMARY:
        //     Checks if an Animal ID already exists in the provided list.
        public static bool IsDuplicateID(string animalID, List<string> existingIDs)
        {
            if (existingIDs == null || string.IsNullOrWhiteSpace(animalID))
            {
                return false; 
            }

            return existingIDs.Contains(animalID.Trim().ToUpper());
        }

    }
}
