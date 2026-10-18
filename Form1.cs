using PRG2782_Project_2026.Models;
using PRG2782_Project_2026.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG2782_Project_2026
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadAnimalsIntoGrid();
        }
        //this loads the animals into the gridview 
        private void LoadAnimalsIntoGrid()
        {
            // Create the file reader.
            AnimalReaderFile reader = new AnimalReaderFile();

            try
            {
                // Load the valid animal records.
                List<Animal> animals = reader.LoadAnimals();
                MessageBox.Show("Animals loaded: " + animals.Count);

                // Prevent the grid from creating extra columns automatically.
                dgvAnimal.AutoGenerateColumns = false;

                // Display the animals in the grid.
                dgvAnimal.DataSource = null;
                dgvAnimal.DataSource = animals;

                // Tell the user if any records were skipped.
                if (reader.SkippedRecords > 0)
                {
                    MessageBox.Show(
                        reader.SkippedRecords + " invalid animal record(s) were skipped.",
                        "Animal Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Permission Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvAnimal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
