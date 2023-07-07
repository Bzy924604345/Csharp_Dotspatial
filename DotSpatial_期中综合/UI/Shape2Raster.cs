using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Data;
using DotSpatial.Controls;
using DotSpatial.Analysis;

namespace DotSpatial_期中综合
{
    public partial class Shape2Raster : Form
    {
        public Shape2Raster()
        {
            InitializeComponent();
        }

        public static IFeatureSet MPL = null;

        //SHP2RASTER
        private void Run_Click(object sender, EventArgs e)
        {
            if(comboBoxShpLayer.Text=="")
            {
                return;
            }

            //象元大小以及输出的名称
            double cellsize = Convert.ToDouble(textBoxCellSize.Text);
            string RasterFileName = textBoxRasterName.Text;
            string FieldName = comboBoxFiledName.Text;

            //转化
            IRaster rasterout = VectorToRaster.ToRaster(MPL, cellsize, FieldName, RasterFileName);
            //IRaster rasterout = null;
            Shape2Raster_File.rasterout = rasterout;
            
        }

        private void GetFiledName_Click(object sender, EventArgs e)
        {
            //寻找需要的图层
            foreach (MapPolygonLayer mp in Shape2Raster_File.mapPolygonLayers)
            {
                if (mp.LegendText == comboBoxShpLayer.Text)
                {
                    MPL = mp.DataSet;
                }
            }

            //获取图层的属性
            foreach (DataColumn col in MPL.DataTable.Columns)
            {
                comboBoxFiledName.Items.AddRange(new object[] { col.ColumnName.ToString() });
            }
        }
    }
}
