namespace AEWINAPP202009
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Ctrl_TOC = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.Ctrl_MapTOCCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Btn_AttributeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_ZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_RemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Symbology = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Slope = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_RasterStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_AddLayerToScene = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_AddMapDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_AddData = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Statistic = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Query = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_ExportSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_DeleteSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Ctrl_Tab = new System.Windows.Forms.TabControl();
            this.tabDataView = new System.Windows.Forms.TabPage();
            this.Ctrl_Map = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabDesignView = new System.Windows.Forms.TabPage();
            this.Ctrl_PageLayout = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.tabSceneView = new System.Windows.Forms.TabPage();
            this.Ctrl_Scene = new ESRI.ArcGIS.Controls.AxSceneControl();
            this.Ctrl_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lb_MouseX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lb_MouseY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lb_MapUnit = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lb_MapScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.Ctrl_Toolbar = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.Ctrl_SceneTOCCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Btn_SceneLayerStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ctrl_PageLayoutCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加标题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_AddLegend = new System.Windows.Forms.ToolStripMenuItem();
            this.添加比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加指南针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_TOC)).BeginInit();
            this.Ctrl_MapTOCCMS.SuspendLayout();
            this.Ctrl_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Ctrl_Tab.SuspendLayout();
            this.tabDataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Map)).BeginInit();
            this.tabDesignView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_PageLayout)).BeginInit();
            this.tabSceneView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Scene)).BeginInit();
            this.Ctrl_StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Toolbar)).BeginInit();
            this.Ctrl_SceneTOCCMS.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Ctrl_PageLayoutCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ctrl_TOC
            // 
            this.Ctrl_TOC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_TOC.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_TOC.Name = "Ctrl_TOC";
            this.Ctrl_TOC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Ctrl_TOC.OcxState")));
            this.Ctrl_TOC.Size = new System.Drawing.Size(255, 483);
            this.Ctrl_TOC.TabIndex = 3;
            this.Ctrl_TOC.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.Ctrl_TOC_OnMouseDown);
            // 
            // Ctrl_MapTOCCMS
            // 
            this.Ctrl_MapTOCCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Ctrl_MapTOCCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_AttributeTable,
            this.Btn_ZoomToLayer,
            this.Btn_RemoveLayer,
            this.Btn_Symbology,
            this.Btn_Slope,
            this.Btn_RasterStatistic,
            this.Btn_AddLayerToScene});
            this.Ctrl_MapTOCCMS.Name = "contextMenuStrip1";
            this.Ctrl_MapTOCCMS.Size = new System.Drawing.Size(198, 172);
            // 
            // Btn_AttributeTable
            // 
            this.Btn_AttributeTable.Name = "Btn_AttributeTable";
            this.Btn_AttributeTable.Size = new System.Drawing.Size(197, 24);
            this.Btn_AttributeTable.Text = "属性表";
            this.Btn_AttributeTable.Click += new System.EventHandler(this.Btn_AtrributeTable_Click);
            // 
            // Btn_ZoomToLayer
            // 
            this.Btn_ZoomToLayer.Name = "Btn_ZoomToLayer";
            this.Btn_ZoomToLayer.Size = new System.Drawing.Size(197, 24);
            this.Btn_ZoomToLayer.Text = "缩放到图层";
            this.Btn_ZoomToLayer.Click += new System.EventHandler(this.Btn_ZoomToLayer_Click);
            // 
            // Btn_RemoveLayer
            // 
            this.Btn_RemoveLayer.Name = "Btn_RemoveLayer";
            this.Btn_RemoveLayer.Size = new System.Drawing.Size(197, 24);
            this.Btn_RemoveLayer.Text = "移除图层";
            this.Btn_RemoveLayer.Click += new System.EventHandler(this.Btn_RemoveLayer_Click);
            // 
            // Btn_Symbology
            // 
            this.Btn_Symbology.Name = "Btn_Symbology";
            this.Btn_Symbology.Size = new System.Drawing.Size(197, 24);
            this.Btn_Symbology.Text = "符号系统";
            this.Btn_Symbology.Click += new System.EventHandler(this.Btn_Symbology_Click);
            // 
            // Btn_Slope
            // 
            this.Btn_Slope.Name = "Btn_Slope";
            this.Btn_Slope.Size = new System.Drawing.Size(197, 24);
            this.Btn_Slope.Text = "坡度";
            this.Btn_Slope.Click += new System.EventHandler(this.Btn_Slope_Click);
            // 
            // Btn_RasterStatistic
            // 
            this.Btn_RasterStatistic.Name = "Btn_RasterStatistic";
            this.Btn_RasterStatistic.Size = new System.Drawing.Size(197, 24);
            this.Btn_RasterStatistic.Text = "栅格统计";
            this.Btn_RasterStatistic.Click += new System.EventHandler(this.Btn_RasterStatistic_Click);
            // 
            // Btn_AddLayerToScene
            // 
            this.Btn_AddLayerToScene.Name = "Btn_AddLayerToScene";
            this.Btn_AddLayerToScene.Size = new System.Drawing.Size(197, 24);
            this.Btn_AddLayerToScene.Text = "添加至Scene视图";
            this.Btn_AddLayerToScene.Click += new System.EventHandler(this.Btn_AddLayerToScene_Click);
            // 
            // Ctrl_MenuStrip
            // 
            this.Ctrl_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Ctrl_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.编辑ToolStripMenuItem});
            this.Ctrl_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_MenuStrip.Name = "Ctrl_MenuStrip";
            this.Ctrl_MenuStrip.Size = new System.Drawing.Size(1104, 28);
            this.Ctrl_MenuStrip.TabIndex = 16;
            this.Ctrl_MenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_AddMapDocument,
            this.Btn_AddData});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem1.Text = "文件";
            // 
            // Btn_AddMapDocument
            // 
            this.Btn_AddMapDocument.Name = "Btn_AddMapDocument";
            this.Btn_AddMapDocument.Size = new System.Drawing.Size(188, 26);
            this.Btn_AddMapDocument.Text = "打开地图文档";
            this.Btn_AddMapDocument.Click += new System.EventHandler(this.Btn_OpenMapDocument_Click);
            // 
            // Btn_AddData
            // 
            this.Btn_AddData.Name = "Btn_AddData";
            this.Btn_AddData.Size = new System.Drawing.Size(188, 26);
            this.Btn_AddData.Text = "加载数据";
            this.Btn_AddData.Click += new System.EventHandler(this.Btn_AddData_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_Statistic,
            this.Btn_Query,
            this.Btn_ExportSelection,
            this.Btn_DeleteSelection});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.编辑ToolStripMenuItem.Text = "工具";
            // 
            // Btn_Statistic
            // 
            this.Btn_Statistic.Name = "Btn_Statistic";
            this.Btn_Statistic.Size = new System.Drawing.Size(172, 26);
            this.Btn_Statistic.Text = "统计";
            this.Btn_Statistic.Click += new System.EventHandler(this.Btn_Statistic_Click);
            // 
            // Btn_Query
            // 
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Size = new System.Drawing.Size(172, 26);
            this.Btn_Query.Text = "查询";
            this.Btn_Query.Click += new System.EventHandler(this.Btn_Query_Click);
            // 
            // Btn_ExportSelection
            // 
            this.Btn_ExportSelection.Name = "Btn_ExportSelection";
            this.Btn_ExportSelection.Size = new System.Drawing.Size(172, 26);
            this.Btn_ExportSelection.Text = "输出选择集";
            this.Btn_ExportSelection.Click += new System.EventHandler(this.Btn_ExportSelection_Click);
            // 
            // Btn_DeleteSelection
            // 
            this.Btn_DeleteSelection.Name = "Btn_DeleteSelection";
            this.Btn_DeleteSelection.Size = new System.Drawing.Size(172, 26);
            this.Btn_DeleteSelection.Text = "删除选择集";
            this.Btn_DeleteSelection.Click += new System.EventHandler(this.Btn_DeleteSelection_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Ctrl_TOC);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Ctrl_Tab);
            this.splitContainer1.Size = new System.Drawing.Size(1104, 483);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 17;
            // 
            // Ctrl_Tab
            // 
            this.Ctrl_Tab.Controls.Add(this.tabDataView);
            this.Ctrl_Tab.Controls.Add(this.tabDesignView);
            this.Ctrl_Tab.Controls.Add(this.tabSceneView);
            this.Ctrl_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_Tab.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_Tab.Name = "Ctrl_Tab";
            this.Ctrl_Tab.SelectedIndex = 0;
            this.Ctrl_Tab.Size = new System.Drawing.Size(845, 483);
            this.Ctrl_Tab.TabIndex = 0;
            this.Ctrl_Tab.SelectedIndexChanged += new System.EventHandler(this.Ctrl_Tab_SelectedIndexChanged);
            // 
            // tabDataView
            // 
            this.tabDataView.Controls.Add(this.Ctrl_Map);
            this.tabDataView.Location = new System.Drawing.Point(4, 25);
            this.tabDataView.Name = "tabDataView";
            this.tabDataView.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataView.Size = new System.Drawing.Size(837, 454);
            this.tabDataView.TabIndex = 1;
            this.tabDataView.Text = "数据视图";
            this.tabDataView.UseVisualStyleBackColor = true;
            // 
            // Ctrl_Map
            // 
            this.Ctrl_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_Map.Location = new System.Drawing.Point(3, 3);
            this.Ctrl_Map.Name = "Ctrl_Map";
            this.Ctrl_Map.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Ctrl_Map.OcxState")));
            this.Ctrl_Map.Size = new System.Drawing.Size(831, 448);
            this.Ctrl_Map.TabIndex = 0;
            this.Ctrl_Map.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.Ctrl_Map_OnMouseMove);
            this.Ctrl_Map.OnSelectionChanged += new System.EventHandler(this.Ctrl_Map_OnSelectionChanged);
            this.Ctrl_Map.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.Ctrl_Map_OnAfterDraw);
            this.Ctrl_Map.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.Ctrl_Map_OnExtentUpdated);
            // 
            // tabDesignView
            // 
            this.tabDesignView.Controls.Add(this.Ctrl_PageLayout);
            this.tabDesignView.Location = new System.Drawing.Point(4, 25);
            this.tabDesignView.Name = "tabDesignView";
            this.tabDesignView.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesignView.Size = new System.Drawing.Size(837, 454);
            this.tabDesignView.TabIndex = 0;
            this.tabDesignView.Text = "设计视图";
            this.tabDesignView.UseVisualStyleBackColor = true;
            // 
            // Ctrl_PageLayout
            // 
            this.Ctrl_PageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_PageLayout.Location = new System.Drawing.Point(3, 3);
            this.Ctrl_PageLayout.Name = "Ctrl_PageLayout";
            this.Ctrl_PageLayout.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Ctrl_PageLayout.OcxState")));
            this.Ctrl_PageLayout.Size = new System.Drawing.Size(831, 448);
            this.Ctrl_PageLayout.TabIndex = 0;
            this.Ctrl_PageLayout.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.Ctrl_PageLayout_OnMouseDown);
            this.Ctrl_PageLayout.OnMouseUp += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseUpEventHandler(this.Ctrl_PageLayout_OnMouseUp);
            this.Ctrl_PageLayout.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.Ctrl_PageLayout_OnMouseMove);
            // 
            // tabSceneView
            // 
            this.tabSceneView.Controls.Add(this.Ctrl_Scene);
            this.tabSceneView.Location = new System.Drawing.Point(4, 25);
            this.tabSceneView.Name = "tabSceneView";
            this.tabSceneView.Size = new System.Drawing.Size(837, 454);
            this.tabSceneView.TabIndex = 2;
            this.tabSceneView.Text = "三维视图";
            this.tabSceneView.UseVisualStyleBackColor = true;
            // 
            // Ctrl_Scene
            // 
            this.Ctrl_Scene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_Scene.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_Scene.Name = "Ctrl_Scene";
            this.Ctrl_Scene.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Ctrl_Scene.OcxState")));
            this.Ctrl_Scene.Size = new System.Drawing.Size(837, 454);
            this.Ctrl_Scene.TabIndex = 0;
            this.Ctrl_Scene.OnMouseMove += new ESRI.ArcGIS.Controls.ISceneControlEvents_Ax_OnMouseMoveEventHandler(this.Ctrl_Scene_OnMouseMove);
            // 
            // Ctrl_StatusStrip
            // 
            this.Ctrl_StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Ctrl_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.Lb_MouseX,
            this.toolStripStatusLabel3,
            this.Lb_MouseY,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.Lb_MapUnit,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel4,
            this.Lb_MapScale});
            this.Ctrl_StatusStrip.Location = new System.Drawing.Point(0, 544);
            this.Ctrl_StatusStrip.Name = "Ctrl_StatusStrip";
            this.Ctrl_StatusStrip.Size = new System.Drawing.Size(1104, 26);
            this.Ctrl_StatusStrip.TabIndex = 19;
            this.Ctrl_StatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(21, 20);
            this.toolStripStatusLabel1.Text = "X:";
            // 
            // Lb_MouseX
            // 
            this.Lb_MouseX.Name = "Lb_MouseX";
            this.Lb_MouseX.Size = new System.Drawing.Size(33, 20);
            this.Lb_MouseX.Text = "null";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel3.Text = "Y:";
            // 
            // Lb_MouseY
            // 
            this.Lb_MouseY.Name = "Lb_MouseY";
            this.Lb_MouseY.Size = new System.Drawing.Size(33, 20);
            this.Lb_MouseY.Text = "null";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(57, 20);
            this.toolStripStatusLabel5.Text = "单位：";
            // 
            // Lb_MapUnit
            // 
            this.Lb_MapUnit.Name = "Lb_MapUnit";
            this.Lb_MapUnit.Size = new System.Drawing.Size(33, 20);
            this.Lb_MapUnit.Text = "null";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel6.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(73, 20);
            this.toolStripStatusLabel4.Text = "比例尺：";
            // 
            // Lb_MapScale
            // 
            this.Lb_MapScale.Name = "Lb_MapScale";
            this.Lb_MapScale.Size = new System.Drawing.Size(33, 20);
            this.Lb_MapScale.Text = "null";
            // 
            // Ctrl_Toolbar
            // 
            this.Ctrl_Toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_Toolbar.Name = "Ctrl_Toolbar";
            this.Ctrl_Toolbar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Ctrl_Toolbar.OcxState")));
            this.Ctrl_Toolbar.Size = new System.Drawing.Size(1102, 28);
            this.Ctrl_Toolbar.TabIndex = 20;
            // 
            // Ctrl_SceneTOCCMS
            // 
            this.Ctrl_SceneTOCCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Ctrl_SceneTOCCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_SceneLayerStyle});
            this.Ctrl_SceneTOCCMS.Name = "Ctrl_SceneCMS";
            this.Ctrl_SceneTOCCMS.Size = new System.Drawing.Size(111, 28);
            // 
            // Btn_SceneLayerStyle
            // 
            this.Btn_SceneLayerStyle.Name = "Btn_SceneLayerStyle";
            this.Btn_SceneLayerStyle.Size = new System.Drawing.Size(110, 24);
            this.Btn_SceneLayerStyle.Text = "样式";
            this.Btn_SceneLayerStyle.Click += new System.EventHandler(this.Btn_SceneLayerStyle_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Ctrl_Toolbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 33);
            this.panel1.TabIndex = 21;
            // 
            // Ctrl_PageLayoutCMS
            // 
            this.Ctrl_PageLayoutCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Ctrl_PageLayoutCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加标题ToolStripMenuItem,
            this.Btn_AddLegend,
            this.添加比例尺ToolStripMenuItem,
            this.添加指南针ToolStripMenuItem});
            this.Ctrl_PageLayoutCMS.Name = "Ctrl_PageLayoutCMS";
            this.Ctrl_PageLayoutCMS.Size = new System.Drawing.Size(159, 100);
            // 
            // 添加标题ToolStripMenuItem
            // 
            this.添加标题ToolStripMenuItem.Name = "添加标题ToolStripMenuItem";
            this.添加标题ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.添加标题ToolStripMenuItem.Text = "添加标题";
            // 
            // Btn_AddLegend
            // 
            this.Btn_AddLegend.Name = "Btn_AddLegend";
            this.Btn_AddLegend.Size = new System.Drawing.Size(210, 24);
            this.Btn_AddLegend.Text = "添加图例";
            this.Btn_AddLegend.Click += new System.EventHandler(this.Btn_AddLegend_Click);
            // 
            // 添加比例尺ToolStripMenuItem
            // 
            this.添加比例尺ToolStripMenuItem.Name = "添加比例尺ToolStripMenuItem";
            this.添加比例尺ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.添加比例尺ToolStripMenuItem.Text = "添加比例尺";
            // 
            // 添加指南针ToolStripMenuItem
            // 
            this.添加指南针ToolStripMenuItem.Name = "添加指南针ToolStripMenuItem";
            this.添加指南针ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.添加指南针ToolStripMenuItem.Text = "添加指北针";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 570);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Ctrl_StatusStrip);
            this.Controls.Add(this.Ctrl_MenuStrip);
            this.MainMenuStrip = this.Ctrl_MenuStrip;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Move += new System.EventHandler(this.FormMain_Move);
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_TOC)).EndInit();
            this.Ctrl_MapTOCCMS.ResumeLayout(false);
            this.Ctrl_MenuStrip.ResumeLayout(false);
            this.Ctrl_MenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Ctrl_Tab.ResumeLayout(false);
            this.tabDataView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Map)).EndInit();
            this.tabDesignView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_PageLayout)).EndInit();
            this.tabSceneView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Scene)).EndInit();
            this.Ctrl_StatusStrip.ResumeLayout(false);
            this.Ctrl_StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Toolbar)).EndInit();
            this.Ctrl_SceneTOCCMS.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Ctrl_PageLayoutCMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl Ctrl_TOC;
        private System.Windows.Forms.ContextMenuStrip Ctrl_MapTOCCMS;
        private System.Windows.Forms.ToolStripMenuItem Btn_AttributeTable;
        private System.Windows.Forms.ToolStripMenuItem Btn_ZoomToLayer;
        private System.Windows.Forms.ToolStripMenuItem Btn_RemoveLayer;
        private System.Windows.Forms.ToolStripMenuItem Btn_Symbology;
        private System.Windows.Forms.MenuStrip Ctrl_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Btn_AddMapDocument;
        private System.Windows.Forms.ToolStripMenuItem Btn_AddData;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl Ctrl_Tab;
        private System.Windows.Forms.TabPage tabDataView;
        private ESRI.ArcGIS.Controls.AxMapControl Ctrl_Map;
        private System.Windows.Forms.TabPage tabDesignView;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl Ctrl_PageLayout;
        private System.Windows.Forms.ToolStripMenuItem Btn_Statistic;
        private System.Windows.Forms.ToolStripMenuItem Btn_Query;
        private System.Windows.Forms.StatusStrip Ctrl_StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel Lb_MouseX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel Lb_MouseY;
        private System.Windows.Forms.ToolStripMenuItem Btn_ExportSelection;
        private System.Windows.Forms.ToolStripMenuItem Btn_DeleteSelection;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel Lb_MapScale;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel Lb_MapUnit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripMenuItem Btn_Slope;
        private System.Windows.Forms.ToolStripMenuItem Btn_RasterStatistic;
        private System.Windows.Forms.TabPage tabSceneView;
        private ESRI.ArcGIS.Controls.AxSceneControl Ctrl_Scene;
        private ESRI.ArcGIS.Controls.AxToolbarControl Ctrl_Toolbar;
        private System.Windows.Forms.ToolStripMenuItem Btn_AddLayerToScene;
        private System.Windows.Forms.ContextMenuStrip Ctrl_SceneTOCCMS;
        private System.Windows.Forms.ToolStripMenuItem Btn_SceneLayerStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip Ctrl_PageLayoutCMS;
        private System.Windows.Forms.ToolStripMenuItem 添加标题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Btn_AddLegend;
        private System.Windows.Forms.ToolStripMenuItem 添加比例尺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加指南针ToolStripMenuItem;
    }
}

