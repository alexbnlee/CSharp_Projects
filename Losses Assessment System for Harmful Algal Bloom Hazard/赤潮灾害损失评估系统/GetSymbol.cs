using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using System.IO;

namespace 赤潮灾害损失评估系统
{
    public class GetSymbolByControlForm : System.Windows.Forms.Form
    {
        //复制此大括号中的文件，同时注意需要将*.cs文件下的design部分删除，
        //否则会显示存在重复定义，因为此代码貌似将控件进行重新定义了。
        public ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.ComponentModel.Container components = null;
        private Label label1;
        private ComboBox cbxStyles;
        private Button btnOtherStyles;
        public IStyleGalleryItem m_styleGalleryItem;
        string stylesPath = string.Empty;
        private FolderBrowserDialog folderBrowserDialog1;
        esriSymbologyStyleClass styleClass;

        public GetSymbolByControlForm(esriSymbologyStyleClass symStyleClass)
        {
            InitializeComponent();
            styleClass = symStyleClass;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void LoadStyles()
        {
            //Get the ArcGIS install location
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            string defaultStyle = System.IO.Path.Combine(sInstall, "Styles\\ESRI.ServerStyle");
            if (System.IO.File.Exists(defaultStyle))
            {
                //Load the ESRI.ServerStyle file into the SymbologyControl
                axSymbologyControl1.LoadStyleFile(defaultStyle);
                axSymbologyControl1.StyleClass = styleClass;
                axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass).SelectItem(0);
                cbxStyles.Text = defaultStyle;
            }
            stylesPath = sInstall + "\\Styles";
            cbxStyles.Items.Clear();
            cbxStylesAddItems(stylesPath);
        }

        private void cbxStylesAddItems(string path)
        {
            string[] serverstyleFiles = System.IO.Directory.GetFiles(stylesPath, "*.serverstyle", SearchOption.AllDirectories);
            string[] styleFiles = System.IO.Directory.GetFiles(stylesPath, "*.style", SearchOption.AllDirectories);

            cbxStylesAddItems(serverstyleFiles);
            cbxStylesAddItems(styleFiles);
        }

        private void cbxStylesAddItems(string[] files)
        {
            if (files.GetLength(0) == 0) return;
            foreach (string file in files)
            {
                cbxStyles.Items.Add(file);
            }
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetSymbolByControlForm));
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStyles = new System.Windows.Forms.ComboBox();
            this.btnOtherStyles = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(10, 51);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(331, 330);
            this.axSymbologyControl1.TabIndex = 0;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(346, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 175);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(371, 324);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(115, 27);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "确  定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(371, 257);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(115, 25);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "取  消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "选择样式库：";
            // 
            // cbxStyles
            // 
            this.cbxStyles.FormattingEnabled = true;
            this.cbxStyles.Location = new System.Drawing.Point(92, 9);
            this.cbxStyles.Name = "cbxStyles";
            this.cbxStyles.Size = new System.Drawing.Size(306, 20);
            this.cbxStyles.TabIndex = 8;
            this.cbxStyles.SelectedIndexChanged += new System.EventHandler(this.cbxStyles_SelectedIndexChanged);
            // 
            // btnOtherStyles
            // 
            this.btnOtherStyles.Location = new System.Drawing.Point(434, 5);
            this.btnOtherStyles.Name = "btnOtherStyles";
            this.btnOtherStyles.Size = new System.Drawing.Size(66, 25);
            this.btnOtherStyles.TabIndex = 7;
            this.btnOtherStyles.Text = "其  它";
            this.btnOtherStyles.Click += new System.EventHandler(this.btnOtherStyles_Click);
            // 
            // GetSymbolByControlForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(510, 394);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxStyles);
            this.Controls.Add(this.btnOtherStyles);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axSymbologyControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GetSymbolByControlForm";
            this.Text = "选择样式符号";
            this.Load += new System.EventHandler(this.GetSymbolByControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void GetSymbolByControlForm_Load(object sender, EventArgs e)
        {
            LoadStyles();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            m_styleGalleryItem = null;
            this.Hide();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            //Preview the selected item
            m_styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
            PreviewImage();
        }

        private void PreviewImage()
        {
            //Get and set the style class 
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);

            //Preview an image of the symbol
            stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(m_styleGalleryItem, pictureBox1.Width, pictureBox1.Height);
            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            pictureBox1.Image = image;
        }

        //public IStyleGalleryItem GetItem(ESRI.ArcGIS.Controls.esriSymbologyStyleClass styleClass)
        //{
        //    //Set the style class
        //    axSymbologyControl1.StyleClass = styleClass;
        //    axSymbologyControl1.Update();
        //    //Show the modal form
        //    this.ShowDialog();

        //    //Return the selected label style
        //    return m_styleGalleryItem;
        //}

        private void cbxStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStyles.SelectedItem == null) return;
            axSymbologyControl1.Clear();
            stylesPath = cbxStyles.SelectedItem.ToString();
            string ext = System.IO.Path.GetExtension(stylesPath).ToLower();
            if (ext == ".serverstyle")
                axSymbologyControl1.LoadStyleFile(stylesPath);
            if (ext == ".style")
                axSymbologyControl1.LoadDesktopStyleFile(stylesPath);
            axSymbologyControl1.StyleClass = styleClass;
        }

        private void btnOtherStyles_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                stylesPath = folderBrowserDialog1.SelectedPath;
                cbxStylesAddItems(stylesPath);
            }
        }

    }
}
