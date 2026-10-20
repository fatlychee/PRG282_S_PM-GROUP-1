# PRG2782 Project 2026 - Baobab Ridge Wildlife Rehabilitation Centre

## Project Description
A Windows Forms application used to manage animal recovery records, track recovery scores, and generate summary reports for the Baobab Ridge Wildlife Rehabilitation Centre.

## Group Members
- Member 1: Lumile Johns - 604931 - Core Models & Business Logic
- Member 2: Tumelo Lepota - 604239 - View Animals & File Loading
- Member 3: Seth White - 603397 - Add Animal Feature
- Member 4: Ben Linde - 603396 - Update & Delete Features
- Member 5: Christopher Heyl - 602473 - Summary, Error Handling & GitHub Manager


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
Pipe-separated values in the format:
`AnimalID|Name|Species|Age|RecoveryScore|Status|HousingUnit`
Example: `WR-0001|Thabo|African Penguin|4|85|Release-Ready|Pre-Release Camp`

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