using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Data;

namespace DotSpatial_期中综合
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (int.Parse(textBox1.Text) >= 6)
                {
                    MessageBox.Show("Sorry!Maximum number of categories is 5!");
                }
                else
                {
                    tableLayoutPanel2.RowCount = int.Parse(textBox1.Text) + 1;
                }
            }

        }

        public static int[] rc_data = new int[50];

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(textBox1.Text) * 3 + 1; i++)
            {
                string text_name = "textBox" + (i+1).ToString();
                TextBox tb = (TextBox)this.Controls.Find(text_name, true)[0];
                rc_data[i] = int.Parse(tb.Text);
            }
            //rc_data[0] = int.Parse(textBox1.Text);
            //rc_data[1] = int.Parse(textBox2.Text);
            //rc_data[2] = int.Parse(textBox3.Text);
            //rc_data[3] = int.Parse(textBox4.Text);
            //rc_data[4] = int.Parse(textBox5.Text);
            //rc_data[5] = int.Parse(textBox6.Text);
            //rc_data[6] = int.Parse(textBox7.Text);
            //rc_data[7] = int.Parse(textBox8.Text);
            //rc_data[8] = int.Parse(textBox9.Text);
            //rc_data[9] = int.Parse(textBox10.Text);
            //rc_data[10] = int.Parse(textBox11.Text);
            //rc_data[11] = int.Parse(textBox12.Text);
            //rc_data[12] = int.Parse(textBox13.Text);
            //rc_data[13] = int.Parse(textBox14.Text);
            //rc_data[14] = int.Parse(textBox15.Text);
            //rc_data[15] = int.Parse(textBox16.Text);
            //Form1.form_main.reclassify();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int row = int.Parse(textBox1.Text);
            int[] data = new int[50];
            data[1] = 0;
            for (int i = 2; i < row * 3 + 1;i++) 
            {
                data[i] = (i / 2) * (int)(Form1.maxdem/ row);
                data[i + 1] = data[i] + 1;
                i++;
            }


            for (int i = 2; i < 3 * row + 1; i++)
            {
                string text_name = "textBox" + i.ToString();
                TextBox tb = (TextBox)this.Controls.Find(text_name, true)[0];
                tb.Text = data[i - ((i - 2)/ 3 + 1)].ToString();
            }

            for (int i = 1; i < row + 1; i++)
            {
                string text_name = "textBox" + (3 * i + 1).ToString();
                TextBox tb = (TextBox)this.Controls.Find(text_name, true)[0];
                tb.Text = (i - 1).ToString();
            }

            string text_name2 = "textBox" + (3 * row).ToString();
            TextBox tb2 = (TextBox)this.Controls.Find(text_name2, true)[0];
            tb2.Text =((int)(Form1.maxdem + 1)).ToString();




        }
    }
}
