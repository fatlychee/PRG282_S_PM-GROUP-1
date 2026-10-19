using System;
using System.IO;

namespace PRG2782_Project_2026 // IMPORTANT: Change this to match your project's namespace!
{
    public static class FileErrorHelper
    {
        public static string GetFriendlyErrorMessage(Exception ex)
        {
            if (ex is UnauthorizedAccessException)
            {
                return "Access denied. The file might be read-only, or you don't have permission to modify it.";
            }
            if (ex is FileNotFoundException)
            {
                return "The required file could not be found.";
            }
            if (ex is DirectoryNotFoundException)
            {
                return "The directory containing the file could not be found.";
            }
            if (ex is IOException)
            {
                return "The file is currently in use by another program. Please close it and try again.";
            }
            return $"An unexpected error occurred: {ex.Message}";
        }
    }
}