using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDL_Toolbox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Name)
            {
                case "sub_11":
                    Frm_clip_data_nc frm_11 = new Frm_clip_data_nc();
                    frm_11.Show();
                    break;
                case "sub_12":
                    Frm_MODIS_data_query frm_12 = new Frm_MODIS_data_query();
                    frm_12.ShowDialog();
                    break;
                case "sub_13":
                    //MessageBox.Show("处理完成！是否打开生成文件？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //string tmp = System.Text.Encoding.Unicode.GetString()
                    //string tmp = System.Web.HttpUtility.UrlEncode(@"\\10.1.8.200\modis要素产品\FLH_4km\MON\全球\AQUA");
                    //tmp = System.Web.HttpUtility.UrlDecode(tmp);
                    //richTextBox1.Text = tmp;
                    break;
                default:
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            treeView1.Nodes.Add("alex");
            
            TreeNode tn_1 = new TreeNode();
            tn_1.Text = "一、一级标题";
            tn_1.Nodes.Add("1.1 二级标题");
            TreeNode tn_12 = new TreeNode();
            tn_12.Text = "1.2 二级标题";
            tn_12.Nodes.Add("1.21 三级标题");
            tn_12.Nodes.Add("1.22 三级标题");
            tn_1.Nodes.Add(tn_12);
            treeView1.Nodes.Add(tn_1);
        }
    }
}
