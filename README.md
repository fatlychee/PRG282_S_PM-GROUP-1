# PRG2782 Project 2026 - Animal Recovery Tracker

## Project Description
A Windows Forms application used to manage animal recovery records, track recovery scores, and generate summary reports.

## Group Members
- Member 1: [Full Name] - [Student Number] - Core Models & Business Logic
- Member 2: [Full Name] - [Student Number] - View Animals & File Loading
- Member 3: [Full Name] - [Student Number] - Add Animal Feature
- Member 4: [Full Name] - [Student Number] - Update & Delete Features
- Member 5: [Your Full Name] - [Your Student Number] - Summary, Error Handling & GitHub Manager

## Build Instructions
1. Clone the repository.
2. Open `PRG2782-Project-2026.sln` in Visual Studio 2022.
3. Ensure the .NET 8 SDK is installed.
4. Press F5 or click "Start" to build and run the application.

## Features
- **View Animals:** Loads and displays records from `animals.txt` in a DataGridView.
- **Add Animal:** Validates input and appends a new record to `animals.txt`.
- **Update Animal:** Allows editing of existing records and recalculates classification.
- **Delete Animal:** Removes a selected record with a confirmation dialog.
- **Generate Summary:** Calculates totals, averages, and status counts, then writes a report to `summary.txt`.

## File Formats
### animals.txt
Comma-separated values in the format:
`AnimalID,Name,Species,Age,RecoveryScore,Status`
Example: `WR-0001,Luna,Lion,5,85,Release-Ready`

### summary.txt
A generated text report showing:
- Total animals
- Average age (years)
- Average recovery score
- Count of each status (Critical, Serious, Stable, Recovering, Release-Ready)

## Limitations
- Data is stored in a plain text file, not a database.
- Multi-user access is not supported (file locking issues).
- No image or photo upload for animals.