using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DotSpatial.Data;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Symbology;
using Microsoft.CSharp;
using DotSpatial.Projections;

namespace DotSpatial_期中综合
{
    class Methods
    {
        [System.AttributeUsage(System.AttributeTargets.All,
        AllowMultiple = true)]

        public class Author : System.Attribute
        {
            string name;
            public double version;

            public Author(string name)
            {
                this.name = name;

                // Default value. 
                version = 1.0;
            }

            public string GetName()
            {
                return name;
            }
        }

        [Author("FTY"), Author("BZY", version = 2.0)]

        /// <summary>
        /// This function is used to get the elevation. 
        /// Based on the given line segment's start and endpoint, 100 points will be divided and based on the points        	elevation will be claculated.
        /// </summary>
        /// <param name="startX">Line segement's start X point</param>
        /// <param name="startY">Line segement's start Y point</param>
        /// <param name="endX">Line segement's end X point</param>
        /// <param name="endY">Line segement's end Y point</param>
        /// <param name="raster">Raster DEM</param>
        /// <returns>List of elevation</returns>
        /// <remarks></remarks>
        public static List<Form1.PathPoint> ExtractElevation(double startX, double startY, double endX, double endY, IMapRasterLayer raster)
        {
            double curX = startX;
            double curY = startY;
            double curElevation = 0;
            List<Form1.PathPoint> pathPointList = new List<Form1.PathPoint>();
            int numberofpoints = 100;
            double constXdif = ((endX - startX) / numberofpoints);
            double constYdif = ((endY - startY) / numberofpoints);
            for (int i = 0; i <= numberofpoints; i++)
            {
                Form1.PathPoint newPathPoint = new Form1.PathPoint();
                if ((i == 0))
                {
                    curX = startX;
                    curY = startY;
                }
                else
                {
                    curX = curX + constXdif;
                    curY = curY + constYdif;
                }
                Coordinate coordinate = new Coordinate(curX, curY);
                RcIndex rowColumn = raster.DataSet.Bounds.ProjToCell(coordinate);
                curElevation = raster.DataSet.Value[rowColumn.Row, rowColumn.Column];
                //set the properties of new PathPoint
                newPathPoint.X = curX;
                newPathPoint.Y = curY;
                newPathPoint.Elevation = curElevation;
                pathPointList.Add(newPathPoint);
            }
            return pathPointList;
        }

        [Author("FTY"), Author("BZY", version = 2.0)]
        // 导出为excel
        public static void ExportToExcel(System.Data.DataTable objDT)
        {
            //excel = new Excel.Application();
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();


            string strFilename = null;
            int intCol = 0;
            int intRow = 0;

            //path for storing excel datasheet
            string strPath = string.Format($"{Application.StartupPath}\\data\\");

            if (xlApp == null)
            {
                MessageBox.Show("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //var _with1 = Microsoft.Office.Interop.Excel.Application();
                xlApp.SheetsInNewWorkbook = 1;
                xlApp.Workbooks.Add();
                xlApp.Worksheets[1].Select();

                xlApp.Cells[1, 1].value = "Attribute table";

                //Heading of the excel file
                xlApp.Cells[1, 1].EntireRow.Font.Bold = true;

                //Add the column names from the attribute table to excel worksheet
                int intI = 1;
                for (intCol = 0; intCol <= objDT.Columns.Count - 1; intCol++)
                {
                    xlApp.Cells[2, intI].value = objDT.Columns[intCol].ColumnName;
                    xlApp.Cells[2, intI].EntireRow.Font.Bold = true;
                    intI += 1;
                }

                //Add the data row values from the attribute table to ecxel worksheet
                intI = 3;
                int intK = 1;
                for (intCol = 0; intCol <= objDT.Columns.Count - 1; intCol++)
                {
                    intI = 3;
                    for (intRow = 0; intRow <= objDT.Rows.Count - 1; intRow++)
                    {
                        xlApp.Cells[intI, intK].Value = objDT.Rows[intRow].ItemArray[intCol];
                        intI += 1;
                    }
                    intK += 1;
                }


                if (strPath.Substring(strPath.Length - 1, 1) != "\\")
                {
                    strPath = strPath + "\\";
                }

                strFilename = strPath + "AttributeTable.xls";

                xlApp.ActiveCell.Worksheet.SaveAs(strFilename);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                xlApp = null;
                MessageBox.Show("Data's are exported to Excel Succesfully in '" + strFilename + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // The excel is created and opened for insert value. We most close this excel using this system
            System.Diagnostics.Process[] pro = (System.Diagnostics.Process[])System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process i in pro)
            {
                i.Kill();
            }
        }

        [Author("BZY"), Author("FTY", version = 2.0)]
        /// <summary>
        /// This sub method is used to control the visibility of any label control
        /// </summary>
        /// <param name="lbl">label name</param>
        /// <param name="vis">Either True / False</param>
        /// <remarks></remarks>
        public static void setVisible(ToolStripStatusLabel lbl, bool vis)
        {
            lbl.Visible = vis;
        }

        [Author("BZY"), Author("FTY", version = 2.0)]
        /// <summary>
        /// This method is used to claculate total area of a feature
        /// </summary>
        /// <param name="mapInput">map control</param>
        /// <returns>total are of the feature from the mapcontrol</returns>
        /// <remarks></remarks>
        public static double _getTotalArea(DotSpatial.Controls.Map mapInput)
        {
            double stateArea = 0;
            if ((mapInput.Layers.Count > 0))
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)mapInput.Layers[0];
                if ((stateLayer == null))
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    foreach (IFeature stateFeature in stateLayer.DataSet.Features)
                    {
                        stateArea += stateFeature.Area();
                    }
                }
            }
            return stateArea;
        }

        [Author("BZY"), Author("FTY", version = 2.0)]
        /// <summary>
        /// This method is used to get the area of the selected region on the combobox
        /// </summary>
        /// <param name="uniqueColumnName">Field name</param>
        /// <param name="uniqueValue">Unique value from the selected region combobox</param>
        /// <param name="mapInput">map layer</param>
        /// <returns>area of the selected field</returns>
        /// <remarks></remarks>
        public static double _getArea(string uniqueColumnName, string uniqueValue, DotSpatial.Controls.Map mapInput)
        {
            double stateArea = 0;
            if ((mapInput.Layers.Count > 0))
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)mapInput.Layers[0];
                if ((stateLayer == null))
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    stateLayer.SelectByAttribute("[" + uniqueColumnName + "] =" + "'" + uniqueValue + "'");
                    foreach (IFeature stateFeature in stateLayer.DataSet.Features)
                    {
                        if (uniqueValue.CompareTo(stateFeature.DataRow[uniqueColumnName]) == 0)
                        {
                            stateArea = stateFeature.Area();
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
            }
            return stateArea;
        }





    }
}
