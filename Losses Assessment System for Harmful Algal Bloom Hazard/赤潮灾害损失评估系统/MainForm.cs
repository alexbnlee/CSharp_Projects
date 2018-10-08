using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using DevExpress.Utils;
using ESRI.ArcGIS.Output;
using Microsoft.VisualBasic;
using System.Collections;
using System.Drawing.Printing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace 赤潮灾害损失评估系统
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static int origin_layer_num = 0;     //原始图层个数
        public static string[] layer_names = new string[10];    //图层名称
        public static float tourism_num = 0;
        public static float breeding_num = 0;
        public static float monitoring_num = 0;
        public static float disposing_num = 0;

        public static DataTable pS1_1 = new DataTable();

        public static float pS2_1 = 0;
        public static float pS2_2 = 0;
        public static float pS2_3 = 0;

        public static float pS3_1 = 0;
        public static DataTable pS3_2 = new DataTable();

        public static float pS4_1 = 0;
        public static float pS4_2 = 0;
        public static float pS4_3 = 0;
        public static float pS4_4 = 0;

        public static string tourism_result = "无评估结果，请点击左侧的评估按钮！";
        public static string breeding_result = "无评估结果，请点击左侧的评估按钮！";
        public static string monitoring_result = "无评估结果，请点击左侧的评估按钮！";
        public static string disposing_result = "无评估结果，请点击左侧的评估按钮！";
        public static string total_result = "无评估结果，请点击左侧的评估按钮！";

        Excel.Application ex = new Excel.Application(); //Excel应用程序
        Excel.Workbook eWorkbook;   //Excel文档
        Excel.Worksheet eWorksheet;
        string path = "";

        private IGeometry GetBasicGeo(string typevalue) //获取ParcelBasic图层中指定Type值的的Geometry！
        {
            IFeatureLayer pFeatureLayer = null;
            for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
            {
                if (axMapControl1.Map.get_Layer(i).Name == "承灾体数据")
                {
                    pFeatureLayer = axMapControl1.Map.get_Layer(i) as IFeatureLayer;
                    break;
                }
            }

            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IQueryFilter pQueryFilter = new QueryFilter();
            pQueryFilter.WhereClause = "Name = '" + typevalue + "'";
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            IGeometry pTempGeo = pFeature.Shape;

            while (true)
            {
                pFeature = pFeatureCursor.NextFeature();
                if (pFeature == null)
                    break;
                ITopologicalOperator pTopo = pTempGeo as ITopologicalOperator;
                pTempGeo = pTopo.Union(pFeature.Shape);
            }
            return pTempGeo;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                axToolbarControl1.SetBuddyControl(axPageLayoutControl1.Object);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                axToolbarControl1.SetBuddyControl(axMapControl1.Object);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            axMapControl1.LoadMxFile(Directory.GetCurrentDirectory() + @"\Map Doc\CZT.mxd");    //加载根目录下的mxd文件
            axPageLayoutControl1.LoadMxFile(axMapControl1.DocumentFilename); //同上

            barDate.EditValue = DateTime.Now.Date;
            barDatePic.EditValue = DateTime.Now.Date;

            //自定义SuperTip显示
            ToolTipItem toolTipItem1 = new ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new ToolTipSeparatorItem();
            ToolTipTitleItem toolTipFooter1 = new ToolTipTitleItem();
            ToolTipTitleItem toolTipFooter2 = new ToolTipTitleItem();
            ToolTipTitleItem toolTipFooter3 = new ToolTipTitleItem();
            ToolTipTitleItem toolTipFooter4 = new ToolTipTitleItem();
            ToolTipTitleItem toolTipFooter5 = new ToolTipTitleItem();

            toolTipItem1.Image = Properties.Resources.result;
            toolTipItem1.Text = "\n无评估结果，\n请点击左侧的评估按钮！";
            toolTipFooter1.Text = "海水养殖业经济损失评估";
            toolTipFooter2.Text = "滨海旅游业经济损失评估";
            toolTipFooter3.Text = "赤潮灾害应急监测费用评估";
            toolTipFooter4.Text = "赤潮灾害处置费用评估";
            toolTipFooter5.Text = "赤潮灾害总经济损失评估";

            button_breeding_result.SuperTip.Items.Add(toolTipItem1);
            button_breeding_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_breeding_result.SuperTip.Items.Add(toolTipFooter1);

            button_tourism_result.SuperTip.Items.Add(toolTipItem1);
            button_tourism_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_tourism_result.SuperTip.Items.Add(toolTipFooter2);

            button_monitoring_result.SuperTip.Items.Add(toolTipItem1);
            button_monitoring_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_monitoring_result.SuperTip.Items.Add(toolTipFooter3);

            button_disposing_result.SuperTip.Items.Add(toolTipItem1);
            button_disposing_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_disposing_result.SuperTip.Items.Add(toolTipFooter4);

            button_total_result.SuperTip.Items.Add(toolTipItem1);
            button_total_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_total_result.SuperTip.Items.Add(toolTipFooter5);

            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Name = "打印预览";
            //set UseAntiAlias to true to allow the operating system to smooth fonts
            printPreviewDialog1.UseAntiAlias = true;
            //printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 600);
            //printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            //printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
            //associate the event-handling method with the document's PrintPage event
            this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);
            
            printDialog1 = new PrintDialog(); //create a print dialog object	

            pageSetupDialog1 = new PageSetupDialog();
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.ShowNetwork = false;

            origin_layer_num = axMapControl1.Map.LayerCount;    //默认图层数
            for (int i = 0; i < origin_layer_num; i++)
                layer_names[i] = axMapControl1.get_Layer(i).Name;   //获取默认图层的名称

            Welcome_Form Wel_frm = new Welcome_Form();
            Wel_frm.ShowDialog();
        }

        private void barButton_detectData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //首先检测是否存在赤潮图层，如果图层增加，则说明添加了。。不严谨
            if (axMapControl1.Map.LayerCount == origin_layer_num)
            {
                MessageBox.Show("请导入赤潮发生区域数据！", "错误提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int new_layer_index = 0;
            int flag = 0;
            string[] new_layer_names = new string[10];
            for (int i = 0; i <= origin_layer_num; i++)
                new_layer_names[i] = axMapControl1.get_Layer(i).Name;  

            for (int i = 0; i <= origin_layer_num; i++)
            {
                flag = 0;   //初始化为0
                for (int j = 0; j < origin_layer_num; j++)  //将新图层的名称与老图层比较，没有共同名称的，就是新添加的图层
                {
                    if (new_layer_names[i] == layer_names[j])
                        continue;
                    else
                        flag++; //若是图层名称不同，则flag增加一个
                }
                if (flag == origin_layer_num)   //跟所有的图层都不一样，说明是新的图层 
                {
                    new_layer_index = i;
                    break;
                }
            }

            try
            {
	            IGeometry pGeo_shatan = GetBasicGeo("沙滩浴场");                          
	            IGeometry pGeo_fufa = GetBasicGeo("浮筏养殖");
                
                //找到新添加的图层
	            IFeatureLayer pFeatureLayer = axMapControl1.Map.get_Layer(new_layer_index) as IFeatureLayer;
	
	            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
	            IQueryFilter pQueryFilter = new QueryFilter();
	            pQueryFilter.WhereClause = "FID >= 0";
	            IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
	            IFeature pFeature = pFeatureCursor.NextFeature();
	            IGeometry pGeo_chichao = pFeature.Shape;
	
	            while (true)
	            {
	                pFeature = pFeatureCursor.NextFeature();
	                if (pFeature == null)
	                {
	                    break;
	                }
	                ITopologicalOperator pTopoTemp = pGeo_chichao as ITopologicalOperator;
	                pGeo_chichao = pTopoTemp.Union(pFeature.Shape);
	            }
	
	            IRelationalOperator pTopo = pGeo_chichao as IRelationalOperator;
	            if ((pTopo.Overlaps(pGeo_fufa) || pTopo.Contains(pGeo_fufa)) && (pTopo.Overlaps(pGeo_shatan) || pTopo.Contains(pGeo_shatan)))
	                MessageBox.Show("赤潮发生区域与浮筏养殖和沙滩浴场的区域存在重叠！");
	            else if (pTopo.Overlaps(pGeo_fufa) || pTopo.Contains(pGeo_fufa))
	                MessageBox.Show("赤潮发生区域与浮筏养殖的区域存在重叠！");
	            else if (pTopo.Overlaps(pGeo_shatan) || pTopo.Contains(pGeo_shatan))
	                MessageBox.Show("赤潮发生区域与沙滩浴场的区域存在重叠！");
	            else
	                MessageBox.Show("赤潮发生区域不与承灾体发生重叠！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请确保导入数据与被检测数据具有相同的空间参考系，建议在样例文件上面修改。", "错误提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButton_addData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (axMapControl1.Map.LayerCount == origin_layer_num + 1)
            {
                DialogResult dr = MessageBox.Show("已存在赤潮发生区域的图层，是否删除此赤潮发生区域图层来添加新" + 
                    "的赤潮发生区域？选择\"是\"会删除此赤潮发生区域并添加新的赤潮发生区域；选择\"否\"则直接退出此窗口" + 
                    "而不做任何其它操作。", "警告提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                    return;
                else
                {
                    try
                    {
                        axMapControl1.LoadMxFile(Directory.GetCurrentDirectory() + @"\Map Doc\CZT.mxd");    //加载根目录下的mxd文件
                        axPageLayoutControl1.LoadMxFile(axMapControl1.DocumentFilename); //同上
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "通知");
                    }
                }
            }
            ICommand openFile = new ControlsAddDataCommand();
            openFile.OnCreate(axMapControl1.Object);
            openFile.OnClick();
        }

        private void barButton_deleteData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (axMapControl1.Map.LayerCount == origin_layer_num)
            {
                MessageBox.Show("没有可以删除的图层数据！", "错误提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                axMapControl1.LoadMxFile(Directory.GetCurrentDirectory() + @"\Map Doc\CZT.mxd");    //加载根目录下的mxd文件
                axPageLayoutControl1.LoadMxFile(axMapControl1.DocumentFilename); //同上
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "通知");
            }
        }

        private void barButton_setting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(axMapControl1.DocumentFilename);
        }

        private void barButton_saveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ICommand saveAsMxd = new ControlsSaveAsDocCommand();
            saveAsMxd.OnCreate(axMapControl1.Object);
            saveAsMxd.OnClick();

            //ICommand openDoc = new ControlsOpenDocCommand();
            //openDoc.OnCreate(axMapControl1.Object);
            //openDoc.OnClick();

            //string strFileName = axMapControl1.DocumentFilename;
            //label_fileName.Text = "文件名：" + strFileName.Substring(strFileName.LastIndexOf('\\') + 1);

            //axMapControl1.LoadMxFile(Directory.GetCurrentDirectory() + @"\Map Doc\CZT.mxd");    //加载根目录下的mxd文件
            //axPageLayoutControl1.LoadMxFile(axMapControl1.DocumentFilename); //同上
        }

        private void button_breeding_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Breeding_Form frm = new Breeding_Form();
            frm.ShowDialog();

            ToolTipItem toolTipItem1 = new ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new ToolTipSeparatorItem();
            ToolTipTitleItem toolTipFooter1 = new ToolTipTitleItem();

            string str1 = MainForm.breeding_result.Substring(0, MainForm.breeding_result.Length / 2);
            string str2 = MainForm.breeding_result.Substring(MainForm.breeding_result.Length / 2);
            toolTipItem1.Image = Properties.Resources.result;
            toolTipItem1.Text = "\n" + str1 + "\n" + str2;
            toolTipFooter1.Text = "海水养殖业经济损失评估";

            //删除掉已有的选项
            button_breeding_result.SuperTip.Items.RemoveAt(button_breeding_result.SuperTip.Items.Count - 1);
            button_breeding_result.SuperTip.Items.RemoveAt(button_breeding_result.SuperTip.Items.Count - 1);
            button_breeding_result.SuperTip.Items.RemoveAt(button_breeding_result.SuperTip.Items.Count - 1);
            //增加新的选项
            button_breeding_result.SuperTip.Items.Add(toolTipItem1);
            button_breeding_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_breeding_result.SuperTip.Items.Add(toolTipFooter1);
        }

        private void button_breeding_result_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(MainForm.breeding_result, "海水养殖业经济损失评估结果", MessageBoxButtons.OK, 
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void button_tourism_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tourism_Form frm = new Tourism_Form();
            frm.ShowDialog();

            ToolTipItem toolTipItem1 = new ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new ToolTipSeparatorItem();
            ToolTipTitleItem toolTipFooter1 = new ToolTipTitleItem();

            string str1 = MainForm.tourism_result.Substring(0, MainForm.tourism_result.Length / 2);
            string str2 = MainForm.tourism_result.Substring(MainForm.tourism_result.Length / 2);
            toolTipItem1.Image = Properties.Resources.result;
            toolTipItem1.Text = "\n" + str1 + "\n" + str2;
            toolTipFooter1.Text = "滨海旅游业经济损失评估";

            //删除掉已有的选项
            button_tourism_result.SuperTip.Items.RemoveAt(button_tourism_result.SuperTip.Items.Count - 1);
            button_tourism_result.SuperTip.Items.RemoveAt(button_tourism_result.SuperTip.Items.Count - 1);
            button_tourism_result.SuperTip.Items.RemoveAt(button_tourism_result.SuperTip.Items.Count - 1);
            //增加新的选项
            button_tourism_result.SuperTip.Items.Add(toolTipItem1);
            button_tourism_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_tourism_result.SuperTip.Items.Add(toolTipFooter1);
        }

        private void button_tourism_result_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(MainForm.tourism_result, "滨海旅游业经济损失评估", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void button_monitoring_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Monitoring_Form frm = new Monitoring_Form();
            frm.ShowDialog();

            ToolTipItem toolTipItem1 = new ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new ToolTipSeparatorItem();
            ToolTipTitleItem toolTipFooter1 = new ToolTipTitleItem();

            string str1 = MainForm.monitoring_result.Substring(0, MainForm.monitoring_result.Length / 2);
            string str2 = MainForm.monitoring_result.Substring(MainForm.monitoring_result.Length / 2);
            toolTipItem1.Image = Properties.Resources.result;
            toolTipItem1.Text = "\n" + str1 + "\n" + str2;
            toolTipFooter1.Text = "赤潮灾害应急监测费用评估";

            //删除掉已有的选项
            button_monitoring_result.SuperTip.Items.RemoveAt(button_monitoring_result.SuperTip.Items.Count - 1);
            button_monitoring_result.SuperTip.Items.RemoveAt(button_monitoring_result.SuperTip.Items.Count - 1);
            button_monitoring_result.SuperTip.Items.RemoveAt(button_monitoring_result.SuperTip.Items.Count - 1);
            //增加新的选项
            button_monitoring_result.SuperTip.Items.Add(toolTipItem1);
            button_monitoring_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_monitoring_result.SuperTip.Items.Add(toolTipFooter1);
        }

        private void button_monitoring_result_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(MainForm.monitoring_result, "赤潮灾害应急监测费用评估", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void button_disposing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Disposing_Form frm = new Disposing_Form();
            frm.ShowDialog();

            ToolTipItem toolTipItem1 = new ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new ToolTipSeparatorItem();
            ToolTipTitleItem toolTipFooter1 = new ToolTipTitleItem();

            string str1 = MainForm.disposing_result.Substring(0, MainForm.disposing_result.Length / 2);
            string str2 = MainForm.disposing_result.Substring(MainForm.disposing_result.Length / 2);
            toolTipItem1.Image = Properties.Resources.result;
            toolTipItem1.Text = "\n" + str1 + "\n" + str2;
            toolTipFooter1.Text = "赤潮灾害处置费用评估";

            //删除掉已有的选项
            button_disposing_result.SuperTip.Items.RemoveAt(button_disposing_result.SuperTip.Items.Count - 1);
            button_disposing_result.SuperTip.Items.RemoveAt(button_disposing_result.SuperTip.Items.Count - 1);
            button_disposing_result.SuperTip.Items.RemoveAt(button_disposing_result.SuperTip.Items.Count - 1);
            //增加新的选项
            button_disposing_result.SuperTip.Items.Add(toolTipItem1);
            button_disposing_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_disposing_result.SuperTip.Items.Add(toolTipFooter1);
        }

        private void button_disposing_result_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(MainForm.disposing_result, "赤潮灾害处置费用评估", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void button_total_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Total_Form frm = new Total_Form();
            frm.ShowDialog();

            ToolTipItem toolTipItem1 = new ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new ToolTipSeparatorItem();
            ToolTipTitleItem toolTipFooter1 = new ToolTipTitleItem();

            string str1 = MainForm.total_result.Substring(0, MainForm.total_result.Length / 2);
            string str2 = MainForm.total_result.Substring(MainForm.total_result.Length / 2);
            toolTipItem1.Image = Properties.Resources.result;
            toolTipItem1.Text = "\n" + str1 + "\n" + str2;
            toolTipFooter1.Text = "赤潮灾害总经济损失评估";

            //删除掉已有的选项
            button_total_result.SuperTip.Items.RemoveAt(button_total_result.SuperTip.Items.Count - 1);
            button_total_result.SuperTip.Items.RemoveAt(button_total_result.SuperTip.Items.Count - 1);
            button_total_result.SuperTip.Items.RemoveAt(button_total_result.SuperTip.Items.Count - 1);
            //增加新的选项
            button_total_result.SuperTip.Items.Add(toolTipItem1);
            button_total_result.SuperTip.Items.Add(toolTipSeparatorItem1);
            button_total_result.SuperTip.Items.Add(toolTipFooter1);
        }

        private void button_total_result_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(MainForm.total_result, "赤潮灾害总经济损失评估", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void barButton_openFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ICommand openDoc = new ControlsOpenDocCommand();
            openDoc.OnCreate(axMapControl1.Object);
            openDoc.OnClick();
            string strFileName = axMapControl1.DocumentFilename;
            label_fileName.Text = "文件名：" + strFileName.Substring(strFileName.LastIndexOf('\\') + 1);
        }

        private void outPicture_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG(*.jpg)|*.jpg|BMP(*.BMP)|*.bmp|EMF(*.emf)|*.emf|GIF(*.gif)|*.gif|AI(*.ai)|*.ai|PDF(*.pdf)|*.pdf|PNG(*.png)|*.png|EPS(*.eps)|*.eps|SVG(*.svg)|*.svg|TIFF(*.tif)|*.tif";
            saveFileDialog1.Title = "输出地图";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            int filterIndex = saveFileDialog1.FilterIndex;
            IActiveView pActiveView = axPageLayoutControl1.ActiveView;
            //ExportPic exportPic = new ExportPic();
            //bool flag = exportPic.ExportMapToImage(pActiveView,fileName,filterIndex);

            bool flag = ExportMapToImage(pActiveView, fileName, filterIndex);
            saveFileDialog1.Dispose();
            if (flag)
            {
                MessageBox.Show("图片输出成功！", "成功");
            }
            else
            {
                MessageBox.Show("图片输出失败，请重新生成！", "失败");
            }
        }

        public bool ExportMapToImage(IActiveView pActiveView, string fileName, int filterIndex)
        {
            try
            {
                IExport pExporter = null;

                switch (filterIndex)
                {
                    case 1:
                        pExporter = new ExportJPEGClass();
                        break;
                    case 2:
                        pExporter = new ExportBMPClass();
                        break;
                    case 3:
                        pExporter = new ExportEMFClass();
                        break;
                    case 4:
                        pExporter = new ExportGIFClass();
                        break;
                    case 5:
                        pExporter = new ExportAIClass();
                        break;
                    case 6:
                        pExporter = new ExportPDFClass();
                        break;
                    case 7:
                        pExporter = new ExportPNGClass();
                        break;
                    case 8:
                        pExporter = new ExportPSClass();
                        break;
                    case 9:
                        pExporter = new ExportSVGClass();
                        break;
                    case 10:
                        pExporter = new ExportTIFFClass();
                        break;
                    default:
                        MessageBox.Show("输出格式错误");
                        return false;
                }

                IEnvelope pEnvelope = new EnvelopeClass();
                ITrackCancel pTrackCancel = new CancelTracker();
                tagRECT ptagRECT;
                ptagRECT.left = 0;
                ptagRECT.top = 0;
                ptagRECT.right = (int)pActiveView.Extent.Width;
                ptagRECT.bottom = (int)pActiveView.Extent.Height;

                int pResolution = (int)(pActiveView.ScreenDisplay.DisplayTransformation.Resolution);
                pEnvelope.PutCoords(ptagRECT.left, ptagRECT.bottom, ptagRECT.right, ptagRECT.top);

                pExporter.Resolution = pResolution;
                pExporter.ExportFileName = fileName;
                pExporter.PixelBounds = pEnvelope;

                pActiveView.Output(pExporter.StartExporting(), pResolution, ref ptagRECT, pActiveView.Extent, pTrackCancel);
                pExporter.FinishExporting();

                //释放资源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pExporter);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "输出图片", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //编写数据拷贝函数（封装起来，便于多处调用）；

        private void CopyAndOverwriteMap()
        {
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            //map to copy
            object toCopyMap = axMapControl1.Map;
            //copied map
            object copiedMap = pObjectCopy.Copy(toCopyMap);
            //map to overwrite(不加这两行就出错)
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            object toOverwriteMap = axPageLayoutControl1.ActiveView.FocusMap;
            //overwrite the pagelayoutcontrol's map
            pObjectCopy.Overwrite(copiedMap, ref toOverwriteMap);
        }

         private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
         {
             IActiveView pActiveView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
             IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
             displayTransformation.VisibleBounds = axMapControl1.Extent;
             axPageLayoutControl1.ActiveView.Refresh();
             CopyAndOverwriteMap();
         }

         private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
         {
             //axTOCControl1.Update();
             CopyAndOverwriteMap();
         }

         private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
         {
             IBasicMap map = new MapClass();
             ILayer layer = new FeatureLayerClass();
             object other = new object();
             object index = new object();
             esriTOCControlItem item = new esriTOCControlItem();

             //Determine what kind of item has been clicked on
             axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

             if (e.button == 1)
             {
                 //QI to IFeatureLayer and IGeoFeatuerLayer interface
                 if (layer == null) return;
                 IFeatureLayer featureLayer = layer as IFeatureLayer;
                 if (featureLayer == null) return;
                 IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)featureLayer;

                 ILegendClass legendClass = new LegendClassClass();
                 ISymbol symbol = null;
                 if (other is ILegendGroup && (int)index != -1)
                 {
                     legendClass = ((ILegendGroup)other).get_Class((int)index);
                     symbol = legendClass.Symbol;
                 }
                 if (symbol == null) return;

                 symbol = GetSymbolByControl(symbol);
                 //symbol = GetSymbolBySymbolSelector(symbol);
                 if (symbol == null) return;
                 legendClass.Symbol = symbol;
                 this.Activate();
                 //Fire contents changed event that the TOCControl listens to
                 axMapControl1.ActiveView.ContentsChanged();
                 //Refresh the display
                 axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                 axTOCControl1.Update();
             }
         }

         private ISymbol GetSymbolByControl(ISymbol symbolType)
         {
             ISymbol symbol = null;
             IStyleGalleryItem styleGalleryItem = null;
             esriSymbologyStyleClass styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
             if (symbolType is IMarkerSymbol)
             {
                 styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
             }
             if (symbolType is ILineSymbol)
             {
                 styleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
             }
             if (symbolType is IFillSymbol)
             {
                 styleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
             }
             GetSymbolByControlForm symbolForm = new GetSymbolByControlForm(styleClass);
             symbolForm.ShowDialog();
             styleGalleryItem = symbolForm.m_styleGalleryItem;
             if (styleGalleryItem == null) return null;
             symbol = styleGalleryItem.Item as ISymbol;
             symbolForm.Dispose();
             this.Activate();
             return symbol;
         }

         internal PageSetupDialog pageSetupDialog1;
         internal PrintPreviewDialog printPreviewDialog1;
         internal PrintDialog printDialog1;
         private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
         IPrinter printer = new EmfPrinterClass();
         private short m_CurrentPrintPage;
         private ITrackCancel m_TrackCancel = new CancelTrackerClass();

         private void button_Printer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             //Release COM objects
             ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
             printDialog1.AllowSomePages = true; //允许用户选择打印哪些页面
             printDialog1.ShowHelp = true;
             printDialog1.Document = document;
             DialogResult result = printDialog1.ShowDialog();
             if (result == DialogResult.OK)
                 document.Print();
         }

         private void button_ExportPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             IExport export = new ExportJPEGClass();
             IOutputRasterSettings rasterSettings;
             double iOutputResolution = Convert.ToDouble(edit_dpi.EditValue);
             string exportFileName = "C:\\Temp\\test.jpg";
             string fileExtension = "JPG";
             SaveFileDialog saveFileDialog2 = new SaveFileDialog();
             saveFileDialog2.Filter = "JPEG|*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png|TIFF|*.tif|AI|*.ai|EMF|*.emf|PDF|*.pdf|PS|*.ps|SVG|*.svg";
             DateTime dt = new DateTime();
             dt = (DateTime)barDatePic.EditValue;
             saveFileDialog2.FileName = dt.ToLongDateString() + " - 赤潮灾害损失评估专题图";
             if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                 exportFileName = saveFileDialog2.FileName + "." + fileExtension;
             else
                 return;

             this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

             if (export is IOutputRasterSettings)
             {
                 //矢量格式输出
                 rasterSettings = (IOutputRasterSettings)export;
                 rasterSettings.ResampleRatio = 1;
             }

             #region 扩展名
             try
             {
                 switch (saveFileDialog2.FilterIndex)
                 {
                     case 0:
                         export = new ExportJPEGClass();
                         fileExtension = "JPG";
                         break;
                     case 1:  //ArcPressPrinter需要ArcGIS桌面许可
                         export = new ExportBMPClass();
                         fileExtension = "BMP";
                         break;
                     case 2:
                         export = new ExportGIFClass();
                         fileExtension = "GIF";
                         break;
                     case 3:
                         export = new ExportAIClass();
                         fileExtension = "AI";
                         break;
                     case 4:
                         export = new ExportEMFClass();
                         fileExtension = "EMF";
                         break;
                     case 5:
                         export = new ExportPDFClass();
                         fileExtension = "PDF";
                         break;
                     case 6:
                         export = new ExportPSClass();
                         fileExtension = "PS";
                         break;
                     case 7:
                         export = new ExportPDFClass();
                         fileExtension = "PDF";
                         break;
                     case 8:
                         export = new ExportPSClass();
                         fileExtension = "PS";
                         break;
                     case 9:
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
             #endregion

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

             this.Cursor = Cursors.Default;

             if (MessageBox.Show("专题地图输出成功！是否打开此文件？", "消息提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 string folderName;
                 folderName = saveFileDialog2.FileName.Substring(0, saveFileDialog2.FileName.LastIndexOf('\\'));
                 System.Diagnostics.Process.Start("explorer.exe", folderName);
             }
         }

         private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
         {
             //地图输出时自动切换成PagelayoutControl界面，其他时候为MapControl界面！
             if (ribbonControl1.SelectedPage.Name == "ribbonPage3")
                 xtraTabControl1.SelectedTabPage = xtraTabPage2;
             else
                 xtraTabControl1.SelectedTabPage = xtraTabPage1;
         }

         private void button_about_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             About_Form frm = new About_Form();
             frm.ShowDialog();
         }

         private void button_PageSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

         private void button_PrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             m_CurrentPrintPage = 0;
             if (axPageLayoutControl1.DocumentFilename == null) return;
             document.DocumentName = axPageLayoutControl1.DocumentFilename;
             printPreviewDialog1.Document = document;
             printPreviewDialog1.ShowDialog();
         }

         private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
         {
             string sPageToPrinterMapping = "esriPageMappingScale";
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

         private void button_Statistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EvaResult_Form frm = new EvaResult_Form();
             frm.ShowDialog();
         }

         private void button_EvaResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             TblResult_Form frm = new TblResult_Form();
             frm.ShowDialog();
         }

         private void button_exportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "Excel文件（*.xlsx）|*.xlsx|文本文件（*.txt）|*.txt";
             DateTime dt = new DateTime();
             dt = (DateTime)barDate.EditValue;
             sfd.FileName = dt.ToLongDateString() + " - 赤潮灾害损失评估结果";
             if (sfd.ShowDialog() == DialogResult.OK)
             {
                 #region 导出为文本文件
                 if (sfd.FilterIndex == 2)
                 {
                     StreamWriter sw = new StreamWriter(sfd.FileName);
                     string s0 = "\r\n" + dt.ToLongDateString() + " - 赤潮灾害损失评估结果";
                     string separator = "\r\n" + "==========================================" + "\r\n";
                     string detailArg = "详细参数如下：\r\n\r\n";

                     string s1 = "1. 海水养殖业经济损失的评估值为" + MainForm.breeding_num + "元。\r\n";
                     string s1_1 = "本次赤潮导致不同养殖品种的损失量（kg）及其社会经济单位价值（元/kg）：\r\n养殖品种名称\t损失量（kg）\t单位价值（元/kg）\r\n";   //图表形式，datagridview转换为datatable数据
                     foreach (DataRow rw in pS1_1.Rows)
                         s1_1 += rw[0].ToString() + "\t" + rw[1].ToString() + "\t" + rw[2].ToString() + "\r\n";

                     string s2 = "2. 滨海旅游业经济损失的评估值为" + MainForm.tourism_num + "元。\r\n";
                     string s2_1 = "受本次赤潮影响的滨海旅游海域的日平均人数（人/天）：" + pS2_1 + "\r\n";
                     string s2_2 = "受本次赤潮影响的滨海旅游海域的人均消费金额（元/天）：" + pS2_2 + "\r\n";
                     string s2_3 = "本次赤潮灾害事件的持续时间（天）：" + pS2_3;

                     string s3 = "3. 赤潮灾害应急监测费用的评估值为" + MainForm.monitoring_num + "元。\r\n";
                     string s3_1 = "本次赤潮灾害处置，用于支付船舶租用的费用（元）：" + pS3_1 + "\r\n";
                     string s3_2 = "本次赤潮事件发生后，每个监测站位的费用（元）：\r\n站位名称\t船舶租用费用（元）\r\n";
                     foreach (DataRow rw in pS3_2.Rows)
                         s3_2 += rw[0].ToString() + "\t" + rw[1].ToString() + "\r\n";

                     string s4 = "4. 赤潮灾害处置费用评估的评估值为" + MainForm.disposing_num + "元。\r\n";
                     string s4_1 = "本次赤潮处置所需处置材料的消耗量（吨）：" + pS4_1 + "\r\n";
                     string s4_2 = "本次赤潮处置材料的经济单位价格（元/吨）：" + pS4_2 + "\r\n";
                     string s4_3 = "本次赤潮灾害处置，用于支付船舶租用的费用（元）：" + pS4_3 + "\r\n";
                     string s4_4 = "本次赤潮灾害处置的人工费等费用（元）：" + pS4_4;

                     float total_num = MainForm.breeding_num + MainForm.tourism_num + MainForm.monitoring_num + MainForm.disposing_num;
                     string s5 = "5. 赤潮灾害总经济损失评估的评估值为" + total_num + "元。\r\n";
                     string s5_1 = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + breeding_num + "\r\n";
                     string s5_2 = "本次赤潮灾害导致滨海旅游业的经济损失（元）：" + tourism_num + "\r\n";
                     string s5_3 = "本次赤潮灾害事件的业务与应急监测费用（元）：" + monitoring_num + "\r\n";
                     string s5_4 = "本次赤潮灾害事件的处置费用（元）：" + disposing_num;

                     string w = s0 + "\r\n" + separator + "\r\n" +
                         s1 + "\r\n" + detailArg + s1_1 + separator + "\r\n" +
                         s2 + "\r\n" + detailArg + s2_1 + s2_2 + s2_3 + "\r\n" + separator + "\r\n" +
                         s3 + "\r\n" + detailArg + s3_1 + s3_2 + separator + "\r\n" +
                         s4 + "\r\n" + detailArg + s4_1 + s4_2 + s4_3 + s4_4 + "\r\n" + separator + "\r\n" +
                         s5 + "\r\n" + detailArg + s5_1 + s5_2 + s5_3 + s5_4 + "\r\n" + separator;
                     sw.Write(w);
                     sw.Close();
                 }
                 #endregion
                 #region 导出为Excel文件
                 else if (sfd.FilterIndex == 1)
                 {
                     path = sfd.FileName;
                     if (File.Exists(path))
                     {
                         //判断文件是否运行，若是运行，则显示错误提示
                         try
                         {
                             System.IO.FileStream fs = File.OpenWrite(path);
                             fs.Close();
                         }
                         catch (System.Exception ex01)
                         {
                             MessageBox.Show(ex01.Message, "错误提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             return;
                         }
                         File.Delete(path);
                     }

                     object nothing = Missing.Value;

                     eWorkbook = ex.Workbooks.Add(true);

                     #region Sheet1
                     eWorksheet = eWorkbook.ActiveSheet;
                     eWorksheet.Name = "损失评估结果";

                     Excel.Range eRange = eWorksheet.get_Range("A1", "C1");     //定义一个Range
                     eRange.MergeCells = true;      //将Range合并
                     eRange.Value = dt.ToLongDateString() + " - 赤潮灾害损失评估结果";   //为Range赋值
                     eRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;    //Range内容水平居中

                     eWorksheet.Cells[3, 1] = "序号";
                     eWorksheet.Cells[3, 2] = "赤潮灾害损失分类";
                     eWorksheet.Cells[3, 3] = "评估值（元）";

                     eWorksheet.Cells[4, 1] = "1";
                     eWorksheet.Cells[4, 2] = "海水养殖业经济损失";
                     eWorksheet.Cells[4, 3] = MainForm.breeding_num;

                     eWorksheet.Cells[5, 1] = "2";
                     eWorksheet.Cells[5, 2] = "滨海旅游业经济损失";
                     eWorksheet.Cells[5, 3] = MainForm.tourism_num;

                     eWorksheet.Cells[6, 1] = "3";
                     eWorksheet.Cells[6, 2] = "赤潮灾害应急监测费用";
                     eWorksheet.Cells[6, 3] = MainForm.monitoring_num;

                     eWorksheet.Cells[7, 1] = "4";
                     eWorksheet.Cells[7, 2] = "赤潮灾害处置费用";
                     eWorksheet.Cells[7, 3] = MainForm.disposing_num;

                     eWorksheet.Cells[8, 1] = "5";
                     eWorksheet.Cells[8, 2] = "赤潮灾害总经济损失";
                     eWorksheet.Cells[8, 3] = MainForm.tourism_num;

                     eWorksheet.Cells.Columns.AutoFit();    //宽度合适

                     eWorkbook.Sheets.Add(nothing, eWorksheet, 5, nothing);     //增加5个工作表
                     #endregion

                     #region Sheet2
                     eWorkbook.Sheets[2].Name = "海水养殖业经济损失";
                     eWorksheet = eWorkbook.Sheets[2];
                     eRange = eWorksheet.get_Range("A1", "C1");
                     eRange.MergeCells = true;
                     eRange.Value = "海水养殖业经济损失";
                     eRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                     eWorksheet.Cells[3, 1] = "养殖品种名称";
                     eWorksheet.Cells[3, 2] = "损失量（kg）";
                     eWorksheet.Cells[3, 3] = "单位价值（元/kg）";

                     int flag = 0;  //循环增加的数量
                     foreach (DataRow rw in pS1_1.Rows)
                     {
                         eWorksheet.Cells[4 + flag, 1] = rw[0].ToString();
                         eWorksheet.Cells[4 + flag, 2] = rw[1].ToString();
                         eWorksheet.Cells[4 + flag, 3] = rw[2].ToString();
                         flag++;
                     }

                     eWorksheet.Cells.Columns.AutoFit();
                     #endregion

                     #region Sheet3
                     eWorkbook.Sheets[3].Name = "滨海旅游业经济损失";
                     eWorksheet = eWorkbook.Sheets[3];
                     eRange = eWorksheet.get_Range("A1", "B1");
                     eRange.MergeCells = true;
                     eRange.Value = "滨海旅游业经济损失";
                     eRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                     eWorksheet.Cells[3, 1] = "日平均人数（人/天）";
                     eWorksheet.Cells[3, 2] = pS2_1;

                     eWorksheet.Cells[4, 1] = "人均消费金额（元/天）";
                     eWorksheet.Cells[4, 2] = pS2_2;

                     eWorksheet.Cells[5, 1] = "事件的持续时间（天）";
                     eWorksheet.Cells[5, 2] = pS2_3;

                     eWorksheet.Cells.Columns.AutoFit();
                     #endregion

                     #region Sheet4
                     eWorkbook.Sheets[4].Name = "赤潮灾害应急监测费用";
                     eWorksheet = eWorkbook.Sheets[4];
                     eRange = eWorksheet.get_Range("A1", "B1");
                     eRange.MergeCells = true;
                     eRange.Value = "赤潮灾害应急监测费用";
                     eRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                     eWorksheet.Cells[3, 1] = "船舶租用的费用（元）";
                     eWorksheet.Cells[3, 2] = pS3_1;

                     eWorksheet.Cells[5, 1] = "站位名称";
                     eWorksheet.Cells[5, 2] = "船舶租用费用（元）";

                     flag = 0;
                     foreach (DataRow rw in pS3_2.Rows)
                     {
                         eWorksheet.Cells[6 + flag, 1] = rw[0].ToString();
                         eWorksheet.Cells[6 + flag, 2] = rw[1].ToString();
                         flag++;
                     }

                     eWorksheet.Cells.Columns.AutoFit();
                     #endregion

                     #region Sheet5
                     eWorkbook.Sheets[5].Name = "赤潮灾害处置费用评估";
                     eWorksheet = eWorkbook.Sheets[5];
                     eRange = eWorksheet.get_Range("A1", "B1");
                     eRange.MergeCells = true;
                     eRange.Value = "赤潮灾害处置费用评估";
                     eRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                     eWorksheet.Cells[3, 1] = "处置材料的消耗量（吨）";
                     eWorksheet.Cells[3, 2] = pS4_1;

                     eWorksheet.Cells[4, 1] = "处置材料的经济单位价格（元/吨）";
                     eWorksheet.Cells[4, 2] = pS4_2;

                     eWorksheet.Cells[5, 1] = "用于支付船舶租用的费用（元）";
                     eWorksheet.Cells[5, 2] = pS4_3;

                     eWorksheet.Cells[6, 1] = "人工费等费用（元）";
                     eWorksheet.Cells[6, 2] = pS4_4;

                     eWorksheet.Cells.Columns.AutoFit();
                     #endregion

                     #region Sheet6
                     eWorkbook.Sheets[6].Name = "赤潮灾害总经济损失评估";
                     eWorksheet = eWorkbook.Sheets[6];
                     eRange = eWorksheet.get_Range("A1", "B1");
                     eRange.MergeCells = true;
                     eRange.Value = "赤潮灾害总经济损失评估";
                     eRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                     eWorksheet.Cells[3, 1] = "损失评估类型";
                     eWorksheet.Cells[3, 2] = "损失值（元）";

                     eWorksheet.Cells[4, 1] = "海水养殖业的经济损失";
                     eWorksheet.Cells[4, 2] = MainForm.breeding_num;

                     eWorksheet.Cells[5, 1] = "滨海旅游业的经济损失";
                     eWorksheet.Cells[5, 2] = MainForm.tourism_num;

                     eWorksheet.Cells[6, 1] = "业务与应急监测费用";
                     eWorksheet.Cells[6, 2] = MainForm.monitoring_num;

                     eWorksheet.Cells[7, 1] = "处置费用";
                     eWorksheet.Cells[7, 2] = MainForm.disposing_num;

                     eWorksheet.Cells.Columns.AutoFit();
                     #endregion

                     eWorkbook.SaveCopyAs(path);
                     eWorkbook.Close(false, nothing, nothing);

                     ex.Quit();
                 }
                 #endregion
             }
             else
                 return;
             
             DialogResult dr = MessageBox.Show("文件输出成功！是否打开此文件？", "消息提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (dr == DialogResult.Yes)
                 System.Diagnostics.Process.Start(sfd.FileName);
         }

         private void button_importData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             try
             {
	            OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel文件（*.xlsx）|*.xlsx|文本文件（*.txt）|*.txt";
                DateTime dt = new DateTime();
	            if (ofd.ShowDialog() == DialogResult.OK)
	            {
                    #region 由文本文件导入
                    if (ofd.FilterIndex == 2)
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8))    //用其他的编码，容易乱码
                        {
                            string s = "";
                            StringBuilder sb = new StringBuilder();
                            while ((s = sr.ReadLine()) != null)
                                sb.AppendLine(s);
                            string totalTxt = sb.ToString();

                            string dt_year;
                            string dt_month;
                            string dt_day;
                            string dt_date = totalTxt.Substring(totalTxt.IndexOf("年") - 4, totalTxt.IndexOf("日") - totalTxt.IndexOf("年") + 5);

                            dt_year = dt_date.Substring(0, dt_date.IndexOf("年"));
                            dt_month = dt_date.Substring(dt_date.IndexOf("年") + 1, dt_date.IndexOf("月") - dt_date.IndexOf("年") - 1);
                            dt_day = dt_date.Substring(dt_date.IndexOf("月") + 1, dt_date.IndexOf("日") - dt_date.IndexOf("月") - 1);

                            dt = new DateTime(Convert.ToInt32(dt_year), Convert.ToInt32(dt_month), Convert.ToInt32(dt_day));
                        
                            int part1_start = totalTxt.IndexOf("本次赤潮导致");
                            int part1_end = totalTxt.IndexOf("2.") - "==========================================".Length - 4;
                            string part1 = totalTxt.Substring(part1_start, part1_end - part1_start);
                            string part1_1 = part1.Substring(part1.LastIndexOf("单位价值（元/kg）") + 12);
                            string[] part1_array = part1_1.Split(new char[] { '\t', '\n' });
                            //清空datatable中的数据，并重新添加3列
                            MainForm.pS1_1.Clear();     //清除datatable中的行（row）
                            MainForm.pS1_1.Columns.Clear();     //清除datatable中的列
                            MainForm.pS1_1.Columns.Add("养殖品种名称");
                            MainForm.pS1_1.Columns.Add("损失量（kg）");
                            MainForm.pS1_1.Columns.Add("单位价值（元/kg）");

                            //通过遍历，将文本中的数据导入到datatable中去
                            for (int i = 0; i < part1_array.Length / 3; i++)
                            {
                                MainForm.pS1_1.Rows.Add();
                                MainForm.pS1_1.Rows[i][0] = part1_array[i * 3];
                                MainForm.pS1_1.Rows[i][1] = part1_array[i * 3 + 1];
                                MainForm.pS1_1.Rows[i][2] = part1_array[i * 3 + 2];
                            }

                            int part2_start = totalTxt.IndexOf("受本次赤潮影响的滨海旅");
                            int part2_end = totalTxt.IndexOf("3.") - "==========================================".Length - 4;
                            string part2 = totalTxt.Substring(part2_start, part2_end - part2_start);
                            string part2_1 = part2.Substring(part2.IndexOf("（人/天）：") + 6,
                                part2.IndexOf("受本次赤潮影响的滨海旅游海域的人均消费金额") - part2.IndexOf("（人/天）：") - 6);
                            string part2_2 = part2.Substring(part2.IndexOf("（元/天）：") + 6,
                                part2.IndexOf("本次赤潮灾害事件的持续时间（天）") - part2.IndexOf("（元/天）：") - 6);
                            string part2_3 = part2.Substring(part2.IndexOf("（天）：") + 4);
                            MainForm.pS2_1 = Convert.ToSingle(part2_1);
                            MainForm.pS2_2 = Convert.ToSingle(part2_2);
                            MainForm.pS2_3 = Convert.ToSingle(part2_3);

                            int part3_start = totalTxt.IndexOf("本次赤潮灾害处置，");
                            int part3_end = totalTxt.IndexOf("4.") - "==========================================".Length - 5;
                            string part3 = totalTxt.Substring(part3_start, part3_end - part3_start);
                            string part3_1 = part3.Substring(part3.IndexOf("（元）：") + 4,
                                part3.IndexOf("本次赤潮事件发生后") - part3.IndexOf("（元）：") - 4);
                            MainForm.pS3_1 = Convert.ToSingle(part3_1);
                            string part3_2 = part3.Substring(part3.LastIndexOf("船舶租用费用（元）") + 11);
                            string[] part3_array = part3_2.Split(new char[] { '\t', '\n' });
                            //清空datatable中的数据，并重新添加3列
                            MainForm.pS3_2.Clear();
                            MainForm.pS3_2.Columns.Clear();
                            MainForm.pS3_2.Columns.Add("站位名称");
                            MainForm.pS3_2.Columns.Add("船舶租用费用（元）");
                            //通过遍历，将文本中的数据导入到datatable中去
                            for (int i = 0; i < part3_array.Length / 2; i++)
                            {
                                MainForm.pS3_2.Rows.Add();
                                MainForm.pS3_2.Rows[i][0] = part3_array[i * 2];
                                MainForm.pS3_2.Rows[i][1] = part3_array[i * 2 + 1];
                            }

                            int part4_start = totalTxt.IndexOf("本次赤潮处置所需处置材料的消耗量");
                            int part4_end = totalTxt.IndexOf("5.") - "==========================================".Length - 4;
                            string part4 = totalTxt.Substring(part4_start, part4_end - part4_start);
                            string part4_1 = part4.Substring(part4.IndexOf("（吨）：") + 4,
                                part4.IndexOf("本次赤潮处置材料的经济单位价格") - part4.IndexOf("（吨）：") - 4);
                            string part4_2 = part4.Substring(part4.IndexOf("（元/吨）：") + 6,
                                part4.IndexOf("本次赤潮灾害处置") - part4.IndexOf("（元/吨）：") - 6);
                            string part4_3 = part4.Substring(part4.IndexOf("（元）：") + 4,
                            part4.IndexOf("本次赤潮灾害处置的人工费等费用") - part4.IndexOf("（元）：") - 4);
                            string part4_4 = part4.Substring(part4.LastIndexOf("（元）：") + 4);
                            MainForm.pS4_1 = Convert.ToSingle(part4_1);
                            MainForm.pS4_2 = Convert.ToSingle(part4_2);
                            MainForm.pS4_3 = Convert.ToSingle(part4_3);
                            MainForm.pS4_4 = Convert.ToSingle(part4_4);

                            int part5_start = totalTxt.IndexOf("本次赤潮灾害导致海水养殖业的经济损失");
                            int part5_end = totalTxt.Length - "==========================================".Length - 4;
                            string part5 = totalTxt.Substring(part5_start, part5_end - part5_start);
                            string part5_1 = part5.Substring(part5.IndexOf("（元）：") + 4,
                                part5.IndexOf("本次赤潮灾害导致滨海旅游业的经济损失") - part5.IndexOf("（元）：") - 4);
                            string part5_2 = part5.Substring(part5.IndexOf("海旅游业的经济损失（元）：") + 13,
                                part5.IndexOf("本次赤潮灾害事件的业务与应急监测费用") - part5.IndexOf("海旅游业的经济损失（元）：") - 13);
                            string part5_3 = part5.Substring(part5.IndexOf("应急监测费用（元）：") + 10,
                            part5.IndexOf("本次赤潮灾害事件的处置费用（元）") - part5.IndexOf("应急监测费用（元）：") - 10);
                            string part5_4 = part5.Substring(part5.LastIndexOf("（元）：") + 4);
                            MainForm.breeding_num = Convert.ToSingle(part5_1);
                            MainForm.tourism_num = Convert.ToSingle(part5_2);
                            MainForm.monitoring_num = Convert.ToSingle(part5_3);
                            MainForm.disposing_num = Convert.ToSingle(part5_4);

                            MainForm.breeding_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.breeding_num.ToString() + "。";
                            MainForm.tourism_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.tourism_num.ToString() + "。";
                            MainForm.monitoring_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.monitoring_num.ToString() + "。";
                            MainForm.disposing_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.disposing_num.ToString() + "。";
                            MainForm.total_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + (MainForm.breeding_num + MainForm.tourism_num +
                                MainForm.monitoring_num + MainForm.disposing_num) + "。";

                            MessageBox.Show("赤潮灾害损失评估数据导入成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion
	                #region 由Excel文件导入
	                else if (ofd.FilterIndex == 1)
	                {
                        path = ofd.FileName;
                        object nothing = Missing.Value;
                        eWorkbook = ex.Workbooks.Open(path, nothing, nothing, nothing, nothing, nothing, 
                            nothing, nothing, nothing, nothing, nothing, nothing, nothing, nothing, nothing);
                        
                        #region Sheet1
                        eWorksheet = eWorkbook.Sheets[1];
                        
                        string dt_year;
                        string dt_month;
                        string dt_day;
                        string dt_date = eWorksheet.Cells[1, 1].Value;

                        dt_year = dt_date.Substring(0, dt_date.IndexOf("年"));
                        dt_month = dt_date.Substring(dt_date.IndexOf("年") + 1, dt_date.IndexOf("月") - dt_date.IndexOf("年") - 1);
                        dt_day = dt_date.Substring(dt_date.IndexOf("月") + 1, dt_date.IndexOf("日") - dt_date.IndexOf("月") - 1);

                        dt = new DateTime(Convert.ToInt32(dt_year), Convert.ToInt32(dt_month), Convert.ToInt32(dt_day));
                        
                        #endregion
                        #region Sheet2
                        
                        eWorksheet = eWorkbook.Sheets[2];

                        //清空datatable中的数据，并重新添加3列
                        MainForm.pS1_1.Clear();     //清除datatable中的行（row）
                        MainForm.pS1_1.Columns.Clear();     //清除datatable中的列
                        MainForm.pS1_1.Columns.Add("养殖品种名称");
                        MainForm.pS1_1.Columns.Add("损失量（kg）");
                        MainForm.pS1_1.Columns.Add("单位价值（元/kg）");

                        //通过遍历，将文本中的数据导入到datatable中去
                        int row = eWorksheet.get_Range("A65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row; //获取文本最后一行
                        for (int i = 4; i <= row; i++)
                        {
                            MainForm.pS1_1.Rows.Add();
                            MainForm.pS1_1.Rows[i - 4][0] = eWorksheet.Cells[i, 1].Value;
                            MainForm.pS1_1.Rows[i - 4][1] = eWorksheet.Cells[i, 2].Value;
                            MainForm.pS1_1.Rows[i - 4][2] = eWorksheet.Cells[i, 3].Value;
                        }
                        #endregion
                        #region Sheet3

                        eWorksheet = eWorkbook.Sheets[3];

                        MainForm.pS2_1 = Convert.ToSingle(eWorksheet.Cells[3, 2].Value);
                        MainForm.pS2_2 = Convert.ToSingle(eWorksheet.Cells[4, 2].Value);
                        MainForm.pS2_3 = Convert.ToSingle(eWorksheet.Cells[5, 2].Value);

                        #endregion
                        #region Sheet4

                        eWorksheet = eWorkbook.Sheets[4];

                        MainForm.pS3_1 = Convert.ToSingle(eWorksheet.Cells[3, 2].Value);

                        //清空datatable中的数据，并重新添加3列
                        MainForm.pS3_2.Clear();
                        MainForm.pS3_2.Columns.Clear();
                        MainForm.pS3_2.Columns.Add("站位名称");
                        MainForm.pS3_2.Columns.Add("船舶租用费用（元）");

                        //row = ex.Application.get_Range("A65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row; //获取文本最后一行

                        row = eWorksheet.get_Range("A65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row;

                        //通过遍历，将文本中的数据导入到datatable中去
                        for (int i = 6; i <= row; i++)
                        {
                            MainForm.pS3_2.Rows.Add();
                            MainForm.pS3_2.Rows[i - 6][0] = eWorksheet.Cells[i, 1].Value;
                            MainForm.pS3_2.Rows[i - 6][1] = eWorksheet.Cells[i, 2].Value;
                        }

                        #endregion
                        #region Sheet5

                        eWorksheet = eWorkbook.Sheets[5];

                        MainForm.pS4_1 = Convert.ToSingle(eWorksheet.Cells[3, 2].Value);
                        MainForm.pS4_2 = Convert.ToSingle(eWorksheet.Cells[4, 2].Value);
                        MainForm.pS4_3 = Convert.ToSingle(eWorksheet.Cells[5, 2].Value);
                        MainForm.pS4_4 = Convert.ToSingle(eWorksheet.Cells[6, 2].Value);

                        #endregion
                        #region Sheet6

                        eWorksheet = eWorkbook.Sheets[6];

                        MainForm.breeding_num = Convert.ToSingle(eWorksheet.Cells[4, 2].Value);
                        MainForm.tourism_num = Convert.ToSingle(eWorksheet.Cells[5, 2].Value);
                        MainForm.monitoring_num = Convert.ToSingle(eWorksheet.Cells[6, 2].Value);
                        MainForm.disposing_num = Convert.ToSingle(eWorksheet.Cells[7, 2].Value);

                        #endregion

                        MainForm.breeding_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.breeding_num.ToString() + "。";
                        MainForm.tourism_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.tourism_num.ToString() + "。";
                        MainForm.monitoring_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.monitoring_num.ToString() + "。";
                        MainForm.disposing_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + MainForm.disposing_num.ToString() + "。";
                        MainForm.total_result = "本次赤潮灾害导致海水养殖业的经济损失（元）：" + (MainForm.breeding_num + MainForm.tourism_num +
                            MainForm.monitoring_num + MainForm.disposing_num) + "。";

                        MessageBox.Show("赤潮灾害损失评估数据导入成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
	                #endregion
	             
                    barDate.EditValue = dt;
                }
             }
             catch (System.Exception ex)
             {
                 MessageBox.Show(ex.ToString(), "错误提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

         private void button_help_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\\CCZHSSPGXT-HELP.chm");
         }
    }
}
