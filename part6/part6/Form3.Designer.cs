
namespace part6
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.checkinchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btncheckin = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.checkinchart)).BeginInit();
            this.SuspendLayout();
            // 
            // checkinchart
            // 
            chartArea2.Name = "ChartArea1";
            this.checkinchart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.checkinchart.Legends.Add(legend2);
            this.checkinchart.Location = new System.Drawing.Point(12, 12);
            this.checkinchart.Name = "checkinchart";
            this.checkinchart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "# of Check-ins";
            this.checkinchart.Series.Add(series2);
            this.checkinchart.Size = new System.Drawing.Size(776, 426);
            this.checkinchart.TabIndex = 0;
            this.checkinchart.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Number of Check-ins Per Month";
            this.checkinchart.Titles.Add(title2);
            // 
            // btncheckin
            // 
            this.btncheckin.Location = new System.Drawing.Point(635, 120);
            this.btncheckin.Name = "btncheckin";
            this.btncheckin.Size = new System.Drawing.Size(136, 77);
            this.btncheckin.TabIndex = 1;
            this.btncheckin.Text = "Check-In";
            this.btncheckin.UseVisualStyleBackColor = true;
            this.btncheckin.Click += new System.EventHandler(this.btncheckin_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(635, 248);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(136, 77);
            this.btnback.TabIndex = 2;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btncheckin);
            this.Controls.Add(this.checkinchart);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.checkinchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart checkinchart;
        private System.Windows.Forms.Button btncheckin;
        private System.Windows.Forms.Button btnback;
    }
}