<<<<<<< HEAD
﻿using GISPrinter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShapeDataSource;
using SimplifiedAlgorithm;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Diagnostics;
using GIS; 

namespace GIS
{
    public partial class MainForm : Form
    {
        private string fileName = "Sample";
        private string path; 
        List<TPShape> srcShapesCopy = new List<TPShape>();
        private GISConfigFile configFile;
        public MainForm()
        {    
            InitializeComponent();
            configFile = GISConfigFile.Load();
            // 清除分块缓存
            AreaGridCellImageCache.ClearAll();
            gisPanel.MapLocationChanged += GisPanel_MapLocationChanged;

            // 更新图层列表
            clbLayerList_ItemsUpdated();
            // Console.WriteLine(Math.Ceiling(0.1) + " ; " + Math.Ceiling(0.99)); 
           
           testGridAlgorithmTimes()
        }

        private void GisPanel_MapLocationChanged(object sender, MapLocationChangedEventArgs e)
        {
            // 地图view改变时更新坐标位置和缩放信息
            int accuracy = 4;
            StringBuilder mapLocaValue = new StringBuilder();
            mapLocaValue.Append("位置: ");
            mapLocaValue.Append(e.Location.X >= 0 ? "东经" : "西经");
            mapLocaValue.Append(Math.Round(Math.Abs(e.Location.X), accuracy));
            mapLocaValue.Append("°");

            // 南北反向
            mapLocaValue.Append(e.Location.Y >= 0 ? " 北纬" : " 南纬");
            mapLocaValue.Append(Math.Round(Math.Abs(e.Location.Y), accuracy));
            mapLocaValue.Append("°");

            mapLocaValue.Append("   缩小比例: ");
            mapLocaValue.Append(e.Scale);

            ssrItemMapLocation.Text = mapLocaValue.ToString();
        }

        private void clbLayerList_ItemsUpdated()
        {
            clbLayerList.ItemCheck -= clbLayerList_ItemCheck;
            clbLayerList.Items.Clear();
            foreach (BaseLayer layer in gisPanel.Layers)
            {
                // 图层名，图层描述和是否激活
                string item = string.Format("名称:{0} 类型:{1}", layer.GetLayerName(), layer.GetDescription());
                clbLayerList.Items.Add(item, layer.Enabled);
            }
            
            clbLayerList.ItemCheck += clbLayerList_ItemCheck;
        }

        private void clbLayerList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 激活状态发生改变
            gisPanel.Layers[e.Index].Enabled = e.NewValue == CheckState.Checked ? true : false;
          
            if (gisPanel.Layers[e.Index].Enabled && gisPanel.Layers[e.Index].GetDescription().Equals("文本图层"))
            {
                ShapeFileLayerOpenForm shapeFileLayerOpenForm = new ShapeFileLayerOpenForm(configFile, path + fileName);
                DialogResult dialogResult = shapeFileLayerOpenForm.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                 ((TextLayer)gisPanel.Layers[e.Index]).DrawingTextStyle = shapeFileLayerOpenForm.SelectedTextStyle;

            }
            gisPanel.RefreshActionArea();

        }

        private void clbLayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 更新原始图形参数
            if (clbLayerList.SelectedIndex < 0) { return; }
            ShapeStatus shapeStatus = ShapeStatus.LoadFrom(gisPanel.Layers[clbLayerList.SelectedIndex]);
            lblSrcLayerName.Text = gisPanel.Layers[clbLayerList.SelectedIndex].GetLayerName();
            lblSrcLength.Text = shapeStatus.Length.ToString();
            lblSrcArea.Text = shapeStatus.Area.ToString();
            lblSrcVertexCount.Text = shapeStatus.VertexCount.ToString();
        }

        private void mnsItemNewCanvas_Click(object sender, EventArgs e)
        {
            // 清除缓存，新建绘制板，重置图层列表
            AreaGridCellImageCache.ClearAll();
            gisPanel.NewPanel();
            clbLayerList_ItemsUpdated();
        }

        private void mnsItemAddShapeLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择一个Shape文件";
            openFileDialog.Filter = "Shape文件|*.shp";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                int index = openFileDialog.FileName.LastIndexOf('\\');
                path = openFileDialog.FileName.Substring(0, index + 1);
                fileName = openFileDialog.FileName.Substring(index + 1, openFileDialog.FileName.Length - index - 1);

                DataSource dataSource = DataSource.Load(openFileDialog.FileName);
                ShapeStyle shapeStyle = new ShapeStyle(Guid.NewGuid());

               

                // 添加文本图层


                //ShapeFileLayerOpenForm shapeFileLayerOpenForm = new ShapeFileLayerOpenForm(configFile, openFileDialog.FileName);
                //DialogResult dialogResult = shapeFileLayerOpenForm.ShowDialog(this);
                //TextLayer textLayer = new TextLayer(dataSource, shapeFileLayerOpenForm.SelectedTextStyle);
                //textLayer.Enabled = false;
                TextStyle style = configFile.GetTextStyles()[0];
                TextLayer textLayer = new TextLayer(dataSource, style);
                textLayer.Enabled = false;

                // 根据需要运用不同的绘制风格
                //shapeStyle.FillColor = Color.Black;
                //shapeStyle.OutlineColor = Color.Black;
                //shapeStyle.OutlinePattern = System.Drawing.Drawing2D.DashStyle.Solid;
                //shapeStyle.OutlineTickness = 2;
                //shapeStyle.PointPattern = ShapePointPattern.Circle;
                //shapeStyle.PointSize = 2;

                // 创建图层，加入到图层列表中，刷新绘制区域
                ShapeLayer layer = new ShapeLayer(dataSource, shapeStyle);
                gisPanel.Layers.Add(layer);
                gisPanel.Layers.Add(textLayer);
                gisPanel.ApplyShapeExtent();
                gisPanel.RefreshActionArea();
                clbLayerList_ItemsUpdated();
            }
        }

        private void mnsItemBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = gisPanel.ActionAreaBackgroundColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                // 刷新活动区域
                gisPanel.ActionAreaBackgroundColor = colorDialog.Color;
                gisPanel.RefreshActionArea();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // 导出为文件，自行修改参数
            string filePath = string.Format("{0}_{1}.report.txt", lblSrcLayerName.Text, DateTime.Now.ToString("yyyyMMddHHmmss"));
            StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Source Layer Name={0}", lblSrcLayerName.Text);
            writer.WriteLine("Source Shape Length={0}", lblSrcLength.Text);
            writer.WriteLine("Source Shape Area={0}", lblSrcArea.Text);
            writer.WriteLine("Source Vertex Count={0}", lblSrcVertexCount.Text);
            writer.WriteLine("Dest Layer Name={0}", lblDestLayerName.Text);
            writer.WriteLine("Dest Shape Length={0}", lblDestLength.Text);
            writer.WriteLine("Dest Shape Area={0}", lblDestArea.Text);
            writer.WriteLine("Dest Vertex Count={0}", lblDestVertexCount.Text);
            writer.WriteLine("Area Diff={0}", lblDiffArea.Text);
            writer.Flush();
            writer.Close();
        }

        private void trbMeasure_Scroll(object sender, EventArgs e)
        {
            // 根据滑块改变输入
            if (trbMeasure.Value == trbMeasure.Minimum) { txtCurrentMesure.Text = txtMinMeasure.Text; }
            else if (trbMeasure.Value == trbMeasure.Maximum) { txtCurrentMesure.Text = txtMaxMeasure.Text; }
            else
            {
                double minValue = double.Parse(txtMinMeasure.Text);
                double frequency = double.Parse(txtFrequencyMeasure.Text);
                txtCurrentMesure.Text = (minValue + frequency * trbMeasure.Value - trbMeasure.Minimum).ToString();
            }
             //test2();
           // ReduceShape(); 

            testGridAlgorithmTimes();           
            //testImprovedAlgorithmTimes();

            //for (int i = 1; i < 10; i++)
            //{

            //    Geohash.Precision = i;
            //    test1();
            //}
            //for (int i = 1; i < 10; i++)
            //{
            //    List<List<double>> timsTotal = new List<List<double>>();
            //    Geohash.Precision = i;
            //    double time = test2();

            //    Write("Geohash编码长度= " + Geohash.Precision + "          " + "提取公共边的平均时间= " + Math.Round(time, 4) + "          "
            //      , fileName + "_最终");


            //}
            Console.WriteLine("I'm Coming .......");
             
        }

        private void btnApplyMeasure_Click(object sender, EventArgs e)
        {
            // 根据输入设定滑块
            double minValue = double.Parse(txtMinMeasure.Text);
            double maxValue = double.Parse(txtMaxMeasure.Text);
            double frequency = double.Parse(txtFrequencyMeasure.Text);
            int count = Convert.ToInt32(Math.Ceiling(Math.Abs(maxValue - minValue) / frequency));
            trbMeasure.Minimum = 0;
            trbMeasure.Maximum = count;
            trbMeasure.TickFrequency = 1;

            double curValue = double.Parse(txtCurrentMesure.Text);
            if (curValue <= minValue) { trbMeasure.Value = 0; }
            else if (curValue >= maxValue) { trbMeasure.Value = count; }
            else if (Math.Abs(curValue - minValue) < frequency) { trbMeasure.Value = 1; }
            else { trbMeasure.Value = Convert.ToInt32(Math.Ceiling(Math.Abs(curValue - minValue) / frequency)); }

           ReduceShape();
           
        }

        private void btnRestrictVertexCount_Click(object sender, EventArgs e)
        {
            // 必须选中线或者多边形图形层
            if (clbLayerList.SelectedIndex < 0) { return; }
            if (!(gisPanel.Layers[clbLayerList.SelectedIndex] is ShapeLayer)) { return; }
            ShapeLayer srcShapeLayer = (gisPanel.Layers[clbLayerList.SelectedIndex] as ShapeLayer);
            if (srcShapeLayer.DataSource.ShapeDataType != ShapeType.PolyLine && srcShapeLayer.DataSource.ShapeDataType != ShapeType.Polygon) { return; }

            // 限制顶点数应该介于2和原始图形顶点数之间
            int restrictVertexCount = int.Parse(txtRestrictVertexCount.Text);
            if (restrictVertexCount < 2) { return; }
            if (restrictVertexCount > ShapeStatus.LoadFrom(srcShapeLayer).VertexCount) { return; }

            // 测量尺度介于0和360度之间
            double minValue = 0;
           // double maxValue = 360;
            double maxValue = 0.5;
            double precious = 0.000000001; // 防止死循环
            
            while (Math.Abs(minValue - maxValue) >= precious)
            {
                double curValue = (minValue + maxValue) / 2.0;
                txtCurrentMesure.Text = curValue.ToString();
                ReduceShape();
                string[] s = lblDestVertexCount.Text.Split(';');
                int destVertexCount = int.Parse(s[0].Split('(')[0]);
                if (destVertexCount == restrictVertexCount) {  break; }
                else if (destVertexCount < restrictVertexCount) { maxValue = curValue; }
                else { minValue = curValue; }
            }
           
        }
        private void mnsItemCloseCanvas_Click(object sender, EventArgs e)
        {
            // 清除缓存，新建绘制板，重置图层列表
            AreaGridCellImageCache.ClearAll();
            gisPanel.NewPanel();
            clbLayerList_ItemsUpdated();

        }

        private void itemRemoveLayer_Click(object sender, EventArgs e)
        {
            if (clbLayerList.SelectedIndex < 0) { return; }
            gisPanel.Layers.RemoveAt(clbLayerList.SelectedIndex);

            gisPanel.ApplyShapeExtent();
            gisPanel.RefreshActionArea();
            clbLayerList_ItemsUpdated();
        }

        private void mnsItemBig_Click(object sender, EventArgs e)
        {
            gisPanel.BigSmall(1);


        }

        private void mnsItemSmall_Click(object sender, EventArgs e)
        {
            gisPanel.BigSmall(-1);
        }
        
       
     

       
        private List<double> RaduceByGridAndDP(List<TPShape> tpShapes)
        {
          
            List<double> times = new List<double>();
            DateTime beforDT = System.DateTime.Now;

            //构建第二层索引结构
            for (int hs = 0; hs < tpShapes.Count; hs++)
                tpShapes[hs].GridStruct = TPShape.ToGridStruct(tpShapes[hs]);
            //构建第一层索引结构
            Dictionary<double, List<int>> gridStruct = ImprovedAlgorithm.TPShapeGridStruct(tpShapes);
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts1 = afterDT.Subtract(beforDT);
            times.Add(ts1.TotalMilliseconds);
            Console.WriteLine("构建两层Grid索引结构的时间= " + ts1.TotalMilliseconds +" ; "+Gridhash.GridWidth );
             
            beforDT = System.DateTime.Now;
            int commonPoint = ImprovedAlgorithm.TwoLevel_GridStruct(tpShapes, gridStruct);
            afterDT = System.DateTime.Now;
            TimeSpan  ts2 = afterDT.Subtract(beforDT);
            Console.WriteLine("提取公共边的时间= " + ts2.TotalMilliseconds  +"  ;  公共点个数：" + commonPoint);
            times.Add(ts2.TotalMilliseconds);


            beforDT = System.DateTime.Now;
            DTAlgorithm algorithm = new DTAlgorithm();
            double measure = double.Parse(txtCurrentMesure.Text);
            for (int hs = 0; hs < tpShapes.Count; hs++)
            {
                TPShape shp = tpShapes[hs];
                Dictionary<int, SortedList<int, TPVertex>> splitPoint = shp.SplitPoint;


                for (int k = 0; k < shp.TPLines.Count; k++)
                {

                    //Console.Write("图形：" + hs + "，曲线：" + k + "  :"); 
                    List<TPVertex> result = new List<TPVertex>();
                    if (splitPoint.ContainsKey(k))
                    {
                        SortedList<int, TPVertex> cs = splitPoint[k];
                        int ind = 0;
                        foreach (KeyValuePair<int, TPVertex> kvp in cs)
                        {
                            if (ind != kvp.Key)
                            {
                                int count = kvp.Key - ind + 1;
                                List<TPVertex> segmentLine1 = shp.TPLines[k].GetRange(ind, count);
                                //Console.Write("开始：" + segmentLine1[0].Id + ",结束：" + segmentLine1[segmentLine1.Count - 1].Id + " ;");
                                List<TPVertex> r1 = new List<TPVertex>();

                                if (count == 2)
                                {
                                    //r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                    r1 = algorithm.Execute(segmentLine1, measure);
                                    //Console.WriteLine("开始：{0},结束：{1},原曲线长度：{2},长度为2的边，无论是公共边还是非公共边都一样，两个端点都必须保存", segmentLine1[0].Id, segmentLine1[segmentLine1.Count - 1].Id, shp.TPLines[k].Count);
                                }
                                else if (segmentLine1[1].Count == 0)//非公共边
                                {
                                    // r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                    r1 = algorithm.Execute( segmentLine1, measure);
                                    //Console.WriteLine("开始：{0},结束：{1},原曲线长度：{2},非公共边", segmentLine1[0].Id, segmentLine1[segmentLine1.Count - 1].Id, shp.TPLines[k].Count);
                                }
                                else
                                {
                                    ImprovedAlgorithm.BuildLineOrder(segmentLine1);
                                    //Console.WriteLine("开始：{0},结束：{1},原曲线长度：{2},Start状态：{3}, 公共边", segmentLine1[0].Id, segmentLine1[segmentLine1.Count - 1].Id, shp.TPLines[k].Count, segmentLine1[0].Status);


                                    int shapeID = segmentLine1[0].TouchedVertexes[0].ShapeIndex;
                                    int lineID = segmentLine1[0].TouchedVertexes[0].LineIndex;
                                    int id = segmentLine1[0].TouchedVertexes[0].Id;
                                    if (segmentLine1[0].Status == TPVertexStatus.End)
                                        id = segmentLine1[segmentLine1.Count - 1].TouchedVertexes[0].Id;
                                    if (tpShapes[shapeID].ReduceResult.ContainsKey(lineID + "," + id))
                                    {

                                        List<int> rs = tpShapes[shapeID].ReduceResult[lineID + "," + id];
                                        //List<TPVertex> r2 = new List<TPVertex>();

                                        if (segmentLine1[0].Status == TPVertexStatus.End)
                                        {
                                            segmentLine1.Reverse();
                                            foreach (int t in rs)
                                                r1.Add(segmentLine1[t]);
                                            r1.Reverse();


                                            //r2 = algorithm.ImprovedIteration_14_2(shp, segmentLine1, measure);
                                            //r2.Reverse();
                                        }
                                        else
                                        {
                                            foreach (int t in rs)
                                                r1.Add(segmentLine1[t]);
                                            //r2 = algorithm.ImprovedIteration_14_2(shp, segmentLine1, measure);
                                        }

                                        ///////////////////////// 

                                        //for (int i = 0; i < r1.Count;i++ )
                                        //{
                                        //    if (r1[i].Id != r2[i].Id)  
                                        //    Console.WriteLine(r1[i].Id + "  ;   " + r2[i].Id + "  ;   " + (r1[i].Id - r2[i].Id));
                                        //}
                                        ///////////////////////////////


                                    }
                                    else
                                    {

                                        if (segmentLine1[0].Status == TPVertexStatus.End)
                                        {
                                            segmentLine1.Reverse();
                                            // r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                            r1 = algorithm.Execute( segmentLine1, measure);
                                            r1.Reverse();
                                        }
                                        else
                                            // r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                            r1 = algorithm.Execute( segmentLine1, measure);

                                        List<int> rs = new List<int>();
                                        foreach (TPVertex t in r1)
                                        {
                                            rs.Add(t.Id - r1[0].Id);
                                            //Console.WriteLine(t.Id + "  ;   " + segmentLine1[0].Id + "  ;   " + (t.Id - segmentLine1[0].Id));
                                        }
                                        shp.ReduceResult.Add(k + "," + segmentLine1[0].Id, rs);
                                    }


                                }
                                //Console.Write("开始：{0},结束：{1} ;", r1[0].Id, r1[r1.Count - 1].Id);

                                if (result.Count != 0)
                                    result.RemoveAt(result.Count - 1);
                                result.AddRange(r1);

                                ind = kvp.Key;

                            }

                        }
                        if (ind != shp.TPLines[k].Count - 1)
                        {
                            List<TPVertex> segmentLine2 = shp.TPLines[k].GetRange(ind, shp.TPLines[k].Count - ind);
                            //Console.WriteLine("开始：{0},结束：{1} ,原曲线长度：{2},非公共边", segmentLine2[0].Id, segmentLine2[segmentLine2.Count - 1].Id, shp.TPLines[k].Count);
                            // List<TPVertex> r2 = algorithm.ImprovedIteration_14_1(segmentLine2, measure);
                            List<TPVertex> r2 = algorithm.Execute( segmentLine2, measure);
                            // Console.Write("开始：{0},结束：{1} ;", r2[0].Id, r2[r2.Count - 1].Id);

                            if (result.Count != 0)
                                result.RemoveAt(result.Count - 1);
                            result.AddRange(r2);

                        }


                    }
                    else
                    {
                        // result = algorithm.ImprovedIteration_14_1(shp.TPLines[k], measure);
                        result = algorithm.Execute( shp.TPLines[k], measure);

                        // Console.WriteLine("开始：{0},结束：{1} ,原曲线长度：{2},未分段", 0, shp.TPLines[k].Count - 1, shp.TPLines[k].Count);     
                        //Console.Write("开始：{0},结束：{1} ;", 0, shp.TPLines[k].Count - 1); 
                        // Console.Write("开始：{0},结束：{1} ;", result[0].Id, result[result.Count - 1].Id);
                    }

                    shp.TPLines[k] = result;


                }
            }

            afterDT = System.DateTime.Now;
            TimeSpan ts3 = afterDT.Subtract(beforDT);
            Console.WriteLine("化简的时间= " + ts3.TotalMilliseconds);
            times.Add(ts3.TotalMilliseconds);
            times.Add(ts1.TotalMilliseconds + ts2.TotalMilliseconds + ts3.TotalMilliseconds);
            return times;


        }
     
     
   
      
       

         

        private double GetDistance(TPVertex v1, TPVertex v2)
        {
            // 获得两顶点的距离
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }
        /// <summary>
        /// 求直线外一点到该直线的投影点
        /// </summary>
        /// <param name="pLine">线上任一点</param>
        /// <param name="k">直线斜率</param>
        /// <param name="pOut">线外指定点</param>
        /// <param name="pProject">投影点</param>
        protected TPVertex GetProjectivePoint(TPVertex pLine, double k, TPVertex pOut)
        {
            TPVertex pProject = new TPVertex();
            if (k.Equals(double.NaN)) //垂线斜率不存在情况
            {
                pProject.X = pLine.X;
                pProject.Y = pOut.Y;
            }
            else if (k == 0) //k=0
            {
                pProject.X = pOut.X;
                pProject.Y = pLine.Y;
            }
            else
            {
                pProject.X = (float)((k * pLine.X + pOut.X / k + pOut.Y - pLine.Y) / (1 / k + k));
                pProject.Y = (float)(-1 / k * (pProject.X - pOut.X) + pOut.Y);
            }
            return pProject;
        }


        /// <summary>
        /// 计算两条直线的交点
        /// </summary>
        /// <param name="lineFirstStar">L1的点1坐标</param>
        /// <param name="lineFirstEnd">L1的点2坐标</param>
        /// <param name="lineSecondStar">L2的点1坐标</param>
        /// <param name="lineSecondEnd">L2的点2坐标</param>
        /// <returns></returns>
        public static TPVertex GetIntersection(TPVertex lineFirstStar, TPVertex lineFirstEnd, TPVertex lineSecondStar, TPVertex lineSecondEnd)
        {
            /*
             * L1，L2都存在斜率的情况：
             * 直线方程L1: ( y - y1 ) / ( y2 - y1 ) = ( x - x1 ) / ( x2 - x1 ) 
             * => y = [ ( y2 - y1 ) / ( x2 - x1 ) ]( x - x1 ) + y1
             * 令 a = ( y2 - y1 ) / ( x2 - x1 )
             * 有 y = a * x - a * x1 + y1   .........1
             * 直线方程L2: ( y - y3 ) / ( y4 - y3 ) = ( x - x3 ) / ( x4 - x3 )
             * 令 b = ( y4 - y3 ) / ( x4 - x3 )
             * 有 y = b * x - b * x3 + y3 ..........2
             * 
             * 如果 a = b，则两直线平等，否则， 联解方程 1,2，得:
             * x = ( a * x1 - b * x3 - y1 + y3 ) / ( a - b )
             * y = a * x - a * x1 + y1
             * 
             * L1存在斜率, L2平行Y轴的情况：
             * x = x3
             * y = a * x3 - a * x1 + y1
             * 
             * L1 平行Y轴，L2存在斜率的情况：
             * x = x1
             * y = b * x - b * x3 + y3
             * 
             * L1与L2都平行Y轴的情况：
             * 如果 x1 = x3，那么L1与L2重合，否则平等
             * 
            */
            TPVertex intersection=new TPVertex();
            double a = 0, b = 0;
            int state = 0;

            //两个斜率都存在
            if (lineFirstStar.X != lineFirstEnd.X && lineSecondStar.X != lineSecondEnd.X)
            {
                a = (lineFirstEnd.Y - lineFirstStar.Y) / (lineFirstEnd.X - lineFirstStar.X);
                b = (lineSecondEnd.Y - lineSecondStar.Y) / (lineSecondEnd.X - lineSecondStar.X);
                state = 3;
            }
            //L1斜率存在，L2不存在
            else if (lineFirstStar.X != lineFirstEnd.X && lineSecondStar.X == lineSecondEnd.X)
            {
                a = (lineFirstEnd.Y - lineFirstStar.Y) / (lineFirstEnd.X - lineFirstStar.X);
                state = 1;
            }
            //L1斜率不存在，L2存在
            else if (lineFirstStar.X == lineFirstEnd.X && lineSecondStar.X != lineSecondEnd.X)
            {
                b = (lineSecondEnd.Y - lineSecondStar.Y) / (lineSecondEnd.X - lineSecondStar.X);
                state = 2;
            }
            else
                state = 0;
            switch (state)
            {
                case 0: //L1与L2都平行Y轴,斜率不存在
                    {
                        if (lineFirstStar.X == lineSecondStar.X)
                        {
                            //throw new Exception("两条直线互相重合，且平行于Y轴，无法计算交点。");
                            intersection= new TPVertex(0, 0, 0.000001);
                        }
                        else
                        {
                            //throw new Exception("两条直线互相平行，且平行于Y轴，无法计算交点。");
                            intersection= new TPVertex(0, 0, 0.000001);
                        }
                  break; 
                    } 
                case 1: //L1存在斜率, L2平行Y轴
                    {
                        double x = lineSecondStar.X;
                        double y = (lineFirstStar.X - x) * (-a) + lineFirstStar.Y;
                        intersection= new TPVertex(x, y, 0.000001);
                        break; 
                    } 
                case 2: //L1 平行Y轴，L2存在斜率
                    {
                        double x = lineFirstStar.X;
                        //网上有相似代码的，这一处是错误的。你可以对比case 1 的逻辑 进行分析
                        //源code:lineSecondStar * x + lineSecondStar * lineSecondStar.X + p3.Y;
                        double y = (lineSecondStar.X - x) * (-b) + lineSecondStar.Y;
                        intersection= new TPVertex(x, y, 0.000001);
                        break; 
                    }
                case 3: //L1，L2都存在斜率
                    {
                        if (a == b)
                        {
                            // throw new Exception("两条直线平行或重合，无法计算交点。");
                            intersection = new TPVertex(0, 0, 0.000001);
                        }
                        double x = (a * lineFirstStar.X - b * lineSecondStar.X - lineFirstStar.Y + lineSecondStar.Y) / (a - b);
                        double y = a * x - a * lineFirstStar.X + lineFirstStar.Y;
                        intersection= new TPVertex(x, y, 0.000001);
                        break;
                    }
            }

             if ((intersection.X - lineFirstStar.X) * (intersection.X - lineFirstEnd.X) <= 0  
                && (intersection.X - lineSecondStar.X) * (intersection.X - lineSecondEnd.X) <= 0  
                && (intersection.Y - lineFirstStar.Y) * (intersection.Y - lineFirstEnd.Y) <= 0  
                && (intersection.Y - lineSecondStar.Y) * (intersection.Y - lineSecondEnd.Y) <= 0) {  
              
            //System.out.println("线段相交于点(" + intersection.X + "," + intersection.Y + ")！");  
                    return intersection; // '相交  
            } else {  

           // System.out.println("线段相交于虚交点(" + intersection.X + "," + intersection.Y + ")！");  
                 return new TPVertex(0, 0, 0.000001); // '相交但不在线段上  
           }  



          

        }


        
        double testGridAlgorithmTimes()
        {
            // 必须选中线或者多边形图形层
            if (clbLayerList.SelectedIndex < 0) { return 0; }
            if (!(gisPanel.Layers[clbLayerList.SelectedIndex] is ShapeLayer)) { return 0; }
            ShapeLayer srcShapeLayer = (gisPanel.Layers[clbLayerList.SelectedIndex] as ShapeLayer);
            if (srcShapeLayer.DataSource.ShapeDataType != ShapeType.PolyLine && srcShapeLayer.DataSource.ShapeDataType != ShapeType.Polygon) { return 0; }

            // 原始图形转化为关系型图形
            var tpShapes = new List<TPShape>();
            List<TPShape> sortShapesCopy = new List<TPShape>(); 
            DateTime beforDT;
            DateTime afterDT;
            TimeSpan ts = new TimeSpan();
            int T =50;
            int count = 1;
            double sumTS = 0;
            double time = 0;
            int h = 1;
            Gridhash.GridWidth = 2;

            //for (double j = 0.000001; j <= 1;)
            //{
            //    T = 50;
            //    count = 1;
            //    sumTS = 0;
            //    time = 0;
            //    Gridhash.GridWidth = j;

            while (count <= T)
                {
                    // 原始图形转化为关系型图形
                    tpShapes = new List<TPShape>();
                    srcShapesCopy = new List<TPShape>();
                    sortShapesCopy = new List<TPShape>();
                    int i = 0;
                    foreach (BaseShape shape in srcShapeLayer.DataSource.Shapes)
                    {
                        TPShapeDataShape t1 = TPShapeDataShape.GenerateFrom(shape, i);
                        t1.Id = i;
                        tpShapes.Add(t1);

                        TPShapeDataShape t2 = TPShapeDataShape.GenerateFrom(shape, i);
                        t2.Id = i;
                        srcShapesCopy.Add(t2);

                        TPShapeDataShape t3 = TPShapeDataShape.GenerateFrom(shape, i);
                        t3.Id = i;
                        sortShapesCopy.Add(t3);

                        i++;
                    }



                    beforDT = System.DateTime.Now;
                    List<double> times1 = RaduceByGridAndDP(tpShapes);
                    afterDT = System.DateTime.Now;
                    times1.Insert(0, Gridhash.GridWidth);
                    times1.Insert(1, count);
                    times1.Insert(2, double.Parse(txtCurrentMesure.Text));
                    ts = afterDT.Subtract(beforDT);
                    // Write(times1, fileName);
                   // Write(string.Join(",", times1.ToArray()), fileName);
                    sumTS += ts.TotalMilliseconds;

                    count++;
                    Console.WriteLine("count=" + count);
                }
          
            time = sumTS / T;
            Console.WriteLine(Gridhash.GridWidth+"  ;  平均时间=" + time);
            //    if (h % 2 != 0)
            //        j = j * 5;
            //    else
            //        j = j * 2;
            //    h++;
            //}
            // 关系型图形转换为结果图形
            var destShapes = new List<BaseShape>();
            foreach (TPShape tpShape in tpShapes)
            {
                destShapes.Add((tpShape as TPShapeDataShape).ToBaseShape());
            }

            // 设置目标图层的显示风格，自行设置
            ShapeStyle destShapeStyle = srcShapeLayer.DrawingShapeStyle.GetCopy();
            destShapeStyle.OutlineColor = System.Drawing.Color.Red;


            // 创建新的图形层
            string destName = Path.GetFileNameWithoutExtension(srcShapeLayer.DataSource.FilePath) + "(R)" + Path.GetExtension(srcShapeLayer.DataSource.FilePath);
            DataSource destDataSource = srcShapeLayer.DataSource.GetCopy(destName);
            destDataSource.Shapes = destShapes;
            ShapeLayer destShapeLayer = new ShapeLayer(destDataSource, destShapeStyle);



            // 删除原图层列表中存在的约减图层
            BaseLayer removedLayer = gisPanel.Layers.FirstOrDefault(l => l.GetLayerName().Equals(destShapeLayer.GetLayerName()));
            if (removedLayer != null) { gisPanel.Layers.Remove(removedLayer); }


            // 添加新图层，刷新绘制区域和图层列表
            gisPanel.Layers.Add(destShapeLayer);

            gisPanel.ApplyShapeExtent();
            gisPanel.RefreshActionArea();
            clbLayerList_ItemsUpdated();
            clbLayerList.SelectedIndex = gisPanel.Layers.IndexOf(srcShapeLayer);

            // 更新约减图形参数
            ShapeStatus shapeStatus = ShapeStatus.LoadFrom(destShapeLayer);

            lblDestLayerName.Text = destShapeLayer.GetLayerName();
            lblDestLength.Text = shapeStatus.Length.ToString();
            lblDestArea.Text = shapeStatus.Area.ToString();

            // lblDestVertexCount.Text = shapeStatus.VertexCount.ToString() + "(红); " + shapeStatus1.VertexCount.ToString() + "(蓝);" + shapeStatus2.VertexCount.ToString() + "(绿);"+ shapeStatus3.VertexCount.ToString() + "(黄)";
            lblDestVertexCount.Text = shapeStatus.VertexCount.ToString() + "(红);";
            // lblDestVertexCount.Text = shapeStatus.VertexCount.ToString() + "(红);" ;


            // 更新差异化参数
            ShapeDiff shapeDiff = ShapeDiff.LoadFrom(srcShapeLayer, destShapeLayer);
            lblDiffArea.Text = shapeDiff.AreaDiff.ToString();
            return time;
        }

        
       
}
=======
﻿using GISPrinter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShapeDataSource;
using SimplifiedAlgorithm;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Diagnostics;
using GIS; 

namespace GIS
{
    public partial class MainForm : Form
    {
        private string fileName = "Sample";
        private string path; 
        List<TPShape> srcShapesCopy = new List<TPShape>();
        private GISConfigFile configFile;
        public MainForm()
        {    
            InitializeComponent();
            configFile = GISConfigFile.Load();
            // 清除分块缓存
            AreaGridCellImageCache.ClearAll();
            gisPanel.MapLocationChanged += GisPanel_MapLocationChanged;

            // 更新图层列表
            clbLayerList_ItemsUpdated();
            // Console.WriteLine(Math.Ceiling(0.1) + " ; " + Math.Ceiling(0.99)); 
           
           testGridAlgorithmTimes()
        }

        private void GisPanel_MapLocationChanged(object sender, MapLocationChangedEventArgs e)
        {
            // 地图view改变时更新坐标位置和缩放信息
            int accuracy = 4;
            StringBuilder mapLocaValue = new StringBuilder();
            mapLocaValue.Append("位置: ");
            mapLocaValue.Append(e.Location.X >= 0 ? "东经" : "西经");
            mapLocaValue.Append(Math.Round(Math.Abs(e.Location.X), accuracy));
            mapLocaValue.Append("°");

            // 南北反向
            mapLocaValue.Append(e.Location.Y >= 0 ? " 北纬" : " 南纬");
            mapLocaValue.Append(Math.Round(Math.Abs(e.Location.Y), accuracy));
            mapLocaValue.Append("°");

            mapLocaValue.Append("   缩小比例: ");
            mapLocaValue.Append(e.Scale);

            ssrItemMapLocation.Text = mapLocaValue.ToString();
        }

        private void clbLayerList_ItemsUpdated()
        {
            clbLayerList.ItemCheck -= clbLayerList_ItemCheck;
            clbLayerList.Items.Clear();
            foreach (BaseLayer layer in gisPanel.Layers)
            {
                // 图层名，图层描述和是否激活
                string item = string.Format("名称:{0} 类型:{1}", layer.GetLayerName(), layer.GetDescription());
                clbLayerList.Items.Add(item, layer.Enabled);
            }
            
            clbLayerList.ItemCheck += clbLayerList_ItemCheck;
        }

        private void clbLayerList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 激活状态发生改变
            gisPanel.Layers[e.Index].Enabled = e.NewValue == CheckState.Checked ? true : false;
          
            if (gisPanel.Layers[e.Index].Enabled && gisPanel.Layers[e.Index].GetDescription().Equals("文本图层"))
            {
                ShapeFileLayerOpenForm shapeFileLayerOpenForm = new ShapeFileLayerOpenForm(configFile, path + fileName);
                DialogResult dialogResult = shapeFileLayerOpenForm.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                 ((TextLayer)gisPanel.Layers[e.Index]).DrawingTextStyle = shapeFileLayerOpenForm.SelectedTextStyle;

            }
            gisPanel.RefreshActionArea();

        }

        private void clbLayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 更新原始图形参数
            if (clbLayerList.SelectedIndex < 0) { return; }
            ShapeStatus shapeStatus = ShapeStatus.LoadFrom(gisPanel.Layers[clbLayerList.SelectedIndex]);
            lblSrcLayerName.Text = gisPanel.Layers[clbLayerList.SelectedIndex].GetLayerName();
            lblSrcLength.Text = shapeStatus.Length.ToString();
            lblSrcArea.Text = shapeStatus.Area.ToString();
            lblSrcVertexCount.Text = shapeStatus.VertexCount.ToString();
        }

        private void mnsItemNewCanvas_Click(object sender, EventArgs e)
        {
            // 清除缓存，新建绘制板，重置图层列表
            AreaGridCellImageCache.ClearAll();
            gisPanel.NewPanel();
            clbLayerList_ItemsUpdated();
        }

        private void mnsItemAddShapeLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择一个Shape文件";
            openFileDialog.Filter = "Shape文件|*.shp";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                int index = openFileDialog.FileName.LastIndexOf('\\');
                path = openFileDialog.FileName.Substring(0, index + 1);
                fileName = openFileDialog.FileName.Substring(index + 1, openFileDialog.FileName.Length - index - 1);

                DataSource dataSource = DataSource.Load(openFileDialog.FileName);
                ShapeStyle shapeStyle = new ShapeStyle(Guid.NewGuid());

               

                // 添加文本图层


                //ShapeFileLayerOpenForm shapeFileLayerOpenForm = new ShapeFileLayerOpenForm(configFile, openFileDialog.FileName);
                //DialogResult dialogResult = shapeFileLayerOpenForm.ShowDialog(this);
                //TextLayer textLayer = new TextLayer(dataSource, shapeFileLayerOpenForm.SelectedTextStyle);
                //textLayer.Enabled = false;
                TextStyle style = configFile.GetTextStyles()[0];
                TextLayer textLayer = new TextLayer(dataSource, style);
                textLayer.Enabled = false;

                // 根据需要运用不同的绘制风格
                //shapeStyle.FillColor = Color.Black;
                //shapeStyle.OutlineColor = Color.Black;
                //shapeStyle.OutlinePattern = System.Drawing.Drawing2D.DashStyle.Solid;
                //shapeStyle.OutlineTickness = 2;
                //shapeStyle.PointPattern = ShapePointPattern.Circle;
                //shapeStyle.PointSize = 2;

                // 创建图层，加入到图层列表中，刷新绘制区域
                ShapeLayer layer = new ShapeLayer(dataSource, shapeStyle);
                gisPanel.Layers.Add(layer);
                gisPanel.Layers.Add(textLayer);
                gisPanel.ApplyShapeExtent();
                gisPanel.RefreshActionArea();
                clbLayerList_ItemsUpdated();
            }
        }

        private void mnsItemBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = gisPanel.ActionAreaBackgroundColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                // 刷新活动区域
                gisPanel.ActionAreaBackgroundColor = colorDialog.Color;
                gisPanel.RefreshActionArea();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // 导出为文件，自行修改参数
            string filePath = string.Format("{0}_{1}.report.txt", lblSrcLayerName.Text, DateTime.Now.ToString("yyyyMMddHHmmss"));
            StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Source Layer Name={0}", lblSrcLayerName.Text);
            writer.WriteLine("Source Shape Length={0}", lblSrcLength.Text);
            writer.WriteLine("Source Shape Area={0}", lblSrcArea.Text);
            writer.WriteLine("Source Vertex Count={0}", lblSrcVertexCount.Text);
            writer.WriteLine("Dest Layer Name={0}", lblDestLayerName.Text);
            writer.WriteLine("Dest Shape Length={0}", lblDestLength.Text);
            writer.WriteLine("Dest Shape Area={0}", lblDestArea.Text);
            writer.WriteLine("Dest Vertex Count={0}", lblDestVertexCount.Text);
            writer.WriteLine("Area Diff={0}", lblDiffArea.Text);
            writer.Flush();
            writer.Close();
        }

        private void trbMeasure_Scroll(object sender, EventArgs e)
        {
            // 根据滑块改变输入
            if (trbMeasure.Value == trbMeasure.Minimum) { txtCurrentMesure.Text = txtMinMeasure.Text; }
            else if (trbMeasure.Value == trbMeasure.Maximum) { txtCurrentMesure.Text = txtMaxMeasure.Text; }
            else
            {
                double minValue = double.Parse(txtMinMeasure.Text);
                double frequency = double.Parse(txtFrequencyMeasure.Text);
                txtCurrentMesure.Text = (minValue + frequency * trbMeasure.Value - trbMeasure.Minimum).ToString();
            }
             //test2();
           // ReduceShape(); 

            testGridAlgorithmTimes();           
            //testImprovedAlgorithmTimes();

            //for (int i = 1; i < 10; i++)
            //{

            //    Geohash.Precision = i;
            //    test1();
            //}
            //for (int i = 1; i < 10; i++)
            //{
            //    List<List<double>> timsTotal = new List<List<double>>();
            //    Geohash.Precision = i;
            //    double time = test2();

            //    Write("Geohash编码长度= " + Geohash.Precision + "          " + "提取公共边的平均时间= " + Math.Round(time, 4) + "          "
            //      , fileName + "_最终");


            //}
            Console.WriteLine("I'm Coming .......");
             
        }

        private void btnApplyMeasure_Click(object sender, EventArgs e)
        {
            // 根据输入设定滑块
            double minValue = double.Parse(txtMinMeasure.Text);
            double maxValue = double.Parse(txtMaxMeasure.Text);
            double frequency = double.Parse(txtFrequencyMeasure.Text);
            int count = Convert.ToInt32(Math.Ceiling(Math.Abs(maxValue - minValue) / frequency));
            trbMeasure.Minimum = 0;
            trbMeasure.Maximum = count;
            trbMeasure.TickFrequency = 1;

            double curValue = double.Parse(txtCurrentMesure.Text);
            if (curValue <= minValue) { trbMeasure.Value = 0; }
            else if (curValue >= maxValue) { trbMeasure.Value = count; }
            else if (Math.Abs(curValue - minValue) < frequency) { trbMeasure.Value = 1; }
            else { trbMeasure.Value = Convert.ToInt32(Math.Ceiling(Math.Abs(curValue - minValue) / frequency)); }

           ReduceShape();
           
        }

        private void btnRestrictVertexCount_Click(object sender, EventArgs e)
        {
            // 必须选中线或者多边形图形层
            if (clbLayerList.SelectedIndex < 0) { return; }
            if (!(gisPanel.Layers[clbLayerList.SelectedIndex] is ShapeLayer)) { return; }
            ShapeLayer srcShapeLayer = (gisPanel.Layers[clbLayerList.SelectedIndex] as ShapeLayer);
            if (srcShapeLayer.DataSource.ShapeDataType != ShapeType.PolyLine && srcShapeLayer.DataSource.ShapeDataType != ShapeType.Polygon) { return; }

            // 限制顶点数应该介于2和原始图形顶点数之间
            int restrictVertexCount = int.Parse(txtRestrictVertexCount.Text);
            if (restrictVertexCount < 2) { return; }
            if (restrictVertexCount > ShapeStatus.LoadFrom(srcShapeLayer).VertexCount) { return; }

            // 测量尺度介于0和360度之间
            double minValue = 0;
           // double maxValue = 360;
            double maxValue = 0.5;
            double precious = 0.000000001; // 防止死循环
            
            while (Math.Abs(minValue - maxValue) >= precious)
            {
                double curValue = (minValue + maxValue) / 2.0;
                txtCurrentMesure.Text = curValue.ToString();
                ReduceShape();
                string[] s = lblDestVertexCount.Text.Split(';');
                int destVertexCount = int.Parse(s[0].Split('(')[0]);
                if (destVertexCount == restrictVertexCount) {  break; }
                else if (destVertexCount < restrictVertexCount) { maxValue = curValue; }
                else { minValue = curValue; }
            }
           
        }
        private void mnsItemCloseCanvas_Click(object sender, EventArgs e)
        {
            // 清除缓存，新建绘制板，重置图层列表
            AreaGridCellImageCache.ClearAll();
            gisPanel.NewPanel();
            clbLayerList_ItemsUpdated();

        }

        private void itemRemoveLayer_Click(object sender, EventArgs e)
        {
            if (clbLayerList.SelectedIndex < 0) { return; }
            gisPanel.Layers.RemoveAt(clbLayerList.SelectedIndex);

            gisPanel.ApplyShapeExtent();
            gisPanel.RefreshActionArea();
            clbLayerList_ItemsUpdated();
        }

        private void mnsItemBig_Click(object sender, EventArgs e)
        {
            gisPanel.BigSmall(1);


        }

        private void mnsItemSmall_Click(object sender, EventArgs e)
        {
            gisPanel.BigSmall(-1);
        }
        
       
     

       
        private List<double> RaduceByGridAndDP(List<TPShape> tpShapes)
        {
          
            List<double> times = new List<double>();
            DateTime beforDT = System.DateTime.Now;

            //构建第二层索引结构
            for (int hs = 0; hs < tpShapes.Count; hs++)
                tpShapes[hs].GridStruct = TPShape.ToGridStruct(tpShapes[hs]);
            //构建第一层索引结构
            Dictionary<double, List<int>> gridStruct = ImprovedAlgorithm.TPShapeGridStruct(tpShapes);
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts1 = afterDT.Subtract(beforDT);
            times.Add(ts1.TotalMilliseconds);
            Console.WriteLine("构建两层Grid索引结构的时间= " + ts1.TotalMilliseconds +" ; "+Gridhash.GridWidth );
             
            beforDT = System.DateTime.Now;
            int commonPoint = ImprovedAlgorithm.TwoLevel_GridStruct(tpShapes, gridStruct);
            afterDT = System.DateTime.Now;
            TimeSpan  ts2 = afterDT.Subtract(beforDT);
            Console.WriteLine("提取公共边的时间= " + ts2.TotalMilliseconds  +"  ;  公共点个数：" + commonPoint);
            times.Add(ts2.TotalMilliseconds);


            beforDT = System.DateTime.Now;
            DTAlgorithm algorithm = new DTAlgorithm();
            double measure = double.Parse(txtCurrentMesure.Text);
            for (int hs = 0; hs < tpShapes.Count; hs++)
            {
                TPShape shp = tpShapes[hs];
                Dictionary<int, SortedList<int, TPVertex>> splitPoint = shp.SplitPoint;


                for (int k = 0; k < shp.TPLines.Count; k++)
                {

                    //Console.Write("图形：" + hs + "，曲线：" + k + "  :"); 
                    List<TPVertex> result = new List<TPVertex>();
                    if (splitPoint.ContainsKey(k))
                    {
                        SortedList<int, TPVertex> cs = splitPoint[k];
                        int ind = 0;
                        foreach (KeyValuePair<int, TPVertex> kvp in cs)
                        {
                            if (ind != kvp.Key)
                            {
                                int count = kvp.Key - ind + 1;
                                List<TPVertex> segmentLine1 = shp.TPLines[k].GetRange(ind, count);
                                //Console.Write("开始：" + segmentLine1[0].Id + ",结束：" + segmentLine1[segmentLine1.Count - 1].Id + " ;");
                                List<TPVertex> r1 = new List<TPVertex>();

                                if (count == 2)
                                {
                                    //r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                    r1 = algorithm.Execute(segmentLine1, measure);
                                    //Console.WriteLine("开始：{0},结束：{1},原曲线长度：{2},长度为2的边，无论是公共边还是非公共边都一样，两个端点都必须保存", segmentLine1[0].Id, segmentLine1[segmentLine1.Count - 1].Id, shp.TPLines[k].Count);
                                }
                                else if (segmentLine1[1].Count == 0)//非公共边
                                {
                                    // r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                    r1 = algorithm.Execute( segmentLine1, measure);
                                    //Console.WriteLine("开始：{0},结束：{1},原曲线长度：{2},非公共边", segmentLine1[0].Id, segmentLine1[segmentLine1.Count - 1].Id, shp.TPLines[k].Count);
                                }
                                else
                                {
                                    ImprovedAlgorithm.BuildLineOrder(segmentLine1);
                                    //Console.WriteLine("开始：{0},结束：{1},原曲线长度：{2},Start状态：{3}, 公共边", segmentLine1[0].Id, segmentLine1[segmentLine1.Count - 1].Id, shp.TPLines[k].Count, segmentLine1[0].Status);


                                    int shapeID = segmentLine1[0].TouchedVertexes[0].ShapeIndex;
                                    int lineID = segmentLine1[0].TouchedVertexes[0].LineIndex;
                                    int id = segmentLine1[0].TouchedVertexes[0].Id;
                                    if (segmentLine1[0].Status == TPVertexStatus.End)
                                        id = segmentLine1[segmentLine1.Count - 1].TouchedVertexes[0].Id;
                                    if (tpShapes[shapeID].ReduceResult.ContainsKey(lineID + "," + id))
                                    {

                                        List<int> rs = tpShapes[shapeID].ReduceResult[lineID + "," + id];
                                        //List<TPVertex> r2 = new List<TPVertex>();

                                        if (segmentLine1[0].Status == TPVertexStatus.End)
                                        {
                                            segmentLine1.Reverse();
                                            foreach (int t in rs)
                                                r1.Add(segmentLine1[t]);
                                            r1.Reverse();


                                            //r2 = algorithm.ImprovedIteration_14_2(shp, segmentLine1, measure);
                                            //r2.Reverse();
                                        }
                                        else
                                        {
                                            foreach (int t in rs)
                                                r1.Add(segmentLine1[t]);
                                            //r2 = algorithm.ImprovedIteration_14_2(shp, segmentLine1, measure);
                                        }

                                        ///////////////////////// 

                                        //for (int i = 0; i < r1.Count;i++ )
                                        //{
                                        //    if (r1[i].Id != r2[i].Id)  
                                        //    Console.WriteLine(r1[i].Id + "  ;   " + r2[i].Id + "  ;   " + (r1[i].Id - r2[i].Id));
                                        //}
                                        ///////////////////////////////


                                    }
                                    else
                                    {

                                        if (segmentLine1[0].Status == TPVertexStatus.End)
                                        {
                                            segmentLine1.Reverse();
                                            // r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                            r1 = algorithm.Execute( segmentLine1, measure);
                                            r1.Reverse();
                                        }
                                        else
                                            // r1 = algorithm.ImprovedIteration_14_1(segmentLine1, measure);
                                            r1 = algorithm.Execute( segmentLine1, measure);

                                        List<int> rs = new List<int>();
                                        foreach (TPVertex t in r1)
                                        {
                                            rs.Add(t.Id - r1[0].Id);
                                            //Console.WriteLine(t.Id + "  ;   " + segmentLine1[0].Id + "  ;   " + (t.Id - segmentLine1[0].Id));
                                        }
                                        shp.ReduceResult.Add(k + "," + segmentLine1[0].Id, rs);
                                    }


                                }
                                //Console.Write("开始：{0},结束：{1} ;", r1[0].Id, r1[r1.Count - 1].Id);

                                if (result.Count != 0)
                                    result.RemoveAt(result.Count - 1);
                                result.AddRange(r1);

                                ind = kvp.Key;

                            }

                        }
                        if (ind != shp.TPLines[k].Count - 1)
                        {
                            List<TPVertex> segmentLine2 = shp.TPLines[k].GetRange(ind, shp.TPLines[k].Count - ind);
                            //Console.WriteLine("开始：{0},结束：{1} ,原曲线长度：{2},非公共边", segmentLine2[0].Id, segmentLine2[segmentLine2.Count - 1].Id, shp.TPLines[k].Count);
                            // List<TPVertex> r2 = algorithm.ImprovedIteration_14_1(segmentLine2, measure);
                            List<TPVertex> r2 = algorithm.Execute( segmentLine2, measure);
                            // Console.Write("开始：{0},结束：{1} ;", r2[0].Id, r2[r2.Count - 1].Id);

                            if (result.Count != 0)
                                result.RemoveAt(result.Count - 1);
                            result.AddRange(r2);

                        }


                    }
                    else
                    {
                        // result = algorithm.ImprovedIteration_14_1(shp.TPLines[k], measure);
                        result = algorithm.Execute( shp.TPLines[k], measure);

                        // Console.WriteLine("开始：{0},结束：{1} ,原曲线长度：{2},未分段", 0, shp.TPLines[k].Count - 1, shp.TPLines[k].Count);     
                        //Console.Write("开始：{0},结束：{1} ;", 0, shp.TPLines[k].Count - 1); 
                        // Console.Write("开始：{0},结束：{1} ;", result[0].Id, result[result.Count - 1].Id);
                    }

                    shp.TPLines[k] = result;


                }
            }

            afterDT = System.DateTime.Now;
            TimeSpan ts3 = afterDT.Subtract(beforDT);
            Console.WriteLine("化简的时间= " + ts3.TotalMilliseconds);
            times.Add(ts3.TotalMilliseconds);
            times.Add(ts1.TotalMilliseconds + ts2.TotalMilliseconds + ts3.TotalMilliseconds);
            return times;


        }
     
     
   
      
       

         

        private double GetDistance(TPVertex v1, TPVertex v2)
        {
            // 获得两顶点的距离
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }
        /// <summary>
        /// 求直线外一点到该直线的投影点
        /// </summary>
        /// <param name="pLine">线上任一点</param>
        /// <param name="k">直线斜率</param>
        /// <param name="pOut">线外指定点</param>
        /// <param name="pProject">投影点</param>
        protected TPVertex GetProjectivePoint(TPVertex pLine, double k, TPVertex pOut)
        {
            TPVertex pProject = new TPVertex();
            if (k.Equals(double.NaN)) //垂线斜率不存在情况
            {
                pProject.X = pLine.X;
                pProject.Y = pOut.Y;
            }
            else if (k == 0) //k=0
            {
                pProject.X = pOut.X;
                pProject.Y = pLine.Y;
            }
            else
            {
                pProject.X = (float)((k * pLine.X + pOut.X / k + pOut.Y - pLine.Y) / (1 / k + k));
                pProject.Y = (float)(-1 / k * (pProject.X - pOut.X) + pOut.Y);
            }
            return pProject;
        }


        /// <summary>
        /// 计算两条直线的交点
        /// </summary>
        /// <param name="lineFirstStar">L1的点1坐标</param>
        /// <param name="lineFirstEnd">L1的点2坐标</param>
        /// <param name="lineSecondStar">L2的点1坐标</param>
        /// <param name="lineSecondEnd">L2的点2坐标</param>
        /// <returns></returns>
        public static TPVertex GetIntersection(TPVertex lineFirstStar, TPVertex lineFirstEnd, TPVertex lineSecondStar, TPVertex lineSecondEnd)
        {
            /*
             * L1，L2都存在斜率的情况：
             * 直线方程L1: ( y - y1 ) / ( y2 - y1 ) = ( x - x1 ) / ( x2 - x1 ) 
             * => y = [ ( y2 - y1 ) / ( x2 - x1 ) ]( x - x1 ) + y1
             * 令 a = ( y2 - y1 ) / ( x2 - x1 )
             * 有 y = a * x - a * x1 + y1   .........1
             * 直线方程L2: ( y - y3 ) / ( y4 - y3 ) = ( x - x3 ) / ( x4 - x3 )
             * 令 b = ( y4 - y3 ) / ( x4 - x3 )
             * 有 y = b * x - b * x3 + y3 ..........2
             * 
             * 如果 a = b，则两直线平等，否则， 联解方程 1,2，得:
             * x = ( a * x1 - b * x3 - y1 + y3 ) / ( a - b )
             * y = a * x - a * x1 + y1
             * 
             * L1存在斜率, L2平行Y轴的情况：
             * x = x3
             * y = a * x3 - a * x1 + y1
             * 
             * L1 平行Y轴，L2存在斜率的情况：
             * x = x1
             * y = b * x - b * x3 + y3
             * 
             * L1与L2都平行Y轴的情况：
             * 如果 x1 = x3，那么L1与L2重合，否则平等
             * 
            */
            TPVertex intersection=new TPVertex();
            double a = 0, b = 0;
            int state = 0;

            //两个斜率都存在
            if (lineFirstStar.X != lineFirstEnd.X && lineSecondStar.X != lineSecondEnd.X)
            {
                a = (lineFirstEnd.Y - lineFirstStar.Y) / (lineFirstEnd.X - lineFirstStar.X);
                b = (lineSecondEnd.Y - lineSecondStar.Y) / (lineSecondEnd.X - lineSecondStar.X);
                state = 3;
            }
            //L1斜率存在，L2不存在
            else if (lineFirstStar.X != lineFirstEnd.X && lineSecondStar.X == lineSecondEnd.X)
            {
                a = (lineFirstEnd.Y - lineFirstStar.Y) / (lineFirstEnd.X - lineFirstStar.X);
                state = 1;
            }
            //L1斜率不存在，L2存在
            else if (lineFirstStar.X == lineFirstEnd.X && lineSecondStar.X != lineSecondEnd.X)
            {
                b = (lineSecondEnd.Y - lineSecondStar.Y) / (lineSecondEnd.X - lineSecondStar.X);
                state = 2;
            }
            else
                state = 0;
            switch (state)
            {
                case 0: //L1与L2都平行Y轴,斜率不存在
                    {
                        if (lineFirstStar.X == lineSecondStar.X)
                        {
                            //throw new Exception("两条直线互相重合，且平行于Y轴，无法计算交点。");
                            intersection= new TPVertex(0, 0, 0.000001);
                        }
                        else
                        {
                            //throw new Exception("两条直线互相平行，且平行于Y轴，无法计算交点。");
                            intersection= new TPVertex(0, 0, 0.000001);
                        }
                  break; 
                    } 
                case 1: //L1存在斜率, L2平行Y轴
                    {
                        double x = lineSecondStar.X;
                        double y = (lineFirstStar.X - x) * (-a) + lineFirstStar.Y;
                        intersection= new TPVertex(x, y, 0.000001);
                        break; 
                    } 
                case 2: //L1 平行Y轴，L2存在斜率
                    {
                        double x = lineFirstStar.X;
                        //网上有相似代码的，这一处是错误的。你可以对比case 1 的逻辑 进行分析
                        //源code:lineSecondStar * x + lineSecondStar * lineSecondStar.X + p3.Y;
                        double y = (lineSecondStar.X - x) * (-b) + lineSecondStar.Y;
                        intersection= new TPVertex(x, y, 0.000001);
                        break; 
                    }
                case 3: //L1，L2都存在斜率
                    {
                        if (a == b)
                        {
                            // throw new Exception("两条直线平行或重合，无法计算交点。");
                            intersection = new TPVertex(0, 0, 0.000001);
                        }
                        double x = (a * lineFirstStar.X - b * lineSecondStar.X - lineFirstStar.Y + lineSecondStar.Y) / (a - b);
                        double y = a * x - a * lineFirstStar.X + lineFirstStar.Y;
                        intersection= new TPVertex(x, y, 0.000001);
                        break;
                    }
            }

             if ((intersection.X - lineFirstStar.X) * (intersection.X - lineFirstEnd.X) <= 0  
                && (intersection.X - lineSecondStar.X) * (intersection.X - lineSecondEnd.X) <= 0  
                && (intersection.Y - lineFirstStar.Y) * (intersection.Y - lineFirstEnd.Y) <= 0  
                && (intersection.Y - lineSecondStar.Y) * (intersection.Y - lineSecondEnd.Y) <= 0) {  
              
            //System.out.println("线段相交于点(" + intersection.X + "," + intersection.Y + ")！");  
                    return intersection; // '相交  
            } else {  

           // System.out.println("线段相交于虚交点(" + intersection.X + "," + intersection.Y + ")！");  
                 return new TPVertex(0, 0, 0.000001); // '相交但不在线段上  
           }  



          

        }


        
        double testGridAlgorithmTimes()
        {
            // 必须选中线或者多边形图形层
            if (clbLayerList.SelectedIndex < 0) { return 0; }
            if (!(gisPanel.Layers[clbLayerList.SelectedIndex] is ShapeLayer)) { return 0; }
            ShapeLayer srcShapeLayer = (gisPanel.Layers[clbLayerList.SelectedIndex] as ShapeLayer);
            if (srcShapeLayer.DataSource.ShapeDataType != ShapeType.PolyLine && srcShapeLayer.DataSource.ShapeDataType != ShapeType.Polygon) { return 0; }

            // 原始图形转化为关系型图形
            var tpShapes = new List<TPShape>();
            List<TPShape> sortShapesCopy = new List<TPShape>(); 
            DateTime beforDT;
            DateTime afterDT;
            TimeSpan ts = new TimeSpan();
            int T =50;
            int count = 1;
            double sumTS = 0;
            double time = 0;
            int h = 1;
            Gridhash.GridWidth = 2;

            //for (double j = 0.000001; j <= 1;)
            //{
            //    T = 50;
            //    count = 1;
            //    sumTS = 0;
            //    time = 0;
            //    Gridhash.GridWidth = j;

            while (count <= T)
                {
                    // 原始图形转化为关系型图形
                    tpShapes = new List<TPShape>();
                    srcShapesCopy = new List<TPShape>();
                    sortShapesCopy = new List<TPShape>();
                    int i = 0;
                    foreach (BaseShape shape in srcShapeLayer.DataSource.Shapes)
                    {
                        TPShapeDataShape t1 = TPShapeDataShape.GenerateFrom(shape, i);
                        t1.Id = i;
                        tpShapes.Add(t1);

                        TPShapeDataShape t2 = TPShapeDataShape.GenerateFrom(shape, i);
                        t2.Id = i;
                        srcShapesCopy.Add(t2);

                        TPShapeDataShape t3 = TPShapeDataShape.GenerateFrom(shape, i);
                        t3.Id = i;
                        sortShapesCopy.Add(t3);

                        i++;
                    }



                    beforDT = System.DateTime.Now;
                    List<double> times1 = RaduceByGridAndDP(tpShapes);
                    afterDT = System.DateTime.Now;
                    times1.Insert(0, Gridhash.GridWidth);
                    times1.Insert(1, count);
                    times1.Insert(2, double.Parse(txtCurrentMesure.Text));
                    ts = afterDT.Subtract(beforDT);
                    // Write(times1, fileName);
                   // Write(string.Join(",", times1.ToArray()), fileName);
                    sumTS += ts.TotalMilliseconds;

                    count++;
                    Console.WriteLine("count=" + count);
                }
          
            time = sumTS / T;
            Console.WriteLine(Gridhash.GridWidth+"  ;  平均时间=" + time);
            //    if (h % 2 != 0)
            //        j = j * 5;
            //    else
            //        j = j * 2;
            //    h++;
            //}
            // 关系型图形转换为结果图形
            var destShapes = new List<BaseShape>();
            foreach (TPShape tpShape in tpShapes)
            {
                destShapes.Add((tpShape as TPShapeDataShape).ToBaseShape());
            }

            // 设置目标图层的显示风格，自行设置
            ShapeStyle destShapeStyle = srcShapeLayer.DrawingShapeStyle.GetCopy();
            destShapeStyle.OutlineColor = System.Drawing.Color.Red;


            // 创建新的图形层
            string destName = Path.GetFileNameWithoutExtension(srcShapeLayer.DataSource.FilePath) + "(R)" + Path.GetExtension(srcShapeLayer.DataSource.FilePath);
            DataSource destDataSource = srcShapeLayer.DataSource.GetCopy(destName);
            destDataSource.Shapes = destShapes;
            ShapeLayer destShapeLayer = new ShapeLayer(destDataSource, destShapeStyle);



            // 删除原图层列表中存在的约减图层
            BaseLayer removedLayer = gisPanel.Layers.FirstOrDefault(l => l.GetLayerName().Equals(destShapeLayer.GetLayerName()));
            if (removedLayer != null) { gisPanel.Layers.Remove(removedLayer); }


            // 添加新图层，刷新绘制区域和图层列表
            gisPanel.Layers.Add(destShapeLayer);

            gisPanel.ApplyShapeExtent();
            gisPanel.RefreshActionArea();
            clbLayerList_ItemsUpdated();
            clbLayerList.SelectedIndex = gisPanel.Layers.IndexOf(srcShapeLayer);

            // 更新约减图形参数
            ShapeStatus shapeStatus = ShapeStatus.LoadFrom(destShapeLayer);

            lblDestLayerName.Text = destShapeLayer.GetLayerName();
            lblDestLength.Text = shapeStatus.Length.ToString();
            lblDestArea.Text = shapeStatus.Area.ToString();

            // lblDestVertexCount.Text = shapeStatus.VertexCount.ToString() + "(红); " + shapeStatus1.VertexCount.ToString() + "(蓝);" + shapeStatus2.VertexCount.ToString() + "(绿);"+ shapeStatus3.VertexCount.ToString() + "(黄)";
            lblDestVertexCount.Text = shapeStatus.VertexCount.ToString() + "(红);";
            // lblDestVertexCount.Text = shapeStatus.VertexCount.ToString() + "(红);" ;


            // 更新差异化参数
            ShapeDiff shapeDiff = ShapeDiff.LoadFrom(srcShapeLayer, destShapeLayer);
            lblDiffArea.Text = shapeDiff.AreaDiff.ToString();
            return time;
        }

        
       
}
>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
