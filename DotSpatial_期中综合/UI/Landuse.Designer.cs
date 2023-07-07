
namespace DotSpatial_期中综合
{
    partial class Landuse
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.comboBoxLayerRaster = new System.Windows.Forms.ComboBox();
            this.btnGA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRuning = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxNumChildren = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxLayerRaster
            // 
            this.comboBoxLayerRaster.FormattingEnabled = true;
            this.comboBoxLayerRaster.Location = new System.Drawing.Point(116, 23);
            this.comboBoxLayerRaster.Name = "comboBoxLayerRaster";
            this.comboBoxLayerRaster.Size = new System.Drawing.Size(178, 23);
            this.comboBoxLayerRaster.TabIndex = 0;
            // 
            // btnGA
            // 
            this.btnGA.BackColor = System.Drawing.SystemColors.Info;
            this.btnGA.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGA.Location = new System.Drawing.Point(335, 115);
            this.btnGA.Name = "btnGA";
            this.btnGA.Size = new System.Drawing.Size(123, 33);
            this.btnGA.TabIndex = 1;
            this.btnGA.Text = "Run";
            this.btnGA.UseVisualStyleBackColor = false;
            this.btnGA.Click += new System.EventHandler(this.btnGA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input Land";
            // 
            // labelRuning
            // 
            this.labelRuning.AutoSize = true;
            this.labelRuning.Location = new System.Drawing.Point(12, 526);
            this.labelRuning.Name = "labelRuning";
            this.labelRuning.Size = new System.Drawing.Size(93, 15);
            this.labelRuning.TabIndex = 13;
            this.labelRuning.Text = "Loading……";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(252, 559);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(206, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // chart1
            // 
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Bottom;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(12, 190);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series5.BorderColor = System.Drawing.Color.Blue;
            series5.BorderWidth = 5;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(442, 322);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "chart1";
            title4.Name = "Land Planning Grades";
            title4.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow;
            this.chart1.Titles.Add(title4);
            // 
            // textBoxNumChildren
            // 
            this.textBoxNumChildren.Location = new System.Drawing.Point(147, 103);
            this.textBoxNumChildren.Name = "textBoxNumChildren";
            this.textBoxNumChildren.Size = new System.Drawing.Size(59, 25);
            this.textBoxNumChildren.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Children Num";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Iterations Num";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 25);
            this.textBox1.TabIndex = 19;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 559);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(206, 23);
            this.progressBar2.TabIndex = 20;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "子代优秀收敛",
            "快速收敛"});
            this.comboBox1.Location = new System.Drawing.Point(237, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(249, 541);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "overall progress";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "heredity progress";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Requirements of Offspring";
            // 
            // chart2
            // 
            this.chart2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Bottom;
            chartArea5.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea5);
            this.chart2.Location = new System.Drawing.Point(474, 12);
            this.chart2.Name = "chart2";
            this.chart2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.Name = "Series1";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series7.Name = "Series2";
            this.chart2.Series.Add(series6);
            this.chart2.Series.Add(series7);
            this.chart2.Size = new System.Drawing.Size(425, 307);
            this.chart2.TabIndex = 25;
            this.chart2.Text = "chart2";
            title5.Name = "Land Planning Grades";
            title5.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow;
            this.chart2.Titles.Add(title5);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(118, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "population mean score";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(541, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(317, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "population max and min score";
            // 
            // chart3
            // 
            this.chart3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Bottom;
            chartArea6.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea6);
            this.chart3.Location = new System.Drawing.Point(474, 336);
            this.chart3.Name = "chart3";
            this.chart3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series8.Name = "Series1";
            this.chart3.Series.Add(series8);
            this.chart3.Size = new System.Drawing.Size(425, 246);
            this.chart3.TabIndex = 28;
            this.chart3.Text = "chart3";
            title6.Name = "Land Planning Grades";
            title6.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow;
            this.chart3.Titles.Add(title6);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(509, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(372, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "The proportion of each block type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Learn about me";
            // 
            // Landuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 601);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumChildren);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelRuning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGA);
            this.Controls.Add(this.comboBoxLayerRaster);
            this.Name = "Landuse";
            this.Text = "Landuse";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxLayerRaster;
        private System.Windows.Forms.Button btnGA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRuning;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBoxNumChildren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}