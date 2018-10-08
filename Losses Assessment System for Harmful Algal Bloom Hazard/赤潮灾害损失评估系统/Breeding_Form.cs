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
    public partial class Breeding_Form : Form
    {
        public Breeding_Form()
        {
            InitializeComponent();
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            float E_CL = 0;
            float[] m = new float[100];
            float[] v = new float[100];

            try
            {
                for (int i = 0; i < yzy_dgv.Rows.Count - 1; i++)
                {
                    m[i] = Convert.ToSingle(yzy_dgv.Rows[i].Cells[1].Value);
                    v[i] = Convert.ToSingle(yzy_dgv.Rows[i].Cells[2].Value);
                    E_CL = E_CL + m[i] * v[i];
                }
                yzy_label_result.Text = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + E_CL.ToString();
                MainForm.breeding_num = E_CL;
                MainForm.breeding_result = yzy_label_result.Text + "。";
                MainForm.pS1_1 = yzy_dgv.DataSource as DataTable;
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

        private void Breeding_Form_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(Directory.GetCurrentDirectory() + @"\Help Doc\Doc1.pdf");

            DataTable dt = new DataTable();
            dt.Columns.Add("养殖品种名称");
            dt.Columns.Add("损失量（kg）");
            dt.Columns.Add("单位价值（元/kg）");
            yzy_dgv.DataSource = dt;
            yzy_dgv.Columns[0].Width = 162;
            yzy_dgv.Columns[1].Width = 162;
            yzy_dgv.Columns[2].Width = 162;

            if (MainForm.pS1_1.Columns.Count > 0)
            {
            	yzy_dgv.DataSource = MainForm.pS1_1;
            }
        }
    }
}
