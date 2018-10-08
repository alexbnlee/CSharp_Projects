namespace IDL_Toolbox
{
    partial class Frm_MODIS_data_query
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MODIS_data_query));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbox_input = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbox_output = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbox_year_from = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbox_frequency = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_help = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.link_openFolder = new System.Windows.Forms.LinkLabel();
            this.link_openFile = new System.Windows.Forms.LinkLabel();
            this.rtb_status = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbox_year_to = new System.Windows.Forms.ComboBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.cmbox_element = new System.Windows.Forms.ComboBox();
            this.btn_input = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.help_body = new System.Windows.Forms.RichTextBox();
            this.help_title = new System.Windows.Forms.Label();
            this.cb_filesave = new System.Windows.Forms.CheckBox();
            this.link_openOFile = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "实现功能：查找 MODIS 数据文件夹中没有的数据，并生成 txt 文件";
            // 
            // cmbox_input
            // 
            this.cmbox_input.FormattingEnabled = true;
            this.cmbox_input.Location = new System.Drawing.Point(20, 67);
            this.cmbox_input.Name = "cmbox_input";
            this.cmbox_input.Size = new System.Drawing.Size(429, 20);
            this.cmbox_input.TabIndex = 4;
            this.cmbox_input.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_input_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入路径";
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_input_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "●";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输出路径";
            this.label4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_output_MouseClick);
            // 
            // cmbox_output
            // 
            this.cmbox_output.FormattingEnabled = true;
            this.cmbox_output.Location = new System.Drawing.Point(20, 123);
            this.cmbox_output.Name = "cmbox_output";
            this.cmbox_output.Size = new System.Drawing.Size(429, 20);
            this.cmbox_output.TabIndex = 4;
            this.cmbox_output.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_output_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(5, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "●";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "选择查询年份范围";
            // 
            // cmbox_year_from
            // 
            this.cmbox_year_from.FormattingEnabled = true;
            this.cmbox_year_from.Items.AddRange(new object[] {
            "2002年",
            "2003年",
            "2004年",
            "2005年",
            "2006年",
            "2007年",
            "2008年",
            "2009年",
            "2010年",
            "2011年",
            "2012年",
            "2013年",
            "2014年",
            "2015年",
            "2016年",
            "2017年",
            "2018年"});
            this.cmbox_year_from.Location = new System.Drawing.Point(20, 180);
            this.cmbox_year_from.Name = "cmbox_year_from";
            this.cmbox_year_from.Size = new System.Drawing.Size(95, 20);
            this.cmbox_year_from.TabIndex = 4;
            this.cmbox_year_from.Text = "2002年";
            this.cmbox_year_from.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_year_from_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(5, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "●";
            // 
            // cmbox_frequency
            // 
            this.cmbox_frequency.FormattingEnabled = true;
            this.cmbox_frequency.Items.AddRange(new object[] {
            "DAY",
            "MON"});
            this.cmbox_frequency.Location = new System.Drawing.Point(269, 180);
            this.cmbox_frequency.Name = "cmbox_frequency";
            this.cmbox_frequency.Size = new System.Drawing.Size(67, 20);
            this.cmbox_frequency.TabIndex = 4;
            this.cmbox_frequency.Text = "DAY";
            this.cmbox_frequency.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_frequency_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "要素频率及类型";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(253, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "●";
            // 
            // btn_help
            // 
            this.btn_help.Location = new System.Drawing.Point(387, 10);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(96, 23);
            this.btn_help.TabIndex = 8;
            this.btn_help.Text = "<< 隐藏帮助";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.btn_help);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 45);
            this.panel1.TabIndex = 9;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(306, 10);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(225, 10);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cb_filesave);
            this.panel2.Controls.Add(this.link_openFolder);
            this.panel2.Controls.Add(this.link_openOFile);
            this.panel2.Controls.Add(this.link_openFile);
            this.panel2.Controls.Add(this.rtb_status);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbox_input);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbox_output);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbox_year_to);
            this.panel2.Controls.Add(this.cmbox_year_from);
            this.panel2.Controls.Add(this.btn_output);
            this.panel2.Controls.Add(this.cmbox_element);
            this.panel2.Controls.Add(this.cmbox_frequency);
            this.panel2.Controls.Add(this.btn_input);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 295);
            this.panel2.TabIndex = 10;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // link_openFolder
            // 
            this.link_openFolder.AutoSize = true;
            this.link_openFolder.BackColor = System.Drawing.Color.White;
            this.link_openFolder.Location = new System.Drawing.Point(252, 277);
            this.link_openFolder.Name = "link_openFolder";
            this.link_openFolder.Size = new System.Drawing.Size(65, 12);
            this.link_openFolder.TabIndex = 8;
            this.link_openFolder.TabStop = true;
            this.link_openFolder.Text = "打开文件夹";
            this.link_openFolder.Visible = false;
            this.link_openFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_openFolder_LinkClicked);
            // 
            // link_openFile
            // 
            this.link_openFile.AutoSize = true;
            this.link_openFile.BackColor = System.Drawing.Color.White;
            this.link_openFile.Location = new System.Drawing.Point(12, 277);
            this.link_openFile.Name = "link_openFile";
            this.link_openFile.Size = new System.Drawing.Size(101, 12);
            this.link_openFile.TabIndex = 8;
            this.link_openFile.TabStop = true;
            this.link_openFile.Text = "打开缺失数据文件";
            this.link_openFile.Visible = false;
            this.link_openFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_openfile_LinkClicked);
            // 
            // rtb_status
            // 
            this.rtb_status.BackColor = System.Drawing.Color.White;
            this.rtb_status.Location = new System.Drawing.Point(10, 239);
            this.rtb_status.Name = "rtb_status";
            this.rtb_status.ReadOnly = true;
            this.rtb_status.Size = new System.Drawing.Size(470, 55);
            this.rtb_status.TabIndex = 7;
            this.rtb_status.Text = "";
            this.rtb_status.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtb_status_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(121, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "-";
            // 
            // cmbox_year_to
            // 
            this.cmbox_year_to.FormattingEnabled = true;
            this.cmbox_year_to.Items.AddRange(new object[] {
            "2002年",
            "2003年",
            "2004年",
            "2005年",
            "2006年",
            "2007年",
            "2008年",
            "2009年",
            "2010年",
            "2011年",
            "2012年",
            "2013年",
            "2014年",
            "2015年",
            "2016年",
            "2017年",
            "2018年"});
            this.cmbox_year_to.Location = new System.Drawing.Point(138, 180);
            this.cmbox_year_to.Name = "cmbox_year_to";
            this.cmbox_year_to.Size = new System.Drawing.Size(95, 20);
            this.cmbox_year_to.TabIndex = 4;
            this.cmbox_year_to.Text = "2017年";
            this.cmbox_year_to.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_year_to_MouseClick);
            // 
            // btn_output
            // 
            this.btn_output.Image = global::IDL_Toolbox.Properties.Resources.GenericOpen16;
            this.btn_output.Location = new System.Drawing.Point(457, 121);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(24, 24);
            this.btn_output.TabIndex = 5;
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // cmbox_element
            // 
            this.cmbox_element.FormattingEnabled = true;
            this.cmbox_element.Items.AddRange(new object[] {
            "CDOM_4km",
            "CHL_chlor_4km",
            "CHL_chlocx_4km",
            "FLH_4km",
            "KD490_4km",
            "PAR_4km",
            "PIC_4km",
            "POC_4km",
            "RRS_488_4km",
            "RRS_531_4km",
            "RRS_547_4km",
            "RRS_645_4km",
            "RRS_667_4km",
            "SST_4km"});
            this.cmbox_element.Location = new System.Drawing.Point(352, 180);
            this.cmbox_element.Name = "cmbox_element";
            this.cmbox_element.Size = new System.Drawing.Size(129, 20);
            this.cmbox_element.TabIndex = 4;
            this.cmbox_element.Text = "SST_4km";
            this.cmbox_element.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_element_MouseClick);
            // 
            // btn_input
            // 
            this.btn_input.Image = global::IDL_Toolbox.Properties.Resources.GenericOpen16;
            this.btn_input.Location = new System.Drawing.Point(457, 65);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(24, 24);
            this.btn_input.TabIndex = 5;
            this.btn_input.UseVisualStyleBackColor = true;
            this.btn_input.Click += new System.EventHandler(this.btn_input_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.help_body);
            this.panel3.Controls.Add(this.help_title);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(495, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 295);
            this.panel3.TabIndex = 11;
            // 
            // help_body
            // 
            this.help_body.BackColor = System.Drawing.Color.White;
            this.help_body.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.help_body.Location = new System.Drawing.Point(14, 45);
            this.help_body.Name = "help_body";
            this.help_body.ReadOnly = true;
            this.help_body.Size = new System.Drawing.Size(167, 226);
            this.help_body.TabIndex = 12;
            this.help_body.Text = "查找 MODIS 数据文件夹中没有的数据，并生成 txt 文件。\n";
            // 
            // help_title
            // 
            this.help_title.AutoSize = true;
            this.help_title.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.help_title.Location = new System.Drawing.Point(11, 13);
            this.help_title.Name = "help_title";
            this.help_title.Size = new System.Drawing.Size(115, 14);
            this.help_title.TabIndex = 9;
            this.help_title.Text = "MODIS 数据查找";
            // 
            // cb_filesave
            // 
            this.cb_filesave.AutoSize = true;
            this.cb_filesave.Location = new System.Drawing.Point(20, 212);
            this.cb_filesave.Name = "cb_filesave";
            this.cb_filesave.Size = new System.Drawing.Size(198, 16);
            this.cb_filesave.TabIndex = 9;
            this.cb_filesave.Text = "保存已存在文件到指定txt文件中";
            this.cb_filesave.UseVisualStyleBackColor = true;
            this.cb_filesave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cb_filesave_MouseClick);
            // 
            // link_openOFile
            // 
            this.link_openOFile.AutoSize = true;
            this.link_openOFile.BackColor = System.Drawing.Color.White;
            this.link_openOFile.Location = new System.Drawing.Point(132, 277);
            this.link_openOFile.Name = "link_openOFile";
            this.link_openOFile.Size = new System.Drawing.Size(101, 12);
            this.link_openOFile.TabIndex = 8;
            this.link_openOFile.TabStop = true;
            this.link_openOFile.Text = "打开已存数据文件";
            this.link_openOFile.Visible = false;
            this.link_openOFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_openOFile_LinkClicked);
            // 
            // Frm_MODIS_data_query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 340);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_MODIS_data_query";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIS 数据查找";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbox_input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_input;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbox_output;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbox_year_from;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbox_frequency;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label help_title;
        private System.Windows.Forms.RichTextBox help_body;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbox_year_to;
        private System.Windows.Forms.ComboBox cmbox_element;
        private System.Windows.Forms.RichTextBox rtb_status;
        private System.Windows.Forms.LinkLabel link_openFile;
        private System.Windows.Forms.LinkLabel link_openFolder;
        private System.Windows.Forms.CheckBox cb_filesave;
        private System.Windows.Forms.LinkLabel link_openOFile;
    }
}

