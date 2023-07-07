
namespace DotSpatial_期中综合
{
    partial class Table
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
            this.pnlTable = new System.Windows.Forms.Panel();
            this.menuStripTable = new System.Windows.Forms.MenuStrip();
            this.tableEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAColumnInTheAttributeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAColumnInTheAttributeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAttributeTableInShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTable2 = new System.Windows.Forms.Panel();
            this.dgvAttributeTable = new System.Windows.Forms.DataGridView();
            this.TableOperation = new System.Windows.Forms.Panel();
            this.TableOperation2 = new System.Windows.Forms.Panel();
            this.bnlDeleteColumn = new System.Windows.Forms.Button();
            this.DeleteColumn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.AddColumnValue = new System.Windows.Forms.TextBox();
            this.Add_Column_Value = new System.Windows.Forms.Label();
            this.AddColumn = new System.Windows.Forms.TextBox();
            this.Add_Column_Name = new System.Windows.Forms.Label();
            this.pnlTable.SuspendLayout();
            this.menuStripTable.SuspendLayout();
            this.pnlTable2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).BeginInit();
            this.TableOperation.SuspendLayout();
            this.TableOperation2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTable
            // 
            this.pnlTable.Controls.Add(this.menuStripTable);
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTable.Location = new System.Drawing.Point(0, 0);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(873, 31);
            this.pnlTable.TabIndex = 0;
            // 
            // menuStripTable
            // 
            this.menuStripTable.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableEditorToolStripMenuItem});
            this.menuStripTable.Location = new System.Drawing.Point(0, 0);
            this.menuStripTable.Name = "menuStripTable";
            this.menuStripTable.Size = new System.Drawing.Size(873, 28);
            this.menuStripTable.TabIndex = 0;
            this.menuStripTable.Text = "menuStrip1";
            // 
            // tableEditorToolStripMenuItem
            // 
            this.tableEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAColumnInTheAttributeTableToolStripMenuItem,
            this.deleteAColumnInTheAttributeTableToolStripMenuItem,
            this.updateAttributeTableInShapefileToolStripMenuItem,
            this.exportToExcelToolStripMenuItem});
            this.tableEditorToolStripMenuItem.Name = "tableEditorToolStripMenuItem";
            this.tableEditorToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.tableEditorToolStripMenuItem.Text = "Table Editor";
            // 
            // addAColumnInTheAttributeTableToolStripMenuItem
            // 
            this.addAColumnInTheAttributeTableToolStripMenuItem.Name = "addAColumnInTheAttributeTableToolStripMenuItem";
            this.addAColumnInTheAttributeTableToolStripMenuItem.Size = new System.Drawing.Size(364, 26);
            this.addAColumnInTheAttributeTableToolStripMenuItem.Text = "Add a column in the attribute table";
            this.addAColumnInTheAttributeTableToolStripMenuItem.Click += new System.EventHandler(this.addAColumnInTheAttributeTableToolStripMenuItem_Click);
            // 
            // deleteAColumnInTheAttributeTableToolStripMenuItem
            // 
            this.deleteAColumnInTheAttributeTableToolStripMenuItem.Name = "deleteAColumnInTheAttributeTableToolStripMenuItem";
            this.deleteAColumnInTheAttributeTableToolStripMenuItem.Size = new System.Drawing.Size(364, 26);
            this.deleteAColumnInTheAttributeTableToolStripMenuItem.Text = "Delete a column in the attribute table";
            this.deleteAColumnInTheAttributeTableToolStripMenuItem.Click += new System.EventHandler(this.deleteAColumnInTheAttributeTableToolStripMenuItem_Click);
            // 
            // updateAttributeTableInShapefileToolStripMenuItem
            // 
            this.updateAttributeTableInShapefileToolStripMenuItem.Name = "updateAttributeTableInShapefileToolStripMenuItem";
            this.updateAttributeTableInShapefileToolStripMenuItem.Size = new System.Drawing.Size(364, 26);
            this.updateAttributeTableInShapefileToolStripMenuItem.Text = "Update attribute table in Shapefile";
            this.updateAttributeTableInShapefileToolStripMenuItem.Click += new System.EventHandler(this.updateAttributeTableInShapefileToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(364, 26);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // pnlTable2
            // 
            this.pnlTable2.Controls.Add(this.dgvAttributeTable);
            this.pnlTable2.Location = new System.Drawing.Point(155, 31);
            this.pnlTable2.Name = "pnlTable2";
            this.pnlTable2.Size = new System.Drawing.Size(718, 302);
            this.pnlTable2.TabIndex = 1;
            // 
            // dgvAttributeTable
            // 
            this.dgvAttributeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvAttributeTable.Location = new System.Drawing.Point(51, 0);
            this.dgvAttributeTable.Name = "dgvAttributeTable";
            this.dgvAttributeTable.RowHeadersWidth = 51;
            this.dgvAttributeTable.RowTemplate.Height = 27;
            this.dgvAttributeTable.Size = new System.Drawing.Size(667, 302);
            this.dgvAttributeTable.TabIndex = 0;
            // 
            // TableOperation
            // 
            this.TableOperation.Controls.Add(this.TableOperation2);
            this.TableOperation.Controls.Add(this.btnAddColumn);
            this.TableOperation.Controls.Add(this.AddColumnValue);
            this.TableOperation.Controls.Add(this.Add_Column_Value);
            this.TableOperation.Controls.Add(this.AddColumn);
            this.TableOperation.Controls.Add(this.Add_Column_Name);
            this.TableOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.TableOperation.Location = new System.Drawing.Point(0, 31);
            this.TableOperation.Name = "TableOperation";
            this.TableOperation.Size = new System.Drawing.Size(200, 302);
            this.TableOperation.TabIndex = 2;
            this.TableOperation.Visible = false;
            // 
            // TableOperation2
            // 
            this.TableOperation2.Controls.Add(this.bnlDeleteColumn);
            this.TableOperation2.Controls.Add(this.DeleteColumn);
            this.TableOperation2.Controls.Add(this.label1);
            this.TableOperation2.Location = new System.Drawing.Point(3, 3);
            this.TableOperation2.Name = "TableOperation2";
            this.TableOperation2.Size = new System.Drawing.Size(194, 296);
            this.TableOperation2.TabIndex = 5;
            this.TableOperation2.Visible = false;
            // 
            // bnlDeleteColumn
            // 
            this.bnlDeleteColumn.Location = new System.Drawing.Point(17, 102);
            this.bnlDeleteColumn.Name = "bnlDeleteColumn";
            this.bnlDeleteColumn.Size = new System.Drawing.Size(84, 30);
            this.bnlDeleteColumn.TabIndex = 6;
            this.bnlDeleteColumn.Text = "Delete";
            this.bnlDeleteColumn.UseVisualStyleBackColor = true;
            this.bnlDeleteColumn.Click += new System.EventHandler(this.bnlDeleteColumn_Click);
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.Location = new System.Drawing.Point(17, 48);
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Size = new System.Drawing.Size(161, 25);
            this.DeleteColumn.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delete Column Name";
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Location = new System.Drawing.Point(12, 185);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(84, 30);
            this.btnAddColumn.TabIndex = 4;
            this.btnAddColumn.Text = "Add";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // AddColumnValue
            // 
            this.AddColumnValue.Location = new System.Drawing.Point(12, 134);
            this.AddColumnValue.Name = "AddColumnValue";
            this.AddColumnValue.Size = new System.Drawing.Size(161, 25);
            this.AddColumnValue.TabIndex = 3;
            // 
            // Add_Column_Value
            // 
            this.Add_Column_Value.AutoSize = true;
            this.Add_Column_Value.Location = new System.Drawing.Point(12, 105);
            this.Add_Column_Value.Name = "Add_Column_Value";
            this.Add_Column_Value.Size = new System.Drawing.Size(135, 15);
            this.Add_Column_Value.TabIndex = 2;
            this.Add_Column_Value.Text = "Add Column Value";
            // 
            // AddColumn
            // 
            this.AddColumn.Location = new System.Drawing.Point(12, 51);
            this.AddColumn.Name = "AddColumn";
            this.AddColumn.Size = new System.Drawing.Size(161, 25);
            this.AddColumn.TabIndex = 1;
            // 
            // Add_Column_Name
            // 
            this.Add_Column_Name.AutoSize = true;
            this.Add_Column_Name.Location = new System.Drawing.Point(12, 23);
            this.Add_Column_Name.Name = "Add_Column_Name";
            this.Add_Column_Name.Size = new System.Drawing.Size(127, 15);
            this.Add_Column_Name.TabIndex = 0;
            this.Add_Column_Name.Text = "Add Column Name";
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 333);
            this.Controls.Add(this.TableOperation);
            this.Controls.Add(this.pnlTable2);
            this.Controls.Add(this.pnlTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStripTable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Table";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table";
            this.pnlTable.ResumeLayout(false);
            this.pnlTable.PerformLayout();
            this.menuStripTable.ResumeLayout(false);
            this.menuStripTable.PerformLayout();
            this.pnlTable2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).EndInit();
            this.TableOperation.ResumeLayout(false);
            this.TableOperation.PerformLayout();
            this.TableOperation2.ResumeLayout(false);
            this.TableOperation2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.MenuStrip menuStripTable;
        private System.Windows.Forms.Panel pnlTable2;
        private System.Windows.Forms.ToolStripMenuItem tableEditorToolStripMenuItem;
        public System.Windows.Forms.DataGridView dgvAttributeTable;
        private System.Windows.Forms.ToolStripMenuItem addAColumnInTheAttributeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAColumnInTheAttributeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAttributeTableInShapefileToolStripMenuItem;
        private System.Windows.Forms.Panel TableOperation;
        private System.Windows.Forms.Label Add_Column_Name;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.Label Add_Column_Value;
        private System.Windows.Forms.Panel TableOperation2;
        private System.Windows.Forms.Button bnlDeleteColumn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox AddColumn;
        public System.Windows.Forms.TextBox AddColumnValue;
        public System.Windows.Forms.TextBox DeleteColumn;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
    }
}