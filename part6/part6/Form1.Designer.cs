
namespace part6
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
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.zipcodeComboBox = new System.Windows.Forms.ComboBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.businessCatComboBox = new System.Windows.Forms.ComboBox();
            this.businessCatLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // stateComboBox
            // 
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Location = new System.Drawing.Point(290, 12);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(121, 24);
            this.stateComboBox.TabIndex = 0;
            this.stateComboBox.SelectionChangeCommitted += new System.EventHandler(this.stateComboBox_SelectionChangeCommitted);
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(290, 55);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(121, 24);
            this.cityComboBox.TabIndex = 1;
            this.cityComboBox.SelectionChangeCommitted += new System.EventHandler(this.cityComboBox_SelectionChangeCommitted);
            // 
            // zipcodeComboBox
            // 
            this.zipcodeComboBox.FormattingEnabled = true;
            this.zipcodeComboBox.Location = new System.Drawing.Point(290, 103);
            this.zipcodeComboBox.Name = "zipcodeComboBox";
            this.zipcodeComboBox.Size = new System.Drawing.Size(121, 24);
            this.zipcodeComboBox.TabIndex = 2;
            this.zipcodeComboBox.SelectionChangeCommitted += new System.EventHandler(this.zipcodeComboBox_SelectionChangeCommitted);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(204, 12);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(64, 25);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "State:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(209, 55);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(52, 25);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City:";
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeLabel.Location = new System.Drawing.Point(186, 99);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(98, 25);
            this.zipCodeLabel.TabIndex = 5;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // businessCatComboBox
            // 
            this.businessCatComboBox.FormattingEnabled = true;
            this.businessCatComboBox.Location = new System.Drawing.Point(290, 146);
            this.businessCatComboBox.Name = "businessCatComboBox";
            this.businessCatComboBox.Size = new System.Drawing.Size(121, 24);
            this.businessCatComboBox.TabIndex = 6;
            // 
            // businessCatLabel
            // 
            this.businessCatLabel.AutoSize = true;
            this.businessCatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessCatLabel.Location = new System.Drawing.Point(63, 142);
            this.businessCatLabel.Name = "businessCatLabel";
            this.businessCatLabel.Size = new System.Drawing.Size(198, 25);
            this.businessCatLabel.TabIndex = 7;
            this.businessCatLabel.Text = "Business Categories:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 180);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(748, 258);
            this.dataGridView1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.businessCatLabel);
            this.Controls.Add(this.businessCatComboBox);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.zipcodeComboBox);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.stateComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.ComboBox zipcodeComboBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label zipCodeLabel;
        private System.Windows.Forms.ComboBox businessCatComboBox;
        private System.Windows.Forms.Label businessCatLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

