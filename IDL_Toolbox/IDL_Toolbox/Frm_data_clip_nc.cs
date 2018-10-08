using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace IDL_Toolbox
{
    public partial class Frm_clip_data_nc : Form
    {
        public Frm_clip_data_nc()
        {
            InitializeComponent();
        }

        string cmbox_input_str = "";

        private void btn_input_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dbd = new FolderBrowserDialog();
            dbd.SelectedPath = cmbox_input.Text;
            if (dbd.ShowDialog() == DialogResult.OK)
            {
                int flag = 0;
                cmbox_input.Text = dbd.SelectedPath;
                //判断是否有此路径，如果有的话不添加，否则添加
                foreach (string str_item in cmbox_input.Items)
                {
                    //判断是否有一致，没有的话，再添加
                    if (dbd.SelectedPath == str_item)
                        flag = 1;
                }
                if (flag == 0)
                    cmbox_input.Items.Add(dbd.SelectedPath);
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dbd = new FolderBrowserDialog();
            dbd.SelectedPath = cmbox_output.Text;
            if (dbd.ShowDialog() == DialogResult.OK)
            {
                int flag = 0;
                cmbox_output.Text = dbd.SelectedPath;
                //判断是否有此路径，如果有的话不添加，否则添加
                foreach (string str_item in cmbox_output.Items)
                {
                    //判断是否有一致，没有的话，再添加
                    if (dbd.SelectedPath == str_item)
                        flag = 1;
                }
                if (flag == 0)
                    cmbox_output.Items.Add(dbd.SelectedPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbox_input_str = Application.StartupPath;
            cmbox_input.Text = cmbox_input_str;
            cmbox_output.Text = Application.StartupPath;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //initial
                COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
                oCom.CreateObject(0, 0, 0);
                oCom.SetIDLVariable("path_input", cmbox_input.Text);
                oCom.SetIDLVariable("path_output", cmbox_output.Text);
                string root_dir = Application.StartupPath + @"\IDL\data_clip_nc\";

                switch (cmbox_sea.SelectedIndex.ToString() + cmbox_element.SelectedIndex.ToString())
                {
                    //CHINA--SST
                    case "00":
                        oCom.ExecuteString(".compile '" + root_dir + "china_sst_from_global_nc.pro'");
                        oCom.ExecuteString("china_sst_from_global_nc, path_input, path_output");
                        break;
                    //CHINA--CHL
                    case "01":
                        oCom.ExecuteString(".compile '" + root_dir + "china_chl_from_global_nc.pro'");
                        oCom.ExecuteString("china_chl_from_global_nc, path_input, path_output");
                        break;
                    //CHINA--RRS 645
                    case "02":
                        oCom.ExecuteString(".compile '" + root_dir + "china_rrs_from_global_nc.pro'");
                        oCom.ExecuteString("china_rrs_from_global_nc, path_input, path_output");
                        break;
                    //CHINA--PAR
                    case "03":
                        oCom.ExecuteString(".compile '" + root_dir + "china_par_from_global_nc.pro'");
                        oCom.ExecuteString("china_par_from_global_nc, path_input, path_output");
                        break;
                    //ZHEJIANG--SST
                    case "10":
                        oCom.ExecuteString(".compile '" + root_dir + "zhejiang_sst_from_global_nc.pro'");
                        oCom.ExecuteString("zhejiang_sst_from_global_nc, path_input, path_output");
                        break;
                    //NANHAI--SST
                    case "20":
                        oCom.ExecuteString(".compile '" + root_dir + "nanhai_sst_from_global_nc.pro'");
                        oCom.ExecuteString("nanhai_sst_from_global_nc, path_input, path_output");
                        break;
                    default:
                        break;
                }
                //Frm_Message frm = new Frm_Message();
                //frm.ShowDialog();
                //Thread.Sleep(500);
                //frm.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            //关闭帮助
            if (this.Width == 700)
            {
                this.Width = 500;
                btn_help.Text = "显示帮助 >>";
            }
            else
            {
                this.Width = 700;
                btn_help.Text = "<< 隐藏帮助";
            }
        }

        private void cmbox_input_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "输入路径";
            help_body.Text = "选择数据所在的路径，选择过的路径值会自动存储在下拉列表中。";
        }

        private void cmbox_output_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "输出路径";
            help_body.Text = "选择处理后数据的存放路径，选择过的路径值会自动存储在下拉列表中。";
        }

        private void cmbox_sea_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "裁切范围";
            help_body.Text = "通过下拉列表选择不同的海区。\n\n中国海域\n浙江海域\n南海海域";
        }

        private void cmbox_element_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "要素类型";
            help_body.Text = "通过下拉列表选择不同的要素。\n\nSST（海表温度）\nCHL（叶绿素）\nRRS（遥感反射率）\nPAR";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "数据剪切";
            help_body.Text = "将 NetCDF 数据根据不同的范围以及不同的要素进行裁切，并转成 HDF 数据输出到指定的文件夹中。";
        }
    }
}
