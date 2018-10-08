using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 信息系统集成方案
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void bt_connect_Click(object sender, EventArgs e)
        {
            //主要是可以将此数据传递给后面打开的TSC窗体,同时若是连接成功将此数据传递给excel中的文件
            MainForm.str_computer = tb_computer.Text;
            MainForm.str_userName = tb_userName.Text;
            MainForm.str_password = tb_password.Text;
            MainForm.is_rememberd = checkBox1.Checked.ToString();

            //打开新的窗体，关闭当前窗体
            TscForm frm_TSC = new TscForm();
            frm_TSC.Width = SystemInformation.WorkingArea.Width;
            frm_TSC.Height = SystemInformation.WorkingArea.Height;
            frm_TSC.WindowState = FormWindowState.Maximized;
            frm_TSC.Show();
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tb_computer.Text = MainForm.str_computer;
            tb_userName.Text = MainForm.str_userName;
            tb_password.Text = MainForm.str_password;
            checkBox1.Checked = Convert.ToBoolean(MainForm.is_rememberd);
        }
    }
}
