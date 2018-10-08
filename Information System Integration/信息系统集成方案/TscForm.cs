using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSTSCLib;

namespace 信息系统集成方案
{
    public partial class TscForm : Form
    {
        public TscForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                axMsTscAxNotSafeForScripting1.Server = MainForm.str_computer;
                axMsTscAxNotSafeForScripting1.UserName = MainForm.str_userName;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)axMsTscAxNotSafeForScripting1.GetOcx();
                secured.ClearTextPassword = MainForm.str_password;
                axMsTscAxNotSafeForScripting1.Connect();

                //连接成功的话，将当前的连接信息存储到相应的按钮上
                switch (MainForm.bt_name)
                {
                    case "bt_part01":
                        MainForm.eWooksheet.Range["D2:D2"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E2:E2"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F2:F2"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G2:G2"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part02_decision":
                        MainForm.eWooksheet.Range["D3:D3"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E3:E3"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F3:F3"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G3:G3"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part02_risk":
                        MainForm.eWooksheet.Range["D4:D4"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E4:E4"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F4:F4"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G4:G4"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part02_evaluation":
                        MainForm.eWooksheet.Range["D5:D5"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E5:E5"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F5:F5"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G5:G5"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part02_loss":
                        MainForm.eWooksheet.Range["D6:D6"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E6:E6"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F6:F6"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G6:G6"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part02_redTide":
                        MainForm.eWooksheet.Range["D7:D7"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E7:E7"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F7:F7"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G7:G7"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part02_oil":
                        MainForm.eWooksheet.Range["D8:D8"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E8:E8"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F8:F8"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G8:G8"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_part03":
                        MainForm.eWooksheet.Range["D9:D9"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E9:E9"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F9:F9"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G9:G9"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_show_land":
                        MainForm.eWooksheet.Range["D10:D10"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E10:E10"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F10:F10"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G10:G10"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_show_pollution":
                        MainForm.eWooksheet.Range["D11:D11"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E11:E11"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F11:F11"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G11:G11"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_show_query":
                        MainForm.eWooksheet.Range["D12:D12"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E12:E12"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F12:F12"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G12:G12"].Value = MainForm.is_rememberd;
                        break;
                    case "bt_show_redTide":
                        MainForm.eWooksheet.Range["D13:D13"].Value = MainForm.str_computer;
                        MainForm.eWooksheet.Range["E13:E13"].Value = MainForm.str_userName;
                        MainForm.eWooksheet.Range["F13:F13"].Value = MainForm.str_password;
                        MainForm.eWooksheet.Range["G13:G13"].Value = MainForm.is_rememberd;
                        break;
                }

                if (!Convert.ToBoolean(MainForm.is_rememberd)) //对于不记住密码的情况，将上述记录的密码都删除掉
                {
                    MainForm.eWooksheet.Range["F2:F2"].Value = "";
                    MainForm.eWooksheet.Range["F3:F3"].Value = "";
                    MainForm.eWooksheet.Range["F4:F4"].Value = "";
                    MainForm.eWooksheet.Range["F5:F5"].Value = "";
                    MainForm.eWooksheet.Range["F6:F6"].Value = "";
                    MainForm.eWooksheet.Range["F7:F7"].Value = "";
                    MainForm.eWooksheet.Range["F8:F8"].Value = "";
                    MainForm.eWooksheet.Range["F9:F9"].Value = "";
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
