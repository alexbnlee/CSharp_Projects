using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace 赤潮灾害损失评估系统
{
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }

        int i = 0;

        private void Welcome_Form_Load(object sender, EventArgs e)
        {
            // 设置欢迎界面的大小
            this.ClientSize = this.BackgroundImage.Size;
            this.Opacity = 0; // 透明界面
            this.timer1.Interval = 50; // 设置Timer的时间间隔
            this.timer1.Enabled = true;

            this.timer1.Start(); // 开始Timer
            this.timer2.Start();
            //Thread.Sleep(2500);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.03;
            if (this.Opacity >= 1)
            {
                Thread.Sleep(1000);
                this.timer1.Stop();
                this.timer2.Stop();
                this.Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            i++;
            if (i % 4 == 1)
                lb_dot01.Text = ".";
            else if (i % 4 == 2)
                lb_dot01.Text = "..";
            else if (i % 4 == 3)
                lb_dot01.Text = "...";
            else
                lb_dot01.Text = "";
        }
    }
}
