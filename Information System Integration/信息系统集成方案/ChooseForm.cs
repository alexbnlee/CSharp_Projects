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
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            InitializeComponent();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            //确定后，若“本地程序”按钮选中，则赋值为“本地程序”，若“远程桌面”按钮选中，则赋值为“远程桌面”
            if (rb_local.Checked == true)
            {
                MainForm.open_default = "本机程序";
            }
            else
            {
                MainForm.open_default = "远程桌面";
            }

            //将上面的值，赋值给相应的button
            switch (MainForm.bt_name)
            {
                case "bt_part01":
                    MainForm.eWooksheet.Range["H2:H2"].Value = MainForm.open_default;
                    break;
                case "bt_part02_decision":
                    MainForm.eWooksheet.Range["H3:H3"].Value = MainForm.open_default;
                    break;
                case "bt_part02_risk":
                    MainForm.eWooksheet.Range["H4:H4"].Value = MainForm.open_default;
                    break;
                case "bt_part02_evaluation":
                    MainForm.eWooksheet.Range["H5:H5"].Value = MainForm.open_default;
                    break;
                case "bt_part02_loss":
                    MainForm.eWooksheet.Range["H6:H6"].Value = MainForm.open_default;
                    break;
                case "bt_part02_redTide":
                    MainForm.eWooksheet.Range["H7:H7"].Value = MainForm.open_default;
                    break;
                case "bt_part02_oil":
                    MainForm.eWooksheet.Range["H8:H8"].Value = MainForm.open_default;
                    break;
                case "bt_part03":
                    MainForm.eWooksheet.Range["H9:H9"].Value = MainForm.open_default;
                    break;
                case "bt_show_land":
                    MainForm.eWooksheet.Range["H10:H10"].Value = MainForm.open_default;
                    break;
                case "bt_show_pollution":
                    MainForm.eWooksheet.Range["H11:H11"].Value = MainForm.open_default;
                    break;
                case "bt_show_query":
                    MainForm.eWooksheet.Range["H12:H12"].Value = MainForm.open_default;
                    break;
                case "bt_show_redTide":
                    MainForm.eWooksheet.Range["H13:H13"].Value = MainForm.open_default;
                    break;
            }

            this.Close();
        }

        private void ChooseForm_Load(object sender, EventArgs e)
        {
            //通过之前存在excel中的数据来赋值
            string open_default_button = "";
            switch (MainForm.bt_name)
            {
                case "bt_part01":
                    open_default_button = MainForm.eWooksheet.Range["H2:H2"].Value;
                    break;
                case "bt_part02_decision":
                    open_default_button = MainForm.eWooksheet.Range["H3:H3"].Value;
                    break;
                case "bt_part02_risk":
                    open_default_button = MainForm.eWooksheet.Range["H4:H4"].Value;
                    break;
                case "bt_part02_evaluation":
                    open_default_button = MainForm.eWooksheet.Range["H5:H5"].Value;
                    break;
                case "bt_part02_loss":
                    open_default_button = MainForm.eWooksheet.Range["H6:H6"].Value;
                    break;
                case "bt_part02_redTide":
                    open_default_button = MainForm.eWooksheet.Range["H7:H7"].Value;
                    break;
                case "bt_part02_oil":
                    open_default_button = MainForm.eWooksheet.Range["H8:H8"].Value;
                    break;
                case "bt_part03":
                    open_default_button = MainForm.eWooksheet.Range["H9:H9"].Value;
                    break;
                case "bt_show_land":
                    open_default_button = MainForm.eWooksheet.Range["H10:H10"].Value;
                    break;
                case "bt_show_pollution":
                    open_default_button = MainForm.eWooksheet.Range["H11:H11"].Value;
                    break;
                case "bt_show_query":
                    open_default_button = MainForm.eWooksheet.Range["H12:H12"].Value;
                    break;
                case "bt_show_redTide":
                    open_default_button = MainForm.eWooksheet.Range["H13:H13"].Value;
                    break;
            }

            //如果是“本地程序”，则将“本地程序”按钮选中，否则将“远程桌面”按钮选中
            if (open_default_button == "本机程序")
            {
                rb_local.Checked = true;
            }
            else
            {
                rb_tsc.Checked = true;
            }
        }
    }
}
