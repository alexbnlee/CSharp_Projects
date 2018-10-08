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
    public partial class TblResult_Form : Form
    {
        public TblResult_Form()
        {
            InitializeComponent();
        }

        private void TblResult_Form_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(int));
            dt.Columns.Add("损失评估类型");
            dt.Columns.Add("评估值(元)", typeof(decimal));

            dt.Rows.Add(new object[] { 1, "海水养殖业经济损失评估", MainForm.breeding_num });
            dt.Rows.Add(new object[] { 2, "滨海旅游业经济损失评估", MainForm.tourism_num });
            dt.Rows.Add(new object[] { 3, "赤潮灾害应急监测费用评估", MainForm.monitoring_num });
            dt.Rows.Add(new object[] { 4, "赤潮灾害处置费用评估", MainForm.disposing_num });
            dt.Rows.Add(new object[] { 5, "赤潮灾害总经济损失评估", MainForm.breeding_num + MainForm.tourism_num + MainForm.monitoring_num + MainForm.disposing_num });

            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
            //gridView1.RowSeparatorHeight = 5;
            gridView1.RowHeight = 35;
            gridView1.ColumnPanelRowHeight = 35;
        }

        private void btn_resultExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件（*.txt）|*.txt";
            sfd.FileName = DateTime.Today.Date.ToLongDateString() + " - 赤潮灾害损失评估结果";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                string s0 = "序号\t损失评估类型\t\t\t评估值(元)";
                string s1 = "1\t海水养殖业经济损失评估\t\t" + MainForm.breeding_num;
                string s2 = "2\t滨海旅游业经济损失评估\t\t" + MainForm.tourism_num;
                string s3 = "3\t赤潮灾害应急监测费用评估\t\t" + MainForm.monitoring_num;
                string s4 = "4\t赤潮灾害处置费用评估\t\t" + MainForm.disposing_num;
                float total_num = MainForm.breeding_num + MainForm.tourism_num + MainForm.monitoring_num + MainForm.disposing_num;
                string s5 = "5\t赤潮灾害总经济损失评估\t\t" + total_num;
                string w = s0 + "\r\n" + s1 + "\r\n" + s2 + "\r\n" + s3 + "\r\n" + s4 + "\r\n" + s5;
                sw.Write(w);
                sw.Close();
            }
            else
            {
                return;
            }
            DialogResult dr = MessageBox.Show("文件输出成功！是否打开此文件？", "消息提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void button_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
