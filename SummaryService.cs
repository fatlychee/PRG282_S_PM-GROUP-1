using PRG2782_Project_2026.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PRG2782_Project_2026
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
                        // RUBRIC FIX: Uses pipe | and expects 7 fields
                        string[] parts = line.Split('|');
                        if (parts.Length == 7)
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
                                    Status = parts[5].Trim(),
                                    HousingUnit = parts[6].Trim()
                                });
                            }
                            catch { /* Skip malformed records */ }
                        }
                    }
                }
            }
            catch (Exception)
            {
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

            // Build the report string EXACTLY as the rubric demands
            string report = "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE\n";
            report += "ANIMAL SUMMARY REPORT\n";
            report += $"Generated: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}\n\n";

            report += $"Total animals: {result.Total}\n";
            report += $"Average age (years): {result.AvgAge}\n";
            report += $"Average recovery score: {result.AvgScore}\n\n";

            report += "Animals per status:\n";
            report += $"Critical: {result.Critical}\n";
            report += $"Serious: {result.Serious}\n";
            report += $"Stable: {result.Stable}\n";
            report += $"Recovering: {result.Recovering}\n";
            report += $"Release-Ready: {result.ReleaseReady}\n";

            try
            {
                // Save beside the .exe
                string summaryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "summary.txt");
                File.WriteAllText(summaryPath, report);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(FileErrorHelper.GetFriendlyErrorMessage(ex), "File Error");
            }

            return result;
        }
    }
}