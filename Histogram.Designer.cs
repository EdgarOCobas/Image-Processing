namespace Projekt_APO_2022
{
    partial class Histogram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.histChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.histChart)).BeginInit();
            this.SuspendLayout();
            // 
            // histChart
            // 
            chartArea1.Name = "ChartArea1";
            this.histChart.ChartAreas.Add(chartArea1);
            this.histChart.Location = new System.Drawing.Point(71, 55);
            this.histChart.Name = "histChart";
            this.histChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.histChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Green,
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.Name = "red";
            series2.ChartArea = "ChartArea1";
            series2.Name = "green";
            series3.ChartArea = "ChartArea1";
            series3.Name = "blue";
            this.histChart.Series.Add(series1);
            this.histChart.Series.Add(series2);
            this.histChart.Series.Add(series3);
            this.histChart.Size = new System.Drawing.Size(469, 331);
            this.histChart.TabIndex = 0;
            this.histChart.Text = "chart1";
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 459);
            this.Controls.Add(this.histChart);
            this.Name = "Histogram";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.histChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataVisualization.Charting.Chart histChart;
    }
}