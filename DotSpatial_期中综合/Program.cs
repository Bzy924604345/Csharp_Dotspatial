﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotSpatial_期中综合
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            login login = new login();

            //界面转换
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {
                login.Dispose();
                Application.Run(new Form1());
            }
            else if (login.DialogResult == DialogResult.Cancel)
            {
                login.Dispose();
                return;
            }


            //Application.Run(new Form1());
        }
    }
}
