using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.IO;

namespace 赤潮灾害损失评估系统
{
    public partial class EvaResult_Form : Form
    {
        public EvaResult_Form()
        {
            InitializeComponent();
        }

        private void Statistics_Form_Load(object sender, EventArgs e)
        {
            //createTblGrid();
            createStaBar();
            createStaPie();
        }

        //private void createTblGrid()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("序号", typeof(int));
        //    dt.Columns.Add("损失评估类型");
        //    dt.Columns.Add("评估值(元)", typeof(decimal));

        //    dt.Rows.Add(new object[] { 1, "海水养殖业经济损失评估", MainForm.breeding_num });
        //    dt.Rows.Add(new object[] { 2, "滨海旅游业经济损失评估", MainForm.tourism_num });
        //    dt.Rows.Add(new object[] { 3, "赤潮灾害应急监测费用评估", MainForm.monitoring_num });
        //    dt.Rows.Add(new object[] { 4, "赤潮灾害处置费用评估", MainForm.disposing_num });
        //    dt.Rows.Add(new object[] { 5, "赤潮灾害总经济损失评估", MainForm.breeding_num + MainForm.tourism_num + MainForm.monitoring_num + MainForm.disposing_num });

        //    gridControl1.DataSource = dt;
        //    gridView1.BestFitColumns();
        //    //gridView1.RowSeparatorHeight = 5;
        //    gridView1.RowHeight = 35;
        //    gridView1.ColumnPanelRowHeight = 35;
        //}

        private void createStaBar()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(int));
            dt.Columns.Add("损失评估类型");
            dt.Columns.Add("评估值(元)", typeof(decimal));

            dt.Rows.Add(new object[] {1, "海水养殖业经济损失", MainForm.breeding_num});
            dt.Rows.Add(new object[] {2, "滨海旅游业", MainForm.tourism_num});
            dt.Rows.Add(new object[] {3, "赤潮应急监测", MainForm.monitoring_num});
            dt.Rows.Add(new object[] {4, "赤潮处置", MainForm.disposing_num});
            
            Series sr = new Series("评估值", ViewType.Bar);

            //绑定数据源
            sr.DataSource = dt.DefaultView;//newdtb是获取到的数据(可以是数据库中的表，也可以是DataTable)
            sr.ArgumentDataMember = "损失评估类型";//绑定的文字信息（名称）(坐标横轴)
            sr.ValueDataMembers[0] = "评估值(元)";//绑定的值（数据）(坐标纵轴)

            //样式
            //sr.View.Color = Color.Red;//颜色

            //添加到统计图上
            chartControl1.Series.Add(sr);

            //图例设置
            //SimpleDiagram3D diagram = new SimpleDiagram3D();

            //diagram.RuntimeRotation = true;
            //diagram.RuntimeScrolling = true;
            //diagram.RuntimeZooming = true;

            //设置图表标题
            ChartTitle ct = new ChartTitle();

            ct.Text = "赤潮灾害损失评估统计（直方图）";
            ct.TextColor = Color.Black;//颜色
            ct.Font = new Font("宋体", 15, FontStyle.Bold);//字体
            ct.Dock = ChartTitleDockStyle.Top;//停靠在上方
            ct.Alignment = StringAlignment.Center;//居中显示
            chartControl1.Titles.Add(ct);
            chartControl1.Legend.Visible = false;//不现实指示图
        }

        private void createStaPie()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(int));
            dt.Columns.Add("损失评估类型");
            dt.Columns.Add("评估值(元)", typeof(decimal));

            dt.Rows.Add(new object[] { 1, "海水养殖业", MainForm.breeding_num });
            dt.Rows.Add(new object[] { 2, "滨海旅游业", MainForm.tourism_num });
            dt.Rows.Add(new object[] { 3, "赤潮应急监测", MainForm.monitoring_num });
            dt.Rows.Add(new object[] { 4, "赤潮处置", MainForm.disposing_num });

            Series sr = new Series("评估值", ViewType.Pie);

            //绑定数据源
            sr.DataSource = dt.DefaultView;//newdtb是获取到的数据(可以是数据库中的表，也可以是DataTable)
            sr.ArgumentDataMember = "损失评估类型";//绑定的文字信息（名称）(坐标横轴)
            sr.ValueDataMembers[0] = "评估值(元)";//绑定的值（数据）(坐标纵轴)

            sr.ArgumentScaleType = ScaleType.Qualitative;   //定性的
            sr.ValueScaleType = ScaleType.Numerical;    //数字类型
            sr.LegendPointOptions.PointView = PointView.Argument;  //显示表示的信息和数据
            sr.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;   //用百分比表示
            sr.LegendText = "图例";


            sr.Label.PointOptions.PointView = PointView.ArgumentAndValues;   // 设置Label显示方式  
            //sr.ToolTipPointPattern = "hello world";   // 自定义ToolTip显示  
            sr.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  
            //sr.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;  
            //sr.ValueScaleType = ScaleType.Numerical;  
            //sr.Label.PointOptions.ValueNumericOptions.Precision = 2;  


            //样式
            //sr.View.Color = Color.Red;//颜色

            //添加到统计图上
            chartControl2.Series.Add(sr);

            //图例设置
            SimpleDiagram3D diagram = new SimpleDiagram3D();

            diagram.RuntimeRotation = true;
            diagram.RuntimeScrolling = true;
            diagram.RuntimeZooming = true;

            //设置图表标题
            ChartTitle ct = new ChartTitle();

            ct.Text = "赤潮灾害损失评估统计（饼图）";
            ct.TextColor = Color.Black;//颜色
            ct.Font = new Font("宋体", 15, FontStyle.Bold);//字体
            ct.Dock = ChartTitleDockStyle.Top;//停靠在上方
            ct.Alignment = StringAlignment.Center;//居中显示
            chartControl2.Titles.Add(ct);
            chartControl2.Legend.Visible = false;//不现实指示图
        }

        private void btn_resultExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件（*.txt）|*.txt";
            sfd.FileName = DateTime.Today.Date.ToLongDateString() + " - 赤潮灾害损失评估结果";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                string s0 = "序号\t损失评估类型\t\t\t\t评估值(元)";
                string s1 = "1\t海水养殖业经济损失评估\t\t" + MainForm.breeding_num;
                string s2 = "2\t滨海旅游业经济损失评估\t\t" + MainForm.tourism_num;
                string s3 = "3\t赤潮灾害应急监测费用评估\t\t" + MainForm.monitoring_num;
                string s4 = "4\t赤潮灾害处置费用评估\t\t" + MainForm.disposing_num;
                float total_num = MainForm.breeding_num + MainForm.tourism_num + MainForm.monitoring_num + MainForm.disposing_num;
                string s5 = "5\t赤潮灾害总经济损失评估\t\t" + total_num;
                string w = s1 + "\r\n" + s2 + "\r\n" + s3 + "\r\n" + s4 + "\r\n" + s5;
                sw.Write(w);
                sw.Close();
            }
            DialogResult dr = MessageBox.Show("文件输出成功！是否打开此文件？", "消息提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void bt_imageExport01_Click(object sender, EventArgs e)
        {
            chartControl1.ShowRibbonPrintPreview();
        }

        private void bt_imageExport02_Click(object sender, EventArgs e)
        {
            chartControl2.ShowRibbonPrintPreview();
        }

        private void button_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
