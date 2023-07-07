using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotSpatial_期中综合
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        //作为x轴的列名
        string X = "NAME";
        //作为y轴的列名
        string Y = "AXD";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            X = this.comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Y = this.comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> chart_dic = new Dictionary<string, double>();
            foreach (DataRow row in Values.values_dt.Rows)
            {
                chart_dic[row[X].ToString()] = Convert.ToDouble(row[Y]);
            }

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            string style = this.comboBox3.Text;
            if (style == "Pie")
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
            if (style == "Column")
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (style == "Spline")
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
            if (style == "Line")
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            if (style == "Point")
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
            chart1.Series[0].Points.Clear();

            chart1.Series[0].Name = Y;

            foreach (KeyValuePair<string, double> kvl in chart_dic)
            {
                chart1.Series[0].Points.AddXY(kvl.Key, kvl.Value);
            }
        }
    }
}
