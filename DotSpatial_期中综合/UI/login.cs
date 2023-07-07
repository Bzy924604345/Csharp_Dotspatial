using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DotSpatial_期中综合
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void LoginIn_Click(object sender, EventArgs e)
        {
            string ID_password = string.Format($"{Application.StartupPath}\\data\\{"ID_PASSWORD.csv"}");
            Dictionary<string, string> ID_password_dic = new Dictionary<string, string>();
            //0.获取用户名和密码
            if (this.Local.Checked)
            {
                StreamReader sr = new StreamReader(ID_password);
                string line = sr.ReadLine();
                string[] strs = null;
                while ((line = sr.ReadLine()) != null)
                {
                    strs = line.Split(',');
                    ID_password_dic[strs[0]] = strs[1];
                }
            }


            //从数据库获取
            if (this.DataBase.Checked)
            {
                DataTable dt = DB.ConnectDB();

                foreach (DataRow r in dt.Rows)
                {
                    ID_password_dic[r[0].ToString()] = r[1].ToString();
                }
            }


            //1. 获取数据
            //从TextBox中获取用户输入信息
            string userName = this.txtUserName.Text;
            //userName = userName.Replace("AtFiElD", "@");
            string userPassword = this.txtPassword.Text;

            //2. 验证数据
            // 验证用户输入是否为空，若为空，提示用户信息

            if (userName.Equals("") || userPassword.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            // 若不为空，验证用户名和密码是否与数据库匹配
            // 这里只做字符串对比验证
            else
            {
                int iflogin = 0;
                foreach (KeyValuePair<string, string> kvl in ID_password_dic)
                {
                    if (userName.Equals(kvl.Key) && userPassword.Equals(kvl.Value))
                    {
                        MessageBox.Show("登录成功！");

                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                        this.Close();
                        iflogin = 1;
                    }
                }
                if (iflogin == 0)
                {
                    MessageBox.Show("用户名或密码错误！");
                }
                //用户名和密码验证正确，提示成功，并执行跳转界面。

                //用户名和密码验证错误，提示错误。
            }
        }

        //获取N位随机码
        private static string createrandom(int codelengh)
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codelengh; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        //发送邮件
        public void Code(string email_r,string cood)
        {
            if (email_r.Contains("@"))
            {
                //实例化一个发送邮件类。
                MailMessage mailMessage = new MailMessage();
                //发件人邮箱地址，方法重载不同，可以根据需求自行选择。xxx处填写自己的qq账户
                mailMessage.From = new MailAddress("xxx@qq.com");
                //收件人邮箱地址。
                mailMessage.To.Add(new MailAddress(email_r));
                //邮件标题。
                mailMessage.Subject = "这是你的验证码为：";
                //邮件内容。
                mailMessage.Body = "验证码：" + cood + "。此验证码只用于登录ARCGIS验证身份，请勿转发他人。";
                //实例化一个SmtpClient类。
                SmtpClient client = new SmtpClient();
                //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
                client.Host = "smtp.qq.com";
                //使用安全加密连接。
                client.EnableSsl = true;
                //不和请求一块发送。
                client.UseDefaultCredentials = false;
                //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
                client.Credentials = new NetworkCredential("3106275610@qq.com", "oiamsnlgpyihdghi");
                //发送
                client.Send(mailMessage);
                MessageBox.Show("发送成功");
            }
            else
            {
                MessageBox.Show("邮箱格式有误，请重新输入。");
            }    
        }

        //注册所需的各项参数
        ////邮箱地址
        string MailAdress = "";
        ////用户输入的验证码
        string Verification = "";
        ////正确的验证码
        string cood = "";
        ////密码
        string PassWord = "";

        //获取验证码
        private void btnSendV_Click(object sender, EventArgs e)
        {
            //检查邮箱是否为空
            if(textBoxMail.Text==null)
            {
                MessageBox.Show("请先填写邮箱！");
            }

            else
            {
                //用户邮箱
                MailAdress = textBoxMail.Text;
                //MailAdress = MailAdress.Replace("@", "AtFiElD");

                //查重,查看账号是否注册
                using (DataTable dt2 = DB.ConnectDB())
                {
                    Dictionary<string, string> ID_password_Login_dic = new Dictionary<string, string>();
                    foreach (DataRow r in dt2.Rows)
                    {
                        ID_password_Login_dic[r[0].ToString()] = r[1].ToString();
                    }
                    foreach(KeyValuePair<string,string> kvl in ID_password_Login_dic)
                    {
                        if (MailAdress.Equals(kvl.Key))
                        {
                            MessageBox.Show("该账号已注册！");
                            return;
                        }
                    }
                }

                //验证码
                //MailAdress = textBoxMail.Text;
                cood = createrandom(6).ToLower();
                //发送验证码
                Code(MailAdress, cood);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //检查邮箱是否为空
            if (textBoxMail.Text == "")
            {
                MessageBox.Show("请先填写邮箱！");
                return;
            }

            //检查验证码是否正确
            else if (textBoxVerification.Text != cood|| textBoxVerification.Text=="")
            {
                MessageBox.Show("请填写正确的验证码！");
                return;
            }

            //若输入正确，查看是否输入密码
            else if(textBoxPassword.Text=="")
            {
                MessageBox.Show("请输入密码！");
                return;
            }

            //若满足所有条件，将账号密码添加到数据库
            else
            {
                MailAdress = textBoxMail.Text;
                PassWord = textBoxPassword.Text;
                DB.AppendDB(MailAdress, PassWord);
                MessageBox.Show("注册成功");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
