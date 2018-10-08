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
    public partial class Disposing_Form : Form
    {
        public Disposing_Form()
        {
            InitializeComponent();
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            try
            {
                float n = Convert.ToSingle(cz_tb1.Text);
                float v = Convert.ToSingle(cz_tb2.Text);
                float E_BU = Convert.ToSingle(cz_tb3.Text);
                float E_RU = Convert.ToSingle(cz_tb4.Text);

                float E_TU = 0;

                E_TU = n * v + E_BU + E_RU;

                cz_label_result.Text = "由于赤潮灾害事件的发生，处置部门需要开展的赤潮灾害处置费用（元）：" + E_TU;
                MainForm.disposing_num = E_TU;
                MainForm.disposing_result = cz_label_result.Text + "。";

                MainForm.pS4_1 = n;
                MainForm.pS4_2 = v;
                MainForm.pS4_3 = E_BU;
                MainForm.pS4_4 = E_RU;
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

        private void cz_tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void cz_tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void cz_tb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void cz_tb4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void Disposing_Form_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(Directory.GetCurrentDirectory() + @"\Help Doc\Doc4.pdf");

            cz_tb1.Text = MainForm.pS4_1.ToString();
            cz_tb2.Text = MainForm.pS4_2.ToString();
            cz_tb3.Text = MainForm.pS4_3.ToString();
            cz_tb4.Text = MainForm.pS4_4.ToString();
        }

    }
}
