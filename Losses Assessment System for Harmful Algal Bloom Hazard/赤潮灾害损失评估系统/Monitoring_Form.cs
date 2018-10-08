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
    public partial class Monitoring_Form : Form
    {
        public Monitoring_Form()
        {
            InitializeComponent();
        }

        private void yyjc_tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) //只能输入一个点
                e.Handled = true;
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            float E_BU = 0;
            float[] v = new float[100];
            float sum_v = 0;
            float E_MU = 0;

            try
            {
                E_BU = Convert.ToSingle(yjjc_tb1.Text);

                for (int i = 0; i < yjjc_dgv.Rows.Count - 1; i++)
                {
                    v[i] = Convert.ToSingle(yjjc_dgv.Rows[i].Cells[1].Value);
                    sum_v = sum_v + v[i];
                }

                E_MU = E_BU + sum_v;
                yjjc_label_result.Text = "本次赤潮灾害事件的发生，监测部门需要开展的赤潮灾害业务与应急监测费用（元）：" + E_MU;
                MainForm.monitoring_num = E_MU;
                MainForm.monitoring_result = yjjc_label_result.Text + "。";

                MainForm.pS3_1 = E_BU;
                MainForm.pS3_2 = yjjc_dgv.DataSource as DataTable;
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

        private void Monitoring_Form_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(Directory.GetCurrentDirectory() + @"\Help Doc\Doc3.pdf");

            DataTable dt = new DataTable();
            dt.Columns.Add("站位名称");
            dt.Columns.Add("船舶租用费用（元）");
            yjjc_dgv.DataSource = dt;
            yjjc_dgv.Columns[0].Width = 243;
            yjjc_dgv.Columns[1].Width = 243;

            yjjc_tb1.Text = MainForm.pS3_1.ToString();
            if (MainForm.pS3_2.Columns.Count > 0)
            {
            	yjjc_dgv.DataSource = MainForm.pS3_2;
            }
        }
    }
}
