using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace 综合业务平台
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox2.Items.Add("气温(℃)");
            listBox2.Items.Add("水温(℃)");
            listBox2.Items.Add("溶解氧(mg/L)");
            listBox2.Items.Add("浊度(NTU)");
            listBox2.Items.Add("叶绿素-a(ug/L)");
            listBox2.SelectedIndex = 0;
            listBox3.SelectedIndex = 0;
        }

        ArrayList dates = new ArrayList();
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {
            ////OpenFileDialog ofd = new OpenFileDialog();
            ////ofd.Filter = "Excel文档|*.xls;*.xlsx";
            ////if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            ////{
            //string str_filename = @"D:\01-Working\综合业务平台数据\浮标\FBQHD-3 2015.6-8 month data.xls";
                
            //    string strCon = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=0'", str_filename);
            //    OleDbConnection myConn = new OleDbConnection(strCon);

            //    string strCom = "SELECT * FROM [Sheet1$]";
            //    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strCom, myConn);
            //    DataSet myDataSet = new DataSet();
            //    myDataAdapter.Fill(myDataSet, "[Sheet1$]");
            //    myConn.Close();
            //    DataTable dt = myDataSet.Tables[0]; //初始化DataTable实例
            //    string str = dt.Rows[0][1].ToString();
            //    DateTime dd = DateTime.Parse(dt.Rows[0][1].ToString());
            //    //MessageBox.Show(dd.Year.ToString());

            //    //listBox1.Items.Add("Example 1");
            //    //listBox1.Items.Add("Example 2");

            //    //获取Excel中包含的日期，不重复的
            //    //string[] dates = new string[]{};
            //    ArrayList dates = new ArrayList();
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        //遍历全部时间，获取日期信息
            //        DateTime date_time = DateTime.Parse(dt.Rows[i][1].ToString());
            //        string date = date_time.ToLongDateString();
            //        if (!dates.Contains(date))
            //            dates.Add(date);
            //        else
            //            continue;
            //    }

            //    //将日期值赋值到ListBox中
            //    for (int i = 0; i < dates.Count; i++)
            //    {
            //        listBox1.Items.Add(dates[i]);
            //    }
            ////}

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //扩展名是xls会出错，xlsx就不会出错
            string str_filename = @"D:\01-Working\综合业务平台数据\浮标\FBQHD-3 2015.6-8 month data.xls";

            string strCon = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=2'", str_filename);
            OleDbConnection myConn = new OleDbConnection(strCon);
            myConn.Open();

            string strCom = "SELECT * FROM [Sheet1$]";
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "[Sheet1$]");
            myConn.Close();
            dt = myDataSet.Tables[0]; //初始化DataTable实例

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //遍历全部时间，获取日期信息
                DateTime date_time = DateTime.Parse(dt.Rows[i][1].ToString());
                string date = date_time.ToLongDateString();
                if (!dates.Contains(date))
                    dates.Add(date);
                else
                    continue;
            }

            //将日期值赋值到ListBox中
            for (int i = 0; i < dates.Count; i++)
            {
                listBox1.Items.Add(dates[i]);
            }

            //横轴显示样式
            //chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "yyyy-MM-dd-HH:mm:ss";
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Hours;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 2;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas[0].AxisX.Title = "时间";

            //将listbox2中内容赋值到Series中，并设置颜色
            for (int ii = 0; ii < listBox2.Items.Count; ii++)
            {
                chart1.Series[ii].Name = listBox2.Items[ii].ToString();
                switch (ii)
                {
                    case 0:
                        chart1.Series[0].Color = Color.Red;
                        break;
                    case 1:
                        chart1.Series[1].Color = Color.Blue;
                        break;
                    case 2:
                        chart1.Series[2].Color = Color.FromArgb(0xFF, 0x66, 0x00);
                        break;
                    case 3:
                        chart1.Series[3].Color = Color.DimGray;
                        break;
                    case 4:
                        chart1.Series[4].Color = Color.LimeGreen;
                        break;
                }
            }

            chart1.ChartAreas[0].AxisY.Title = listBox2.Items[0].ToString();
            chart1.Series[0].BorderWidth = 1;
            //默认选中第一个项目
            listBox1.SelectedIndex = 0;
            listBox1_SelectedIndexChanged(listBox1, e);
            button2_Click(button2, e);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
	            //清除所有曲线
                for (int ii = 0; ii < listBox2.Items.Count; ii++)
                    chart1.Series[ii].Points.Clear();
	
	            //遍历每个日期
	            for (int i = 0; i < dates.Count; i++)
	            {
	                //获取被选择的索引
	                if (listBox1.SelectedIndex == i)
	                {
	                    //遍历该日期的所有数据
	                    for (int j = 0; j < dt.Rows.Count; j++)
	                    {
	                        DateTime date_time = DateTime.Parse(dt.Rows[j][1].ToString());
	                        string date = date_time.ToLongDateString();
	                        //表格中提取的时间值如果与选择项的值相同，则加载表格
	                        if (date == dates[i].ToString())
	                        {
	                            chart1.Series[listBox2.SelectedIndex].XValueType = ChartValueType.Time;
	                            //double double_time = date_time.ToOADate();
	                            //选择项对应的数据
	                            double lb2 = 0.0;
	                            switch (listBox2.SelectedIndex)
	                            {
	                                case 0:
	                                    lb2 = Double.Parse(dt.Rows[j][3].ToString());
	                                    break;
	                                case 1:
	                                    lb2 = Double.Parse(dt.Rows[j][6].ToString());
	                                    break;
	                                case 2:
	                                    lb2 = Double.Parse(dt.Rows[j][8].ToString());
	                                    break;
	                                case 3:
	                                    lb2 = Double.Parse(dt.Rows[j][9].ToString());
	                                    break;
	                                case 4:
	                                    //存在数据为空的情况，取前后的平均值
	                                    if (dt.Rows[j][10].ToString() != "")
	                                        lb2 = Double.Parse(dt.Rows[j][10].ToString());
	                                    else
	                                        lb2 = (Double.Parse(dt.Rows[j - 1][10].ToString()) + 
	                                            Double.Parse(dt.Rows[j - 1][10].ToString()))/2;
	                                    break;
	                            }
	                            //chart1.Series[listBox2.SelectedIndex].Points.AddXY(date_time.ToString("H:mm:ss")).ToOADate(), lb2);
                                chart1.Series[listBox2.SelectedIndex].Points.AddXY(date_time.ToOADate(), lb2);
                            }
	                    }
	                }
	
	            }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (listBox1.SelectedIndex > -1 && listBox2.SelectedIndex > -1)
                chart1.Titles[0].Text = String.Format("FB-QHD-03 {0} {1} 变化曲线", listBox1.SelectedItem.ToString(),
	                listBox2.SelectedItem.ToString());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //执行一下listBox1被选择内的代码
            listBox1_SelectedIndexChanged(listBox1, e);
            chart1.ChartAreas[0].AxisY.Title = listBox2.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //清除所有曲线
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();

            DataTable dtzh = new DataTable();
            dtzh.Columns.Add("Time");
            dtzh.Columns.Add("采集时间");
            dtzh.Columns.Add("经度");
            dtzh.Columns.Add("纬度");
            dtzh.Columns.Add("Fo");
            dtzh.Columns.Add("Fm");
            dtzh.Columns.Add("Fv");
            dtzh.Columns.Add("Blank Value");
            dtzh.Columns.Add("Yield");

            //标记是否是第二行，要将两行的数据放到一行中
            bool line_first = false;
            
            int index_cjsj = 0;
            int index_lon = 0;
            int index_lat = 0;

            int index_Fo = 0;
            int index_Fm = 0;
            int index_Fv = 0;
            int index_BV = 0;
            int index_Yield = 0;

            using (StreamReader streamReader = new StreamReader(@"D:\01-Working\综合业务平台数据\船载\传感器2.2014-08-29.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null) //没读到最后
                {
                    //12:49:06 =>  采集时间：NA，经度：NA，纬度：NA
                    //12:49:06 =>  Fo = ，Fm = 3，Fv = 3，Blank Value=0，Yield=1.000痧痧痧
                    
                    line_first = !line_first;
                    if (line_first)
                    {
                        //第一行读取 0-Time、1-采集时间、2-经度、3-纬度
                        index_cjsj = str.IndexOf("采集时间");
                        index_lon = str.IndexOf("经度");
                        index_lat = str.IndexOf("纬度");

                        //新建数据行
                        DataRow drzh = dtzh.NewRow();

                        //为数据赋值
                        drzh["Time"] = str.Substring(0, 8);
                        drzh["采集时间"] = str.Substring(index_cjsj + 5, index_lon - index_cjsj - 6).Trim();
                        drzh["经度"] = str.Substring(index_lon + 3, index_lat - index_lon - 4).Trim();
                        drzh["纬度"] = str.Substring(index_lat + 3).Trim();
                        
                        //将数据行加入表格中
                        dtzh.Rows.Add(drzh);
                    }
                    else
                    {
                        //第二行读取 4-Fo、5-Fm、6-Fv、7-Blank Value、8-Yield
                        index_Fo = str.IndexOf("Fo");
                        index_Fm = str.IndexOf("Fm");
                        index_Fv = str.IndexOf("Fv");
                        index_BV = str.IndexOf("Blank Value");
                        index_Yield = str.IndexOf("Yield");

                        //为数据赋值
                        dtzh.Rows[dtzh.Rows.Count - 1]["Fo"] = 
                            str.Substring(index_Fo + 4, index_Fm - index_Fo - 5).Trim();
                        dtzh.Rows[dtzh.Rows.Count - 1]["Fm"] =
                            str.Substring(index_Fm + 4, index_Fv - index_Fm - 5).Trim();
                        dtzh.Rows[dtzh.Rows.Count - 1]["Fv"] =
                            str.Substring(index_Fv + 4, index_BV - index_Fv - 5).Trim();
                        dtzh.Rows[dtzh.Rows.Count - 1]["Blank Value"] =
                            str.Substring(index_BV + 12, index_Yield - index_BV - 13).Trim();
                        dtzh.Rows[dtzh.Rows.Count - 1]["Yield"] = str.Substring(index_Yield + 6).Trim();
                    } 
                }

                chart2.Series[0].XValueType = ChartValueType.Time;
                chart2.Series[1].XValueType = ChartValueType.Time;
                chart2.Series[2].XValueType = ChartValueType.Time;

                for (int i = 0; i < dtzh.Rows.Count; i++)
                {
                    DateTime dt1 = DateTime.Parse("2000/8/8  " + dtzh.Rows[i]["Time"].ToString());
                    double dd = Double.Parse(dtzh.Rows[i][listBox3.SelectedItem.ToString()].ToString());
                    chart2.Series[listBox3.SelectedIndex].Points.AddXY(dt1.ToOADate(), dd);
                }
                
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2_Click(button2, e);
        }

    }
}
