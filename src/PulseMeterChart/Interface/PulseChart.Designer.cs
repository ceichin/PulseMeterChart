namespace PulseMeterChart
{
    partial class PulseChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblRate = new System.Windows.Forms.Label();
            this.imgHeart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea7.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart.Legends.Add(legend7);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart.Series.Add(series7);
            this.chart.Size = new System.Drawing.Size(1335, 622);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(1103, 373);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(128, 25);
            this.lblRate.TabIndex = 1;
            this.lblRate.Text = "Rate: - BPM";
            // 
            // imgHeart
            // 
            this.imgHeart.Image = global::WindowsFormsApplication1.Properties.Resources.heart;
            this.imgHeart.Location = new System.Drawing.Point(1108, 221);
            this.imgHeart.Name = "imgHeart";
            this.imgHeart.Size = new System.Drawing.Size(116, 116);
            this.imgHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgHeart.TabIndex = 14;
            this.imgHeart.TabStop = false;
            this.imgHeart.Click += new System.EventHandler(this.imgHeart_Click);
            // 
            // PulseChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgHeart);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.chart);
            this.Name = "PulseChart";
            this.Size = new System.Drawing.Size(1338, 628);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.PictureBox imgHeart;
    }
}
