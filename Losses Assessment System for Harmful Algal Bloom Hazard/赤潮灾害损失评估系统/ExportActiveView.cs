using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Output;
using System.IO;
using System.Collections;
using System.Drawing.Printing;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.OutputExtensions;
using Microsoft.VisualBasic;

namespace 赤潮灾害损失评估系统
{
    public class ExportActiveView : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnPrint;

        internal PrintPreviewDialog printPreviewDialog1;
        internal PrintDialog printDialog1;
        internal PageSetupDialog pageSetupDialog1;

        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private short m_CurrentPrintPage;

        IExport export = new ExportBMPClass();
        IOutputRasterSettings rasterSettings;
        string strOutputType = "ExportBMP";
        private Label label1;
        private ComboBox cbxOutputType;
        private Button btnOutputFile;
        double iOutputResolution = 300;
        private SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        string exportFileName = "C:\\Temp\\test.bmp";
        string fileExtension = "BMP";
        private TextBox txtResolution;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;

        public ExportActiveView(string docName)
        {
            InitializeComponent();
            axPageLayoutControl1.LoadMxFile(docName);
        }

        protected override void Dispose(bool disposing)
        {
            //Release COM objects
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportActiveView));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxOutputType = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(625, 43);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(88, 22);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "其他地图文档";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(625, 73);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 22);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "文件输出";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Location = new System.Drawing.Point(10, 111);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(705, 520);
            this.axPageLayoutControl1.TabIndex = 9;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(10, 10);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(398, 28);
            this.axToolbarControl1.TabIndex = 12;
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(291, 43);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(75, 21);
            this.txtResolution.TabIndex = 24;
            this.txtResolution.Text = "300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "分辨率：";
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(530, 73);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(74, 22);
            this.btnOutputFile.TabIndex = 22;
            this.btnOutputFile.Text = "浏览...";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.btnOutputFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "选择输出类型：";
            // 
            // cbxOutputType
            // 
            this.cbxOutputType.FormattingEnabled = true;
            this.cbxOutputType.Items.AddRange(new object[] {
            "ExportJPEG",
            "ExportBMP",
            "ExportGIF",
            "ExportPNG",
            "ExportTIFF",
            "ExportAI",
            "ExportEMF",
            "ExportPDF",
            "ExportPS",
            "ExportSVG"});
            this.cbxOutputType.Location = new System.Drawing.Point(104, 43);
            this.cbxOutputType.Name = "cbxOutputType";
            this.cbxOutputType.Size = new System.Drawing.Size(114, 20);
            this.cbxOutputType.TabIndex = 15;
            this.cbxOutputType.Text = "ExportJPEG";
            this.cbxOutputType.SelectedIndexChanged += new System.EventHandler(this.cbxOutputType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "输出文件位置及文件：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 21);
            this.textBox1.TabIndex = 25;
            // 
            // ExportActiveView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(725, 643);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOutputFile);
            this.Controls.Add(this.txtResolution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axPageLayoutControl1);
            this.Controls.Add(this.cbxOutputType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "ExportActiveView";
            this.Text = "地图的转换输出";
            this.Load += new System.EventHandler(this.ExportActiveView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "template files (*.mxt)|*.mxt|mxd files (*.mxd)|*.mxd";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //检测是否选择了一个文件
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string fileName = openFileDialog1.FileName;
                    //检测选择的文件是否为一mxd 文件
                    if (axPageLayoutControl1.CheckMxFile(fileName))
                    {
                        axPageLayoutControl1.LoadMxFile(fileName, "");
                    }
                    myStream.Close();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            if (export is IOutputRasterSettings)
            {
                //矢量格式输出
                rasterSettings = (IOutputRasterSettings)export;
                rasterSettings.ResampleRatio = 1;
            }
            if (Information.IsNumeric(txtResolution.Text))
            {
                iOutputResolution = Convert.ToInt32(txtResolution.Text);
            }
            else
                iOutputResolution = 300;

            IActiveView pActiveView = axPageLayoutControl1.ActiveView;
            double iScreenResolution = pActiveView.ScreenDisplay.DisplayTransformation.Resolution;
            tagRECT exportRECT;
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = Convert.ToInt32(Math.Ceiling(pActiveView.ExportFrame.right * (iOutputResolution / iScreenResolution)));
            exportRECT.bottom = Convert.ToInt32(Math.Round(pActiveView.ExportFrame.bottom * (iOutputResolution / iScreenResolution)));
            IEnvelope pPixelBoundsEnv = new EnvelopeClass();
            pPixelBoundsEnv.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.Resolution = iOutputResolution;
            export.PixelBounds = pPixelBoundsEnv;
            export.ExportFileName = exportFileName;
            int hDC = export.StartExporting();
            pActiveView.Output(hDC, (int)export.Resolution, ref exportRECT, null, null);
            export.FinishExporting();
            export.Cleanup();
            this.Close();
            this.Cursor = Cursors.Default;
            MessageBox.Show("输出成功！", "消息提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbxOutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxOutputType.SelectedItem == null) return;
            strOutputType = cbxOutputType.SelectedItem.ToString();
            try
            {
                switch (strOutputType)
                {
                    case "ExportBMP":
                        export = new ExportBMPClass();
                        fileExtension = "BMP";
                        break;
                    case "ExportGIF":  //ArcPressPrinter需要ArcGIS桌面许可
                        export = new ExportGIFClass();
                        fileExtension = "GIF";
                        break;
                    case "ExportJPEG":
                        export = new ExportJPEGClass();
                        fileExtension = "JPG";
                        break;
                    case "ExportPNG":
                        export = new ExportPNGClass();
                        fileExtension = "PNG";
                        break;
                    case "ExportTIFF":
                        export = new ExportTIFFClass();
                        fileExtension = "TIFF";
                        break;
                    case "ExportAI":
                        export = new ExportAIClass();
                        fileExtension = "AI";
                        break;
                    case "ExportEMF":
                        export = new ExportEMFClass();
                        fileExtension = "EMF";
                        break;
                    case "ExportPDF":
                        export = new ExportPDFClass();
                        fileExtension = "PDF";
                        break;
                    case "ExportPS":
                        export = new ExportPSClass();
                        fileExtension = "PS";
                        break;
                    case "ExportSVG":
                        export = new ExportSVGClass();
                        fileExtension = "SVG";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exportFileName = saveFileDialog1.FileName + "." + fileExtension;
                textBox1.Text = exportFileName;
            }
        }

        private void ExportActiveView_Load(object sender, EventArgs e)
        {
            export = new ExportJPEGClass();
            fileExtension = "JPG";
        }

    }
}
