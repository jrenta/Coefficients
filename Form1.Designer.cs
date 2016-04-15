namespace MacAdamsCoefficients
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.2D, 0.8D);
            this.chartG11 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_LoadGraph = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.txt_Browse = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartG11)).BeginInit();
            this.SuspendLayout();
            // 
            // chartG11
            // 
            chartArea2.Name = "ChartArea1";
            this.chartG11.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartG11.Legends.Add(legend2);
            this.chartG11.Location = new System.Drawing.Point(362, 12);
            this.chartG11.Name = "chartG11";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "550";
            series2.Points.Add(dataPoint2);
            series2.XValueMember = "0.2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueMembers = ".15, .33, .10";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartG11.Series.Add(series2);
            this.chartG11.Size = new System.Drawing.Size(300, 194);
            this.chartG11.TabIndex = 0;
            this.chartG11.Text = "chartG11";
            // 
            // btn_LoadGraph
            // 
            this.btn_LoadGraph.Location = new System.Drawing.Point(541, 255);
            this.btn_LoadGraph.Name = "btn_LoadGraph";
            this.btn_LoadGraph.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadGraph.TabIndex = 1;
            this.btn_LoadGraph.Text = "Load Graph";
            this.btn_LoadGraph.UseVisualStyleBackColor = true;
            this.btn_LoadGraph.Click += new System.EventHandler(this.btn_LoadGraph_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(587, 212);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 2;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_Browse
            // 
            this.txt_Browse.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Browse.Location = new System.Drawing.Point(362, 214);
            this.txt_Browse.Name = "txt_Browse";
            this.txt_Browse.Size = new System.Drawing.Size(219, 20);
            this.txt_Browse.TabIndex = 3;
            this.txt_Browse.Text = "Load Excel File Here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 471);
            this.Controls.Add(this.txt_Browse);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btn_LoadGraph);
            this.Controls.Add(this.chartG11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chartG11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartG11;
        private System.Windows.Forms.Button btn_LoadGraph;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox txt_Browse;
    }
}

