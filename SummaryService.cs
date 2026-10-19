using PRG2782_Project_2026.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PRG2782_Project_2026 // IMPORTANT: Change this to match your project's namespace!
{
    public class SummaryResult
    {
        public int Total { get; set; }
        public string AvgAge { get; set; }
        public string AvgScore { get; set; }
        public int Critical { get; set; }
        public int Serious { get; set; }
        public int Stable { get; set; }
        public int Recovering { get; set; }
        public int ReleaseReady { get; set; }
    }

    public static class SummaryService
    {
        public static SummaryResult Calculate(string filePath)
        {
            var result = new SummaryResult();
            List<Animal> animals = new List<Animal>();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 6)
                        {
                            try
                            {
                                animals.Add(new Animal
                                {
                                    AnimalID = parts[0].Trim(),
                                    Name = parts[1].Trim(),
                                    Species = parts[2].Trim(),
                                    Age = int.Parse(parts[3].Trim()),
                                    RecoveryScore = int.Parse(parts[4].Trim()),
                                    Status = parts[5].Trim()
                                });
                            }
                            catch { /* Skip malformed records */ }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If there's a file error, we'll return empty results
                return result;
            }

            // Calculate values
            result.Total = animals.Count;
            result.AvgAge = result.Total > 0 ? animals.Average(a => a.Age).ToString("F2", CultureInfo.InvariantCulture) : "N/A";
            result.AvgScore = result.Total > 0 ? animals.Average(a => a.RecoveryScore).ToString("F2", CultureInfo.InvariantCulture) : "N/A";

            result.Critical = animals.Count(a => a.Status == "Critical");
            result.Serious = animals.Count(a => a.Status == "Serious");
            result.Stable = animals.Count(a => a.Status == "Stable");
            result.Recovering = animals.Count(a => a.Status == "Recovering");
            result.ReleaseReady = animals.Count(a => a.Status == "Release-Ready");

            // Build the report string and save to summary.txt
            string report = "Summary Report\n==============\n";
            report += "Total animals".PadRight(26) + result.Total + "\n";
            report += "Average age (years)".PadRight(26) + result.AvgAge + "\n";
            report += "Average recovery score".PadRight(26) + result.AvgScore + "\n";
            report += "Critical".PadRight(26) + result.Critical + "\n";
            report += "Serious".PadRight(26) + result.Serious + "\n";
            report += "Stable".PadRight(26) + result.Stable + "\n";
            report += "Recovering".PadRight(26) + result.Recovering + "\n";
            report += "Release-Ready".PadRight(26) + result.ReleaseReady + "\n";

            try
            {
                File.WriteAllText("summary.txt", report);
            }
            catch (Exception ex)
            {
                // If we can't write the file, we still want the UI to show the results
                System.Windows.Forms.MessageBox.Show(FileErrorHelper.GetFriendlyErrorMessage(ex), "File Error");
            }

            return result;
        }
    }
}