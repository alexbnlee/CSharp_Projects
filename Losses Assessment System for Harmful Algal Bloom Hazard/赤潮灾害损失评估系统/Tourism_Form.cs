using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 赤潮灾害损失评估系统
{
    public partial class Tourism_Form : Form
    {
        public Tourism_Form()
        {
            InitializeComponent();
        }
        private void Haishuiyangzhi_Form_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(Directory.GetCurrentDirectory() + @"\Help Doc\Doc2.pdf");
            //导入已存储的结果
            lyy_tb1.Text = MainForm.pS2_1.ToString();
            lyy_tb2.Text = MainForm.pS2_2.ToString();
            lyy_tb3.Text = MainForm.pS2_3.ToString();
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            if (button_help.Text == "<<隐藏说明")
            {
                this.Width = 606;
                button_help.Text = "显示说明>>";
            }
            else
            {
                this.Width = 1058;
                button_help.Text = "<<隐藏说明";
            }
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(lyy_tb1.Text);
                float v = Convert.ToSingle(lyy_tb2.Text);
                int t = Convert.ToInt32(lyy_tb3.Text);
                float E_TL = 0;

                E_TL = n * v * t;

                lyy_label_result.Text = "本次赤潮灾害导致滨海旅游业的经济损失（元）：" + E_TL;
                MainForm.tourism_num = E_TL;
                MainForm.tourism_result = lyy_label_result.Text + "。";

                MainForm.pS2_1 = n;
                MainForm.pS2_2 = v;
                MainForm.pS2_3 = t;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "评价参数输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lyy_tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void lyy_tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void lyy_tb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
