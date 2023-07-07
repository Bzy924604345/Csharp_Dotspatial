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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading;


namespace DotSpatial_期中综合
{
    public partial class Landuse : Form
    {
        public Landuse()
        {
            InitializeComponent();
        }

        public static int RasterRow = 6;
        public static int RasterCol = 6;
        public static Random randomRound = new Random();
        

        //获取三个目标的结果值，输入参数字典,改造成本矩阵，和raster0(原来的栅格）,raster(变化后的栅格）
        public double GetResult(Dictionary<string, double> parameter_Dic, double[,] Cost, IRaster raster0, int[,] raster)
        {
            //结果字典
            Dictionary<string, double> Result_Dic = new Dictionary<string, double>();
            //各个地块数量字典
            Dictionary<int, int> DEM_Num_Dic = new Dictionary<int, int>();
            for (int i = 1; i <= 6; i++)
            {
                DEM_Num_Dic[i] = 0;
            }

            Result_Dic["GDP"] = 0;
            Result_Dic["Cost"] = 0;
            Result_Dic["Ecology"] = 0;

            //遍历，获取地块数量值，获取cost
            for (int row = 0; row < RasterRow; row++)
            {
                for (int col = 0; col < RasterCol; col++)
                {
                    //获取地块数量值
                    for (int i = 1; i <= 6; i++)
                    {
                        if (raster[row, col] == i)
                        {
                            DEM_Num_Dic[i]++;
                        }
                    }
                    //获取cost
                    double cost = Cost[Convert.ToInt32(raster0.Value[row, col]) - 1, Convert.ToInt32(raster[row, col]) - 1];
                    Result_Dic["Cost"] += cost;
                }
            }

            if (DEM_Num_Dic[1] > RasterRow * RasterCol / 2)
            {
                return 0;
            }

            for (int i = 1; i <= 6; i++)
            {
                Result_Dic["GDP"] += parameter_Dic[string.Format($"GDP{i}")] * DEM_Num_Dic[i];

                Result_Dic["Ecology"] += parameter_Dic[string.Format($"Ecology{i}")] * DEM_Num_Dic[i];
            }

            
            double gender = Result_Dic["GDP"] + Result_Dic["Ecology"] - 100*Result_Dic["Cost"];
            return gender;
        }

        //遗传算法

        ////1.轮盘赌选取分数最高的两个种子
        ///1.1轮盘赌
        public int nextDiscrete(double[] probs)
        {

            double sum = 0.0;
            for (int i = 0; i < probs.Length; i++)
                sum += probs[i];

            double r = randomRound.NextDouble() * sum;
            sum = 0.0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum > r)
                    return i;
            }
            return probs.Length - 1;
        }
        ///1.2利用轮盘赌
        public List<Dictionary<double, int[,]>> ChooseGene(int numround, List<int[,]> AllGene, Dictionary<string, double> parameter_Dic, double[,] Cost, IRaster raster0)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<Dictionary<double, int[,]>> Chosengender_Dic_List = new List<Dictionary<double, int[,]>>();

            double[] genderList = new double[AllGene.Count];

            int i = 0;
            foreach (int[,] gene in AllGene)
            {
                double gender = GetResult(parameter_Dic, Cost, raster0, gene);

                genderList[i] = gender;
                i++;
            }
            int genefirst =0;
            int genesecond = 0;

            for(int igene=0;igene<numround;igene++)
            {
                Dictionary<double, int[,]> Chosengender_Dic = new Dictionary<double, int[,]>();

                genefirst = nextDiscrete(genderList);
                genesecond = nextDiscrete(genderList);
                while (genesecond == genefirst)
                {
                    genesecond = nextDiscrete(genderList);
                }

                Chosengender_Dic[genderList[genefirst]] = AllGene[genefirst];
                Chosengender_Dic[genderList[genesecond]] = AllGene[genesecond];

                Chosengender_Dic_List.Add(Chosengender_Dic);
            }

            sw.Stop();

            return Chosengender_Dic_List;
        }


        ////2.初始化染色体
        public List<int[,]> InitialGene(int num)
        {
            List<int[,]> initialgeneList = new List<int[,]>();
            Random randomSeed = new Random();

            for (int i = 0; i < num; i++)
            {
                Random random = new Random(randomSeed.Next(1, 60));
                int[,] Gene = new int[RasterRow, RasterCol];
                for (int j = 0; j < RasterRow; j++)
                {
                    for (int k = 0; k < RasterCol; k++)
                    {
                        Gene[j, k] = random.Next(1, 7);
                    }
                }
                initialgeneList.Add(Gene);
            }

            return initialgeneList;
        }

        

        ////3.两个基因交叉、变异形成新的基因
        public Dictionary<double, int[,]> Heredity(Dictionary<double, int[,]> parent, Dictionary<string, double> parameter_Dic, double[,] Cost, IRaster raster0)
        {

            Dictionary<double, int[,]> children0 = new Dictionary<double, int[,]>();

            //父母最大的值
            double father = parent.First().Key;
            double monther = parent.Last().Key;
            double p = 0.0;
            int[,] child0 = null;

            if (father > monther)
            {
                p = father;
                child0 = (int[,])parent.First().Value.Clone();
            }
            else { p = monther; child0 = (int[,])parent.Last().Value.Clone(); }

            Random randomSeed = new Random();
            Random randomGene = new Random();

            int[,] child1 = (int[,])child0.Clone();

            //交叉
            if (true)
            {
                int times = 0;
                List<double> rowlist = new List<double>();
                List<double> collist = new List<double>();

                while (times < 10000)
                {
                    rowlist.Clear();
                    collist.Clear();
                    for (int j = 0; j <= RasterRow * RasterCol / 3; j++)
                    {
                        //生成需要交换的基因的地址
                        Random random1 = new Random();
                        rowlist.Add(random1.Next(0, RasterRow));
                        collist.Add(random1.Next(0, RasterCol));
                    }
                    foreach (int rowH in rowlist)
                    {
                        foreach (int colH in collist)
                        {
                            child1[rowH, colH] = parent.Last().Value[rowH, colH];
                        }
                    }

                    //变异
                    if (randomGene.NextDouble() < 0.35)
                    {
                        rowlist.Clear();
                        collist.Clear();

                        for (int j = 0; j <= RasterRow * RasterCol / 6; j++)
                        {
                            //生成需要变异的基因的地址
                            Random random1 = new Random();
                            rowlist.Add(random1.Next(0, RasterRow));
                            collist.Add(random1.Next(0, RasterCol));
                        }

                        foreach (int rowH in rowlist)
                        {
                            foreach (int colH in collist)
                            {
                                child1[rowH, colH] = randomGene.Next(1, 7);
                            }
                        }


                    }

                    bool way = true;

                    if(comboBox1.Text== "子代优秀收敛")
                    {
                        way = GetResult(parameter_Dic, Cost, raster0, child1) > p + 0.2;
                    }

                    if (way)
                    {
                        break;
                    }

                    else
                    {
                        child1 = (int[,])child0.Clone();
                    }

                    progressBar2.Maximum = 100000;
                    progressBar2.Minimum = 0;
                    progressBar2.Value = times;
                    progressBar2.Show();

                    times++;
                }
            }

            

            children0[GetResult(parameter_Dic, Cost, raster0, child1)] = child1;

            return children0;
        }

        //读取遗传算法参数函数
        private Dictionary<string, double> ReadGA_parameter(string GA_parameter)
        {
            Dictionary<string, double> GA_parameter_Dic = new Dictionary<string, double>();

            StreamReader sr = new StreamReader(GA_parameter);

            string line0 = sr.ReadLine();
            string line1 = sr.ReadLine();

            string[] strs0 = null;
            strs0 = line0.Split(',');

            string[] strs1 = null;
            strs1 = line1.Split(',');

            for (int i = 0; i < strs0.Count(); i++)
            {
                GA_parameter_Dic[strs0[i]] = Convert.ToDouble(strs1[i]);
            }

            return GA_parameter_Dic;
        }

        //读取改造成本参数函数
        private double [,] ReadCost(string Cost)
        {
            double[,] cost = new double[6,6];

            StreamReader sr = new StreamReader(Cost);

            string line = "";
            string[] strs = null;
            int i = 0;
            while ((line=sr.ReadLine())!=null)
            {
                strs = line.Split(',');
                for(int j=0;j<6;j++)
                {
                    cost[i, j] = Convert.ToDouble(strs[j]);
                }
                i++;
            }

            return cost;
        }

        //主函数
        private void btnGA_Click(object sender, EventArgs e)
        {
            labelRuning.Text = "Loading DEM data……";
            //汇总的字典:建筑数据rasterBuilding, 农田数据rasterFarmland
            //林地数据rasterForest, 水域数据rasterWater, 草地数据rasterGrass, 未利用地数据rasterUnused
            IRaster raster = null;
            //第一个combobox中的数据
            foreach (MapRasterLayer ly in LandUse_GA.RasterList)
            {                
                if (ly.LegendText==comboBoxLayerRaster.Text)
                {
                    raster = ly.DataSet;
                    LandUse_GA.rasterAfter= ly.DataSet;
                }
            }

            RasterRow = raster.NumRows;
            RasterCol = raster.NumColumns;

            labelRuning.Text = "Loading parameter……";
            //读取遗传算法参数和改造成本矩阵
            string GA_parameter = string.Format($"{Application.StartupPath}\\data\\Try\\{"遗传算法参数.csv"}");
            Dictionary<string, double> GA_parameter_Dic = new Dictionary<string, double>();
            GA_parameter_Dic = ReadGA_parameter(GA_parameter);

            string Cost = string.Format($"{Application.StartupPath}\\data\\Try\\{"Cost.csv"}");
            double[,] Cost_Matrix = new double[6, 6];
            Cost_Matrix = ReadCost(Cost);

            //起始
            List<int[,]> start = InitialGene(Convert.ToInt32(textBoxNumChildren.Text));

            //孩子数量
            int childnum = Convert.ToInt32(textBoxNumChildren.Text);

            //第一次

            ///孩子字典
            Dictionary<double, int[,]> kids = new Dictionary<double, int[,]>();

            ///选择要配对的
            List<Dictionary<double, int[,]>> Choosens = ChooseGene(childnum, start, GA_parameter_Dic, Cost_Matrix, raster);

            for (int childn = 0; childn < childnum; childn++)
            {
                ////选择两个子基因
                Dictionary<double, int[,]> choosen = new Dictionary<double, int[,]>();
                choosen = Choosens[childn];
                ////生孩子
                Dictionary<double, int[,]> kid = Heredity(choosen, GA_parameter_Dic, Cost_Matrix, raster);
                kids[kid.First().Key] = kid.First().Value;
            }

            //2~n次
            for(int n=0;n<Convert.ToInt32(textBox1.Text); n++)
            {
                //构建后代列表
                List<int[,]> KidsList = new List<int[,]>();
                foreach(KeyValuePair<double, int[,]> kvl in kids)
                {
                    KidsList.Add(kvl.Value);
                }

                kids.Clear();
                Choosens.Clear();

                ///选择要配对的
                Choosens = ChooseGene(childnum, KidsList, GA_parameter_Dic, Cost_Matrix, raster);

                //迭代求解
                for (int childn = 0; childn < childnum; childn++)
                {
                    ////选择两个子基因
                    Dictionary<double, int[,]> choosen = new Dictionary<double, int[,]>();
                    choosen = Choosens[childn];

                    ////生孩子
                    Dictionary<double, int[,]> kid = Heredity(choosen, GA_parameter_Dic, Cost_Matrix, raster);
                    kids[kid.First().Key] = kid.First().Value;

                }

                chart1.Series[0].Points.AddXY(n+1, kids.Average(kvp => kvp.Key));
                chart2.Series[0].Points.AddXY(n + 1, kids.Max(kvp => kvp.Key));
                chart2.Series[1].Points.AddXY(n + 1, kids.Min(kvp => kvp.Key));
                chart1.Series[0].ChartType = SeriesChartType.Line;

                if (n==0)
                {
                    chart1.ChartAreas[0].AxisY.Minimum = kids.Min(kvp => kvp.Key);
                }

                chart1.Show();
                chart2.Show();
                

                if (true)
                {
                    chart1.Update();
                    chart2.Update();
                    
                }

                for (int row1 = 0; row1 <= LandUse_GA.rasterAfter.NumRows - 1; row1++)
                {
                    for (int col1 = 0; col1 <= LandUse_GA.rasterAfter.NumColumns - 1; col1++)
                    {
                        LandUse_GA.rasterAfter.Value[row1, col1] = kids[kids.Max(kvp => kvp.Key)][row1, col1];
                    }
                }

                LandUse_GA.inn = textBox1.Text;
                progressBar1.Maximum = Convert.ToInt32(textBox1.Text)-1;
                progressBar1.Minimum = 0;
                progressBar1.Value = n ;
                progressBar1.Show();
            }

            labelRuning.Text = "Finished";

            Dictionary<int, int> AfterNum = new Dictionary<int, int>();

            for (int i2 = 1; i2 <=6; i2++)
            {
                AfterNum[i2] = 0;
            }

            for (int row = 0; row < RasterRow; row++)
            {
                for (int col = 0; col < RasterCol; col++)
                {
                    //获取地块数量值
                    for (int i = 1; i <= 6; i++)
                    {
                        if (LandUse_GA.rasterAfter.Value[row, col] == i)
                        {
                            AfterNum[i]++;
                        }
                    }
                }
            }

            chart3.Series[0].Points.Clear();
            for(int i2=0;i2<6; i2++)
            {
                chart3.Series[0].Points.AddXY(i2 + 1, AfterNum[i2 + 1]);
                
            }
            chart3.Series[0].Points[0].Color = Color.Black;
            chart3.Series[0].Points[1].Color = Color.Yellow;
            chart3.Series[0].Points[2].Color = Color.Green;
            chart3.Series[0].Points[3].Color = Color.Blue;
            chart3.Series[0].Points[4].Color = Color.GreenYellow;
            chart3.Series[0].Points[5].Color = Color.Gray;
            chart3.Show();
        }
    }
}
