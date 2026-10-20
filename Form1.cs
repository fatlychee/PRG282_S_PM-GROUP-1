using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PRG2782_Project_2026.Services;
using PRG2782_Project_2026.Forms;
using PRG2782_Project_2026.Models;

namespace PRG2782_Project_2026
{
    public partial class Form1 : Form
    {
        // Path to animals.txt, stored beside the running .exe so it works on any computer
        private readonly string animalsFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");

        public Form1()
        {
            InitializeComponent();

            // --- MEMBER 5 SUMMARY UI (Added via code to avoid designer conflicts) ---
            Button btnGenerateSummary = new Button();
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.Location = new System.Drawing.Point(30, 280);
            btnGenerateSummary.Size = new System.Drawing.Size(150, 30);
            btnGenerateSummary.Click += BtnGenerateSummary_Click;
            this.Controls.Add(btnGenerateSummary);

            TextBox txtSummaryResults = new TextBox();
            txtSummaryResults.Name = "txtSummaryResults";
            txtSummaryResults.Multiline = true;
            txtSummaryResults.ReadOnly = true;
            txtSummaryResults.Location = new System.Drawing.Point(30, 320);
            txtSummaryResults.Size = new System.Drawing.Size(340, 150);
            txtSummaryResults.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(txtSummaryResults);
            // -----------------------------------------------------------------------

            // --- QUICK NAVIGATION TO ANIMALFORM (VIEW) ---
            Button btnViewAnimals = new Button();
            btnViewAnimals.Text = "View Animals Grid";
            btnViewAnimals.Location = new System.Drawing.Point(200, 280);
            btnViewAnimals.Size = new System.Drawing.Size(150, 30);
            btnViewAnimals.Click += (s, ev) =>
            {
                AnimalForm animalForm = new AnimalForm();
                animalForm.Show();
            };
            this.Controls.Add(btnViewAnimals);
            // --------------------------------------
        }

        // TEMPORARY stand-in until the View feature is merged.
        private void RefreshGrid() { }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error = ValidationService.ValidateFields(
                txtAnimalId.Text, txtName.Text, txtSpecies.Text, txtAge.Text, txtScore.Text);

            if (error != string.Empty)
            {
                ShowError(error, GetFaultyBox(error));
                return;   // nothing saved
            }

            // read the values now, because validation passed
            string animalId = txtAnimalId.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            int age = int.Parse(txtAge.Text.Trim());
            int score = int.Parse(txtScore.Text.Trim());

            // save, with file error handling
            try
            {
                if (ValidationService.IsDuplicateID(animalId, GetExistingIds()))
                {
                    ShowError("Animal ID already exists. IDs must be unique.", txtAnimalId);
                    return;
                }

                // ClassificationService
                (string status, string housingUnit) = ClassificationService.GetClassification(score);

                string line = string.Join("|", animalId, name, species, age, score, status, housingUnit);
                File.AppendAllText(animalsFilePath, line + Environment.NewLine);

                MessageBox.Show($"Animal saved.\nStatus: {status}\nHousing Unit: {housingUnit}");
                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("The file could not be saved. It may be read-only or open in another program.");
            }
        }

        // --- MEMBER 5 SUMMARY CLICK EVENT ---
        private void BtnGenerateSummary_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Call the fixed SummaryService method
                SummaryService.Calculate(animalsFilePath);

                // 2. Read the generated file and show it
                string summaryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "summary.txt");

                if (File.Exists(summaryPath))
                {
                    string report = File.ReadAllText(summaryPath);
                    Control[] found = this.Controls.Find("txtSummaryResults", true);
                    if (found.Length > 0)
                    {
                        ((TextBox)found[0]).Text = report;
                    }
                }
                else
                {
                    MessageBox.Show("summary.txt was not found. Check your SummaryService method.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating summary: " + ex.Message);
            }
        }
        // ------------------------------------

        private TextBox GetFaultyBox(string error)
        {
            if (error.StartsWith("Animal ID")) return txtAnimalId;
            if (error.StartsWith("Name")) return txtName;
            if (error.StartsWith("Species")) return txtSpecies;
            if (error.StartsWith("Age")) return txtAge;
            return txtScore;   // the only remaining possibility
        }

        // Shows an error message and puts the cursor back in the faulty box.
        private void ShowError(string message, TextBox faultyBox)
        {
            MessageBox.Show(message);
            faultyBox.Focus();
        }

        // Empties all input boxes, ready for the next animal.
        private void ClearInputs()
        {
            txtAnimalId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtScore.Clear();
            txtAnimalId.Focus();
        }

        // Reads every ID (first field of each line) from animals.txt into a list.
        private List<string> GetExistingIds()
        {
            List<string> ids = new List<string>();
            if (!File.Exists(animalsFilePath)) return ids;

            foreach (string line in File.ReadLines(animalsFilePath))
            {
                ids.Add(line.Split('|')[0]);
            }
            return ids;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }
    }
}