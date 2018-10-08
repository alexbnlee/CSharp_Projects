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

namespace 赤潮灾害损失评估系统
{
    public class PrintActiveview : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnPageSetup;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbxMappingType;

        internal PrintPreviewDialog printPreviewDialog1;
        internal PrintDialog printDialog1;
        internal PageSetupDialog pageSetupDialog1;

        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private Label lblPrinter;
        private ComboBox cbxPrinterType;
        private Label lblMapping;
        private short m_CurrentPrintPage;

        IPrinter printer = new EmfPrinterClass();
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private string strPrinterType = "EmfPrinter";

        public PrintActiveview(string docName)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintActiveview));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbxMappingType = new System.Windows.Forms.ComboBox();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cbxPrinterType = new System.Windows.Forms.ComboBox();
            this.lblMapping = new System.Windows.Forms.Label();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(225, 45);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(116, 26);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "打印其他地图文档";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.Location = new System.Drawing.Point(10, 45);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(72, 26);
            this.btnPageSetup.TabIndex = 4;
            this.btnPageSetup.Text = "页面设置";
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Location = new System.Drawing.Point(87, 45);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(68, 26);
            this.btnPrintPreview.TabIndex = 5;
            this.btnPrintPreview.Text = "打印预览";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(160, 45);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 26);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "打  印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbxMappingType
            // 
            this.cbxMappingType.Items.AddRange(new object[] {
            "esriPageMappingScale",
            "esriPageMappingTile",
            "esriPageMappingCrop"});
            this.cbxMappingType.Location = new System.Drawing.Point(535, 45);
            this.cbxMappingType.Name = "cbxMappingType";
            this.cbxMappingType.Size = new System.Drawing.Size(180, 20);
            this.cbxMappingType.TabIndex = 8;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Location = new System.Drawing.Point(10, 78);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(705, 520);
            this.axPageLayoutControl1.TabIndex = 9;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(404, 21);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(125, 12);
            this.lblPrinter.TabIndex = 10;
            this.lblPrinter.Text = "选择打印机对象类型：";
            // 
            // cbxPrinterType
            // 
            this.cbxPrinterType.FormattingEnabled = true;
            this.cbxPrinterType.Items.AddRange(new object[] {
            "EmfPrinter",
            "ArcPressPrinter",
            "PsPrinter"});
            this.cbxPrinterType.Location = new System.Drawing.Point(535, 16);
            this.cbxPrinterType.Name = "cbxPrinterType";
            this.cbxPrinterType.Size = new System.Drawing.Size(180, 20);
            this.cbxPrinterType.TabIndex = 11;
            this.cbxPrinterType.SelectedIndexChanged += new System.EventHandler(this.cbxPrinterType_SelectedIndexChanged);
            // 
            // lblMapping
            // 
            this.lblMapping.AutoSize = true;
            this.lblMapping.Location = new System.Drawing.Point(356, 50);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(173, 12);
            this.lblMapping.TabIndex = 10;
            this.lblMapping.Text = "选择地图页面与纸张映射关系：";
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(10, 10);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(374, 28);
            this.axToolbarControl1.TabIndex = 12;
            // 
            // PrintActiveview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(726, 609);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.cbxPrinterType);
            this.Controls.Add(this.lblMapping);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.axPageLayoutControl1);
            this.Controls.Add(this.cbxMappingType);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnPageSetup);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "PrintActiveview";
            this.Text = "打印视图";
            this.Load += new System.EventHandler(this.PrintActiveView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void PrintActiveView_Load(object sender, EventArgs e)
        {
            InitializePrintPreviewDialog(); //initialize the print preview dialog
            printDialog1 = new PrintDialog(); //create a print dialog object
            InitializePageSetupDialog(); //initialize the page setup dialog         
            axPageLayoutControl1.AutoMouseWheel = true;
            axPageLayoutControl1.Refresh();
        }

        private void InitializePrintPreviewDialog()
        {
            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Name = "打印预览";
            //set UseAntiAlias to true to allow the operating system to smooth fonts
            printPreviewDialog1.UseAntiAlias = true;

            //printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 600);
            //printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            //printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);

            //associate the event-handling method with the document's PrintPage event
            this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);
        }

        private void InitializePageSetupDialog()
        {
            pageSetupDialog1 = new PageSetupDialog();
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.ShowNetwork = false;

        }

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

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            DialogResult result = pageSetupDialog1.ShowDialog();
            document.PrinterSettings = pageSetupDialog1.PrinterSettings;
            document.DefaultPageSettings = pageSetupDialog1.PageSettings;

            IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
            paperSizes.Reset();

            for (int i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
            {
                paperSizes.MoveNext();
                if (((PaperSize)paperSizes.Current).Kind == document.DefaultPageSettings.PaperSize.Kind)
                {
                    document.DefaultPageSettings.PaperSize = ((PaperSize)paperSizes.Current);
                }
            }
            IPaper paper = new PaperClass();
            paper.Attach(pageSetupDialog1.PrinterSettings.GetHdevmode(pageSetupDialog1.PageSettings).ToInt32(), pageSetupDialog1.PrinterSettings.GetHdevnames().ToInt32());

            printer.Paper = paper;
            axPageLayoutControl1.Printer = printer;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            m_CurrentPrintPage = 0;
            if (axPageLayoutControl1.DocumentFilename == null) return;
            document.DocumentName = axPageLayoutControl1.DocumentFilename;
            printPreviewDialog1.Document = document;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog1.AllowSomePages = true; //允许用户选择打印哪些页面
            printDialog1.ShowHelp = true;
            printDialog1.Document = document;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK) 
                document.Print();
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string sPageToPrinterMapping = (string)this.cbxMappingType.SelectedItem;
            if (sPageToPrinterMapping == null)
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("esriPageMappingTile"))
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("esriPageMappingCrop"))
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingCrop;
            else if (sPageToPrinterMapping.Equals("esriPageMappingScale"))
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
            else
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;

            short dpi = (short)e.Graphics.DpiX;
            IEnvelope devBounds = new EnvelopeClass();
            IPage page = axPageLayoutControl1.Page;
            short printPageCount = axPageLayoutControl1.get_PrinterPageCount(0);
            m_CurrentPrintPage++;
            IPrinter printer = axPageLayoutControl1.Printer;
            page.GetDeviceBounds(printer, m_CurrentPrintPage, 0, dpi, devBounds);
            tagRECT deviceRect;
            double xmin, ymin, xmax, ymax;
            devBounds.QueryCoords(out xmin, out ymin, out xmax, out ymax);
            deviceRect.bottom = (int)ymax;
            deviceRect.left = (int)xmin;
            deviceRect.top = (int)ymin;
            deviceRect.right = (int)xmax;
            IEnvelope visBounds = new EnvelopeClass();
            page.GetPageBounds(printer, m_CurrentPrintPage, 0, visBounds);
            IntPtr hdc = e.Graphics.GetHdc();
            axPageLayoutControl1.ActiveView.Output(hdc.ToInt32(), dpi, ref deviceRect, visBounds, m_TrackCancel);

            e.Graphics.ReleaseHdc(hdc);
            if (m_CurrentPrintPage < printPageCount)
                e.HasMorePages = true; //document_PrintPage event will be called again
            else
                e.HasMorePages = false;
        }

        private void cbxPrinterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPrinterType.SelectedItem == null) return;
            strPrinterType = cbxPrinterType.SelectedItem.ToString();
            try
            {
                switch (strPrinterType)
                {
                    case "EmfPrinter":
                        printer = new EmfPrinterClass();
                        break;
                    case "ArcPressPrinter":  //ArcPressPrinter需要ArcGIS桌面许可
                        printer = new ArcPressPrinterClass();
                        break;
                    case "PsPrinter":
                        printer = new PsPrinterClass();
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

    }
}
