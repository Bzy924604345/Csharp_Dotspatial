using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
namespace DotSpatial_期中综合
{
    class DB
    {
        public static DataTable ConnectDB()
        {
            string ConStr = @"PORT=5433;DATABASE=dbcdb080df30624caf8220e235c1adbff2Csharp;HOST= 47.100.38.198;PASSWORD=ATField2022;USER ID=ATField";
            NpgsqlConnection SqlConn = new NpgsqlConnection(ConStr);
            DataSet dataSet = new DataSet();
            string sql = string.Format($"SELECT * FROM IDPassword.arcgis");
            NpgsqlDataAdapter ad = new NpgsqlDataAdapter(sql, SqlConn);
            ad.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static void AppendDB(string Mail,string password)
        {
            string ConStr = @"PORT=5433;DATABASE=dbcdb080df30624caf8220e235c1adbff2Csharp;HOST= 47.100.38.198;PASSWORD=ATField2022;USER ID=ATField";
            NpgsqlConnection SqlConn = new NpgsqlConnection(ConStr);
            SqlConn.Open();


            string sql = string.Format($"insert into IDPassword.arcgis(id,password)" +
                $"values('{Mail}','{password}')");
            NpgsqlCommand ADD = new NpgsqlCommand(sql, SqlConn);
            ADD.ExecuteNonQuery();
        }
    }
}
