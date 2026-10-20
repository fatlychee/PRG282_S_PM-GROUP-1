using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2782_Project_2026.Services
{

//     Handles classification logic for animal records based on recovery scores.
    public static class ClassificationService
    {
        
        
        public static (string Status, string HousingUnit) GetClassification(int score)
        {
            if (score >= 0 && score <= 19)
            {
                return ("Critical", "Intensive Care Unit");
            }
            if (score >= 20 && score <= 39)
            {
                return ("Serious", "High-Dependency Ward");
            }
            if (score >= 40 && score <= 59)
            {
                return ("Stable", "Recovery Ward");
            }
            if (score >= 60 && score <= 79)
            {
                return ("Recovering", "Outdoor Enclosure");
            }
            if (score >= 80 && score <= 100)
            {
                return ("Release-Ready", "Pre-Release Camp");
            }

            throw new ArgumentOutOfRangeException(nameof(score), "Recovery score must be a whole number between 0 and 100.");
        }
    }
}
