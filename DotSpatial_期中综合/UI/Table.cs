using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Controls;

namespace DotSpatial_期中综合
{
    public delegate DataTable Add();

    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
        }
        //委托
        public event Add Addcolumn;
        public event Add Deletecolumn;
        public event Add UpdateData;
        public event Add ExportExcel;

        Form1 form = new Form1();
        private void addAColumnInTheAttributeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TableOperation.Visible = true;
            
        }

        private void deleteAColumnInTheAttributeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TableOperation2.Visible = true;
            
        }

        private void updateAttributeTableInShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAttributeTable.DataSource = UpdateData();
        }


        private void btnAddColumn_Click(object sender, EventArgs e)
        {

            string AddColumnName = AddColumn.Text;
            string AddColumnFunction = AddColumnValue.Text;
            AddColumn.Clear();
            AddColumnValue.Clear();
            Values.strAddColumnName = AddColumnName;
            Values.strAddColumnFunction = AddColumnFunction;
            dgvAttributeTable.DataSource = Addcolumn();

        }

        private void bnlDeleteColumn_Click(object sender, EventArgs e)
        {
            string DeleteColumnName = DeleteColumn.Text;
            DeleteColumn.Clear();
            Values.strDeleteColumnName = DeleteColumnName;
            dgvAttributeTable.DataSource = Deletecolumn();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAttributeTable.DataSource = ExportExcel();
        }
    }
}
