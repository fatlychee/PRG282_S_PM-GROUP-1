using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG2782_Project_2026.Services;
using PRG2782_Project_2026.Models;
using System.IO;

namespace PRG2782_Project_2026.Forms
{
    public partial class AnimalForm : Form
    {
        AnimalReaderFile reader = new AnimalReaderFile();
        List<Animal> animals = new List<Animal>();
        public AnimalForm()
        {
            InitializeComponent();
        }

        private void AnimalForm_Load(object sender, EventArgs e)
        {
            SetUpGrid();
            RefreshGrid();
        }

        public void SetUpGrid()
        {
            dgvAnimal.AutoGenerateColumns = true;
            dgvAnimal.Columns.Clear();

            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Animal ID", DataPropertyName = "AnimalID" });
            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Species", DataPropertyName = "Species" });
            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Age", DataPropertyName = "Age" });
            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "RecoveryScore", DataPropertyName = "RecoveryScore" });
            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            dgvAnimal.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "HousingUnit", DataPropertyName = "HousinUnit" });

            dgvAnimal.ReadOnly = true;
            dgvAnimal.AllowUserToAddRows = false;
            dgvAnimal.AllowUserToDeleteRows = false;
            dgvAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimal.MultiSelect = false;
            dgvAnimal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void RefreshGrid()
        {
            try
            {
                animals = reader.LoadAnimals();
                dgvAnimal.DataSource = animals;
                lblOut.Text = $"{animals.Count} record(s) loaded. {reader.SkippedRecords} invalid record(s) skipped.";
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
