namespace 赤潮灾害损失评估系统
{
    partial class Welcome_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome_Form));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_dot01 = new System.Windows.Forms.Label();
            this.lb_text = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_dot01
            // 
            this.lb_dot01.AutoSize = true;
            this.lb_dot01.BackColor = System.Drawing.Color.Transparent;
            this.lb_dot01.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_dot01.Location = new System.Drawing.Point(463, 171);
            this.lb_dot01.Name = "lb_dot01";
            this.lb_dot01.Size = new System.Drawing.Size(0, 14);
            this.lb_dot01.TabIndex = 0;
            // 
            // lb_text
            // 
            this.lb_text.AutoSize = true;
            this.lb_text.BackColor = System.Drawing.Color.Transparent;
            this.lb_text.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_text.Location = new System.Drawing.Point(400, 173);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(65, 12);
            this.lb_text.TabIndex = 0;
            this.lb_text.Text = "系统初始化";
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Welcome_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::赤潮灾害损失评估系统.Properties.Resources.初始化界面_无字版;
            this.ClientSize = new System.Drawing.Size(569, 271);
            this.Controls.Add(this.lb_text);
            this.Controls.Add(this.lb_dot01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome_Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome_Form";
            this.Load += new System.EventHandler(this.Welcome_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_dot01;
        private System.Windows.Forms.Label lb_text;
        private System.Windows.Forms.Timer timer2;
    }
}