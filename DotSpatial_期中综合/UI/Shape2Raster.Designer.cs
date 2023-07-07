
namespace DotSpatial_期中综合
{
    partial class Shape2Raster
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
            this.comboBoxShpLayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCellSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFiledName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRasterName = new System.Windows.Forms.TextBox();
            this.Run = new System.Windows.Forms.Button();
            this.GetFiledName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxShpLayer
            // 
            this.comboBoxShpLayer.FormattingEnabled = true;
            this.comboBoxShpLayer.Location = new System.Drawing.Point(90, 27);
            this.comboBoxShpLayer.Name = "comboBoxShpLayer";
            this.comboBoxShpLayer.Size = new System.Drawing.Size(206, 23);
            this.comboBoxShpLayer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ShpLayer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "CellSize";
            // 
            // textBoxCellSize
            // 
            this.textBoxCellSize.Location = new System.Drawing.Point(90, 65);
            this.textBoxCellSize.Name = "textBoxCellSize";
            this.textBoxCellSize.Size = new System.Drawing.Size(100, 25);
            this.textBoxCellSize.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "FiledName";
            // 
            // comboBoxFiledName
            // 
            this.comboBoxFiledName.FormattingEnabled = true;
            this.comboBoxFiledName.Location = new System.Drawing.Point(90, 102);
            this.comboBoxFiledName.Name = "comboBoxFiledName";
            this.comboBoxFiledName.Size = new System.Drawing.Size(206, 23);
            this.comboBoxFiledName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "RasterName";
            // 
            // textBoxRasterName
            // 
            this.textBoxRasterName.Location = new System.Drawing.Point(90, 137);
            this.textBoxRasterName.Name = "textBoxRasterName";
            this.textBoxRasterName.Size = new System.Drawing.Size(100, 25);
            this.textBoxRasterName.TabIndex = 7;
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(251, 174);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 8;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // GetFiledName
            // 
            this.GetFiledName.Location = new System.Drawing.Point(322, 102);
            this.GetFiledName.Name = "GetFiledName";
            this.GetFiledName.Size = new System.Drawing.Size(30, 23);
            this.GetFiledName.TabIndex = 9;
            this.GetFiledName.Text = "button1";
            this.GetFiledName.UseVisualStyleBackColor = true;
            this.GetFiledName.Click += new System.EventHandler(this.GetFiledName_Click);
            // 
            // Shape2Raster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 209);
            this.Controls.Add(this.GetFiledName);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.textBoxRasterName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxFiledName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCellSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxShpLayer);
            this.Name = "Shape2Raster";
            this.Text = "Shape2Raster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBoxShpLayer;
        public System.Windows.Forms.TextBox textBoxCellSize;
        public System.Windows.Forms.ComboBox comboBoxFiledName;
        public System.Windows.Forms.TextBox textBoxRasterName;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button GetFiledName;
    }
}