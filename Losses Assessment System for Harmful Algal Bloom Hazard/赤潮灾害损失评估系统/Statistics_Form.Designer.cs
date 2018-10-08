namespace 赤潮灾害损失评估系统
{
    partial class EvaResult_Form
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
            DevExpress.XtraCharts.DoughnutSeriesLabel doughnutSeriesLabel1 = new DevExpress.XtraCharts.DoughnutSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions1 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.DoughnutSeriesView doughnutSeriesView1 = new DevExpress.XtraCharts.DoughnutSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvaResult_Form));
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.bt_imageExport01 = new System.Windows.Forms.Button();
            this.bt_imageExport02 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_cancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.CrosshairOptions.ArgumentLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(57)))), ((int)(((byte)(205)))));
            this.chartControl1.CrosshairOptions.ValueLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(57)))), ((int)(((byte)(205)))));
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            pointOptions1.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General;
            pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General;
            sideBySideBarSeriesLabel1.PointOptions = pointOptions1;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chartControl1.Size = new System.Drawing.Size(484, 293);
            this.chartControl1.TabIndex = 0;
            // 
            // chartControl2
            // 
            this.chartControl2.CrosshairOptions.ArgumentLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(57)))), ((int)(((byte)(205)))));
            this.chartControl2.CrosshairOptions.ValueLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(57)))), ((int)(((byte)(205)))));
            this.chartControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl2.Location = new System.Drawing.Point(0, 0);
            this.chartControl2.Name = "chartControl2";
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            doughnutSeriesLabel1.LineVisible = true;
            piePointOptions1.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General;
            piePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General;
            doughnutSeriesLabel1.PointOptions = piePointOptions1;
            this.chartControl2.SeriesTemplate.Label = doughnutSeriesLabel1;
            doughnutSeriesView1.RuntimeExploding = false;
            this.chartControl2.SeriesTemplate.View = doughnutSeriesView1;
            this.chartControl2.Size = new System.Drawing.Size(484, 293);
            this.chartControl2.TabIndex = 0;
            // 
            // bt_imageExport01
            // 
            this.bt_imageExport01.Location = new System.Drawing.Point(11, 305);
            this.bt_imageExport01.Name = "bt_imageExport01";
            this.bt_imageExport01.Size = new System.Drawing.Size(138, 30);
            this.bt_imageExport01.TabIndex = 1;
            this.bt_imageExport01.Text = "直方图图片输出";
            this.bt_imageExport01.UseVisualStyleBackColor = true;
            this.bt_imageExport01.Click += new System.EventHandler(this.bt_imageExport01_Click);
            // 
            // bt_imageExport02
            // 
            this.bt_imageExport02.Location = new System.Drawing.Point(819, 305);
            this.bt_imageExport02.Name = "bt_imageExport02";
            this.bt_imageExport02.Size = new System.Drawing.Size(138, 30);
            this.bt_imageExport02.TabIndex = 1;
            this.bt_imageExport02.Text = "饼图图片输出";
            this.bt_imageExport02.UseVisualStyleBackColor = true;
            this.bt_imageExport02.Click += new System.EventHandler(this.bt_imageExport02_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.bt_imageExport02);
            this.panel2.Controls.Add(this.button_cancle);
            this.panel2.Controls.Add(this.bt_imageExport01);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 347);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 293);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chartControl2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(484, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 293);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chartControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 293);
            this.panel3.TabIndex = 0;
            // 
            // button_cancle
            // 
            this.button_cancle.Location = new System.Drawing.Point(414, 305);
            this.button_cancle.Name = "button_cancle";
            this.button_cancle.Size = new System.Drawing.Size(138, 30);
            this.button_cancle.TabIndex = 1;
            this.button_cancle.Text = "关闭";
            this.button_cancle.UseVisualStyleBackColor = true;
            this.button_cancle.Click += new System.EventHandler(this.button_cancle_Click);
            // 
            // EvaResult_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 347);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EvaResult_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "统计分析";
            this.Load += new System.EventHandler(this.Statistics_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_imageExport01;
        private System.Windows.Forms.Button bt_imageExport02;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_cancle;

    }
}