using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Data;
using DotSpatial.Controls;

namespace DotSpatial_期中综合
{
    public class Shape2Raster_File
    {
        //输入的shp
        public static List<MapPolygonLayer> mapPolygonLayers = new List<MapPolygonLayer>();
        MapPolygonLayer MPL = null;

        //输出的dem
        public static IRaster rasterout = null;
    }
}
