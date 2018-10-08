namespace IDL_Toolbox
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("数据裁切", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("MODIS 数据查找", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("辅助模块", 1, 1);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("浮标数据处理", 1, 1);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("SVD分解", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("DINEOF", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点8", 1, 1);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点9", 1, 1);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("MODIS_Hutai", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "sub_11";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "数据裁切";
            treeNode1.ToolTipText = "数据裁切";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "sub_12";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "MODIS 数据查找";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "sub_13";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "辅助模块";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "节点5";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "浮标数据处理";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "节点6";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Text = "SVD分解";
            treeNode6.ImageIndex = 0;
            treeNode6.Name = "root_1";
            treeNode6.Text = "DINEOF";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "节点8";
            treeNode7.SelectedImageIndex = 1;
            treeNode7.Text = "节点8";
            treeNode8.ImageIndex = 1;
            treeNode8.Name = "节点9";
            treeNode8.SelectedImageIndex = 1;
            treeNode8.Text = "节点9";
            treeNode9.Name = "节点7";
            treeNode9.Text = "MODIS_Hutai";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(524, 719);
            this.treeView1.TabIndex = 0;
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GeoprocessingToolset16.png");
            this.imageList1.Images.SetKeyName(1, "GeoprocessingTool16.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 719);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDL工具箱";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
    }
}