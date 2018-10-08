using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace IDL_Toolbox
{
    public partial class Frm_MODIS_data_query : Form
    {
        public Frm_MODIS_data_query()
        {
            InitializeComponent();
        }

        string cmbox_input_str = "";
        string file_path = "";
        string ofile_path = "";

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
            cmbox_input_str = @"\\10.1.8.200\modis要素产品";
            cmbox_input.Text = cmbox_input_str;
            cmbox_input.Items.Add(@"\\10.1.8.200\modis要素产品\SST_4km\DAY\全球\nc");
            cmbox_input.Items.Add(@"\\10.1.8.200\modis要素产品\SST_4km\MON\全球\nc");
            cmbox_output.Text = Application.StartupPath;
            cmbox_output.Items.Add(@"D:\IDLpro\Alex\Data");
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //acquire the year_start, year_end and element name
                int year_from = cmbox_year_from.SelectedIndex + 2002;
                int year_to = cmbox_year_to.SelectedIndex + 2002;
                string[] ele_names = { "cdom", "chlor", "chlocx", "flh", "kd490", "par", "pic", "poc", 
                                         "rrs488", "rrs531", "rrs547", "rrs645", "rrs667", "sst"};
                string[] fre_names = { "DAY", "MON" };

                //initial
                COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
                oCom.CreateObject(0, 0, 0);
                oCom.SetIDLVariable("path_input", cmbox_input.Text);
                oCom.SetIDLVariable("path_output", cmbox_output.Text);
                oCom.SetIDLVariable("year_start", year_from);
                oCom.SetIDLVariable("year_end", year_to);
                oCom.SetIDLVariable("NAD_str", ele_names[cmbox_element.SelectedIndex]);
                string root_dir = Application.StartupPath + @"\IDL\modis_data_query\";

                switch ( fre_names[cmbox_frequency.SelectedIndex])
                {
                    case "DAY":
                        oCom.ExecuteString(String.Format(".compile '{0}nasa_data_day_query.pro'", root_dir));
                        oCom.ExecuteString(String.Format(".compile '{0}nasa_data_day_query_batch.pro'", root_dir));
                        if (cb_filesave.Checked)
                            oCom.ExecuteString("nasa_data_day_query_batch, path_input, path_output, year_start, year_end, NAD_str, /OF_SAVE");
                        else
                            oCom.ExecuteString("nasa_data_day_query_batch, path_input, path_output, year_start, year_end, NAD_str");
                        //get the file path
                        file_path = oCom.GetIDLVariable("!fp").ToString();
                        ofile_path = oCom.GetIDLVariable("!fp_of").ToString();
                        break;
                    case "MON":
                        oCom.ExecuteString(String.Format(".compile '{0}nasa_data_mon_query.pro'", root_dir));
                        oCom.ExecuteString(String.Format(".compile '{0}nasa_data_mon_query_batch.pro'", root_dir));
                        if (cb_filesave.Checked)
                            oCom.ExecuteString("nasa_data_mon_query_batch, path_input, path_output, year_start, year_end, NAD_str, /OF_SAVE");
                        else
                            oCom.ExecuteString("nasa_data_mon_query_batch, path_input, path_output, year_start, year_end, NAD_str");
                        //get the file path
                        file_path = oCom.GetIDLVariable("!fp").ToString();
                        ofile_path = oCom.GetIDLVariable("!fp_of").ToString();
                        break;
                    
                    default:
                        break;
                }

                link_openFile.Visible = true;
                link_openFolder.Visible = true;
                link_openOFile.Visible = true;
                if (cb_filesave.Checked)
                    link_openOFile.Enabled = true;
                else
                    link_openOFile.Enabled = false;
                
                rtb_status.Text = "处理完成！";
                rtb_status.Text += "\n查找信息：" + fre_names[cmbox_frequency.SelectedIndex]+"/"+
                    ele_names[cmbox_element.SelectedIndex].ToUpper() + " (" + year_from.ToString() + 
                    "年-" + year_to.ToString() + "年" + ")";
                
                //功能调用完毕后销毁对象，否则容易报错，没来得及回收资源
                //oCom.DestroyObject();
                //Marshal.ReleaseComObject(oCom);

                DialogResult dr = MessageBox.Show("处理完成！是否打开生成文件？", "信息提示", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(file_path);
                    if (cb_filesave.Checked)
                        System.Diagnostics.Process.Start(ofile_path);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtb_status.Text = "处理失败！";
                link_openFile.Visible = false;
                link_openFolder.Visible = false;
                link_openOFile.Visible = false;
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
            help_body.Text = "选择数据所在的路径，选择过的路径值会自动存储在下拉列表中。\n\n注意：如果处理出错，可能是因为存在中文路径名！";
        }

        private void cmbox_output_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "输出路径";
            help_body.Text = "选择处理后数据下载链接生成 txt 文件的存放路径，选择过的路径值会自动存储在下拉列表中。";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "MODIS 数据查找";
            help_body.Text = "查找 MODIS 数据文件夹中没有的数据，并生成 txt 文件。";
        }

        private void cmbox_frequency_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "要素频率";
            help_body.Text = "通过下拉列表选择不同的频率。\n\nDAY（日平均）\nMON（月平均）";
        }

        private void cmbox_element_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "要素类型";
            help_body.Text = "通过下拉列表选择不同的要素。\n\nCDOM_4km\nCHL_4km\nFLH_4km\nKD490_4km\nPAR_4km\nPIC_4km\nPOC_4km\nRRS_4km\nSST_4km\n";
        }

        private void cmbox_year_from_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "查询的开始年份";
            help_body.Text = "从2002年-2018年";
        }

        private void cmbox_year_to_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "查询的结束年份";
            help_body.Text = "从2002年-2018年";
        }

        private void link_openfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            	System.Diagnostics.Process.Start(file_path);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void link_openFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            	System.Diagnostics.Process.Start(cmbox_output.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rtb_status_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "处理信息输出";
            help_body.Text = "用来显示处理结果。";
        }

        private void cb_filesave_MouseClick(object sender, MouseEventArgs e)
        {
            help_title.Text = "保存已存在文件";
            help_body.Text = "如果勾选复选框，则保存已存在文件到指定txt文件中，否则不保存，默认不保存。";
        }

        private void link_openOFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(ofile_path);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
