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
    public partial class Total_Form : Form
    {
        public Total_Form()
        {
            InitializeComponent();
        }

        private void Total_Form_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(Directory.GetCurrentDirectory() + @"\Help Doc\Doc5.pdf");
            jjss_tb1.Text = MainForm.breeding_num.ToString();
            jjss_tb2.Text = MainForm.tourism_num.ToString();
            jjss_tb3.Text = MainForm.monitoring_num.ToString();
            jjss_tb4.Text = MainForm.disposing_num.ToString();
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            try
            {
                float E_RTL = 0;
                float E_CL = 0;
                float E_TL = 0;
                float E_MU = 0;
                float E_TU = 0;

                E_CL = Convert.ToSingle(jjss_tb1.Text);
                E_TL = Convert.ToSingle(jjss_tb2.Text);
                E_MU = Convert.ToSingle(jjss_tb3.Text);
                E_TU = Convert.ToSingle(jjss_tb4.Text);

                E_RTL = E_CL + E_TL + E_MU + E_TU;
                jjss_label_result.Text = "本次赤潮灾害事件造成的经济损失（元）：" + E_RTL.ToString();
                MainForm.total_result = jjss_label_result.Text + "。";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "评价参数输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void jjss_tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void jjss_tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void jjss_tb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void jjss_tb4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }
    }
}
