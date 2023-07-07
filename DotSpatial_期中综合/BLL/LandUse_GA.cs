using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Data;
using DotSpatial.Controls;


namespace DotSpatial_期中综合
{
    public class LandUse_GA
    {
        ////储存图层
        public static List<MapRasterLayer> RasterList;

        //储存输出的栅格
        public static IRaster rasterBefore = null;
        public static IRaster rasterAfter = null;

        //
        public static string inn = null;
    }
}
