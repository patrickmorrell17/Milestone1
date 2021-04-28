
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnback = new System.Windows.Forms.Button();
            this.btncheckin = new System.Windows.Forms.Button();
            this.checkinchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.checkinchart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(971, 383);
            this.btnback.Margin = new System.Windows.Forms.Padding(4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(181, 95);
            this.btnback.TabIndex = 4;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncheckin
            // 
            this.btncheckin.Location = new System.Drawing.Point(971, 234);
            this.btncheckin.Margin = new System.Windows.Forms.Padding(4);
            this.btncheckin.Name = "btncheckin";
            this.btncheckin.Size = new System.Drawing.Size(181, 95);
            this.btncheckin.TabIndex = 3;
            this.btncheckin.Text = "Check-In";
            this.btncheckin.UseVisualStyleBackColor = true;
            this.btncheckin.Click += new System.EventHandler(this.btncheckin_Click);
            // 
            // checkinchart
            // 
            chartArea3.Name = "ChartArea1";
            this.checkinchart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.checkinchart.Legends.Add(legend3);
            this.checkinchart.Location = new System.Drawing.Point(33, 41);
            this.checkinchart.Name = "checkinchart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.checkinchart.Series.Add(series3);
            this.checkinchart.Size = new System.Drawing.Size(901, 437);
            this.checkinchart.TabIndex = 5;
            this.checkinchart.Text = "checkinchart";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 602);
            this.Controls.Add(this.checkinchart);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btncheckin);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.checkinchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btncheckin;
        private System.Windows.Forms.DataVisualization.Charting.Chart checkinchart;
    }
}