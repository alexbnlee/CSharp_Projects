using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MSTSCLib;
using System.Drawing.Drawing2D;

namespace 信息系统集成方案
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //用于存放程序的链接地址
        string str_part01 = "str_part01";
        string str_part02_decision = "str_part02_decision";
        string str_part02_risk = "str_part02_risk";
        string str_part02_evaluation = "str_part02_evaluation";
        string str_part02_loss = "str_part02_loss";
        string str_part02_redTide = "str_part02_redTide";
        string str_part02_oil = "str_part02_oil";
        string str_part03 = "str_part03";

        string str_show_pollution = "str_show_pollution";
        string str_show_query = "str_show_query";

        string str_part01_name = "str_part01_name";
        string str_part02_decision_name = "str_part02_decision_name";
        string str_part02_risk_name = "str_part02_risk_name";
        string str_part02_evaluation_name = "str_part02_evaluation_name";
        string str_part02_loss_name = "str_part02_loss_name";
        string str_part02_redTide_name = "str_part02_redTide_name";
        string str_part02_oil_name = "str_part02_oil_name";
        string str_part03_name = "str_part03_name";

        string str_show_pollution_name = "str_show_pollution_name";
        string str_show_query_name = "str_show_query_name";

        string strPath = "";    //当前按钮对应的地址值
        string strPath_name = "";    //当前按钮对应地址的文件名

        public static string bt_name = "";        //全局静态变量，当前右键按钮的名称
        public static string str_computer = "";   //全局静态变量，远程电脑的ip
        public static string str_userName = "";   //全局静态变量，远程电脑的用户名
        public static string str_password = "";   //全局静态变量，远程电脑的密码
        public static string is_rememberd = "";   //全局静态变量，是否记住密码，为了方便操作，将此值转为字符串

        public static string open_default = "本地程序";   //全局静态变量，默认打开的形式

        public static Excel.Application ex = new Excel.Application();
        public static Excel.Workbook eWorkbook;
        public static Excel.Worksheet eWooksheet;

        public static GraphicsPath GetNoneTransparentRegion(Bitmap img, byte alpha)
        {
            int height = img.Height;
            int width = img.Width;
            int xStart, xEnd;
            GraphicsPath grpPath = new GraphicsPath();
            for (int y = 0; y < height; y++)
            {
                //逐行扫描
                for (int x = 0; x < width; x++)
                {
                    //略过连续透明的部分
                    while (x < width && img.GetPixel(x, y).A <= alpha)
                    {
                        x++;
                    }
                    //不透明部分
                    xStart = x;
                    while (x < width && img.GetPixel(x, y).A > alpha)
                    {
                        x++;
                    }
                    xEnd = x;
                    if (img.GetPixel(x - 1, y).A > alpha)
                    {
                        grpPath.AddRectangle(new Rectangle(xStart, y, xEnd - xStart, 1));
                    }
                }
            }
            return grpPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eWorkbook = ex.Workbooks.Open(Directory.GetCurrentDirectory() + @"\config.xlsx", Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            eWooksheet = eWorkbook.Sheets[1];
            str_part01 = eWooksheet.Cells[2, 3].Value;  //通过excel中表格的值为变量赋值
            str_part02_decision = eWooksheet.Cells[3, 3].Value;
            str_part02_risk = eWooksheet.Cells[4, 3].Value;
            str_part02_evaluation = eWooksheet.Cells[5, 3].Value;
            str_part02_loss = eWooksheet.Cells[6, 3].Value;
            str_part02_redTide = eWooksheet.Cells[7, 3].Value;
            str_part02_oil = eWooksheet.Cells[8, 3].Value;
            str_part03 = eWooksheet.Cells[9, 3].Value;

            str_show_pollution = eWooksheet.Cells[11, 3].Value;
            str_show_query = eWooksheet.Cells[12, 3].Value;

            str_part01_name = eWooksheet.Cells[2, 9].Value;  //通过excel中表格的值为变量赋值
            str_part02_decision_name = eWooksheet.Cells[3, 9].Value;
            str_part02_risk_name = eWooksheet.Cells[4, 9].Value;
            str_part02_evaluation_name = eWooksheet.Cells[5, 9].Value;
            str_part02_loss_name = eWooksheet.Cells[6, 9].Value;
            str_part02_redTide_name = eWooksheet.Cells[7, 9].Value;
            str_part02_oil_name = eWooksheet.Cells[8, 9].Value;
            str_part03_name = eWooksheet.Cells[9, 9].Value;

            str_show_pollution_name = eWooksheet.Cells[11, 9].Value;
            str_show_query_name = eWooksheet.Cells[12, 9].Value;
            
            lb_nowDate.Text = DateTime.Now.Date.ToLongDateString();
            string weekChange = "";
            #region 星期中英文兑换
            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Monday":
                    weekChange = "星期一";
                    break;
                case "Tuesday":
                    weekChange = "星期二";
                    break;
                case "Wednesday":
                    weekChange = "星期三";
                    break;
                case "Thursday":
                    weekChange = "星期四";
                    break;
                case "Friday":
                    weekChange = "星期五";
                    break;
                case "Saturday":
                    weekChange = "星期六";
                    break;
                case "Sunday":
                    weekChange = "星期日";
                    break;
            }
            #endregion
            lb_week.Text = weekChange;
            lb_hour.Text = String.Format("{0:D2}", DateTime.Now.Hour);
            lb_minite.Text = String.Format("{0:D2}", DateTime.Now.Minute);
            lb_second.Text = String.Format("{0:D2}", DateTime.Now.Second);  //个位数以前面加0的形式出现

            #region 鼠标点击按钮变换颜色
            bt_part01.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part02_decision.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part02_evaluation.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part02_loss.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part02_risk.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part02_redTide.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part02_oil.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_part03.MouseDown += new MouseEventHandler(button_MouseDown);

            bt_show_pollution.MouseDown += new MouseEventHandler(button_MouseDown);
            bt_show_query.MouseDown += new MouseEventHandler(button_MouseDown);
            

            bt_part01.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part02_decision.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part02_evaluation.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part02_loss.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part02_oil.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part02_redTide.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part02_risk.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_part03.MouseUp += new MouseEventHandler(button_MouseUp);

            bt_show_pollution.MouseUp += new MouseEventHandler(button_MouseUp);
            bt_show_query.MouseUp += new MouseEventHandler(button_MouseUp);
            
            #endregion

            #region 鼠标点击事件
            bt_part01.Click += new EventHandler(button_Click);
            bt_part02_decision.Click += new EventHandler(button_Click);
            bt_part02_evaluation.Click += new EventHandler(button_Click);
            bt_part02_loss.Click += new EventHandler(button_Click);
            bt_part02_oil.Click += new EventHandler(button_Click);
            bt_part02_redTide.Click += new EventHandler(button_Click);
            bt_part02_risk.Click += new EventHandler(button_Click);
            bt_part03.Click += new EventHandler(button_Click);

            
            bt_show_pollution.Click += new EventHandler(button_Click);
            bt_show_query.Click += new EventHandler(button_Click);
           
            #endregion

            //pictureBox1.MouseDown += new MouseEventHandler(control_MouseDown);
            //pictureBox2.MouseDown += new MouseEventHandler(control_MouseDown);
            
            
            //pictureBox2.MouseDown += new MouseEventHandler(control_MouseDown);

            #region 鼠标悬浮和离开事件
            bt_part01.MouseHover += new EventHandler(button_MouseHover);
            bt_part02_decision.MouseHover += new EventHandler(button_MouseHover);
            bt_part02_evaluation.MouseHover += new EventHandler(button_MouseHover);
            bt_part02_loss.MouseHover += new EventHandler(button_MouseHover);
            bt_part02_oil.MouseHover += new EventHandler(button_MouseHover);
            bt_part02_redTide.MouseHover += new EventHandler(button_MouseHover);
            bt_part02_risk.MouseHover += new EventHandler(button_MouseHover);
            bt_part03.MouseHover += new EventHandler(button_MouseHover);
            bt_about.MouseHover += new EventHandler(button_MouseHover);
            bt_help.MouseHover += new EventHandler(button_MouseHover);
            bt_quit.MouseHover += new EventHandler(button_MouseHover);

            
            bt_show_pollution.MouseHover += new EventHandler(button_MouseHover);
            bt_show_query.MouseHover += new EventHandler(button_MouseHover);
            

            bt_part01.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part02_decision.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part02_evaluation.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part02_loss.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part02_oil.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part02_redTide.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part02_risk.MouseLeave += new EventHandler(button_MouseLeave);
            bt_part03.MouseLeave += new EventHandler(button_MouseLeave);
            bt_about.MouseLeave += new EventHandler(button_MouseLeave);
            bt_help.MouseLeave += new EventHandler(button_MouseLeave);
            bt_quit.MouseLeave += new EventHandler(button_MouseLeave);

            
            bt_show_pollution.MouseLeave += new EventHandler(button_MouseLeave);
            bt_show_query.MouseLeave += new EventHandler(button_MouseLeave);
            
            #endregion

            //ToolTip tip = new ToolTip();
            //tip.BackColor = Color.Red;
            //tip.ForeColor = Color.Blue;
            //tip.ToolTipTitle = "使用说明：";
            //tip.SetToolTip(bt_part01, "单击左键打开系统，单击右键弹出菜单栏，" + Environment.NewLine + "可以显示当前系统的路径、修改当前系统的路径。");
            //tip.IsBalloon = true;

            pb_part01.Visible = false;
            bt_part01.Text = "";
            bt_part01.BackColor = Color.Black;

            pb_part03.Visible = false;
            bt_part03.Text = "";
            bt_part03.BackColor = Color.Black;

            pb_part02_risk.Visible = false;
            bt_part02_risk.Text = "";
            bt_part02_risk.BackColor = Color.Black;

            pb_part02_loss.Visible = false;
            bt_part02_loss.Text = "";
            bt_part02_loss.BackColor = Color.Black;

            pb_part02_evaluation.Visible = false;
            bt_part02_evaluation.Text = "";
            bt_part02_evaluation.BackColor = Color.Black;

            pb_part02_decision.Visible = false;
            bt_part02_decision.Text = "";
            bt_part02_decision.BackColor = Color.Black;

            pb_part02_redTide.Visible = false;
            bt_part02_redTide.Text = "";
            bt_part02_redTide.BackColor = Color.Black;

            pb_part02_oil.Visible = false;
            bt_part02_oil.Text = "";
            bt_part02_oil.BackColor = Color.Black;

            pb_show_pollution.Visible = false;
            bt_show_pollution.Text = "";
            bt_show_pollution.BackColor = Color.Black;

            pb_show_query.Visible = false;
            bt_show_query.Text = "";
            bt_show_query.BackColor = Color.Black;

            pb_about.Visible = false;
            bt_about.Text = "";
            bt_about.BackColor = Color.Black;

            pb_help.Visible = false;
            bt_help.Text = "";
            bt_help.BackColor = Color.Black;

            pb_quit.Visible = false;
            bt_quit.Text = "";
            bt_quit.BackColor = Color.Black;

            String ls_appPath = System.Windows.Forms.Application.StartupPath + "\\font\\";//font是程序

            String fontFile1 = ls_appPath + "LCDM2N__.TTF";
            String fontFile2 = ls_appPath + "张海山锐线体简1.0.TTF";

            System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();

            pfc.AddFontFile(fontFile1);//字体文件的路径
            pfc.AddFontFile(fontFile2);//字体文件的路径

            Font myFont1 = new Font(pfc.Families[0], lb_hour.Font.Size);//myFont1就是你创建的字体对象
            Font myFont2 = new Font(pfc.Families[1], lb_nowDate.Font.Size);//myFont1就是你创建的字体对象

            lb_hour.Font = lb_mh1.Font = lb_mh2.Font = lb_minite.Font = lb_second.Font = myFont1;
            lb_nowDate.Font = lb_week.Font = myFont2;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_second.Text = String.Format("{0:D2}", DateTime.Now.Second);  //个位数以前面加0的形式出现
            if (DateTime.Now.Second == 0)
            {
                lb_minite.Text = String.Format("{0:D2}", DateTime.Now.Minute);
                if (DateTime.Now.Minute == 0)
                {
                    lb_hour.Text = String.Format("{0:D2}", DateTime.Now.Hour);
                    if (DateTime.Now.Hour == 0)
                    {
                        lb_nowDate.Text = DateTime.Now.Date.ToLongDateString();
                    }
                }
            }
        }

        //定义全部按钮的MouseDown事件
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;

            if (e.Button == MouseButtons.Right)
            {
                //获取此按钮对应的默认打开形式
                switch (bt.Name)
                {
                    case "bt_part01":
                        open_default = MainForm.eWooksheet.Range["H2:H2"].Value;
                        break;
                    case "bt_part02_decision":
                        open_default = MainForm.eWooksheet.Range["H3:H3"].Value;
                        break;
                    case "bt_part02_risk":
                        open_default = MainForm.eWooksheet.Range["H4:H4"].Value;
                        break;
                    case "bt_part02_evaluation":
                        open_default = MainForm.eWooksheet.Range["H5:H5"].Value;
                        break;
                    case "bt_part02_loss":
                        open_default = MainForm.eWooksheet.Range["H6:H6"].Value;
                        break;
                    case "bt_part02_redTide":
                        open_default = MainForm.eWooksheet.Range["H7:H7"].Value;
                        break;
                    case "bt_part02_oil":
                        open_default = MainForm.eWooksheet.Range["H8:H8"].Value;
                        break;
                    case "bt_part03":
                        open_default = MainForm.eWooksheet.Range["H9:H9"].Value;
                        break;
                    case "bt_show_pollution":
                        open_default = MainForm.eWooksheet.Range["H11:H11"].Value;
                        break;
                    case "bt_show_query":
                        open_default = MainForm.eWooksheet.Range["H12:H12"].Value;
                        break;
                }

                //根据默认的打开方式，选择性使一些功能失效
                if (open_default == "本机程序")
                {
                    item_showTscInfo.Enabled = false;
                    item_editTscLogin.Enabled = false;
                    item_showLocalPath.Enabled = true;
                    item_editLocalPath.Enabled = true;
                }
                else
                {
                    item_showLocalPath.Enabled = false;
                    item_editLocalPath.Enabled = false;
                    item_showTscInfo.Enabled = true;
                    item_editTscLogin.Enabled = true;
                }

                //根据按钮的名称确定被点击的按钮，然后将此按钮对应的地址值赋给strPath
                switch (bt.Name)
                {
                    case "bt_part01":
                        strPath = str_part01;
                        strPath_name = str_part01_name;
                        break;
                    case "bt_part02_decision":
                        strPath = str_part02_decision;
                        strPath_name = str_part02_decision_name;
                        break;
                    case "bt_part02_evaluation":
                        strPath = str_part02_evaluation;
                        strPath_name = str_part02_evaluation_name;
                        break;
                    case "bt_part02_loss":
                        strPath = str_part02_loss;
                        strPath_name = str_part02_loss_name;
                        break;
                    case "bt_part02_oil":
                        strPath = str_part02_oil;
                        strPath_name = str_part02_oil_name;
                        break;
                    case "bt_part02_redTide":
                        strPath = str_part02_redTide;
                        strPath_name = str_part02_redTide_name;
                        break;
                    case "bt_part02_risk":
                        strPath = str_part02_risk;
                        strPath_name = str_part02_risk_name;
                        break;
                    case "bt_part03":
                        strPath = str_part03;
                        strPath_name = str_part03_name;
                        break;
                    case "bt_show_pollution":
                        strPath = str_show_pollution;
                        strPath_name = str_show_pollution_name;
                        break;
                    case "bt_show_query":
                        strPath = str_show_query;
                        strPath_name = str_show_query_name;
                        break;
                  }
                bt_name = bt.Name;  //将点击了右键的按钮赋值给bt_name
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.Black;
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        //定义全部按钮的MouseUp事件
        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.White;
        }
       
        //定义全部按钮的ButtonClick事件
        private void button_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;   //提取出当前点击的按钮

            //获取此按钮对应的默认打开形式
            switch (bt.Name)
            {
                case "bt_part01":
                    open_default = MainForm.eWooksheet.Range["H2:H2"].Value;
                    break;
                case "bt_part02_decision":
                    open_default = MainForm.eWooksheet.Range["H3:H3"].Value;
                    break;
                case "bt_part02_risk":
                    open_default = MainForm.eWooksheet.Range["H4:H4"].Value;
                    break;
                case "bt_part02_evaluation":
                    open_default = MainForm.eWooksheet.Range["H5:H5"].Value;
                    break;
                case "bt_part02_loss":
                    open_default = MainForm.eWooksheet.Range["H6:H6"].Value;
                    break;
                case "bt_part02_redTide":
                    open_default = MainForm.eWooksheet.Range["H7:H7"].Value;
                    break;
                case "bt_part02_oil":
                    open_default = MainForm.eWooksheet.Range["H8:H8"].Value;
                    break;
                case "bt_part03":
                    open_default = MainForm.eWooksheet.Range["H9:H9"].Value;
                    break;
                case "bt_show_pollution":
                    open_default = MainForm.eWooksheet.Range["H11:H11"].Value;
                    break;
                case "bt_show_query":
                    open_default = MainForm.eWooksheet.Range["H12:H12"].Value;
                    break;
            }

            if (open_default == "本机程序")
            {
                //打开程序之前提醒“是否要打开此程序”
                //DialogResult dr = MessageBox.Show("是否要打开" + open_default + "？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (dr == DialogResult.Yes)
                //{
                    switch (bt.Name)
                    {
                        case "bt_part01":
                            strPath = str_part01;
                            strPath_name = str_part01_name;
                            break;
                        case "bt_part02_decision":
                            strPath = str_part02_decision;
                            strPath_name = str_part02_decision_name;
                            break;
                        case "bt_part02_evaluation":
                            strPath = str_part02_evaluation;
                            strPath_name = str_part02_evaluation_name;
                            break;
                        case "bt_part02_loss":
                            strPath = str_part02_loss;
                            strPath_name = str_part02_loss_name;
                            break;
                        case "bt_part02_oil":
                            strPath = str_part02_oil;
                            strPath_name = str_part02_oil_name;
                            break;
                        case "bt_part02_redTide":
                            strPath = str_part02_redTide;
                            strPath_name = str_part02_redTide_name;
                            break;
                        case "bt_part02_risk":
                            strPath = str_part02_risk;
                            strPath_name = str_part02_risk_name;
                            break;
                        case "bt_part03":
                            strPath = str_part03;
                            strPath_name = str_part03_name;
                            break;
                        case "bt_show_pollution":
                            strPath = str_show_pollution;
                            strPath_name = str_show_pollution_name;
                            break;
                        case "bt_show_query":
                            strPath = str_show_query;
                            strPath_name = str_show_query_name;
                            break;
                    }
                    try
                    {
                        //判断程序是否已经打开了，对于已经打开的程序，不打开第二个
                        Process[] temp = Process.GetProcessesByName(strPath_name);
                        if (temp.Length > 0)
                            MessageBox.Show("程序“" + strPath_name + "”已经打开！", "错误提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            ProcessStartInfo info = new ProcessStartInfo(strPath);
                            info.WorkingDirectory = Path.GetDirectoryName(strPath);
                            Process.Start(info);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n解决办法：可以通过在按钮上点击右键重新设置程序的路径。", "打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
            }
            else       //打开远程桌面
            {
                try
                    {
                        //根据当前按钮来提取三个值
                        switch (bt.Name)
                        {
                            case "bt_part01":
                                str_computer = eWooksheet.Range["D2:D2"].Value.ToString();
                                str_userName = eWooksheet.Range["E2:E2"].Value.ToString();
                                str_password = eWooksheet.Range["F2:F2"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G2:G2"].Value.ToString();
                                break;
                            case "bt_part02_decision":
                                str_computer = eWooksheet.Range["D3:D3"].Value.ToString();
                                str_userName = eWooksheet.Range["E3:E3"].Value.ToString();
                                str_password = eWooksheet.Range["F3:F3"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G3:G3"].Value.ToString();
                                break;
                            case "bt_part02_risk":
                                str_computer = eWooksheet.Range["D4:D4"].Value.ToString();
                                str_userName = eWooksheet.Range["E4:E4"].Value.ToString();
                                str_password = eWooksheet.Range["F4:F4"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G4:G4"].Value.ToString();
                                break;
                            case "bt_part02_evaluation":
                                str_computer = eWooksheet.Range["D5:D5"].Value.ToString();
                                str_userName = eWooksheet.Range["E5:E5"].Value.ToString();
                                str_password = eWooksheet.Range["F5:F5"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G5:G5"].Value.ToString();
                                break;
                            case "bt_part02_loss":
                                str_computer = eWooksheet.Range["D6:D6"].Value.ToString();
                                str_userName = eWooksheet.Range["E6:E6"].Value.ToString();
                                str_password = eWooksheet.Range["F6:F6"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G6:G6"].Value.ToString();
                                break;
                            case "bt_part02_redTide":
                                str_computer = eWooksheet.Range["D7:D7"].Value.ToString();
                                str_userName = eWooksheet.Range["E7:E7"].Value.ToString();
                                str_password = eWooksheet.Range["F7:F7"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G7:G7"].Value.ToString();
                                break;
                            case "bt_part02_oil":
                                str_computer = eWooksheet.Range["D8:D8"].Value.ToString();
                                str_userName = eWooksheet.Range["E8:E8"].Value.ToString();
                                str_password = eWooksheet.Range["F8:F8"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G8:G8"].Value.ToString();
                                break;
                            case "bt_part03":
                                str_computer = eWooksheet.Range["D9:D9"].Value.ToString();
                                str_userName = eWooksheet.Range["E9:E9"].Value.ToString();
                                str_password = eWooksheet.Range["F9:F9"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G9:G9"].Value.ToString();
                                break;
                            case "bt_show_pollution":
                                str_computer = eWooksheet.Range["D11:D11"].Value.ToString();
                                str_userName = eWooksheet.Range["E11:E11"].Value.ToString();
                                str_password = eWooksheet.Range["F11:F11"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G11:G11"].Value.ToString();
                                break;
                            case "bt_show_query":
                                str_computer = eWooksheet.Range["D12:D12"].Value.ToString();
                                str_userName = eWooksheet.Range["E12:E12"].Value.ToString();
                                str_password = eWooksheet.Range["F12:F12"].Value.ToString();
                                is_rememberd = eWooksheet.Range["G12:G12"].Value.ToString();
                                break;
                        }

                        //LoginForm frm_login = new LoginForm();
                        //frm_login.Visible = false;
                        //frm_login.sh
                        //frm_login.bt_connect_Click(frm_login.bt_connect, e);

                        //直接打开新的窗体
                        TscForm frm_TSC = new TscForm();
                        frm_TSC.Width = SystemInformation.WorkingArea.Width;
                        frm_TSC.Height = SystemInformation.WorkingArea.Height;
                        frm_TSC.WindowState = FormWindowState.Maximized;
                        frm_TSC.Show();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n解决办法：可以通过在按钮上点击右键重新设置远程桌面。", "打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        //定义全部按钮的右键第一个功能 - 显示
        private void 显示当前程序的路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("当前程序的路径为：\n" + strPath, "当前程序的路径信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //定义全部按钮的右键第二个功能 - 修改
        private void 修改当前程序的路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择需要默认打开的应用";
            DialogResult ofd_dr = ofd.ShowDialog();
            if (ofd_dr == DialogResult.OK)  //点击了选取的文件
            {
                DialogResult dr = MessageBox.Show("确认将当前程序修改为如下的路径吗？\n" + ofd.FileName, "修改提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    //将此事的浏览地址赋值给当前按钮对应的地址值，如何判断当前按钮的地址变量？
                    //由于在点击按钮的时候给strPath赋予了与当前按钮地址变量一样的地址
                    if (strPath == str_part01)
                    {
                        str_part01 = ofd.FileName;
                        str_part01_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part02_decision)
                    {
                        str_part02_decision = ofd.FileName;
                        str_part02_decision_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part02_evaluation)
                    {
                        str_part02_evaluation = ofd.FileName;
                        str_part02_evaluation_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part02_loss)
                    {
                        str_part02_loss = ofd.FileName;
                        str_part02_loss_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part02_oil)
                    {
                        str_part02_oil = ofd.FileName;
                        str_part02_oil_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part02_redTide)
                    {
                        str_part02_redTide = ofd.FileName;
                        str_part02_redTide_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part02_risk)
                    {
                        str_part02_risk = ofd.FileName;
                        str_part02_risk_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_part03)
                    {
                        str_part03 = ofd.FileName;
                        str_part03_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_show_pollution)
                    {
                        str_show_pollution = ofd.FileName;
                        str_show_pollution_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }
                    if (strPath == str_show_query)
                    {
                        str_show_query = ofd.FileName;
                        str_show_query_name = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1, ofd.FileName.LastIndexOf('.') - ofd.FileName.LastIndexOf('\\') - 1);
                    }

                    strPath = ofd.FileName;
                    MessageBox.Show("导入成功！当前程序的路径为：\n" + strPath, "路径导入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("导入失败！当前程序的路径仍然为：\n" + strPath, "路径导入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //将变量值赋值给单元格
            eWooksheet.Cells[2, 3].Value = str_part01;
            eWooksheet.Cells[3, 3].Value = str_part02_decision;
            eWooksheet.Cells[4, 3].Value = str_part02_risk;
            eWooksheet.Cells[5, 3].Value = str_part02_evaluation;
            eWooksheet.Cells[6, 3].Value = str_part02_loss;
            eWooksheet.Cells[7, 3].Value = str_part02_redTide;
            eWooksheet.Cells[8, 3].Value = str_part02_oil;
            eWooksheet.Cells[9, 3].Value = str_part03;

            eWooksheet.Cells[11, 3].Value = str_show_pollution;
            eWooksheet.Cells[12, 3].Value = str_show_query;

            eWooksheet.Cells[2, 9].Value = str_part01_name;
            eWooksheet.Cells[3, 9].Value = str_part02_decision_name;
            eWooksheet.Cells[4, 9].Value = str_part02_risk_name;
            eWooksheet.Cells[5, 9].Value = str_part02_evaluation_name;
            eWooksheet.Cells[6, 9].Value = str_part02_loss_name;
            eWooksheet.Cells[7, 9].Value = str_part02_redTide_name;
            eWooksheet.Cells[8, 9].Value = str_part02_oil_name;
            eWooksheet.Cells[9, 9].Value = str_part03_name;

            eWooksheet.Cells[11, 9].Value = str_show_pollution_name;
            eWooksheet.Cells[12, 9].Value = str_show_query_name;

            eWorkbook.Save();   //保存
            eWorkbook.Close();  //关闭
            ex.Quit();          //退出excel程序
        }

        //鼠标悬浮在按钮上显示小手
        private void button_MouseHover(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.FlatAppearance.BorderSize = 1;
            Cursor = Cursors.Hand;
        }

        //鼠标离开显示正常
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Arrow;
        }

        private void 通过远程桌面登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //根据当前按钮来提取三个值
            switch (bt_name)
            {
                case "bt_part01":
                    str_computer = eWooksheet.Range["D2:D2"].Value.ToString();
                    str_userName = eWooksheet.Range["E2:E2"].Value.ToString();
                    str_password = eWooksheet.Range["F2:F2"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G2:G2"].Value.ToString();
                    break;
                case "bt_part02_decision":
                    str_computer = eWooksheet.Range["D3:D3"].Value.ToString();
                    str_userName = eWooksheet.Range["E3:E3"].Value.ToString();
                    str_password = eWooksheet.Range["F3:F3"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G3:G3"].Value.ToString();
                    break;
                case "bt_part02_risk":
                    str_computer = eWooksheet.Range["D4:D4"].Value.ToString();
                    str_userName = eWooksheet.Range["E4:E4"].Value.ToString();
                    str_password = eWooksheet.Range["F4:F4"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G4:G4"].Value.ToString();
                    break;
                case "bt_part02_evaluation":
                    str_computer = eWooksheet.Range["D5:D5"].Value.ToString();
                    str_userName = eWooksheet.Range["E5:E5"].Value.ToString();
                    str_password = eWooksheet.Range["F5:F5"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G5:G5"].Value.ToString();
                    break;
                case "bt_part02_loss":
                    str_computer = eWooksheet.Range["D6:D6"].Value.ToString();
                    str_userName = eWooksheet.Range["E6:E6"].Value.ToString();
                    str_password = eWooksheet.Range["F6:F6"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G6:G6"].Value.ToString();
                    break;
                case "bt_part02_redTide":
                    str_computer = eWooksheet.Range["D7:D7"].Value.ToString();
                    str_userName = eWooksheet.Range["E7:E7"].Value.ToString();
                    str_password = eWooksheet.Range["F7:F7"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G7:G7"].Value.ToString();
                    break;
                case "bt_part02_oil":
                    str_computer = eWooksheet.Range["D8:D8"].Value.ToString();
                    str_userName = eWooksheet.Range["E8:E8"].Value.ToString();
                    str_password = eWooksheet.Range["F8:F8"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G8:G8"].Value.ToString();
                    break;
                case "bt_part03":
                    str_computer = eWooksheet.Range["D9:D9"].Value.ToString();
                    str_userName = eWooksheet.Range["E9:E9"].Value.ToString();
                    str_password = eWooksheet.Range["F9:F9"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G9:G9"].Value.ToString();
                    break;
                case "bt_show_pollution":
                    str_computer = eWooksheet.Range["D11:D11"].Value.ToString();
                    str_userName = eWooksheet.Range["E11:E11"].Value.ToString();
                    str_password = eWooksheet.Range["F11:F11"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G11:G11"].Value.ToString();
                    break;
                case "bt_show_query":
                    str_computer = eWooksheet.Range["D12:D12"].Value.ToString();
                    str_userName = eWooksheet.Range["E12:E12"].Value.ToString();
                    str_password = eWooksheet.Range["F12:F12"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G12:G12"].Value.ToString();
                    break;
            }

            LoginForm frm_login = new LoginForm();
            frm_login.ShowDialog();
        }

        private void 选择默认进入的形式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseForm frm = new ChooseForm();
            frm.ShowDialog();
        }

        private void item_showTscInfo_Click(object sender, EventArgs e)
        {
            //根据当前按钮来提取三个值
            switch (bt_name)
            {
                case "bt_part01":
                    str_computer = eWooksheet.Range["D2:D2"].Value.ToString();
                    str_userName = eWooksheet.Range["E2:E2"].Value.ToString();
                    str_password = eWooksheet.Range["F2:F2"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G2:G2"].Value.ToString();
                    break;
                case "bt_part02_decision":
                    str_computer = eWooksheet.Range["D3:D3"].Value.ToString();
                    str_userName = eWooksheet.Range["E3:E3"].Value.ToString();
                    str_password = eWooksheet.Range["F3:F3"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G3:G3"].Value.ToString();
                    break;
                case "bt_part02_risk":
                    str_computer = eWooksheet.Range["D4:D4"].Value.ToString();
                    str_userName = eWooksheet.Range["E4:E4"].Value.ToString();
                    str_password = eWooksheet.Range["F4:F4"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G4:G4"].Value.ToString();
                    break;
                case "bt_part02_evaluation":
                    str_computer = eWooksheet.Range["D5:D5"].Value.ToString();
                    str_userName = eWooksheet.Range["E5:E5"].Value.ToString();
                    str_password = eWooksheet.Range["F5:F5"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G5:G5"].Value.ToString();
                    break;
                case "bt_part02_loss":
                    str_computer = eWooksheet.Range["D6:D6"].Value.ToString();
                    str_userName = eWooksheet.Range["E6:E6"].Value.ToString();
                    str_password = eWooksheet.Range["F6:F6"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G6:G6"].Value.ToString();
                    break;
                case "bt_part02_redTide":
                    str_computer = eWooksheet.Range["D7:D7"].Value.ToString();
                    str_userName = eWooksheet.Range["E7:E7"].Value.ToString();
                    str_password = eWooksheet.Range["F7:F7"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G7:G7"].Value.ToString();
                    break;
                case "bt_part02_oil":
                    str_computer = eWooksheet.Range["D8:D8"].Value.ToString();
                    str_userName = eWooksheet.Range["E8:E8"].Value.ToString();
                    str_password = eWooksheet.Range["F8:F8"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G8:G8"].Value.ToString();
                    break;
                case "bt_part03":
                    str_computer = eWooksheet.Range["D9:D9"].Value.ToString();
                    str_userName = eWooksheet.Range["E9:E9"].Value.ToString();
                    str_password = eWooksheet.Range["F9:F9"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G9:G9"].Value.ToString();
                    break;
                case "bt_show_pollution":
                    str_computer = eWooksheet.Range["D11:D11"].Value.ToString();
                    str_userName = eWooksheet.Range["E11:E11"].Value.ToString();
                    str_password = eWooksheet.Range["F11:F11"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G11:G11"].Value.ToString();
                    break;
                case "bt_show_query":
                    str_computer = eWooksheet.Range["D12:D12"].Value.ToString();
                    str_userName = eWooksheet.Range["E12:E12"].Value.ToString();
                    str_password = eWooksheet.Range["F12:F12"].Value.ToString();
                    is_rememberd = eWooksheet.Range["G12:G12"].Value.ToString();
                    break;
            }
            MessageBox.Show("远程桌面的信息为：\n计算机 (C)：" + str_computer + "\n用户名：" + str_userName + "\n密码：********"
            ,"当前程序的路径信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_quit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否要退出当前系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bt_quit_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.Black;
        }

        private void bt_quit_MouseUp(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.White;
        }

        private void bt_help_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("单击左键可以进入相应的系统；\n单击右键可以弹出菜单，能够实现修改程序路径。", "系统帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(Directory.GetCurrentDirectory() + @"\CHM-OR.CHM");
        }

        private void bt_help_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.Black;
            
        }

        private void bt_help_MouseUp(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.White;
        }

        private void 系统帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetCurrentDirectory() + @"\CHM-OR.CHM");
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否要退出当前系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyForm frm = new PropertyForm();
            frm.ShowDialog();
        }

        private void 关于系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void bt_part01_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part01.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part01.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part01.BackgroundImage = pb_part01.Image;
            bt_part01.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part01.Width = pb_part01.Image.Width;
            bt_part01.Height = pb_part01.Image.Height;
        }

        private void bt_part03_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part03.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part03.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part03.BackgroundImage = pb_part03.Image;
            bt_part03.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part03.Width = pb_part03.Image.Width;
            bt_part03.Height = pb_part03.Image.Height;
        }

        private void bt_part02_risk_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part02_risk.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part02_risk.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part02_risk.BackgroundImage = pb_part02_risk.Image;
            bt_part02_risk.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part02_risk.Width = pb_part02_risk.Image.Width;
            bt_part02_risk.Height = pb_part02_risk.Image.Height;
        }

        private void bt_part02_loss_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part02_loss.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part02_loss.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part02_loss.BackgroundImage = pb_part02_loss.Image;
            bt_part02_loss.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part02_loss.Width = pb_part02_loss.Image.Width;
            bt_part02_loss.Height = pb_part02_loss.Image.Height;
        }

        private void bt_part02_evaluation_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part02_evaluation.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part02_evaluation.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part02_evaluation.BackgroundImage = pb_part02_evaluation.Image;
            bt_part02_evaluation.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part02_evaluation.Width = pb_part02_evaluation.Image.Width;
            bt_part02_evaluation.Height = pb_part02_evaluation.Image.Height;
        }

        private void bt_part02_decision_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part02_decision.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part02_decision.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part02_decision.BackgroundImage = pb_part02_decision.Image;
            bt_part02_decision.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part02_decision.Width = pb_part02_decision.Image.Width;
            bt_part02_decision.Height = pb_part02_decision.Image.Height;
        }

        private void bt_part02_redTide_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part02_redTide.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part02_redTide.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part02_redTide.BackgroundImage = pb_part02_redTide.Image;
            bt_part02_redTide.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part02_redTide.Width = pb_part02_redTide.Image.Width;
            bt_part02_redTide.Height = pb_part02_redTide.Image.Height;
        }

        private void bt_part02_oil_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_part02_oil.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_part02_oil.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_part02_oil.BackgroundImage = pb_part02_oil.Image;
            bt_part02_oil.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_part02_oil.Width = pb_part02_oil.Image.Width;
            bt_part02_oil.Height = pb_part02_oil.Image.Height;
        }

        private void bt_show_pollution_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_show_pollution.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_show_pollution.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_show_pollution.BackgroundImage = pb_show_pollution.Image;
            bt_show_pollution.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_show_pollution.Width = pb_show_pollution.Image.Width;
            bt_show_pollution.Height = pb_show_pollution.Image.Height;
        }

        private void bt_show_query_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_show_query.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_show_query.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_show_query.BackgroundImage = pb_show_query.Image;
            bt_show_query.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_show_query.Width = pb_show_query.Image.Width;
            bt_show_query.Height = pb_show_query.Image.Height;
        }

        private void bt_about_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_about.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_about.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_about.BackgroundImage = pb_about.Image;
            bt_about.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_about.Width = pb_about.Image.Width;
            bt_about.Height = pb_about.Image.Height;
        }

        private void bt_help_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_help.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_help.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_help.BackgroundImage = pb_help.Image;
            bt_help.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_help.Width = pb_help.Image.Width;
            bt_help.Height = pb_help.Image.Height;
        }

        private void bt_quit_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = (Bitmap)pb_quit.Image;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 10);
            bt_quit.Region = new Region(grapth);
            //要显示的图片设置为窗体背景；            
            bt_quit.BackgroundImage = pb_quit.Image;
            bt_quit.BackgroundImageLayout = ImageLayout.Zoom;
            //在修改窗体尺寸之前设置窗体为无边框样式；            
            bt_quit.Width = pb_quit.Image.Width;
            bt_quit.Height = pb_quit.Image.Height;
        }


        
    }
}
