namespace PRG2782_Project_2026
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAnimal = new System.Windows.Forms.DataGridView();
            this.ColAnimalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnimalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnimalSpecies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnimalAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecoveryScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHousingUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnimal
            // 
            this.dgvAnimal.AllowUserToAddRows = false;
            this.dgvAnimal.AllowUserToDeleteRows = false;
            this.dgvAnimal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAnimalID,
            this.ColAnimalName,
            this.ColAnimalSpecies,
            this.ColAnimalAge,
            this.colRecoveryScore,
            this.ColStatus,
            this.ColHousingUnit});
            this.dgvAnimal.Location = new System.Drawing.Point(40, 46);
            this.dgvAnimal.MultiSelect = false;
            this.dgvAnimal.Name = "dgvAnimal";
            this.dgvAnimal.RowHeadersWidth = 51;
            this.dgvAnimal.RowTemplate.Height = 24;
            this.dgvAnimal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimal.Size = new System.Drawing.Size(934, 307);
            this.dgvAnimal.TabIndex = 0;
            this.dgvAnimal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnimal_CellContentClick);
            // 
            // ColAnimalID
            // 
            this.ColAnimalID.DataPropertyName = "AnimalID";
            this.ColAnimalID.HeaderText = "AnimalID";
            this.ColAnimalID.MinimumWidth = 6;
            this.ColAnimalID.Name = "ColAnimalID";
            this.ColAnimalID.ReadOnly = true;
            this.ColAnimalID.Width = 125;
            // 
            // ColAnimalName
            // 
            this.ColAnimalName.DataPropertyName = "Name";
            this.ColAnimalName.HeaderText = "AnimalName";
            this.ColAnimalName.MinimumWidth = 6;
            this.ColAnimalName.Name = "ColAnimalName";
            this.ColAnimalName.ReadOnly = true;
            this.ColAnimalName.Width = 125;
            // 
            // ColAnimalSpecies
            // 
            this.ColAnimalSpecies.DataPropertyName = "Species";
            this.ColAnimalSpecies.HeaderText = "AnimalSpecies";
            this.ColAnimalSpecies.MinimumWidth = 6;
            this.ColAnimalSpecies.Name = "ColAnimalSpecies";
            this.ColAnimalSpecies.ReadOnly = true;
            this.ColAnimalSpecies.Width = 125;
            // 
            // ColAnimalAge
            // 
            this.ColAnimalAge.DataPropertyName = "Age";
            this.ColAnimalAge.HeaderText = "AnimalAge";
            this.ColAnimalAge.MinimumWidth = 6;
            this.ColAnimalAge.Name = "ColAnimalAge";
            this.ColAnimalAge.ReadOnly = true;
            this.ColAnimalAge.Width = 125;
            // 
            // colRecoveryScore
            // 
            this.colRecoveryScore.DataPropertyName = "RecoveryScore";
            this.colRecoveryScore.HeaderText = "RecoveryScore";
            this.colRecoveryScore.MinimumWidth = 6;
            this.colRecoveryScore.Name = "colRecoveryScore";
            this.colRecoveryScore.ReadOnly = true;
            this.colRecoveryScore.Width = 125;
            // 
            // ColStatus
            // 
            this.ColStatus.DataPropertyName = "Status";
            this.ColStatus.HeaderText = "AnimalStatus";
            this.ColStatus.MinimumWidth = 6;
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.ReadOnly = true;
            this.ColStatus.Width = 125;
            // 
            // ColHousingUnit
            // 
            this.ColHousingUnit.DataPropertyName = "HousingUnit";
            this.ColHousingUnit.HeaderText = "HousingUnit";
            this.ColHousingUnit.MinimumWidth = 6;
            this.ColHousingUnit.Name = "ColHousingUnit";
            this.ColHousingUnit.ReadOnly = true;
            this.ColHousingUnit.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 450);
            this.Controls.Add(this.dgvAnimal);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnimalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnimalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnimalSpecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnimalAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecoveryScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHousingUnit;
    }
}

