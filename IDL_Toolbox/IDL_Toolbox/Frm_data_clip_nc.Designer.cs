namespace IDL_Toolbox
{
    partial class Frm_clip_data_nc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_clip_data_nc));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbox_input = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbox_output = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbox_sea = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbox_element = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_help = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.help_body = new System.Windows.Forms.RichTextBox();
            this.help_title = new System.Windows.Forms.Label();
            this.btn_output = new System.Windows.Forms.Button();
            this.btn_input = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(287, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "实现功能：将 NetCDF 数据进行裁切并转成 HDF 数据";
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
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "裁切范围";
            this.label6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_sea_MouseClick);
            // 
            // cmbox_sea
            // 
            this.cmbox_sea.FormattingEnabled = true;
            this.cmbox_sea.Items.AddRange(new object[] {
            "中国海域",
            "浙江海域",
            "南海海域"});
            this.cmbox_sea.Location = new System.Drawing.Point(20, 180);
            this.cmbox_sea.Name = "cmbox_sea";
            this.cmbox_sea.Size = new System.Drawing.Size(209, 20);
            this.cmbox_sea.TabIndex = 4;
            this.cmbox_sea.Text = "中国海域";
            this.cmbox_sea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_sea_MouseClick);
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
            // cmbox_element
            // 
            this.cmbox_element.FormattingEnabled = true;
            this.cmbox_element.Items.AddRange(new object[] {
            "SST",
            "CHL",
            "RRS 645",
            "PAR"});
            this.cmbox_element.Location = new System.Drawing.Point(269, 180);
            this.cmbox_element.Name = "cmbox_element";
            this.cmbox_element.Size = new System.Drawing.Size(209, 20);
            this.cmbox_element.TabIndex = 4;
            this.cmbox_element.Text = "SST";
            this.cmbox_element.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_element_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "要素类型";
            this.label8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbox_element_MouseClick);
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
            this.panel1.Location = new System.Drawing.Point(0, 273);
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
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbox_input);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbox_output);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbox_sea);
            this.panel2.Controls.Add(this.btn_output);
            this.panel2.Controls.Add(this.cmbox_element);
            this.panel2.Controls.Add(this.btn_input);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 273);
            this.panel2.TabIndex = 10;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
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
            this.panel3.Size = new System.Drawing.Size(195, 273);
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
            this.help_body.Text = "将 NetCDF 数据根据不同的范围以及不同的要素进行裁切，并转成 HDF 数据输出到指定的文件夹中。";
            // 
            // help_title
            // 
            this.help_title.AutoSize = true;
            this.help_title.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.help_title.Location = new System.Drawing.Point(11, 13);
            this.help_title.Name = "help_title";
            this.help_title.Size = new System.Drawing.Size(67, 14);
            this.help_title.TabIndex = 9;
            this.help_title.Text = "数据剪切";
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
            // Frm_clip_data_nc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 318);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_clip_data_nc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据剪切";
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
        private System.Windows.Forms.ComboBox cmbox_sea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbox_element;
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
    }
}

