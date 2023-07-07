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
using DotSpatial.Topology;
using DotSpatial.Symbology;
using Microsoft.CSharp;
using DotSpatial.Projections;
using DotSpatial.Data.Rasters.GdalExtension;

namespace DotSpatial_期中综合
{
    public partial class Form1 : Form
    {
        // 初始化
        public Form1()
        {
            InitializeComponent();
            InitMapControl();
            //appManager1.LoadExtensions();
        }

        string shapeType;

        private void InitMapControl()
        {
            map1.Projection = KnownCoordinateSystems.Projected.Asia.AsiaLambertConformalConic;
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.AddLayer();
            //appManager1.LoadExtensions();
            if (map1.Layers.GetType().ToString() == "MapPolygonLayer")
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)map1.Layers[0];
                map1.Projection = stateLayer.Projection;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.ClearLayers();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DotSpatial.Controls.LayoutForm frm = new DotSpatial.Controls.LayoutForm();
            frm.MapControl = map1;
            frm.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.SaveLayer();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Confirm with users that  they are ready to close application or not with the help of message box.
            if (MessageBox.Show("Do you want to close this application?", "Admin", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Close() method is used to close the application.
                this.Close();
            }
        }

        #region Point ShapeFile class level variable

        //the new point feature set
        FeatureSet pointF = new FeatureSet(FeatureType.Point);

        //the id of point
        int pointID = 0;

        //to differentiate the right and left mouse click
        bool pointmouseClick = false;


        #endregion

        private void createPointShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change the cursor style
            map1.Cursor = Cursors.Cross;

            //set the shape type to the classlevel string variable
            //we are going to use this variable in select case statement

            shapeType = "Point";

            //set projection
            pointF.Projection = map1.Projection;

            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("PointID");

            pointF.DataTable.Columns.Add(column);

            //add the featureSet as map layer
            MapPointLayer pointLayer = (MapPointLayer)map1.Layers.Add(pointF);

            //Create a new symbolizer
            PointSymbolizer symbol = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 3);

            //Set the symbolizer to the point layer
            pointLayer.Symbolizer = symbol;

            //Set the legentText as point
            pointLayer.LegendText = "point";

            //Set left mouse click as true
            pointmouseClick = true;
        }

        #region Polyline  ShapeFile class level variables

        MapLineLayer lineLayer = default(MapLineLayer);

        //the line feature set
        FeatureSet lineF = new FeatureSet(FeatureType.Line);

        int lineID = 0;

        //boolean variable for first time mouse click
        bool firstClick = false;

        //It controls the drawing the polyline after the polyline saved operation.
        bool linemouseClick = false;



        #endregion

        private void createPolylineShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Change the mouse cursor
            map1.Cursor = Cursors.Cross;

            //set shape type
            shapeType = "line";

            //set projection
            lineF.Projection = map1.Projection;

            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("LineID");

            if (!lineF.DataTable.Columns.Contains("LineID"))
            {
                lineF.DataTable.Columns.Add(column);
            }

            //add the featureSet as map layer
            lineLayer = (MapLineLayer)map1.Layers.Add(lineF);

            //Set the symbolizer to the line feature. 
            LineSymbolizer symbol = new LineSymbolizer(Color.Blue, 2);
            lineLayer.Symbolizer = symbol;
            lineLayer.LegendText = "line";

            firstClick = true;

            linemouseClick = true;
        }

        #region Polygon ShapeFile class level variables

        FeatureSet polygonF = new FeatureSet(FeatureType.Polygon);

        int polygonID = 0;

        bool polygonmouseClick = false;

        #endregion

        private void createPolygonShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //initialize polyline feature set
            map1.Cursor = Cursors.Cross;

            //set shape type
            shapeType = "polygon";

            //set projection
            polygonF.Projection = map1.Projection;

            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("PolygonID");

            if (!polygonF.DataTable.Columns.Contains("PolygonID"))
            {
                polygonF.DataTable.Columns.Add(column);
            }

            //add the featureSet as map layer
            MapPolygonLayer polygonLayer = (MapPolygonLayer)map1.Layers.Add(polygonF);

            PolygonSymbolizer symbol = new PolygonSymbolizer(Color.Green);

            polygonLayer.Symbolizer = symbol;
            polygonLayer.LegendText = "polygon";

            firstClick = true;

            polygonmouseClick = true;
        }

        private void savePointShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pointF.SaveAs("data\\point.shp", true);
            MessageBox.Show("The point shapefile has been saved.");
            map1.Cursor = Cursors.Arrow;
        }

        private void savePolylineShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineF.SaveAs("data\\line.shp", true);
            MessageBox.Show("The line shapefile has been saved.");
            map1.Cursor = Cursors.Arrow;
            linemouseClick = false;
        }

        private void savePolygonShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygonF.SaveAs("data\\polygon.shp", true);
            MessageBox.Show("The polygon shapefile has been saved.");
            map1.Cursor = Cursors.Arrow;
            polygonmouseClick = false;
        }

        public class PathPoint
        {
            public double X;
            public double Y;
            public double Distance;
            public double Elevation;
        }

        // 打开属性表
        private void openTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table _dlg = new Table();
            _dlg.Dock = DockStyle.Fill;
            _dlg.Show();

            //Declare a datatable
            System.Data.DataTable dt = null;

            _dlg.Addcolumn += new Add(FAddcolumn);
            _dlg.Deletecolumn += new Add(FDeleteColumn);
            _dlg.UpdateData += new Add(UpDate);
            _dlg.ExportExcel += new Add(Export);


            if (map1.Layers.Count > 0)
            {

                if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
                {
                    MessageBox.Show("Need Polygon Data!");
                }

                if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
                {
                    MapPolygonLayer stateLayer = default(MapPolygonLayer);


                    stateLayer = (MapPolygonLayer)map1.Layers[0];

                    if (stateLayer == null)
                    {
                        MessageBox.Show("The layer is not a polygon layer.");
                    }
                    else
                    {
                        //Get the shapefile's attribute table to our datatable dt
                        dt = stateLayer.DataSet.DataTable;

                        //Set the datagridview datasource from datatable dt
                        _dlg.dgvAttributeTable.DataSource = dt;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        //属性表增加列
        DataTable FAddcolumn()
        {
            //Declare a datatable
            System.Data.DataTable dt = null;

            //check the layers
            if (map1.Layers.Count > 0)
            {
                //Declare a mappolygon layer
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                //Assign the mappolygon layer from the map
                stateLayer = (MapPolygonLayer)map1.Layers[0];

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                    return null;
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;

                    //Add new column

                    DataColumn column = new DataColumn(Values.strAddColumnName);
                    dt.Columns.Add(column);

                    //calculate values
                    foreach (DataRow row in dt.Rows)
                    {
                        string Function = Values.strAddColumnFunction;
                        if (Function.Contains("/"))
                        {
                            string[] strs = Function.Split('/');
                            double A = Convert.ToDouble(row[strs[0]]);
                            double B = Convert.ToDouble(row[strs[1]]);
                            double malesPercentage = A / B;
                            row[Values.strAddColumnName] = malesPercentage;
                        }
                        if (Function.Contains("+"))
                        {
                            string[] strs = Function.Split('+');
                            double A = Convert.ToDouble(row[strs[0]]);
                            double B = Convert.ToDouble(row[strs[1]]);
                            double malesPercentage = A + B;
                            row[Values.strAddColumnName] = malesPercentage;
                        }
                        if (Function.Contains("-"))
                        {
                            string[] strs = Function.Split('-');
                            double A = Convert.ToDouble(row[strs[0]]);
                            double B = Convert.ToDouble(row[strs[1]]);
                            double malesPercentage = A - B;
                            row[Values.strAddColumnName] = malesPercentage;
                        }
                        if (Function.Contains("*"))
                        {
                            string[] strs = Function.Split('*');
                            double A = Convert.ToDouble(row[strs[0]]);
                            double B = Convert.ToDouble(row[strs[1]]);
                            double malesPercentage = A * B;
                            row[Values.strAddColumnName] = malesPercentage;
                        }
                    }
                    //Set the datagridview datasource from datatable dt
                    return dt;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
                return null;
            }
        }

        //属性表删除列；
        DataTable FDeleteColumn()
        {
            string removestr = Values.strDeleteColumnName;

            //Declare a datatable
            System.Data.DataTable dt = null;

            if (map1.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)map1.Layers[0];

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                    return dt;
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;

                    //Remove a column
                    dt.Columns.Remove(removestr);

                    //Set the datagridview datasource from datatable dt
                    //dgvAttributeTable.DataSource = dt;
                    return dt;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
                return dt;
            }
        }

        //更新属性表
        DataTable UpDate()
        {
            if (map1.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)map1.Layers[0];
                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                    return null;
                }
                else
                {
                    stateLayer.DataSet.Save();
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
                return null;
            }
        }

        //导出属性表
        DataTable Export()
        {
            //Declare a datatable
            System.Data.DataTable dt = null;

            if (map1.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)map1.Layers[0];
                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                    return null;
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;

                    //Call the sub ExportToExcel 
                    //This sub procedure expects a datatable as an input
                    Methods.ExportToExcel(dt);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
                return null;
            }
        }

        private void SelecttoolStripButton_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Select;
        }

        private void PantoolStripButton_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Pan;
        }

        private void ZoomOuttoolStripButton_Click(object sender, EventArgs e)
        {
            map1.ZoomOut();
        }

        private void ZoomIntoolStripButton_Click(object sender, EventArgs e)
        {
            map1.ZoomIn();
        }

        private void ZoomToMaxExtenttoolStripButton_Click(object sender, EventArgs e)
        {
            map1.ZoomToMaxExtent();
        }

        //山体阴影
        private void HillshadetoolStripLabe_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count > 0)
            {
                //typecast the first layer to IMapRasterLayer
                if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
                {
                    MessageBox.Show("Need Raster Data!");
                }

                if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
                {
                    IMapRasterLayer layer = (IMapRasterLayer)map1.Layers[0];

                    if (layer == null)
                    {
                        MessageBox.Show("Please select a raster layer.");
                        return;
                    }

                    //set the hillshade properties
                    layer.Symbolizer.ShadedRelief.ElevationFactor = 1;
                    layer.Symbolizer.ShadedRelief.IsUsed = true;

                    //refresh the layer display in the map
                    layer.WriteBitmap();
                }
                
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        //栅格改色
        private void ChangecolortoolStripLabe_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count > 0)
            {
                //typecast the first layer to MapRasterLayer
                if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
                {
                    MessageBox.Show("Need Raster Data!");
                }

                if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
                {
                    IMapRasterLayer layer = (IMapRasterLayer)map1.Layers[0];

                    if (layer == null)
                    {
                        MessageBox.Show("Please add a raster layer.");
                        return;
                    }

                    //set the color scheme
                    //create an instance for a colorscheme
                    ColorScheme scheme = new ColorScheme();

                    //create a new category
                    ColorCategory category1 = new ColorCategory(0, 282, Color.Red, Color.Yellow);

                    category1.LegendText = "Elevation 0 - 100";

                    //add the category to the color scheme
                    scheme.AddCategory(category1);

                    //create another category
                    ColorCategory category2 = new ColorCategory(100, 300, Color.Blue, Color.Green);
                    category2.LegendText = "Elevation 100 - 300";
                    scheme.AddCategory(category2);

                    //assign new color scheme
                    layer.Symbolizer.Scheme = scheme;

                    //refresh the layer display in the map
                    layer.WriteBitmap();
                }
                else
                {
                    MessageBox.Show("Please add a layer to the map.");
                }
            }

                
        }

        // 复制栅格
        private void RunMultiplyRaster_Click(object sender, EventArgs e)
        {
            string Function = MultiplyTextBox.Text;

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MessageBox.Show("Need Raster Data!");
            }
            //check the number of layers on the map
            if (map1.Layers.Count > 0 && map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                //typecast the first layer to MapRasterLayer
                IMapRasterLayer layer = (IMapRasterLayer)map1.Layers[0];

                if (layer == null)
                {
                    MessageBox.Show("Please select a raster layer.");
                    return;
                }

                //get the raster dataset
                IRaster demRaster = layer.DataSet;

                //create a new raster with the same dimensions as the original raster

                //rasterOptions is only used by special raster formats. For most rasters it should be array of empty string
                string[] rasterOptions = new string[1];

                //Create a raster layer
                IRaster newRaster = Raster.CreateRaster("multiply.bgd", null, demRaster.NumColumns, demRaster.NumRows, 1, demRaster.DataType, rasterOptions);

                //Bounds specify the cellsize and the coordinates of raster corner
                newRaster.Bounds = demRaster.Bounds.Copy();
                newRaster.NoDataValue = demRaster.NoDataValue;
                newRaster.Projection = demRaster.Projection;

                //multiplication
                for (int i = 0; i <= demRaster.NumRows - 1; i++)
                {
                    for (int j = 0; j <= demRaster.NumColumns - 1; j++)
                    {
                        if (demRaster.Value[i, j] != demRaster.NoDataValue)
                        {
                            newRaster.Value[i, j] = demRaster.Value[i, j] * Convert.ToDouble(Function);

                        }
                    }
                }

                //save the new raster to the file
                newRaster.Save();

                //add the new raster to the map
                map1.Layers.Add(newRaster);
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        //栅格重分类0-1
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MessageBox.Show("Need Raster Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                //typecast the selected layer to IMapRasterLayer
                IMapRasterLayer layer = (IMapRasterLayer)map1.Layers.SelectedLayer;

                if (layer == null)
                {
                    MessageBox.Show("Please select a raster layer.");
                }
                else
                {
                    //get the raster dataset
                    IRaster demRaster = layer.DataSet;

                    //create a new empty raster with same dimension as original raster
                    string[] rasterOptions = new string[1];

                    IRaster newRaster = Raster.CreateRaster("reclassify.bgd", null, demRaster.NumColumns, demRaster.NumRows, 1, demRaster.DataType, rasterOptions);
                    newRaster.Bounds = demRaster.Bounds.Copy();
                    newRaster.NoDataValue = demRaster.NoDataValue;
                    newRaster.Projection = demRaster.Projection;

                    //reclassify raster.
                    //values >= specified value will have new value 1
                    //values < specified value will have new value 0

                    double oldValue = 0;

                    //get the specified value from the textbox
                    double specifiedValue = Convert.ToDouble(toolStripTextBox2.Text);

                    for (int i = 0; i <= demRaster.NumRows - 1; i++)
                    {
                        for (int j = 0; j <= demRaster.NumColumns - 1; j++)
                        {
                            //get the value of original raster
                            oldValue = demRaster.Value[i, j];

                            if (oldValue >= specifiedValue)
                            {
                                newRaster.Value[i, j] = 1;
                            }
                            else
                            {
                                newRaster.Value[i, j] = 0;
                            }
                        }
                    }

                    newRaster.Save();

                    map1.Layers.Add(newRaster);
                }
            }
        }

        int Raster_Value = 0;

        //定位栅格值
        private void RasterValue_Click(object sender, EventArgs e)
        {

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MessageBox.Show("Need Raster Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                Raster_Value++;

                if (Raster_Value % 2 == 1)
                {
                    IMapRasterLayer rasterLayer = (IMapRasterLayer)map1.Layers.SelectedLayer;

                    if ((rasterLayer != null))
                    {
                        //set the map cursor to cross
                        map1.Cursor = Cursors.Cross;
                    }
                    else
                    {
                        //if no raster layer is selected, uncheck the checkbox
                        MessageBox.Show("Please select a raster layer.");
                        Raster_Value = 0;
                    }
                }
                else if (Raster_Value % 2 == 0)
                {
                    //change map cursor back to arrow
                    map1.Cursor = Cursors.Arrow;
                    Methods.setVisible(toolStripStatusLabel3, false);
                }
            }        
        }

        // 判断是否为投影坐标系（全局）
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (!map1.Projection.ToEsriString().Contains("PROJECTION"))
            {
                MessageBox.Show("Please switch the projection coordinates!");
            }
            else
            {
                Methods.setVisible(toolStripStatusLabel4, true);
                toolStripStatusLabel4.Text = "Total area: " + Methods._getTotalArea(map1).ToString() + " m^2";
            }
        }
 
        private void FillUniqueValues(string uniqueField, DotSpatial.Controls.Map mapInput)
        {
            List<string> fieldList = new List<string>();
            if ((mapInput.Layers.Count > 0))
            {
                MapPolygonLayer currentLayer = default(MapPolygonLayer);
                currentLayer = (MapPolygonLayer)mapInput.Layers[0];
                if ((currentLayer == null))
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    DataTable dt = currentLayer.DataSet.DataTable;
                    SelectedComboBox2.Items.Clear();

                    foreach (DataRow rows in dt.Rows)
                    {
                        SelectedComboBox2.Items.Add(rows[uniqueField]);
                    }
                }
            }
        }
        
        private void NameComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUniqueValues(NameComboBox1.Text, map1);
        }

        private void SelectedareatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Methods.setVisible(toolStripStatusLabel5,true);
            toolStripStatusLabel5.Text = "Selected region area: " + Methods._getArea(NameComboBox1.Text, SelectedComboBox2.Text, map1).ToString() + " m^2";
        }

        private void attributeChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                Chart chart = new Chart();
                chart.Show();
                System.Data.DataTable dt = null;
                if (map1.Layers.Count > 0)
                {
                    MapPolygonLayer stateLayer = default(MapPolygonLayer);

                    stateLayer = (MapPolygonLayer)map1.Layers[0];

                    if (stateLayer == null)
                    {
                        MessageBox.Show("The layer is not a polygon layer.");
                    }
                    else
                    {
                        //Get the shapefile's attribute table to our datatable dt
                        dt = stateLayer.DataSet.DataTable;
                        Values.values_dt = dt.Copy();
                        foreach (DataColumn col in Values.values_dt.Columns)
                        {
                            chart.comboBox2.Items.AddRange(new object[] { col.ColumnName.ToString() });
                            chart.comboBox1.Items.AddRange(new object[] { col.ColumnName.ToString() });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please add a layer to the map.");
                }
            }          
        }
        
        // 填充下拉栏集合
        private void SymbolSystem_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)map1.Layers[0];

                System.Data.DataTable dt = null;

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;
                }

                foreach (DataColumn col in dt.Columns)
                {
                    //this.toolStripComboBox1.Items.AddRange(new object[] { col.ColumnName.ToString() });
                    this.toolStripComboBox2.Items.AddRange(new object[] { col.ColumnName.ToString() });
                }
            }
            
        }

        //矢量分割
        private void showAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                if (map1.Layers.Count > 0)
                {
                    MapPolygonLayer stateLayer = default(MapPolygonLayer);

                    stateLayer = (MapPolygonLayer)map1.Layers[0];

                    if (stateLayer == null)
                    {
                        MessageBox.Show("The layer is not a polygon layer.");
                    }
                    else
                    {
                        //!!! this line is necessary otherwise the code doesn't work
                        //this will load the attribute table of the layer into memory.
                        stateLayer.DataSet.FillAttributes();

                        PolygonScheme scheme = new PolygonScheme();

                        PolygonCategory category = new PolygonCategory(Color.Red, Color.Black, 1);

                        string columnName = this.toolStripComboBox2.Text.ToString();

                        string filter = string.Format($"[{columnName}] > ") + this.toolStripTextBox1.Text + "";

                        category.FilterExpression = filter;

                        category.LegendText = $"{columnName} > " + this.toolStripTextBox1.Text;

                        scheme.AddCategory(category);

                        stateLayer.Symbology = scheme;
                    }
                }
                else
                {
                    MessageBox.Show("Please add a layer to the map.");
                }
            }
        }

        // 判断是否为投影坐标系（局部）
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (!map1.Projection.ToEsriString().Contains("PROJECTION"))
            {
                MessageBox.Show("Please switch the projection coordinates!");
            }
            else
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)map1.Layers[0];

                System.Data.DataTable dt = null;

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;
                }

                foreach (DataColumn col in dt.Columns)
                {
                    this.NameComboBox1.Items.AddRange(new object[] { col.ColumnName.ToString() });
                    this.SelectedComboBox2.Items.AddRange(new object[] { col.ColumnName.ToString() });
                }
            }
        }

        bool PathFinished =true;

        //展示剖面
        private void ProfiletoolStripButton8_Click(object sender, EventArgs e)
        {

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MessageBox.Show("Need Raster Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                foreach (IMapLineLayer existingPath in map1.GetLineLayers())
                {
                    map1.Layers.Remove(existingPath);
                }
                lineF = new FeatureSet(FeatureType.Line);

                //ski path is not finished
                PathFinished = false;

                //initialize polyline feature set
                map1.Cursor = Cursors.Cross;

                //set projection
                lineF.Projection = map1.Projection;

                //initialize the featureSet attribute table
                DataColumn column = new DataColumn("ID");
                lineF.DataTable.Columns.Add(column);

                //add the featureSet as map layer
                lineLayer = (MapLineLayer)map1.Layers.Add(lineF);
                LineSymbolizer symbol = new LineSymbolizer(Color.Blue, 2);
                lineLayer.Symbolizer = symbol;
                lineLayer.LegendText = "Profile Chart";
                firstClick = true;
            }           
        }
        
        // 展示属性名
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)map1.Layers[0];

                System.Data.DataTable dt = null;

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;
                    foreach (DataColumn col in dt.Columns)
                    {
                        //this.toolStripComboBox1.Items.AddRange(new object[] { col.ColumnName.ToString() });
                        this.toolStripComboBox1.Items.AddRange(new object[] { col.ColumnName.ToString() });
                    }

                    //dsp.Displaypnl1.Controls.Add(fontDialog1);
                }             
            }         
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)map1.Layers[0];

                System.Data.DataTable dt = null;

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;
                }

                foreach (DataColumn col in dt.Columns)
                {
                    this.toolStripComboBox3.Items.AddRange(new object[] { col.ColumnName.ToString() });
                }
            }          
        }

        private void btnRamdonColor_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                //check the number of layers from map control
                if (map1.Layers.Count > 0)
                {
                    //Delacre a MapPolygonLayer
                    MapPolygonLayer stateLayer = default(MapPolygonLayer);

                    //Type cast the FirstLayer of MapControl to MapPolygonLayer
                    stateLayer = (MapPolygonLayer)map1.Layers[0];

                    //Check the MapPolygonLayer ( Make sure that it has a polygon layer)
                    if (stateLayer == null)
                    {
                        MessageBox.Show("The layer is not a polygon layer.");
                    }
                    else
                    {
                        //Create a new PolygonScheme
                        PolygonScheme scheme = new PolygonScheme();

                        //Set the ClassificationType for the PolygonScheme via EditorSettings
                        scheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;

                        //Set the UniqueValue field name
                        //Here STATE_NAME would be the Unique value field
                        scheme.EditorSettings.FieldName = this.toolStripComboBox3.Text;

                        //create categories on the scheme based on the attributes table and field name
                        //In this case field name is STATE_NAME
                        scheme.CreateCategories(stateLayer.DataSet.DataTable);

                        //Set the scheme to stateLayer's symbology
                        stateLayer.Symbology = scheme;
                    }
                }
                else
                {
                    MessageBox.Show("Please add a layer to the map.");
                }
            }
        }

        // 默认字体
        string fname = "Tahoma";
        double fsize = 8.0;
        Color fcolor = Color.Black;
        bool Box_selection = false;
        private System.Drawing.Point startPoint;
        private Coordinate geoStartPoint;

        // 展示标记
        private void DisplayLabels(string attributename)
        {
            //Check the number of layers from MapControl
            if (map1.Layers.Count > 0)
            {
                map1.AddLabels((DotSpatial.Symbology.FeatureLayer)map1.Layers[0], "[" + attributename + "]", new Font("" + fname + "", (float)fsize), fcolor);
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void btnDisplayAttribute_Click(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                MessageBox.Show("Need Polygon Data!");
            }


            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                if ((toolStripComboBox1.Text == string.Empty))
                {
                    MessageBox.Show("Please select an attribute from the textbox");
                }
                else
                {
                    DisplayLabels(toolStripComboBox1.Text.ToString());
                }
            }
            
        }

        private void LocalviewtoolStripButton_Click(object sender, EventArgs e)
        {
            map1.FunctionMode =FunctionMode.None;
            Box_selection = true;
            map1.Cursor = Cursors.Cross;
        }

        private void FontchangetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fname = fontDialog1.Font.Name;
                fsize = fontDialog1.Font.Size;
            }
        }

        private void ColorchangetoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fcolor = colorDialog1.Color;
            }
        }

        private void DisplayCustomLabel(string attributeValue)
        {
            if (string.IsNullOrEmpty(txtCustomAttribute.Text))
            {
                MessageBox.Show("Please enter the label text");
                return;
            }

            IMapFeatureLayer selectedLayer = (IMapFeatureLayer)map1.Layers[0];
            if (selectedLayer == null)
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }

            int numSelectedFeatures = selectedLayer.Selection.Count;
            if (numSelectedFeatures == 0)
            {
                MessageBox.Show("Please select a shape in the map");
                return;
            }

            //create new column in attribute table
            DataTable table = selectedLayer.DataSet.DataTable;


            if (!(table.Columns.Contains("new_label")))
            {
                table.Columns.Add(new DataColumn("new_label"));
            }

            List<IFeature> selectedFeatureList = selectedLayer.Selection.ToFeatureList();
            IFeature selectedFeature = selectedFeatureList[0];

            selectedFeature.DataRow["new_label"] = txtCustomAttribute.Text;

            //display labels in the map
            map1.AddLabels(selectedLayer, "[new_label]", new Font("" + fname + "", (float)fsize), fcolor);

            //reset map selection mode
            map1.FunctionMode = FunctionMode.None;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayCustomLabel(txtCustomAttribute.Text);
            txtCustomAttribute.Text = "";
        }

        // 更改文本后选择要素
        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Select;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count > 0)
            {
                IMapFeatureLayer stateLayer = default(IMapFeatureLayer);
                stateLayer = (IMapFeatureLayer)map1.Layers[0];
                stateLayer.DataSet.Save();
                MessageBox.Show("Attribute has been saved in the shapefile.");
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare a datatable
            DataTable dt = null;

            if (map1.Layers.Count > 0)
            {
                IMapFeatureLayer stateLayer = default(IMapFeatureLayer);
                stateLayer = (IMapFeatureLayer)map1.Layers[0];

                //Get the shapefile's attribute table to our datatable dt
                dt = stateLayer.DataSet.DataTable;

                //Remove a column
                dt.Columns.Remove("new_label");
                stateLayer.DataSet.Save();
                MessageBox.Show("Attribute has been removed in the shapefile.");
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        public IRaster demRaster;
        public static double maxdem =0;
        private void ReclassifytoolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MessageBox.Show("Need Raster Data!");
            }

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {

                //typecast the selected layer to IMapRasterLayer
                IMapRasterLayer layer = (IMapRasterLayer)map1.Layers.SelectedLayer;

                if (layer == null)
                {
                    MessageBox.Show("Please select a raster layer.");
                }
                else
                {
                    Display display = new Display();
                    display.Show();

                    //get the raster dataset
                    demRaster = layer.DataSet;
                    maxdem = demRaster.Maximum;

                }
            }
        }

        public void reclassify()
        {
            //create a new empty raster with same dimension as original raster
            string[] rasterOptions = new string[3];

            IRaster newRaster = Raster.CreateRaster("reclassify.bgd", null, demRaster.NumColumns, demRaster.NumRows, 3, demRaster.DataType, rasterOptions);
            newRaster.Bounds = demRaster.Bounds.Copy();
            newRaster.NoDataValue = demRaster.NoDataValue;
            newRaster.Projection = demRaster.Projection;

            //reclassify raster.
            double oldValue = 0;

            for (int i = 0; i <= demRaster.NumRows - 1; i++)
            {
                for (int j = 0; j <= demRaster.NumColumns - 1; j++)
                {
                    //get the value of original raster
                    oldValue = demRaster.Value[i, j];
                    for (int k = 0; k < Display.rc_data[0]; k++)
                    {
                        if (oldValue >= Display.rc_data[3 * k + 1] && oldValue < Display.rc_data[3 * k + 2])
                        {
                            newRaster.Value[i, j] = Display.rc_data[3 * k + 3];

                        }
                    }
                }
            }



            newRaster.Save();

            map1.Layers.Add(newRaster);

            IMapRasterLayer layer = (IMapRasterLayer)map1.Layers[0];
            //layer.Symbolizer.Scheme = scheme;

        }

        private void map1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Box_selection == true)
            {
                GeoMouseArgs args = new GeoMouseArgs(e, map1); //屏幕坐标到地图坐标转换
                startPoint = e.Location;//屏幕起始点坐标
                geoStartPoint = args.GeographicLocation;//地图起始点坐标
            }

            //在地图上绘制shape
            switch (shapeType)
            {
                case "Point":
                    if (e.Button == MouseButtons.Left)
                    {
                        if ((pointmouseClick))
                        {
                            //This method is used to convert the screen cordinate to map coordinate
                            //e.location is the mouse click point on the map control
                            Coordinate coord = map1.PixelToProj(e.Location);

                            //Create a new point
                            //Input parameter is clicked point coordinate
                            DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(coord);

                            //Add the point into the Point Feature
                            //assigning the point feature to IFeature because via it only we can set the attributes.
                            IFeature currentFeature = pointF.AddFeature(point);

                            //increase the point id
                            pointID = pointID + 1;

                            //set the ID attribute
                            currentFeature.DataRow["PointID"] = pointID;

                            //refresh the map
                            map1.ResetBuffer();
                        }
                    }

                    else
                    {
                        //mouse right click
                        map1.Cursor = Cursors.Default;
                        pointmouseClick = false;
                    }
                    break;
                case "line":
                    if (e.Button == MouseButtons.Left)
                    {
                        //left click - fill array of coordinates
                        //coordinate of clicked point
                        Coordinate coord = map1.PixelToProj(e.Location);
                        if (linemouseClick)
                        {
                            //first time left click - create empty line feature
                            if (firstClick)
                            {
                                //Create a new List called lineArray.                          
                                //This list will store the Coordinates
                                //We are going to store the mouse click coordinates into this array.
                                List<Coordinate> lineArray = new List<Coordinate>();

                                //Create an instance for LineString class.
                                //We need to pass collection of list coordinates
                                LineString lineGeometry = new LineString(lineArray);

                                //Add the linegeometry to line feature
                                IFeature lineFeature = lineF.AddFeature(lineGeometry);

                                //add first coordinate to the line feature
                                lineFeature.Coordinates.Add(coord);

                                //set the line feature attribute
                                lineID = lineID + 1;
                                lineFeature.DataRow["LineID"] = lineID;
                                firstClick = false;
                            }
                            else
                            {
                                //second or more clicks - add points to the existing feature
                                IFeature existingFeature = lineF.Features[lineF.Features.Count - 1];
                                existingFeature.Coordinates.Add(coord);

                                //refresh the map if line has 2 or more points
                                if (existingFeature.Coordinates.Count >= 2)
                                {
                                    lineF.InitializeVertices();
                                    map1.ResetBuffer();
                                }
                            }
                        }
                    }
                    else
                    {
                        //right click - reset first mouse click
                        firstClick = true;
                        map1.ResetBuffer();
                    }
                    break;
                case "polygon":

                    if (e.Button == MouseButtons.Left)
                    {
                        //left click - fill array of coordinates
                        Coordinate coord = map1.PixelToProj(e.Location);

                        if (polygonmouseClick)
                        {
                            //first time left click - create empty line feature
                            if (firstClick)
                            {
                                //Create a new List called polygonArray.

                                //this list will store the Coordinates
                                //We are going to store the mouse click coordinates into this array.

                                List<Coordinate> polygonArray = new List<Coordinate>();

                                //Create an instance for LinearRing class.
                                //We pass the polygon List to the constructor of this class
                                LinearRing polygonGeometry = new LinearRing(polygonArray);

                                //Add the polygonGeometry instance to PolygonFeature
                                IFeature polygonFeature = polygonF.AddFeature(polygonGeometry);

                                //add first coordinate to the polygon feature
                                polygonFeature.Coordinates.Add(coord);

                                //set the polygon feature attribute
                                polygonID = polygonID + 1;
                                polygonFeature.DataRow["PolygonID"] = polygonID;
                                firstClick = false;
                            }
                            else
                            {
                                //second or more clicks - add points to the existing feature
                                IFeature existingFeature = (IFeature)polygonF.Features[polygonF.Features.Count - 1];

                                existingFeature.Coordinates.Add(coord);

                                //refresh the map if line has 2 or more points
                                if (existingFeature.Coordinates.Count >= 3)
                                {
                                    //refresh the map
                                    polygonF.InitializeVertices();
                                    map1.ResetBuffer();
                                }
                            }
                        }
                    }
                    else
                    {
                        //right click - reset first mouse click
                        firstClick = true;
                    }
                    break;

            }

            // 绘制路径
            if (PathFinished == true)
                return;
            if (e.Button == MouseButtons.Left)
            {
                //left click - fill array of coordinates
                //coordinate of clicked point
                Coordinate coord = map1.PixelToProj(e.Location);
                //first time left click - create empty line feature
                if (firstClick)
                {
                    //Create a new List called lineArray.
                    //In List we need not define the size and also 
                    //Here this list will store the Coordinates
                    //We are going to store the mouse click coordinates into this array.
                    List<Coordinate> lineArray = new List<Coordinate>();

                    //Create an instance for LineString class.
                    //We need to pass collection of list coordinates
                    LineString lineGeometry = new LineString(lineArray);

                    //Add the linegeometry to line feature
                    IFeature lineFeature = lineF.AddFeature(lineGeometry);

                    //add first coordinate to the line feature
                    lineFeature.Coordinates.Add(coord);
                    //set the line feature attribute
                    lineID = lineID + 1;
                    lineFeature.DataRow["ID"] = lineID;
                    firstClick = false;
                }
                else
                {
                    //second or more clicks - add points to the existing feature
                    IFeature existingFeature = lineF.Features[lineF.Features.Count - 1];
                    existingFeature.Coordinates.Add(coord);

                    //refresh the map if line has 2 or more points
                    if (existingFeature.Coordinates.Count >= 2)
                    {
                        lineF.InitializeVertices();
                        map1.ResetBuffer();
                    }
                }
            }
            else
            {
                //right click - reset first mouse click
                firstClick = true;
                map1.ResetBuffer();
                string savepath = string.Format($"{Application.StartupPath}\\data\\sourcedata\\linepath.shp");

                lineF.SaveAs(savepath, true);
                MessageBox.Show("The line shapefile has been saved.");
                map1.Cursor = Cursors.Arrow;

                // 弹窗显示表格
                try
                {
                    //extract the complete elevation
                    //get the raster layer
                    IMapRasterLayer rasterLayer = default(IMapRasterLayer);

                    if (map1.GetRasterLayers().Count() == 0)
                    {
                        MessageBox.Show("Please add a raster layer");
                        return;
                    }

                    //use the first raster layer in the map
                    rasterLayer = map1.GetRasterLayers()[0];

                    //get the ski path line layer
                    IMapLineLayer pathLayer = default(IMapLineLayer);
                    if (map1.GetLineLayers().Count() == 0)
                    {
                        MessageBox.Show("Please add the ski path");
                        return;
                    }
                    pathLayer = map1.GetLineLayers()[0];

                    IFeatureSet featureSet = pathLayer.DataSet;
                    //get the coordinates of the ski path. this is the first feature of
                    //the feature set.
                    IList<Coordinate> coordinateList = featureSet.Features[0].Coordinates;

                    //get elevation of all segments of the path
                    List<PathPoint> fullPathList = new List<PathPoint>();

                    for (int i = 0; i < coordinateList.Count - 1; i++)
                    {
                        //for each line segment
                        Coordinate startCoord = coordinateList[i];
                        Coordinate endCoord = coordinateList[i + 1];
                        List<PathPoint> segmentPointList = Methods.ExtractElevation(startCoord.X, startCoord.Y, endCoord.X, endCoord.Y, rasterLayer);
                        //add list of points from this line segment to the complete list
                        fullPathList.AddRange(segmentPointList);
                    }

                    //calculate the distance
                    double distanceFromStart = 0;
                    for (int i = 1; i <= fullPathList.Count - 1; i++)
                    {
                        //distance between two neighbouring points
                        double x1 = fullPathList[i - 1].X;
                        double y1 = fullPathList[i - 1].Y;
                        double x2 = fullPathList[i].X;
                        double y2 = fullPathList[i].Y;
                        double distance12 = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
                        distanceFromStart += distance12;
                        fullPathList[i].Distance = distanceFromStart;
                    }

                    PathGraph graphForm = new PathGraph(fullPathList);
                    graphForm.Show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error calculating elevation. the whole path should be inside the DEM area");
                }


                //the ski path is finished
                PathFinished = true;
            }

        }

        private void map1_MouseMove(object sender, MouseEventArgs e)
        {
            // 将地图和坐标函数绑定
            GeoMouseArgs args = new GeoMouseArgs(e, map1);
            // 求x,y坐标
            string xpanel = String.Format("X:{0:0.00000}", args.GeographicLocation.X);
            string ypanel = String.Format("Y:{0:0.00000}", args.GeographicLocation.Y);
            this.toolStripStatusLabel2.Text = xpanel + "," + ypanel;
        }

        private void map1_MouseUp(object sender, MouseEventArgs e)
        {

            if (Box_selection == true)
            {
                map1.Cursor = Cursors.Default;
                GeoMouseArgs args = new GeoMouseArgs(e, map1);//屏幕坐标到地图坐标转换
                IEnvelope env = new Envelope(geoStartPoint.X, args.GeographicLocation.X,
                geoStartPoint.Y, args.GeographicLocation.Y);//在地图坐标系中定义二维矩形区域
                map1.ViewExtents = env.ToExtent();//将二维矩形区域作为地图可视区域
                Box_selection = false;
            }

            if (Raster_Value % 2 == 1)
            {
                // 显示栅格状态栏
                Methods.setVisible(toolStripStatusLabel3, true);

                //get the layer selected in the legend
                IMapRasterLayer rasterLayer = (IMapRasterLayer)map1.Layers.SelectedLayer;

                if ((rasterLayer != null))
                {
                    //get the raster data object
                    IRaster raster = rasterLayer.DataSet;

                    //convert mouse position to map coordinate
                    Coordinate coord = map1.PixelToProj(e.Location);

                    //convert map coordinate to raster row and column
                    RcIndex rc = raster.Bounds.ProjToCell(coord);

                    int row = rc.Row;

                    int column = rc.Column;

                    //check if clicked point is inside of raster
                    if ((column > 0 & column < raster.NumColumns & row > 0 & row < raster.NumRows))
                    {
                        //get the raster value at row and column
                        double value = raster.Value[row, column];

                        //show the row, column and value in the label
                        toolStripStatusLabel3.Text = string.Format("row: {0} column: {1} value: {2}", row, column, value);
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = "outside of raster";
                    }

                }
            }
        }

        //打开关于文档
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        //切换到土地利用算法

        private void LandUse_Click(object sender, EventArgs e)
        {
            Landuse ld = new Landuse();
            string[] LayerNameList = new string[map1.Layers.Count];
            List<MapRasterLayer> rasterlist = new List<MapRasterLayer>();

            for (int i=0;i<map1.Layers.Count();i++)
            {
                LayerNameList[i] = map1.Layers[i].LegendText;
                MapRasterLayer ly = (MapRasterLayer)map1.Layers[i];
                rasterlist.Add(ly);
            }

            //将图层储存到LandUse_GA中
            LandUse_GA.RasterList = rasterlist;

            //在下拉栏中添加图层名
            ld.comboBoxLayerRaster.Items.AddRange(LayerNameList);


            ld.Show();
        }

        //shp2raster
        private void Shapefile2Raster_Click_1(object sender, EventArgs e)
        {
            Shape2Raster sr = new Shape2Raster();
            string[] LayerNameList = new string[map1.Layers.Count];

            int i = 0;
            foreach (Layer ly in map1.Layers)
            {
                if (ly.GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
                {
                    LayerNameList[i] = ly.LegendText;
                    Shape2Raster_File.mapPolygonLayers.Add((MapPolygonLayer)ly);
                    i++;
                }
            }

            sr.comboBoxShpLayer.Items.AddRange(LayerNameList);

            sr.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            string Function = MultiplyTextBox.Text;

            if (map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapPolygonLayer")
            {
                MessageBox.Show("Need Raster Data!");
            }
            //check the number of layers on the map
            if (map1.Layers.Count > 0 && map1.Layers[0].GetType().ToString() == "DotSpatial.Controls.MapRasterLayer")
            {
                //typecast the first layer to MapRasterLayer
                IMapRasterLayer layer = (IMapRasterLayer)map1.Layers[0];

                
                if (layer == null)
                {
                    MessageBox.Show("Please select a raster layer.");
                    return;
                }

                //get the raster dataset
                IRaster demRaster = layer.DataSet;

                //create a new raster with the same dimensions as the original raster

                //rasterOptions is only used by special raster formats. For most rasters it should be array of empty string
                string[] rasterOptions = new string[1];

                //Create a raster layer
                IRaster newRaster = Raster.CreateRaster("multiply.bgd", null, 10, 10, 1, demRaster.DataType, rasterOptions);

                //Bounds specify the cellsize and the coordinates of raster corner
                //MessageBox.Show(demRaster.Projection.ToEsriString());
                newRaster.Bounds = demRaster.Bounds.Copy();
                newRaster.NoDataValue = demRaster.NoDataValue;
                newRaster.Projection = demRaster.Projection;

                //multiplication
                int[][] array = new int[10][] { new int[] { 2, 2, 2, 2, 2, 2, 2, 4, 3, 3 },
                    new int[] { 5, 2, 1, 1, 1, 2, 4, 3, 3, 3 }, new int[] { 6,6,1,1,1,4,2,5,5,5},
                new int[] {6,6,6,6,4,1,1,2,2,2}, new int[] {1,1,6,4,1,1,1,5,5,6},
                new int[] {1,1,4,1,1,4,1,5,5,1}, new int[] {2,4,1,1,1,4,4,2,3,1},
                new int[] {4,5,4,1,1,1,1,1,6,6}, new int[] {5,3,6,4,1,1,6,6,6,6},
                new int[] {5,5,6,4,6,6,6,6,2,2}};

                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        newRaster.Value[row,col] = array[row][col];
                    }
                }

                //save the new raster to the file
                newRaster.Save();

                

                //add the new raster to the map
                map1.Layers.Add(newRaster);
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            LandUse_GA.rasterAfter.Save();

            map1.Layers.Add(LandUse_GA.rasterAfter);

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            IMapRasterLayer layer = (IMapRasterLayer)map1.Layers.SelectedLayer;

            if (layer == null)
            {
                MessageBox.Show("Please select a raster layer.");
            }
            else
            {
                
                IRaster raster = (IRaster)layer;
                raster.CategoryColors();
            }


        }
    }
}
