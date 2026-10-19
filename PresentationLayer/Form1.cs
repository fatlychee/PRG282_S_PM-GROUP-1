using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG2782_Project_2026
{
    public partial class Form1 : Form
    {
        //Memeber 4 variables
        private List<Animal> animals;
        private Animal selectedAnimals;
        public Form1()
        {
            InitializeComponent();
        }

        //Form Load
         private void Form1_Load(object sender, EventArgs e)
        {
           animals = AnimalFileService.LoadAnimals();

          RefreshGrid();
        }
        
        //Search Button
        private void btnSearch_Click(object sender,EventArgs e)
        {
        selectedAnimal = UpdateDeleteService.SearchAnimal(animals,txtSearchID.Text);

    if (selectedAnimal == null)
    {
        MessageBox.Show("Animal not found.");

        return;
    }

    txtAnimalID.Text = selectedAnimal.AnimalID;

    txtName.Text = selectedAnimal.Name;

    txtSpecies.Text = selectedAnimal.Species;

    txtAge.Text = selectedAnimal.Age.ToString();

    txtRecoveryScore.Text = selectedAnimal.RecoveryScore.ToString();
}

     //Save Changes Button
     private void btnSaveChanges_Click(object sender,EventArgs e)
{
    try
    {
        Animal updatedAnimal = new Animal
            {
                AnimalID = txtAnimalID.Text,

                Name = txtName.Text,

                Species = txtSpecies.Text,

                Age = int.Parse(txtAge.Text),

                RecoveryScore =int.Parse(txtRecoveryScore.Text)
            };

        bool updated = UpdateDeleteService.UpdateAnimal(animals, updatedAnimal);

        if (updated)
        {
            RefreshGrid();

            MessageBox.Show("Animal updated successfully.");
        }
        else
        {
            MessageBox.Show("Animal not found.");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}   
//Delete Button
private void btnDelete_Click( object sender,EventArgs e)
{
    if (selectedAnimal == null)
    {
        MessageBox.Show("Select an animal first.");

        return;
    }

    DialogResult result = MessageBox.Show($"Delete {selectedAnimal.AnimalID} ({selectedAnimal.Name})?", "Confirm Delete", MessageBoxButtons.YesNo);

    if (result == DialogResult.No)
        return;

    bool deleted = UpdateDeleteService.DeleteAnimal(animals,selectedAnimal.AnimalID);

    if (deleted)
    {
        RefreshGrid();

        MessageBox.Show("Animal deleted.");

        ClearFields();
    }
}
//DataGridView row selection
private void dgvAnimals_CellClick(object sender,DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0)
        return;

    selectedAnimal = (Animal)dgvAnimals.Rows[e.RowIndex].DataBoundItem;

    txtAnimalID.Text = selectedAnimal.AnimalID;

    txtName.Text = selectedAnimal.Name;

    txtSpecies.Text = selectedAnimal.Species;

    txtAge.Text = selectedAnimal.Age.ToString();

    txtRecoveryScore.Text =  selectedAnimal.RecoveryScore.ToString();
}
//Clear Fields
private void ClearFields()
{
    txtAnimalID.Clear();
    txtName.Clear();
    txtSpecies.Clear();
    txtAge.Clear();
    txtRecoveryScore.Clear();
    txtSearchID.Clear();

    selectedAnimal = null;
}

    }
}
