
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
            this.businessCatLabel = new System.Windows.Forms.Label();
            this.businessGrid = new System.Windows.Forms.DataGridView();
            this.busCatListBox = new System.Windows.Forms.ListBox();
            this.busCatbutton = new System.Windows.Forms.Button();
            this.searchbutton = new System.Windows.Forms.Button();
            this.currentCategoriesTextBox = new System.Windows.Forms.TextBox();
            this.currentCatlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
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
            // businessCatLabel
            // 
            this.businessCatLabel.AutoSize = true;
            this.businessCatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessCatLabel.Location = new System.Drawing.Point(513, 8);
            this.businessCatLabel.Name = "businessCatLabel";
            this.businessCatLabel.Size = new System.Drawing.Size(198, 25);
            this.businessCatLabel.TabIndex = 7;
            this.businessCatLabel.Text = "Business Categories:";
            // 
            // businessGrid
            // 
            this.businessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.businessGrid.Location = new System.Drawing.Point(95, 277);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.RowHeadersWidth = 51;
            this.businessGrid.RowTemplate.Height = 24;
            this.businessGrid.Size = new System.Drawing.Size(748, 258);
            this.businessGrid.TabIndex = 8;
            this.businessGrid.SelectionChanged += new System.EventHandler(this.businessGrid_SelectionChanged);
            // 
            // busCatListBox
            // 
            this.busCatListBox.FormattingEnabled = true;
            this.busCatListBox.ItemHeight = 16;
            this.busCatListBox.Location = new System.Drawing.Point(518, 83);
            this.busCatListBox.Name = "busCatListBox";
            this.busCatListBox.Size = new System.Drawing.Size(198, 148);
            this.busCatListBox.TabIndex = 9;
            // 
            // busCatbutton
            // 
            this.busCatbutton.Location = new System.Drawing.Point(518, 44);
            this.busCatbutton.Name = "busCatbutton";
            this.busCatbutton.Size = new System.Drawing.Size(153, 33);
            this.busCatbutton.TabIndex = 10;
            this.busCatbutton.Text = "Add Category";
            this.busCatbutton.UseVisualStyleBackColor = true;
            this.busCatbutton.Click += new System.EventHandler(this.busCatbutton_Click);
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(316, 240);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(302, 31);
            this.searchbutton.TabIndex = 11;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            // 
            // currentCategoriesTextBox
            // 
            this.currentCategoriesTextBox.Location = new System.Drawing.Point(737, 83);
            this.currentCategoriesTextBox.Multiline = true;
            this.currentCategoriesTextBox.Name = "currentCategoriesTextBox";
            this.currentCategoriesTextBox.Size = new System.Drawing.Size(183, 84);
            this.currentCategoriesTextBox.TabIndex = 12;
            // 
            // currentCatlabel
            // 
            this.currentCatlabel.AutoSize = true;
            this.currentCatlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCatlabel.Location = new System.Drawing.Point(731, 59);
            this.currentCatlabel.Name = "currentCatlabel";
            this.currentCatlabel.Size = new System.Drawing.Size(208, 18);
            this.currentCatlabel.TabIndex = 13;
            this.currentCatlabel.Text = "Currently Selected Categories:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 547);
            this.Controls.Add(this.currentCatlabel);
            this.Controls.Add(this.currentCategoriesTextBox);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.busCatbutton);
            this.Controls.Add(this.busCatListBox);
            this.Controls.Add(this.businessGrid);
            this.Controls.Add(this.businessCatLabel);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.zipcodeComboBox);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.stateComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).EndInit();
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
        private System.Windows.Forms.Label businessCatLabel;
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.ListBox busCatListBox;
        private System.Windows.Forms.Button busCatbutton;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.TextBox currentCategoriesTextBox;
        private System.Windows.Forms.Label currentCatlabel;
    }
}

