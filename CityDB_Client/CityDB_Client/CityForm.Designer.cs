namespace CityDB_Client
{
    partial class CityForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCities = new DataGridView();
            lblChoices = new Label();
            cboChoices = new ComboBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCountryCode = new Label();
            txtCountryCode = new TextBox();
            btnFetch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCities).BeginInit();
            SuspendLayout();
            // 
            // dgvCities
            // 
            dgvCities.BackgroundColor = Color.FromArgb(128, 255, 255);
            dgvCities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCities.Location = new Point(28, 92);
            dgvCities.Name = "dgvCities";
            dgvCities.Size = new Size(598, 289);
            dgvCities.TabIndex = 0;
            // 
            // lblChoices
            // 
            lblChoices.AutoSize = true;
            lblChoices.Location = new Point(28, 19);
            lblChoices.Name = "lblChoices";
            lblChoices.Size = new Size(104, 15);
            lblChoices.TabIndex = 1;
            lblChoices.Text = "Choose an option:";
            // 
            // cboChoices
            // 
            cboChoices.FormattingEnabled = true;
            cboChoices.Location = new Point(138, 16);
            cboChoices.Name = "cboChoices";
            cboChoices.Size = new Size(181, 23);
            cboChoices.TabIndex = 2;
            cboChoices.SelectedIndexChanged += cboChoices_SelectedIndexChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(28, 57);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 3;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(138, 54);
            txtName.Name = "txtName";
            txtName.Size = new Size(181, 23);
            txtName.TabIndex = 4;
            // 
            // lblCountryCode
            // 
            lblCountryCode.AutoSize = true;
            lblCountryCode.Location = new Point(340, 57);
            lblCountryCode.Name = "lblCountryCode";
            lblCountryCode.Size = new Size(82, 15);
            lblCountryCode.TabIndex = 5;
            lblCountryCode.Text = "Country code:";
            // 
            // txtCountryCode
            // 
            txtCountryCode.Location = new Point(428, 54);
            txtCountryCode.Name = "txtCountryCode";
            txtCountryCode.Size = new Size(43, 23);
            txtCountryCode.TabIndex = 6;
            // 
            // btnFetch
            // 
            btnFetch.FlatStyle = FlatStyle.Popup;
            btnFetch.Location = new Point(551, 54);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(75, 23);
            btnFetch.TabIndex = 7;
            btnFetch.Text = "Get";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += btnFetch_Click;
            // 
            // CityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(656, 412);
            Controls.Add(btnFetch);
            Controls.Add(txtCountryCode);
            Controls.Add(lblCountryCode);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(cboChoices);
            Controls.Add(lblChoices);
            Controls.Add(dgvCities);
            Name = "CityForm";
            Text = "World Cities";
            Load += CityForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCities).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCities;
        private Label lblChoices;
        private ComboBox cboChoices;
        private Label lblName;
        private TextBox txtName;
        private Label lblCountryCode;
        private TextBox txtCountryCode;
        private Button btnFetch;
    }
}
