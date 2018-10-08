namespace 赤潮灾害损失评估系统
{
    partial class Monitoring_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitoring_Form));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.yyjc_label1 = new System.Windows.Forms.Label();
            this.yjjc_label2 = new System.Windows.Forms.Label();
            this.yjjc_tb1 = new System.Windows.Forms.TextBox();
            this.yjjc_dgv = new System.Windows.Forms.DataGridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.yjjc_label_result = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.button_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button_calc = new DevExpress.XtraEditors.SimpleButton();
            this.button_help = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yjjc_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(597, 428);
            this.panelControl2.TabIndex = 15;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.yyjc_label1);
            this.groupControl1.Controls.Add(this.yjjc_label2);
            this.groupControl1.Controls.Add(this.yjjc_tb1);
            this.groupControl1.Controls.Add(this.yjjc_dgv);
            this.groupControl1.Location = new System.Drawing.Point(14, 15);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(569, 284);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "评价参数";
            // 
            // yyjc_label1
            // 
            this.yyjc_label1.AutoSize = true;
            this.yyjc_label1.Location = new System.Drawing.Point(17, 38);
            this.yyjc_label1.Name = "yyjc_label1";
            this.yyjc_label1.Size = new System.Drawing.Size(293, 12);
            this.yyjc_label1.TabIndex = 15;
            this.yyjc_label1.Text = "本次赤潮灾害处置，用于支付船舶租用的费用（元）：";
            // 
            // yjjc_label2
            // 
            this.yjjc_label2.AutoSize = true;
            this.yjjc_label2.Location = new System.Drawing.Point(17, 69);
            this.yjjc_label2.Name = "yjjc_label2";
            this.yjjc_label2.Size = new System.Drawing.Size(461, 12);
            this.yjjc_label2.TabIndex = 14;
            this.yjjc_label2.Text = "本次赤潮事件发生后，每个监测站位的费用（元）：（船舶租用费用（元）为必填列）";
            // 
            // yjjc_tb1
            // 
            this.yjjc_tb1.Location = new System.Drawing.Point(414, 34);
            this.yjjc_tb1.Name = "yjjc_tb1";
            this.yjjc_tb1.Size = new System.Drawing.Size(138, 21);
            this.yjjc_tb1.TabIndex = 16;
            this.yjjc_tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yyjc_tb1_KeyPress);
            // 
            // yjjc_dgv
            // 
            this.yjjc_dgv.AllowUserToResizeColumns = false;
            this.yjjc_dgv.AllowUserToResizeRows = false;
            this.yjjc_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.yjjc_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yjjc_dgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yjjc_dgv.Location = new System.Drawing.Point(20, 98);
            this.yjjc_dgv.Name = "yjjc_dgv";
            this.yjjc_dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.yjjc_dgv.RowTemplate.Height = 23;
            this.yjjc_dgv.Size = new System.Drawing.Size(529, 162);
            this.yjjc_dgv.TabIndex = 17;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.yjjc_label_result);
            this.groupControl2.Location = new System.Drawing.Point(14, 325);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(569, 84);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "评价结果";
            // 
            // yjjc_label_result
            // 
            this.yjjc_label_result.AutoSize = true;
            this.yjjc_label_result.BackColor = System.Drawing.Color.Transparent;
            this.yjjc_label_result.Location = new System.Drawing.Point(22, 45);
            this.yjjc_label_result.Name = "yjjc_label_result";
            this.yjjc_label_result.Size = new System.Drawing.Size(0, 12);
            this.yjjc_label_result.TabIndex = 5;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.axAcroPDF1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(2, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(427, 474);
            this.groupControl3.TabIndex = 13;
            this.groupControl3.Text = "赤潮灾害应急监测费用评估模型说明";
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(2, 22);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(423, 450);
            this.axAcroPDF1.TabIndex = 11;
            this.axAcroPDF1.TabStop = false;
            // 
            // button_cancel
            // 
            this.button_cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Appearance.Options.UseFont = true;
            this.button_cancel.Location = new System.Drawing.Point(386, 11);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(73, 26);
            this.button_cancel.TabIndex = 11;
            this.button_cancel.Text = "关闭";
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button_cancel);
            this.panelControl1.Controls.Add(this.button_calc);
            this.panelControl1.Controls.Add(this.button_help);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 430);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(597, 46);
            this.panelControl1.TabIndex = 14;
            // 
            // button_calc
            // 
            this.button_calc.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_calc.Appearance.Options.UseFont = true;
            this.button_calc.Location = new System.Drawing.Point(294, 11);
            this.button_calc.Name = "button_calc";
            this.button_calc.Size = new System.Drawing.Size(73, 26);
            this.button_calc.TabIndex = 11;
            this.button_calc.Text = "评估";
            this.button_calc.Click += new System.EventHandler(this.button_calc_Click);
            // 
            // button_help
            // 
            this.button_help.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_help.Appearance.Options.UseFont = true;
            this.button_help.Location = new System.Drawing.Point(478, 11);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(105, 26);
            this.button_help.TabIndex = 11;
            this.button_help.Text = "<<隐藏说明";
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.groupControl3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(601, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(431, 478);
            this.panelControl3.TabIndex = 18;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl2);
            this.panelControl4.Controls.Add(this.panelControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(601, 478);
            this.panelControl4.TabIndex = 19;
            // 
            // Monitoring_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 478);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitoring_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "赤潮灾害应急监测费用评估";
            this.Load += new System.EventHandler(this.Monitoring_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yjjc_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label yjjc_label_result;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private DevExpress.XtraEditors.SimpleButton button_cancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton button_calc;
        private DevExpress.XtraEditors.SimpleButton button_help;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.Label yyjc_label1;
        private System.Windows.Forms.Label yjjc_label2;
        private System.Windows.Forms.TextBox yjjc_tb1;
        private System.Windows.Forms.DataGridView yjjc_dgv;
    }
}