
namespace part6
{
    partial class Form2
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
            this.tipGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.submitTipButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tipGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tipGrid
            // 
            this.tipGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tipGrid.Location = new System.Drawing.Point(42, 68);
            this.tipGrid.Name = "tipGrid";
            this.tipGrid.RowHeadersWidth = 51;
            this.tipGrid.RowTemplate.Height = 24;
            this.tipGrid.Size = new System.Drawing.Size(996, 217);
            this.tipGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tips for this business:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 324);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(864, 107);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter a new tip for this business:";
            // 
            // submitTipButton
            // 
            this.submitTipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitTipButton.Location = new System.Drawing.Point(723, 438);
            this.submitTipButton.Name = "submitTipButton";
            this.submitTipButton.Size = new System.Drawing.Size(183, 34);
            this.submitTipButton.TabIndex = 4;
            this.submitTipButton.Text = "Submit";
            this.submitTipButton.UseVisualStyleBackColor = true;
            this.submitTipButton.Click += new System.EventHandler(this.submitTipButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 494);
            this.Controls.Add(this.submitTipButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipGrid);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.tipGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tipGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitTipButton;
    }
}