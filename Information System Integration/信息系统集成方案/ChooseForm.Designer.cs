namespace 信息系统集成方案
{
    partial class ChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.rb_local = new System.Windows.Forms.RadioButton();
            this.rb_tsc = new System.Windows.Forms.RadioButton();
            this.bt_OK = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择点击左键默认进入本机程序或是远程桌面：";
            // 
            // rb_local
            // 
            this.rb_local.AutoSize = true;
            this.rb_local.Checked = true;
            this.rb_local.Location = new System.Drawing.Point(37, 46);
            this.rb_local.Name = "rb_local";
            this.rb_local.Size = new System.Drawing.Size(237, 24);
            this.rb_local.TabIndex = 1;
            this.rb_local.TabStop = true;
            this.rb_local.Text = "本机程序（直接打开本机的程序）";
            this.rb_local.UseVisualStyleBackColor = true;
            // 
            // rb_tsc
            // 
            this.rb_tsc.AutoSize = true;
            this.rb_tsc.Location = new System.Drawing.Point(37, 76);
            this.rb_tsc.Name = "rb_tsc";
            this.rb_tsc.Size = new System.Drawing.Size(251, 24);
            this.rb_tsc.TabIndex = 2;
            this.rb_tsc.TabStop = true;
            this.rb_tsc.Text = "远程桌面（远程其他电脑打开程序）";
            this.rb_tsc.UseVisualStyleBackColor = true;
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(37, 118);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(85, 30);
            this.bt_OK.TabIndex = 3;
            this.bt_OK.Text = "确定";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(189, 118);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(85, 30);
            this.bt_cancel.TabIndex = 4;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 162);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.rb_tsc);
            this.Controls.Add(this.rb_local);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择默认进入的形式";
            this.Load += new System.EventHandler(this.ChooseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_local;
        private System.Windows.Forms.RadioButton rb_tsc;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Button bt_cancel;
    }
}