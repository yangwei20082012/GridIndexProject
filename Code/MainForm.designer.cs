<<<<<<< HEAD
﻿namespace GIS
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.mnsItemCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemNewCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsItemCloseCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemAddShapeLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemRemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDisplayLayers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsItemBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDatabaseLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemBig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ssrMain = new System.Windows.Forms.StatusStrip();
            this.ssrItemMapLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.clbLayerList = new System.Windows.Forms.CheckedListBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.btnApplyMeasure = new System.Windows.Forms.Button();
            this.rdoUseDP = new System.Windows.Forms.RadioButton();
            this.rdoUseImproved = new System.Windows.Forms.RadioButton();
            this.lblFrequencyMeasure = new System.Windows.Forms.Label();
            this.lblMaxMeasure = new System.Windows.Forms.Label();
            this.lblMinMeasure = new System.Windows.Forms.Label();
            this.lblCurrentMesure = new System.Windows.Forms.Label();
            this.txtFrequencyMeasure = new System.Windows.Forms.TextBox();
            this.txtMaxMeasure = new System.Windows.Forms.TextBox();
            this.txtMinMeasure = new System.Windows.Forms.TextBox();
            this.txtCurrentMesure = new System.Windows.Forms.TextBox();
            this.trbMeasure = new System.Windows.Forms.TrackBar();
            this.lblSrcVertexCountName = new System.Windows.Forms.Label();
            this.lblSrcVertexCount = new System.Windows.Forms.Label();
            this.lblDestVertexCountName = new System.Windows.Forms.Label();
            this.lblDestVertexCount = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpLayerList = new System.Windows.Forms.GroupBox();
            this.btnRestrictVertexCount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRestrictVertexCount = new System.Windows.Forms.Label();
            this.txtRestrictVertexCount = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblDiffAreaName = new System.Windows.Forms.Label();
            this.lblDestAreaName = new System.Windows.Forms.Label();
            this.lblDestLengthName = new System.Windows.Forms.Label();
            this.lblSrcAreaName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSrcLengthName = new System.Windows.Forms.Label();
            this.lblDiffArea = new System.Windows.Forms.Label();
            this.lblDestArea = new System.Windows.Forms.Label();
            this.lblDestLength = new System.Windows.Forms.Label();
            this.lblSrcArea = new System.Windows.Forms.Label();
            this.lblSrcLength = new System.Windows.Forms.Label();
            this.lblDestLayerName = new System.Windows.Forms.Label();
            this.lblSrcLayerName = new System.Windows.Forms.Label();
            this.lblDestLayerNameName = new System.Windows.Forms.Label();
            this.lblSrcLayerNameName = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gisPanel = new GISPrinter.GISPanel();
            this.rdoUseLiOpenshaw = new System.Windows.Forms.RadioButton();
            this.rdoUseFra = new System.Windows.Forms.RadioButton();
            this.mnsMain.SuspendLayout();
            this.ssrMain.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMeasure)).BeginInit();
            this.grpLayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.mnsMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemCanvas,
            this.mnsItemLayer,
            this.mnsItemDisplay,
            this.mnsItemDatabase,
            this.mnsItemBig,
            this.mnsItemSmall});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1264, 24);
            this.mnsMain.TabIndex = 0;
            // 
            // mnsItemCanvas
            // 
            this.mnsItemCanvas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemNewCanvas,
            this.toolStripSeparator1,
            this.mnsItemCloseCanvas});
            this.mnsItemCanvas.Name = "mnsItemCanvas";
            this.mnsItemCanvas.Size = new System.Drawing.Size(59, 20);
            this.mnsItemCanvas.Text = "画布(&C)";
            // 
            // mnsItemNewCanvas
            // 
            this.mnsItemNewCanvas.Name = "mnsItemNewCanvas";
            this.mnsItemNewCanvas.Size = new System.Drawing.Size(155, 38);
            this.mnsItemNewCanvas.Text = "新建画布(&N)";
            this.mnsItemNewCanvas.Click += new System.EventHandler(this.mnsItemNewCanvas_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnsItemCloseCanvas
            // 
            this.mnsItemCloseCanvas.Image = global::GIS.Properties.Resources.CloseLayer;
            this.mnsItemCloseCanvas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemCloseCanvas.Name = "mnsItemCloseCanvas";
            this.mnsItemCloseCanvas.Size = new System.Drawing.Size(155, 38);
            this.mnsItemCloseCanvas.Text = "关闭画布(&C)";
            this.mnsItemCloseCanvas.Click += new System.EventHandler(this.mnsItemCloseCanvas_Click);
            // 
            // mnsItemLayer
            // 
            this.mnsItemLayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemAddShapeLayer,
            this.mnsItemRemoveLayer});
            this.mnsItemLayer.Name = "mnsItemLayer";
            this.mnsItemLayer.Size = new System.Drawing.Size(57, 20);
            this.mnsItemLayer.Text = "图层(&L)";
            // 
            // mnsItemAddShapeLayer
            // 
            this.mnsItemAddShapeLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemAddShapeLayer.Name = "mnsItemAddShapeLayer";
            this.mnsItemAddShapeLayer.Size = new System.Drawing.Size(208, 38);
            this.mnsItemAddShapeLayer.Text = "添加Shape数据图层(&S)";
            this.mnsItemAddShapeLayer.Click += new System.EventHandler(this.mnsItemAddShapeLayer_Click);
            // 
            // mnsItemRemoveLayer
            // 
            this.mnsItemRemoveLayer.Image = global::GIS.Properties.Resources.RemoveShape;
            this.mnsItemRemoveLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemRemoveLayer.Name = "mnsItemRemoveLayer";
            this.mnsItemRemoveLayer.Size = new System.Drawing.Size(208, 38);
            this.mnsItemRemoveLayer.Text = "移除图层(&R)";
            this.mnsItemRemoveLayer.Click += new System.EventHandler(this.itemRemoveLayer_Click);
            // 
            // mnsItemDisplay
            // 
            this.mnsItemDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemDisplayLayers,
            this.toolStripSeparator3,
            this.mnsItemBackgroundColor});
            this.mnsItemDisplay.Name = "mnsItemDisplay";
            this.mnsItemDisplay.Size = new System.Drawing.Size(58, 20);
            this.mnsItemDisplay.Text = "显示(&V)";
            // 
            // mnsItemDisplayLayers
            // 
            this.mnsItemDisplayLayers.Image = global::GIS.Properties.Resources.ViewLayer;
            this.mnsItemDisplayLayers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemDisplayLayers.Name = "mnsItemDisplayLayers";
            this.mnsItemDisplayLayers.Size = new System.Drawing.Size(161, 38);
            this.mnsItemDisplayLayers.Text = "显示图层...(L)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // mnsItemBackgroundColor
            // 
            this.mnsItemBackgroundColor.Image = global::GIS.Properties.Resources.BackgroundColor;
            this.mnsItemBackgroundColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemBackgroundColor.Name = "mnsItemBackgroundColor";
            this.mnsItemBackgroundColor.Size = new System.Drawing.Size(161, 38);
            this.mnsItemBackgroundColor.Text = "背景颜色(&G)";
            this.mnsItemBackgroundColor.Click += new System.EventHandler(this.mnsItemBackgroundColor_Click);
            // 
            // mnsItemDatabase
            // 
            this.mnsItemDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemDatabaseLayer});
            this.mnsItemDatabase.Name = "mnsItemDatabase";
            this.mnsItemDatabase.Size = new System.Drawing.Size(59, 20);
            this.mnsItemDatabase.Text = "数据(&D)";
            // 
            // mnsItemDatabaseLayer
            // 
            this.mnsItemDatabaseLayer.Image = global::GIS.Properties.Resources.ViewSelectedData;
            this.mnsItemDatabaseLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemDatabaseLayer.Name = "mnsItemDatabaseLayer";
            this.mnsItemDatabaseLayer.Size = new System.Drawing.Size(161, 38);
            this.mnsItemDatabaseLayer.Text = "查看图层...(&L)";
            // 
            // mnsItemBig
            // 
            this.mnsItemBig.Image = global::GIS.Properties.Resources.Big;
            this.mnsItemBig.Name = "mnsItemBig";
            this.mnsItemBig.Size = new System.Drawing.Size(75, 20);
            this.mnsItemBig.Text = "放大(&C)";
            this.mnsItemBig.Click += new System.EventHandler(this.mnsItemBig_Click);
            // 
            // mnsItemSmall
            // 
            this.mnsItemSmall.Image = global::GIS.Properties.Resources.Small;
            this.mnsItemSmall.Name = "mnsItemSmall";
            this.mnsItemSmall.Size = new System.Drawing.Size(75, 20);
            this.mnsItemSmall.Text = "缩小(&C)";
            this.mnsItemSmall.Click += new System.EventHandler(this.mnsItemSmall_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // ssrMain
            // 
            this.ssrMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230))))); 
            this.ssrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrItemMapLocation});
            this.ssrMain.Location = new System.Drawing.Point(0, 670);
            this.ssrMain.Name = "ssrMain";
            this.ssrMain.Size = new System.Drawing.Size(1264, 22);
            this.ssrMain.SizingGrip = false;
            this.ssrMain.TabIndex = 1;
            // 
            // ssrItemMapLocation
            // 
            this.ssrItemMapLocation.Name = "ssrItemMapLocation";
            this.ssrItemMapLocation.Size = new System.Drawing.Size(1249, 17);
            this.ssrItemMapLocation.Spring = true;
            this.ssrItemMapLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clbLayerList
            // 
            this.clbLayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLayerList.FormattingEnabled = true;
            this.clbLayerList.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.clbLayerList.Location = new System.Drawing.Point(3, 22);
            this.clbLayerList.Name = "clbLayerList";
            this.clbLayerList.Size = new System.Drawing.Size(244, 171);
            this.clbLayerList.TabIndex = 2;
            this.clbLayerList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbLayerList_ItemCheck);
            this.clbLayerList.SelectedIndexChanged += new System.EventHandler(this.clbLayerList_SelectedIndexChanged);
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControl.Controls.Add(this.grpAlgorithm);
            this.pnlControl.Controls.Add(this.splitter1);
            this.pnlControl.Controls.Add(this.grpLayerList);
            this.pnlControl.Location = new System.Drawing.Point(0, 25);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(250, 645);
            this.pnlControl.TabIndex = 3;
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.grpAlgorithm.Controls.Add(this.btnApplyMeasure);
            this.grpAlgorithm.Controls.Add(this.rdoUseDP);
            this.grpAlgorithm.Controls.Add(this.rdoUseImproved);
            this.grpAlgorithm.Controls.Add(this.lblFrequencyMeasure);
            this.grpAlgorithm.Controls.Add(this.lblMaxMeasure);
            this.grpAlgorithm.Controls.Add(this.lblMinMeasure);
            this.grpAlgorithm.Controls.Add(this.lblCurrentMesure);
            this.grpAlgorithm.Controls.Add(this.txtFrequencyMeasure);
            this.grpAlgorithm.Controls.Add(this.txtMaxMeasure);
            this.grpAlgorithm.Controls.Add(this.txtMinMeasure);
            this.grpAlgorithm.Controls.Add(this.txtCurrentMesure);
            this.grpAlgorithm.Controls.Add(this.trbMeasure);
            this.grpAlgorithm.Controls.Add(this.lblSrcVertexCountName);
            this.grpAlgorithm.Controls.Add(this.lblSrcVertexCount);
            this.grpAlgorithm.Controls.Add(this.lblDestVertexCountName);
            this.grpAlgorithm.Controls.Add(this.lblDestVertexCount);
            this.grpAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlgorithm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpAlgorithm.Location = new System.Drawing.Point(0, 199);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(250, 446);
            this.grpAlgorithm.TabIndex = 2;
            this.grpAlgorithm.TabStop = false;
            this.grpAlgorithm.Text = "算法";
            // 
            // btnApplyMeasure
            // 
            this.btnApplyMeasure.Location = new System.Drawing.Point(166, 98);
            this.btnApplyMeasure.Name = "btnApplyMeasure";
            this.btnApplyMeasure.Size = new System.Drawing.Size(75, 27);
            this.btnApplyMeasure.TabIndex = 19;
            this.btnApplyMeasure.Text = "应用参数";
            this.btnApplyMeasure.UseVisualStyleBackColor = true;
            this.btnApplyMeasure.Click += new System.EventHandler(this.btnApplyMeasure_Click);
            // 
            // rdoUseDP
            // 
            this.rdoUseDP.AutoSize = true;
            this.rdoUseDP.Location = new System.Drawing.Point(6, 131);
            this.rdoUseDP.Name = "rdoUseDP";
            this.rdoUseDP.Size = new System.Drawing.Size(75, 24);
            this.rdoUseDP.TabIndex = 18;
            this.rdoUseDP.Text = "DP算法";
            this.rdoUseDP.UseVisualStyleBackColor = true;
            // 
            // rdoUseImproved
            // 
            this.rdoUseImproved.AutoSize = true;
            this.rdoUseImproved.Checked = true;
            this.rdoUseImproved.Location = new System.Drawing.Point(100, 131);
            this.rdoUseImproved.Name = "rdoUseImproved";
            this.rdoUseImproved.Size = new System.Drawing.Size(83, 24);
            this.rdoUseImproved.TabIndex = 18;
            this.rdoUseImproved.TabStop = true;
            this.rdoUseImproved.Text = "改进算法";
            this.rdoUseImproved.UseVisualStyleBackColor = true;
            // 
            // lblFrequencyMeasure
            // 
            this.lblFrequencyMeasure.AutoSize = true;
            this.lblFrequencyMeasure.Location = new System.Drawing.Point(6, 44);
            this.lblFrequencyMeasure.Name = "lblFrequencyMeasure";
            this.lblFrequencyMeasure.Size = new System.Drawing.Size(37, 20);
            this.lblFrequencyMeasure.TabIndex = 12;
            this.lblFrequencyMeasure.Text = "频率";
            // 
            // lblMaxMeasure
            // 
            this.lblMaxMeasure.AutoSize = true;
            this.lblMaxMeasure.Location = new System.Drawing.Point(124, 20);
            this.lblMaxMeasure.Name = "lblMaxMeasure";
            this.lblMaxMeasure.Size = new System.Drawing.Size(37, 20);
            this.lblMaxMeasure.TabIndex = 13;
            this.lblMaxMeasure.Text = "最大";
            // 
            // lblMinMeasure
            // 
            this.lblMinMeasure.AutoSize = true;
            this.lblMinMeasure.Location = new System.Drawing.Point(6, 20);
            this.lblMinMeasure.Name = "lblMinMeasure";
            this.lblMinMeasure.Size = new System.Drawing.Size(37, 20);
            this.lblMinMeasure.TabIndex = 14;
            this.lblMinMeasure.Text = "最小";
            // 
            // lblCurrentMesure
            // 
            this.lblCurrentMesure.AutoSize = true;
            this.lblCurrentMesure.Location = new System.Drawing.Point(124, 44);
            this.lblCurrentMesure.Name = "lblCurrentMesure";
            this.lblCurrentMesure.Size = new System.Drawing.Size(37, 20);
            this.lblCurrentMesure.TabIndex = 15;
            this.lblCurrentMesure.Text = "当前";
            // 
            // txtFrequencyMeasure
            // 
            this.txtFrequencyMeasure.Location = new System.Drawing.Point(42, 42);
            this.txtFrequencyMeasure.Name = "txtFrequencyMeasure";
            this.txtFrequencyMeasure.Size = new System.Drawing.Size(72, 26);
            this.txtFrequencyMeasure.TabIndex = 8;
            this.txtFrequencyMeasure.Text = "0.01";
            // 
            // txtMaxMeasure
            // 
            this.txtMaxMeasure.Location = new System.Drawing.Point(166, 18);
            this.txtMaxMeasure.Name = "txtMaxMeasure";
            this.txtMaxMeasure.Size = new System.Drawing.Size(78, 26);
            this.txtMaxMeasure.TabIndex = 9;
            this.txtMaxMeasure.Text = "1";
            // 
            // txtMinMeasure
            // 
            this.txtMinMeasure.Location = new System.Drawing.Point(42, 18);
            this.txtMinMeasure.Name = "txtMinMeasure";
            this.txtMinMeasure.Size = new System.Drawing.Size(72, 26);
            this.txtMinMeasure.TabIndex = 10;
            this.txtMinMeasure.Text = "0.1";
            // 
            // txtCurrentMesure
            // 
            this.txtCurrentMesure.Location = new System.Drawing.Point(166, 42);
            this.txtCurrentMesure.Name = "txtCurrentMesure";
            this.txtCurrentMesure.Size = new System.Drawing.Size(78, 26);
            this.txtCurrentMesure.TabIndex = 11;
            this.txtCurrentMesure.Text = "0.5";
            // 
            // trbMeasure
            // 
            this.trbMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.trbMeasure.Location = new System.Drawing.Point(8, 70);
            this.trbMeasure.Name = "trbMeasure";
            this.trbMeasure.Size = new System.Drawing.Size(233, 45);
            this.trbMeasure.TabIndex = 7;
            this.trbMeasure.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbMeasure.Scroll += new System.EventHandler(this.trbMeasure_Scroll);
            // 
            // lblSrcVertexCountName
            // 
            this.lblSrcVertexCountName.AutoSize = true;
            this.lblSrcVertexCountName.Location = new System.Drawing.Point(7, 164);
            this.lblSrcVertexCountName.Name = "lblSrcVertexCountName";
            this.lblSrcVertexCountName.Size = new System.Drawing.Size(107, 20);
            this.lblSrcVertexCountName.TabIndex = 14;
            this.lblSrcVertexCountName.Text = "原图顶点数目：";
            // 
            // lblSrcVertexCount
            // 
            this.lblSrcVertexCount.AutoSize = true;
            this.lblSrcVertexCount.Location = new System.Drawing.Point(110, 164);
            this.lblSrcVertexCount.Name = "lblSrcVertexCount";
            this.lblSrcVertexCount.Size = new System.Drawing.Size(17, 20);
            this.lblSrcVertexCount.TabIndex = 14;
            this.lblSrcVertexCount.Text = "1";
            // 
            // lblDestVertexCountName
            // 
            this.lblDestVertexCountName.AutoSize = true;
            this.lblDestVertexCountName.Location = new System.Drawing.Point(7, 190);
            this.lblDestVertexCountName.Name = "lblDestVertexCountName";
            this.lblDestVertexCountName.Size = new System.Drawing.Size(107, 20);
            this.lblDestVertexCountName.TabIndex = 14;
            this.lblDestVertexCountName.Text = "约减顶点数目：";
            // 
            // lblDestVertexCount
            // 
            this.lblDestVertexCount.AutoSize = true;
            this.lblDestVertexCount.Location = new System.Drawing.Point(110, 190);
            this.lblDestVertexCount.Name = "lblDestVertexCount";
            this.lblDestVertexCount.Size = new System.Drawing.Size(17, 20);
            this.lblDestVertexCount.TabIndex = 14;
            this.lblDestVertexCount.Text = "1";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 196);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(250, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // grpLayerList
            // 
            this.grpLayerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.grpLayerList.Controls.Add(this.clbLayerList);
            this.grpLayerList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLayerList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpLayerList.Location = new System.Drawing.Point(0, 0);
            this.grpLayerList.Name = "grpLayerList";
            this.grpLayerList.Size = new System.Drawing.Size(250, 196);
            this.grpLayerList.TabIndex = 0;
            this.grpLayerList.TabStop = false;
            this.grpLayerList.Text = "图层列表";
            // 
            // btnRestrictVertexCount
            // 
            this.btnRestrictVertexCount.Location = new System.Drawing.Point(115, 106);
            this.btnRestrictVertexCount.Name = "btnRestrictVertexCount";
            this.btnRestrictVertexCount.Size = new System.Drawing.Size(75, 23);
            this.btnRestrictVertexCount.TabIndex = 19;
            this.btnRestrictVertexCount.Text = "顶点固定";
            this.btnRestrictVertexCount.UseVisualStyleBackColor = true;
            this.btnRestrictVertexCount.Click += new System.EventHandler(this.btnRestrictVertexCount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "-------------------------------------------------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "-------------------------------------------------------------";
            // 
            // lblRestrictVertexCount
            // 
            this.lblRestrictVertexCount.AutoSize = true;
            this.lblRestrictVertexCount.Location = new System.Drawing.Point(6, 112);
            this.lblRestrictVertexCount.Name = "lblRestrictVertexCount";
            this.lblRestrictVertexCount.Size = new System.Drawing.Size(29, 12);
            this.lblRestrictVertexCount.TabIndex = 14;
            this.lblRestrictVertexCount.Text = "顶点";
            // 
            // txtRestrictVertexCount
            // 
            this.txtRestrictVertexCount.Location = new System.Drawing.Point(41, 109);
            this.txtRestrictVertexCount.Name = "txtRestrictVertexCount";
            this.txtRestrictVertexCount.Size = new System.Drawing.Size(50, 21);
            this.txtRestrictVertexCount.TabIndex = 10;
            this.txtRestrictVertexCount.Text = "5";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(115, 194);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 21);
            this.btnReport.TabIndex = 15;
            this.btnReport.Text = "生成文件";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblDiffAreaName
            // 
            this.lblDiffAreaName.AutoSize = true;
            this.lblDiffAreaName.Location = new System.Drawing.Point(6, 167);
            this.lblDiffAreaName.Name = "lblDiffAreaName";
            this.lblDiffAreaName.Size = new System.Drawing.Size(53, 12);
            this.lblDiffAreaName.TabIndex = 14;
            this.lblDiffAreaName.Text = "面积差：";
            // 
            // lblDestAreaName
            // 
            this.lblDestAreaName.AutoSize = true;
            this.lblDestAreaName.Location = new System.Drawing.Point(6, 143);
            this.lblDestAreaName.Name = "lblDestAreaName";
            this.lblDestAreaName.Size = new System.Drawing.Size(65, 12);
            this.lblDestAreaName.TabIndex = 14;
            this.lblDestAreaName.Text = "约减面积：";
            // 
            // lblDestLengthName
            // 
            this.lblDestLengthName.AutoSize = true;
            this.lblDestLengthName.Location = new System.Drawing.Point(6, 126);
            this.lblDestLengthName.Name = "lblDestLengthName";
            this.lblDestLengthName.Size = new System.Drawing.Size(89, 12);
            this.lblDestLengthName.TabIndex = 14;
            this.lblDestLengthName.Text = "约减线段总长：";
            // 
            // lblSrcAreaName
            // 
            this.lblSrcAreaName.AutoSize = true;
            this.lblSrcAreaName.Location = new System.Drawing.Point(7, 70);
            this.lblSrcAreaName.Name = "lblSrcAreaName";
            this.lblSrcAreaName.Size = new System.Drawing.Size(65, 12);
            this.lblSrcAreaName.TabIndex = 14;
            this.lblSrcAreaName.Text = "原图面积：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "-------------------------------------------------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(371, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "-------------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "-------------------------------------------------------------";
            // 
            // lblSrcLengthName
            // 
            this.lblSrcLengthName.AutoSize = true;
            this.lblSrcLengthName.Location = new System.Drawing.Point(7, 54);
            this.lblSrcLengthName.Name = "lblSrcLengthName";
            this.lblSrcLengthName.Size = new System.Drawing.Size(89, 12);
            this.lblSrcLengthName.TabIndex = 14;
            this.lblSrcLengthName.Text = "原图线段总长：";
            // 
            // lblDiffArea
            // 
            this.lblDiffArea.AutoSize = true;
            this.lblDiffArea.Location = new System.Drawing.Point(98, 167);
            this.lblDiffArea.Name = "lblDiffArea";
            this.lblDiffArea.Size = new System.Drawing.Size(11, 12);
            this.lblDiffArea.TabIndex = 14;
            this.lblDiffArea.Text = "1";
            // 
            // lblDestArea
            // 
            this.lblDestArea.AutoSize = true;
            this.lblDestArea.Location = new System.Drawing.Point(98, 143);
            this.lblDestArea.Name = "lblDestArea";
            this.lblDestArea.Size = new System.Drawing.Size(11, 12);
            this.lblDestArea.TabIndex = 14;
            this.lblDestArea.Text = "1";
            // 
            // lblDestLength
            // 
            this.lblDestLength.AutoSize = true;
            this.lblDestLength.Location = new System.Drawing.Point(98, 126);
            this.lblDestLength.Name = "lblDestLength";
            this.lblDestLength.Size = new System.Drawing.Size(11, 12);
            this.lblDestLength.TabIndex = 14;
            this.lblDestLength.Text = "1";
            // 
            // lblSrcArea
            // 
            this.lblSrcArea.AutoSize = true;
            this.lblSrcArea.Location = new System.Drawing.Point(98, 70);
            this.lblSrcArea.Name = "lblSrcArea";
            this.lblSrcArea.Size = new System.Drawing.Size(11, 12);
            this.lblSrcArea.TabIndex = 14;
            this.lblSrcArea.Text = "1";
            // 
            // lblSrcLength
            // 
            this.lblSrcLength.AutoSize = true;
            this.lblSrcLength.Location = new System.Drawing.Point(98, 54);
            this.lblSrcLength.Name = "lblSrcLength";
            this.lblSrcLength.Size = new System.Drawing.Size(11, 12);
            this.lblSrcLength.TabIndex = 14;
            this.lblSrcLength.Text = "1";
            // 
            // lblDestLayerName
            // 
            this.lblDestLayerName.AutoSize = true;
            this.lblDestLayerName.Location = new System.Drawing.Point(98, 94);
            this.lblDestLayerName.Name = "lblDestLayerName";
            this.lblDestLayerName.Size = new System.Drawing.Size(11, 12);
            this.lblDestLayerName.TabIndex = 14;
            this.lblDestLayerName.Text = "1";
            // 
            // lblSrcLayerName
            // 
            this.lblSrcLayerName.AutoSize = true;
            this.lblSrcLayerName.Location = new System.Drawing.Point(98, 18);
            this.lblSrcLayerName.Name = "lblSrcLayerName";
            this.lblSrcLayerName.Size = new System.Drawing.Size(11, 12);
            this.lblSrcLayerName.TabIndex = 14;
            this.lblSrcLayerName.Text = "1";
            // 
            // lblDestLayerNameName
            // 
            this.lblDestLayerNameName.AutoSize = true;
            this.lblDestLayerNameName.Location = new System.Drawing.Point(7, 94);
            this.lblDestLayerNameName.Name = "lblDestLayerNameName";
            this.lblDestLayerNameName.Size = new System.Drawing.Size(65, 12);
            this.lblDestLayerNameName.TabIndex = 14;
            this.lblDestLayerNameName.Text = "约减名称：";
            // 
            // lblSrcLayerNameName
            // 
            this.lblSrcLayerNameName.AutoSize = true;
            this.lblSrcLayerNameName.Location = new System.Drawing.Point(7, 18);
            this.lblSrcLayerNameName.Name = "lblSrcLayerNameName";
            this.lblSrcLayerNameName.Size = new System.Drawing.Size(65, 12);
            this.lblSrcLayerNameName.TabIndex = 14;
            this.lblSrcLayerNameName.Text = "原图名称：";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.splitter2.Location = new System.Drawing.Point(0, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 646);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // gisPanel
            // 
            this.gisPanel.ActionAreaBackgroundColor = System.Drawing.Color.White;
            this.gisPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gisPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gisPanel.BackgroundImage")));
            this.gisPanel.Location = new System.Drawing.Point(256, 31);
            this.gisPanel.Name = "gisPanel";
            this.gisPanel.Size = new System.Drawing.Size(1007, 639);
            this.gisPanel.TabIndex = 5;
            // 
            // rdoUseLiOpenshaw
            // 
            this.rdoUseLiOpenshaw.AutoSize = true;
            this.rdoUseLiOpenshaw.Location = new System.Drawing.Point(3, 210);
            this.rdoUseLiOpenshaw.Name = "rdoUseLiOpenshaw";
            this.rdoUseLiOpenshaw.Size = new System.Drawing.Size(119, 16);
            this.rdoUseLiOpenshaw.TabIndex = 18;
            this.rdoUseLiOpenshaw.Text = "用LiOpenshaw算法";
            this.rdoUseLiOpenshaw.UseVisualStyleBackColor = true;
            // 
            // rdoUseFra
            // 
            this.rdoUseFra.AutoSize = true;
            this.rdoUseFra.Location = new System.Drawing.Point(3, 188);
            this.rdoUseFra.Name = "rdoUseFra";
            this.rdoUseFra.Size = new System.Drawing.Size(83, 16);
            this.rdoUseFra.TabIndex = 17;
            this.rdoUseFra.TabStop = true;
            this.rdoUseFra.Text = "用分形算法";
            this.rdoUseFra.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1264, 692);
            this.Controls.Add(this.gisPanel);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.ssrMain);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "MainForm";
            this.Text = "GIS";
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ssrMain.ResumeLayout(false);
            this.ssrMain.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMeasure)).EndInit();
            this.grpLayerList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

}

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem mnsItemCanvas;
        private System.Windows.Forms.ToolStripMenuItem mnsItemNewCanvas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnsItemCloseCanvas;

        private System.Windows.Forms.ToolStripMenuItem mnsItemLayer;
        private System.Windows.Forms.ToolStripMenuItem mnsItemAddShapeLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnsItemRemoveLayer;

        private System.Windows.Forms.ToolStripMenuItem mnsItemDisplay;
        private System.Windows.Forms.ToolStripMenuItem mnsItemDisplayLayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnsItemBackgroundColor;

        private System.Windows.Forms.ToolStripMenuItem mnsItemDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnsItemDatabaseLayer;

        private System.Windows.Forms.ToolStripMenuItem mnsItemBig;
        private System.Windows.Forms.ToolStripMenuItem mnsItemSmall;
        private System.Windows.Forms.ToolStripMenuItem mnsItemMove;

        private System.Windows.Forms.StatusStrip ssrMain;
        private System.Windows.Forms.ToolStripStatusLabel ssrItemMapLocation;
        private System.Windows.Forms.CheckedListBox clbLayerList;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.GroupBox grpLayerList;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private GISPrinter.GISPanel gisPanel;
        private System.Windows.Forms.RadioButton rdoUseDP;
        private System.Windows.Forms.RadioButton rdoUseImproved;

        private System.Windows.Forms.Label lblFrequencyMeasure;
        private System.Windows.Forms.Label lblMaxMeasure;
        private System.Windows.Forms.Label lblMinMeasure;
        private System.Windows.Forms.Label lblCurrentMesure;
        private System.Windows.Forms.TextBox txtFrequencyMeasure;
        private System.Windows.Forms.TextBox txtMaxMeasure;
        private System.Windows.Forms.TextBox txtMinMeasure;
        private System.Windows.Forms.TextBox txtCurrentMesure;
        private System.Windows.Forms.TrackBar trbMeasure;
        private System.Windows.Forms.Button btnApplyMeasure;
        //private System.Windows.Forms.Splitter splitter3;
        //private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.Label lblSrcVertexCountName;
        private System.Windows.Forms.Label lblSrcLengthName;
        private System.Windows.Forms.Label lblSrcAreaName;
        private System.Windows.Forms.Label lblDestAreaName;
        private System.Windows.Forms.Label lblDestLengthName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDestVertexCountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDiffAreaName;
        private System.Windows.Forms.Label lblRestrictVertexCount;
        private System.Windows.Forms.TextBox txtRestrictVertexCount;
        private System.Windows.Forms.Button btnRestrictVertexCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDestLength;
        private System.Windows.Forms.Label lblDestVertexCount;
        private System.Windows.Forms.Label lblSrcArea;
        private System.Windows.Forms.Label lblSrcLength;
        private System.Windows.Forms.Label lblSrcVertexCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDiffArea;
        private System.Windows.Forms.Label lblDestArea;
        private System.Windows.Forms.Label lblSrcLayerName;
        private System.Windows.Forms.Label lblSrcLayerNameName;
        private System.Windows.Forms.Label lblDestLayerName;
        private System.Windows.Forms.Label lblDestLayerNameName;
        private System.Windows.Forms.RadioButton rdoUseFra;
        private System.Windows.Forms.RadioButton rdoUseLiOpenshaw;
    }
}

=======
﻿namespace GIS
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.mnsItemCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemNewCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsItemCloseCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemAddShapeLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemRemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDisplayLayers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsItemBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemDatabaseLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemBig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItemSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ssrMain = new System.Windows.Forms.StatusStrip();
            this.ssrItemMapLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.clbLayerList = new System.Windows.Forms.CheckedListBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.btnApplyMeasure = new System.Windows.Forms.Button();
            this.rdoUseDP = new System.Windows.Forms.RadioButton();
            this.rdoUseImproved = new System.Windows.Forms.RadioButton();
            this.lblFrequencyMeasure = new System.Windows.Forms.Label();
            this.lblMaxMeasure = new System.Windows.Forms.Label();
            this.lblMinMeasure = new System.Windows.Forms.Label();
            this.lblCurrentMesure = new System.Windows.Forms.Label();
            this.txtFrequencyMeasure = new System.Windows.Forms.TextBox();
            this.txtMaxMeasure = new System.Windows.Forms.TextBox();
            this.txtMinMeasure = new System.Windows.Forms.TextBox();
            this.txtCurrentMesure = new System.Windows.Forms.TextBox();
            this.trbMeasure = new System.Windows.Forms.TrackBar();
            this.lblSrcVertexCountName = new System.Windows.Forms.Label();
            this.lblSrcVertexCount = new System.Windows.Forms.Label();
            this.lblDestVertexCountName = new System.Windows.Forms.Label();
            this.lblDestVertexCount = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpLayerList = new System.Windows.Forms.GroupBox();
            this.btnRestrictVertexCount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRestrictVertexCount = new System.Windows.Forms.Label();
            this.txtRestrictVertexCount = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblDiffAreaName = new System.Windows.Forms.Label();
            this.lblDestAreaName = new System.Windows.Forms.Label();
            this.lblDestLengthName = new System.Windows.Forms.Label();
            this.lblSrcAreaName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSrcLengthName = new System.Windows.Forms.Label();
            this.lblDiffArea = new System.Windows.Forms.Label();
            this.lblDestArea = new System.Windows.Forms.Label();
            this.lblDestLength = new System.Windows.Forms.Label();
            this.lblSrcArea = new System.Windows.Forms.Label();
            this.lblSrcLength = new System.Windows.Forms.Label();
            this.lblDestLayerName = new System.Windows.Forms.Label();
            this.lblSrcLayerName = new System.Windows.Forms.Label();
            this.lblDestLayerNameName = new System.Windows.Forms.Label();
            this.lblSrcLayerNameName = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gisPanel = new GISPrinter.GISPanel();
            this.rdoUseLiOpenshaw = new System.Windows.Forms.RadioButton();
            this.rdoUseFra = new System.Windows.Forms.RadioButton();
            this.mnsMain.SuspendLayout();
            this.ssrMain.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMeasure)).BeginInit();
            this.grpLayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.mnsMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemCanvas,
            this.mnsItemLayer,
            this.mnsItemDisplay,
            this.mnsItemDatabase,
            this.mnsItemBig,
            this.mnsItemSmall});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1264, 24);
            this.mnsMain.TabIndex = 0;
            // 
            // mnsItemCanvas
            // 
            this.mnsItemCanvas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemNewCanvas,
            this.toolStripSeparator1,
            this.mnsItemCloseCanvas});
            this.mnsItemCanvas.Name = "mnsItemCanvas";
            this.mnsItemCanvas.Size = new System.Drawing.Size(59, 20);
            this.mnsItemCanvas.Text = "画布(&C)";
            // 
            // mnsItemNewCanvas
            // 
            this.mnsItemNewCanvas.Name = "mnsItemNewCanvas";
            this.mnsItemNewCanvas.Size = new System.Drawing.Size(155, 38);
            this.mnsItemNewCanvas.Text = "新建画布(&N)";
            this.mnsItemNewCanvas.Click += new System.EventHandler(this.mnsItemNewCanvas_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnsItemCloseCanvas
            // 
            this.mnsItemCloseCanvas.Image = global::GIS.Properties.Resources.CloseLayer;
            this.mnsItemCloseCanvas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemCloseCanvas.Name = "mnsItemCloseCanvas";
            this.mnsItemCloseCanvas.Size = new System.Drawing.Size(155, 38);
            this.mnsItemCloseCanvas.Text = "关闭画布(&C)";
            this.mnsItemCloseCanvas.Click += new System.EventHandler(this.mnsItemCloseCanvas_Click);
            // 
            // mnsItemLayer
            // 
            this.mnsItemLayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemAddShapeLayer,
            this.mnsItemRemoveLayer});
            this.mnsItemLayer.Name = "mnsItemLayer";
            this.mnsItemLayer.Size = new System.Drawing.Size(57, 20);
            this.mnsItemLayer.Text = "图层(&L)";
            // 
            // mnsItemAddShapeLayer
            // 
            this.mnsItemAddShapeLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemAddShapeLayer.Name = "mnsItemAddShapeLayer";
            this.mnsItemAddShapeLayer.Size = new System.Drawing.Size(208, 38);
            this.mnsItemAddShapeLayer.Text = "添加Shape数据图层(&S)";
            this.mnsItemAddShapeLayer.Click += new System.EventHandler(this.mnsItemAddShapeLayer_Click);
            // 
            // mnsItemRemoveLayer
            // 
            this.mnsItemRemoveLayer.Image = global::GIS.Properties.Resources.RemoveShape;
            this.mnsItemRemoveLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemRemoveLayer.Name = "mnsItemRemoveLayer";
            this.mnsItemRemoveLayer.Size = new System.Drawing.Size(208, 38);
            this.mnsItemRemoveLayer.Text = "移除图层(&R)";
            this.mnsItemRemoveLayer.Click += new System.EventHandler(this.itemRemoveLayer_Click);
            // 
            // mnsItemDisplay
            // 
            this.mnsItemDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemDisplayLayers,
            this.toolStripSeparator3,
            this.mnsItemBackgroundColor});
            this.mnsItemDisplay.Name = "mnsItemDisplay";
            this.mnsItemDisplay.Size = new System.Drawing.Size(58, 20);
            this.mnsItemDisplay.Text = "显示(&V)";
            // 
            // mnsItemDisplayLayers
            // 
            this.mnsItemDisplayLayers.Image = global::GIS.Properties.Resources.ViewLayer;
            this.mnsItemDisplayLayers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemDisplayLayers.Name = "mnsItemDisplayLayers";
            this.mnsItemDisplayLayers.Size = new System.Drawing.Size(161, 38);
            this.mnsItemDisplayLayers.Text = "显示图层...(L)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // mnsItemBackgroundColor
            // 
            this.mnsItemBackgroundColor.Image = global::GIS.Properties.Resources.BackgroundColor;
            this.mnsItemBackgroundColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemBackgroundColor.Name = "mnsItemBackgroundColor";
            this.mnsItemBackgroundColor.Size = new System.Drawing.Size(161, 38);
            this.mnsItemBackgroundColor.Text = "背景颜色(&G)";
            this.mnsItemBackgroundColor.Click += new System.EventHandler(this.mnsItemBackgroundColor_Click);
            // 
            // mnsItemDatabase
            // 
            this.mnsItemDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsItemDatabaseLayer});
            this.mnsItemDatabase.Name = "mnsItemDatabase";
            this.mnsItemDatabase.Size = new System.Drawing.Size(59, 20);
            this.mnsItemDatabase.Text = "数据(&D)";
            // 
            // mnsItemDatabaseLayer
            // 
            this.mnsItemDatabaseLayer.Image = global::GIS.Properties.Resources.ViewSelectedData;
            this.mnsItemDatabaseLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnsItemDatabaseLayer.Name = "mnsItemDatabaseLayer";
            this.mnsItemDatabaseLayer.Size = new System.Drawing.Size(161, 38);
            this.mnsItemDatabaseLayer.Text = "查看图层...(&L)";
            // 
            // mnsItemBig
            // 
            this.mnsItemBig.Image = global::GIS.Properties.Resources.Big;
            this.mnsItemBig.Name = "mnsItemBig";
            this.mnsItemBig.Size = new System.Drawing.Size(75, 20);
            this.mnsItemBig.Text = "放大(&C)";
            this.mnsItemBig.Click += new System.EventHandler(this.mnsItemBig_Click);
            // 
            // mnsItemSmall
            // 
            this.mnsItemSmall.Image = global::GIS.Properties.Resources.Small;
            this.mnsItemSmall.Name = "mnsItemSmall";
            this.mnsItemSmall.Size = new System.Drawing.Size(75, 20);
            this.mnsItemSmall.Text = "缩小(&C)";
            this.mnsItemSmall.Click += new System.EventHandler(this.mnsItemSmall_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // ssrMain
            // 
            this.ssrMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230))))); 
            this.ssrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrItemMapLocation});
            this.ssrMain.Location = new System.Drawing.Point(0, 670);
            this.ssrMain.Name = "ssrMain";
            this.ssrMain.Size = new System.Drawing.Size(1264, 22);
            this.ssrMain.SizingGrip = false;
            this.ssrMain.TabIndex = 1;
            // 
            // ssrItemMapLocation
            // 
            this.ssrItemMapLocation.Name = "ssrItemMapLocation";
            this.ssrItemMapLocation.Size = new System.Drawing.Size(1249, 17);
            this.ssrItemMapLocation.Spring = true;
            this.ssrItemMapLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clbLayerList
            // 
            this.clbLayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLayerList.FormattingEnabled = true;
            this.clbLayerList.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.clbLayerList.Location = new System.Drawing.Point(3, 22);
            this.clbLayerList.Name = "clbLayerList";
            this.clbLayerList.Size = new System.Drawing.Size(244, 171);
            this.clbLayerList.TabIndex = 2;
            this.clbLayerList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbLayerList_ItemCheck);
            this.clbLayerList.SelectedIndexChanged += new System.EventHandler(this.clbLayerList_SelectedIndexChanged);
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControl.Controls.Add(this.grpAlgorithm);
            this.pnlControl.Controls.Add(this.splitter1);
            this.pnlControl.Controls.Add(this.grpLayerList);
            this.pnlControl.Location = new System.Drawing.Point(0, 25);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(250, 645);
            this.pnlControl.TabIndex = 3;
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.grpAlgorithm.Controls.Add(this.btnApplyMeasure);
            this.grpAlgorithm.Controls.Add(this.rdoUseDP);
            this.grpAlgorithm.Controls.Add(this.rdoUseImproved);
            this.grpAlgorithm.Controls.Add(this.lblFrequencyMeasure);
            this.grpAlgorithm.Controls.Add(this.lblMaxMeasure);
            this.grpAlgorithm.Controls.Add(this.lblMinMeasure);
            this.grpAlgorithm.Controls.Add(this.lblCurrentMesure);
            this.grpAlgorithm.Controls.Add(this.txtFrequencyMeasure);
            this.grpAlgorithm.Controls.Add(this.txtMaxMeasure);
            this.grpAlgorithm.Controls.Add(this.txtMinMeasure);
            this.grpAlgorithm.Controls.Add(this.txtCurrentMesure);
            this.grpAlgorithm.Controls.Add(this.trbMeasure);
            this.grpAlgorithm.Controls.Add(this.lblSrcVertexCountName);
            this.grpAlgorithm.Controls.Add(this.lblSrcVertexCount);
            this.grpAlgorithm.Controls.Add(this.lblDestVertexCountName);
            this.grpAlgorithm.Controls.Add(this.lblDestVertexCount);
            this.grpAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlgorithm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpAlgorithm.Location = new System.Drawing.Point(0, 199);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(250, 446);
            this.grpAlgorithm.TabIndex = 2;
            this.grpAlgorithm.TabStop = false;
            this.grpAlgorithm.Text = "算法";
            // 
            // btnApplyMeasure
            // 
            this.btnApplyMeasure.Location = new System.Drawing.Point(166, 98);
            this.btnApplyMeasure.Name = "btnApplyMeasure";
            this.btnApplyMeasure.Size = new System.Drawing.Size(75, 27);
            this.btnApplyMeasure.TabIndex = 19;
            this.btnApplyMeasure.Text = "应用参数";
            this.btnApplyMeasure.UseVisualStyleBackColor = true;
            this.btnApplyMeasure.Click += new System.EventHandler(this.btnApplyMeasure_Click);
            // 
            // rdoUseDP
            // 
            this.rdoUseDP.AutoSize = true;
            this.rdoUseDP.Location = new System.Drawing.Point(6, 131);
            this.rdoUseDP.Name = "rdoUseDP";
            this.rdoUseDP.Size = new System.Drawing.Size(75, 24);
            this.rdoUseDP.TabIndex = 18;
            this.rdoUseDP.Text = "DP算法";
            this.rdoUseDP.UseVisualStyleBackColor = true;
            // 
            // rdoUseImproved
            // 
            this.rdoUseImproved.AutoSize = true;
            this.rdoUseImproved.Checked = true;
            this.rdoUseImproved.Location = new System.Drawing.Point(100, 131);
            this.rdoUseImproved.Name = "rdoUseImproved";
            this.rdoUseImproved.Size = new System.Drawing.Size(83, 24);
            this.rdoUseImproved.TabIndex = 18;
            this.rdoUseImproved.TabStop = true;
            this.rdoUseImproved.Text = "改进算法";
            this.rdoUseImproved.UseVisualStyleBackColor = true;
            // 
            // lblFrequencyMeasure
            // 
            this.lblFrequencyMeasure.AutoSize = true;
            this.lblFrequencyMeasure.Location = new System.Drawing.Point(6, 44);
            this.lblFrequencyMeasure.Name = "lblFrequencyMeasure";
            this.lblFrequencyMeasure.Size = new System.Drawing.Size(37, 20);
            this.lblFrequencyMeasure.TabIndex = 12;
            this.lblFrequencyMeasure.Text = "频率";
            // 
            // lblMaxMeasure
            // 
            this.lblMaxMeasure.AutoSize = true;
            this.lblMaxMeasure.Location = new System.Drawing.Point(124, 20);
            this.lblMaxMeasure.Name = "lblMaxMeasure";
            this.lblMaxMeasure.Size = new System.Drawing.Size(37, 20);
            this.lblMaxMeasure.TabIndex = 13;
            this.lblMaxMeasure.Text = "最大";
            // 
            // lblMinMeasure
            // 
            this.lblMinMeasure.AutoSize = true;
            this.lblMinMeasure.Location = new System.Drawing.Point(6, 20);
            this.lblMinMeasure.Name = "lblMinMeasure";
            this.lblMinMeasure.Size = new System.Drawing.Size(37, 20);
            this.lblMinMeasure.TabIndex = 14;
            this.lblMinMeasure.Text = "最小";
            // 
            // lblCurrentMesure
            // 
            this.lblCurrentMesure.AutoSize = true;
            this.lblCurrentMesure.Location = new System.Drawing.Point(124, 44);
            this.lblCurrentMesure.Name = "lblCurrentMesure";
            this.lblCurrentMesure.Size = new System.Drawing.Size(37, 20);
            this.lblCurrentMesure.TabIndex = 15;
            this.lblCurrentMesure.Text = "当前";
            // 
            // txtFrequencyMeasure
            // 
            this.txtFrequencyMeasure.Location = new System.Drawing.Point(42, 42);
            this.txtFrequencyMeasure.Name = "txtFrequencyMeasure";
            this.txtFrequencyMeasure.Size = new System.Drawing.Size(72, 26);
            this.txtFrequencyMeasure.TabIndex = 8;
            this.txtFrequencyMeasure.Text = "0.01";
            // 
            // txtMaxMeasure
            // 
            this.txtMaxMeasure.Location = new System.Drawing.Point(166, 18);
            this.txtMaxMeasure.Name = "txtMaxMeasure";
            this.txtMaxMeasure.Size = new System.Drawing.Size(78, 26);
            this.txtMaxMeasure.TabIndex = 9;
            this.txtMaxMeasure.Text = "1";
            // 
            // txtMinMeasure
            // 
            this.txtMinMeasure.Location = new System.Drawing.Point(42, 18);
            this.txtMinMeasure.Name = "txtMinMeasure";
            this.txtMinMeasure.Size = new System.Drawing.Size(72, 26);
            this.txtMinMeasure.TabIndex = 10;
            this.txtMinMeasure.Text = "0.1";
            // 
            // txtCurrentMesure
            // 
            this.txtCurrentMesure.Location = new System.Drawing.Point(166, 42);
            this.txtCurrentMesure.Name = "txtCurrentMesure";
            this.txtCurrentMesure.Size = new System.Drawing.Size(78, 26);
            this.txtCurrentMesure.TabIndex = 11;
            this.txtCurrentMesure.Text = "0.5";
            // 
            // trbMeasure
            // 
            this.trbMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.trbMeasure.Location = new System.Drawing.Point(8, 70);
            this.trbMeasure.Name = "trbMeasure";
            this.trbMeasure.Size = new System.Drawing.Size(233, 45);
            this.trbMeasure.TabIndex = 7;
            this.trbMeasure.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbMeasure.Scroll += new System.EventHandler(this.trbMeasure_Scroll);
            // 
            // lblSrcVertexCountName
            // 
            this.lblSrcVertexCountName.AutoSize = true;
            this.lblSrcVertexCountName.Location = new System.Drawing.Point(7, 164);
            this.lblSrcVertexCountName.Name = "lblSrcVertexCountName";
            this.lblSrcVertexCountName.Size = new System.Drawing.Size(107, 20);
            this.lblSrcVertexCountName.TabIndex = 14;
            this.lblSrcVertexCountName.Text = "原图顶点数目：";
            // 
            // lblSrcVertexCount
            // 
            this.lblSrcVertexCount.AutoSize = true;
            this.lblSrcVertexCount.Location = new System.Drawing.Point(110, 164);
            this.lblSrcVertexCount.Name = "lblSrcVertexCount";
            this.lblSrcVertexCount.Size = new System.Drawing.Size(17, 20);
            this.lblSrcVertexCount.TabIndex = 14;
            this.lblSrcVertexCount.Text = "1";
            // 
            // lblDestVertexCountName
            // 
            this.lblDestVertexCountName.AutoSize = true;
            this.lblDestVertexCountName.Location = new System.Drawing.Point(7, 190);
            this.lblDestVertexCountName.Name = "lblDestVertexCountName";
            this.lblDestVertexCountName.Size = new System.Drawing.Size(107, 20);
            this.lblDestVertexCountName.TabIndex = 14;
            this.lblDestVertexCountName.Text = "约减顶点数目：";
            // 
            // lblDestVertexCount
            // 
            this.lblDestVertexCount.AutoSize = true;
            this.lblDestVertexCount.Location = new System.Drawing.Point(110, 190);
            this.lblDestVertexCount.Name = "lblDestVertexCount";
            this.lblDestVertexCount.Size = new System.Drawing.Size(17, 20);
            this.lblDestVertexCount.TabIndex = 14;
            this.lblDestVertexCount.Text = "1";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 196);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(250, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // grpLayerList
            // 
            this.grpLayerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.grpLayerList.Controls.Add(this.clbLayerList);
            this.grpLayerList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLayerList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpLayerList.Location = new System.Drawing.Point(0, 0);
            this.grpLayerList.Name = "grpLayerList";
            this.grpLayerList.Size = new System.Drawing.Size(250, 196);
            this.grpLayerList.TabIndex = 0;
            this.grpLayerList.TabStop = false;
            this.grpLayerList.Text = "图层列表";
            // 
            // btnRestrictVertexCount
            // 
            this.btnRestrictVertexCount.Location = new System.Drawing.Point(115, 106);
            this.btnRestrictVertexCount.Name = "btnRestrictVertexCount";
            this.btnRestrictVertexCount.Size = new System.Drawing.Size(75, 23);
            this.btnRestrictVertexCount.TabIndex = 19;
            this.btnRestrictVertexCount.Text = "顶点固定";
            this.btnRestrictVertexCount.UseVisualStyleBackColor = true;
            this.btnRestrictVertexCount.Click += new System.EventHandler(this.btnRestrictVertexCount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "-------------------------------------------------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "-------------------------------------------------------------";
            // 
            // lblRestrictVertexCount
            // 
            this.lblRestrictVertexCount.AutoSize = true;
            this.lblRestrictVertexCount.Location = new System.Drawing.Point(6, 112);
            this.lblRestrictVertexCount.Name = "lblRestrictVertexCount";
            this.lblRestrictVertexCount.Size = new System.Drawing.Size(29, 12);
            this.lblRestrictVertexCount.TabIndex = 14;
            this.lblRestrictVertexCount.Text = "顶点";
            // 
            // txtRestrictVertexCount
            // 
            this.txtRestrictVertexCount.Location = new System.Drawing.Point(41, 109);
            this.txtRestrictVertexCount.Name = "txtRestrictVertexCount";
            this.txtRestrictVertexCount.Size = new System.Drawing.Size(50, 21);
            this.txtRestrictVertexCount.TabIndex = 10;
            this.txtRestrictVertexCount.Text = "5";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(115, 194);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 21);
            this.btnReport.TabIndex = 15;
            this.btnReport.Text = "生成文件";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblDiffAreaName
            // 
            this.lblDiffAreaName.AutoSize = true;
            this.lblDiffAreaName.Location = new System.Drawing.Point(6, 167);
            this.lblDiffAreaName.Name = "lblDiffAreaName";
            this.lblDiffAreaName.Size = new System.Drawing.Size(53, 12);
            this.lblDiffAreaName.TabIndex = 14;
            this.lblDiffAreaName.Text = "面积差：";
            // 
            // lblDestAreaName
            // 
            this.lblDestAreaName.AutoSize = true;
            this.lblDestAreaName.Location = new System.Drawing.Point(6, 143);
            this.lblDestAreaName.Name = "lblDestAreaName";
            this.lblDestAreaName.Size = new System.Drawing.Size(65, 12);
            this.lblDestAreaName.TabIndex = 14;
            this.lblDestAreaName.Text = "约减面积：";
            // 
            // lblDestLengthName
            // 
            this.lblDestLengthName.AutoSize = true;
            this.lblDestLengthName.Location = new System.Drawing.Point(6, 126);
            this.lblDestLengthName.Name = "lblDestLengthName";
            this.lblDestLengthName.Size = new System.Drawing.Size(89, 12);
            this.lblDestLengthName.TabIndex = 14;
            this.lblDestLengthName.Text = "约减线段总长：";
            // 
            // lblSrcAreaName
            // 
            this.lblSrcAreaName.AutoSize = true;
            this.lblSrcAreaName.Location = new System.Drawing.Point(7, 70);
            this.lblSrcAreaName.Name = "lblSrcAreaName";
            this.lblSrcAreaName.Size = new System.Drawing.Size(65, 12);
            this.lblSrcAreaName.TabIndex = 14;
            this.lblSrcAreaName.Text = "原图面积：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "-------------------------------------------------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(371, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "-------------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "-------------------------------------------------------------";
            // 
            // lblSrcLengthName
            // 
            this.lblSrcLengthName.AutoSize = true;
            this.lblSrcLengthName.Location = new System.Drawing.Point(7, 54);
            this.lblSrcLengthName.Name = "lblSrcLengthName";
            this.lblSrcLengthName.Size = new System.Drawing.Size(89, 12);
            this.lblSrcLengthName.TabIndex = 14;
            this.lblSrcLengthName.Text = "原图线段总长：";
            // 
            // lblDiffArea
            // 
            this.lblDiffArea.AutoSize = true;
            this.lblDiffArea.Location = new System.Drawing.Point(98, 167);
            this.lblDiffArea.Name = "lblDiffArea";
            this.lblDiffArea.Size = new System.Drawing.Size(11, 12);
            this.lblDiffArea.TabIndex = 14;
            this.lblDiffArea.Text = "1";
            // 
            // lblDestArea
            // 
            this.lblDestArea.AutoSize = true;
            this.lblDestArea.Location = new System.Drawing.Point(98, 143);
            this.lblDestArea.Name = "lblDestArea";
            this.lblDestArea.Size = new System.Drawing.Size(11, 12);
            this.lblDestArea.TabIndex = 14;
            this.lblDestArea.Text = "1";
            // 
            // lblDestLength
            // 
            this.lblDestLength.AutoSize = true;
            this.lblDestLength.Location = new System.Drawing.Point(98, 126);
            this.lblDestLength.Name = "lblDestLength";
            this.lblDestLength.Size = new System.Drawing.Size(11, 12);
            this.lblDestLength.TabIndex = 14;
            this.lblDestLength.Text = "1";
            // 
            // lblSrcArea
            // 
            this.lblSrcArea.AutoSize = true;
            this.lblSrcArea.Location = new System.Drawing.Point(98, 70);
            this.lblSrcArea.Name = "lblSrcArea";
            this.lblSrcArea.Size = new System.Drawing.Size(11, 12);
            this.lblSrcArea.TabIndex = 14;
            this.lblSrcArea.Text = "1";
            // 
            // lblSrcLength
            // 
            this.lblSrcLength.AutoSize = true;
            this.lblSrcLength.Location = new System.Drawing.Point(98, 54);
            this.lblSrcLength.Name = "lblSrcLength";
            this.lblSrcLength.Size = new System.Drawing.Size(11, 12);
            this.lblSrcLength.TabIndex = 14;
            this.lblSrcLength.Text = "1";
            // 
            // lblDestLayerName
            // 
            this.lblDestLayerName.AutoSize = true;
            this.lblDestLayerName.Location = new System.Drawing.Point(98, 94);
            this.lblDestLayerName.Name = "lblDestLayerName";
            this.lblDestLayerName.Size = new System.Drawing.Size(11, 12);
            this.lblDestLayerName.TabIndex = 14;
            this.lblDestLayerName.Text = "1";
            // 
            // lblSrcLayerName
            // 
            this.lblSrcLayerName.AutoSize = true;
            this.lblSrcLayerName.Location = new System.Drawing.Point(98, 18);
            this.lblSrcLayerName.Name = "lblSrcLayerName";
            this.lblSrcLayerName.Size = new System.Drawing.Size(11, 12);
            this.lblSrcLayerName.TabIndex = 14;
            this.lblSrcLayerName.Text = "1";
            // 
            // lblDestLayerNameName
            // 
            this.lblDestLayerNameName.AutoSize = true;
            this.lblDestLayerNameName.Location = new System.Drawing.Point(7, 94);
            this.lblDestLayerNameName.Name = "lblDestLayerNameName";
            this.lblDestLayerNameName.Size = new System.Drawing.Size(65, 12);
            this.lblDestLayerNameName.TabIndex = 14;
            this.lblDestLayerNameName.Text = "约减名称：";
            // 
            // lblSrcLayerNameName
            // 
            this.lblSrcLayerNameName.AutoSize = true;
            this.lblSrcLayerNameName.Location = new System.Drawing.Point(7, 18);
            this.lblSrcLayerNameName.Name = "lblSrcLayerNameName";
            this.lblSrcLayerNameName.Size = new System.Drawing.Size(65, 12);
            this.lblSrcLayerNameName.TabIndex = 14;
            this.lblSrcLayerNameName.Text = "原图名称：";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.splitter2.Location = new System.Drawing.Point(0, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 646);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // gisPanel
            // 
            this.gisPanel.ActionAreaBackgroundColor = System.Drawing.Color.White;
            this.gisPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gisPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gisPanel.BackgroundImage")));
            this.gisPanel.Location = new System.Drawing.Point(256, 31);
            this.gisPanel.Name = "gisPanel";
            this.gisPanel.Size = new System.Drawing.Size(1007, 639);
            this.gisPanel.TabIndex = 5;
            // 
            // rdoUseLiOpenshaw
            // 
            this.rdoUseLiOpenshaw.AutoSize = true;
            this.rdoUseLiOpenshaw.Location = new System.Drawing.Point(3, 210);
            this.rdoUseLiOpenshaw.Name = "rdoUseLiOpenshaw";
            this.rdoUseLiOpenshaw.Size = new System.Drawing.Size(119, 16);
            this.rdoUseLiOpenshaw.TabIndex = 18;
            this.rdoUseLiOpenshaw.Text = "用LiOpenshaw算法";
            this.rdoUseLiOpenshaw.UseVisualStyleBackColor = true;
            // 
            // rdoUseFra
            // 
            this.rdoUseFra.AutoSize = true;
            this.rdoUseFra.Location = new System.Drawing.Point(3, 188);
            this.rdoUseFra.Name = "rdoUseFra";
            this.rdoUseFra.Size = new System.Drawing.Size(83, 16);
            this.rdoUseFra.TabIndex = 17;
            this.rdoUseFra.TabStop = true;
            this.rdoUseFra.Text = "用分形算法";
            this.rdoUseFra.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1264, 692);
            this.Controls.Add(this.gisPanel);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.ssrMain);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "MainForm";
            this.Text = "GIS";
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ssrMain.ResumeLayout(false);
            this.ssrMain.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMeasure)).EndInit();
            this.grpLayerList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

}

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem mnsItemCanvas;
        private System.Windows.Forms.ToolStripMenuItem mnsItemNewCanvas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnsItemCloseCanvas;

        private System.Windows.Forms.ToolStripMenuItem mnsItemLayer;
        private System.Windows.Forms.ToolStripMenuItem mnsItemAddShapeLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnsItemRemoveLayer;

        private System.Windows.Forms.ToolStripMenuItem mnsItemDisplay;
        private System.Windows.Forms.ToolStripMenuItem mnsItemDisplayLayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnsItemBackgroundColor;

        private System.Windows.Forms.ToolStripMenuItem mnsItemDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnsItemDatabaseLayer;

        private System.Windows.Forms.ToolStripMenuItem mnsItemBig;
        private System.Windows.Forms.ToolStripMenuItem mnsItemSmall;
        private System.Windows.Forms.ToolStripMenuItem mnsItemMove;

        private System.Windows.Forms.StatusStrip ssrMain;
        private System.Windows.Forms.ToolStripStatusLabel ssrItemMapLocation;
        private System.Windows.Forms.CheckedListBox clbLayerList;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.GroupBox grpLayerList;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private GISPrinter.GISPanel gisPanel;
        private System.Windows.Forms.RadioButton rdoUseDP;
        private System.Windows.Forms.RadioButton rdoUseImproved;

        private System.Windows.Forms.Label lblFrequencyMeasure;
        private System.Windows.Forms.Label lblMaxMeasure;
        private System.Windows.Forms.Label lblMinMeasure;
        private System.Windows.Forms.Label lblCurrentMesure;
        private System.Windows.Forms.TextBox txtFrequencyMeasure;
        private System.Windows.Forms.TextBox txtMaxMeasure;
        private System.Windows.Forms.TextBox txtMinMeasure;
        private System.Windows.Forms.TextBox txtCurrentMesure;
        private System.Windows.Forms.TrackBar trbMeasure;
        private System.Windows.Forms.Button btnApplyMeasure;
        //private System.Windows.Forms.Splitter splitter3;
        //private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.Label lblSrcVertexCountName;
        private System.Windows.Forms.Label lblSrcLengthName;
        private System.Windows.Forms.Label lblSrcAreaName;
        private System.Windows.Forms.Label lblDestAreaName;
        private System.Windows.Forms.Label lblDestLengthName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDestVertexCountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDiffAreaName;
        private System.Windows.Forms.Label lblRestrictVertexCount;
        private System.Windows.Forms.TextBox txtRestrictVertexCount;
        private System.Windows.Forms.Button btnRestrictVertexCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDestLength;
        private System.Windows.Forms.Label lblDestVertexCount;
        private System.Windows.Forms.Label lblSrcArea;
        private System.Windows.Forms.Label lblSrcLength;
        private System.Windows.Forms.Label lblSrcVertexCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDiffArea;
        private System.Windows.Forms.Label lblDestArea;
        private System.Windows.Forms.Label lblSrcLayerName;
        private System.Windows.Forms.Label lblSrcLayerNameName;
        private System.Windows.Forms.Label lblDestLayerName;
        private System.Windows.Forms.Label lblDestLayerNameName;
        private System.Windows.Forms.RadioButton rdoUseFra;
        private System.Windows.Forms.RadioButton rdoUseLiOpenshaw;
    }
}

>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
