<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using ShapeDataSource;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
namespace SimplifiedAlgorithm
{
    public class ImprovedAlgorithm
    {
        private double maxMeasure;

        public ImprovedAlgorithm()
        {
            maxMeasure = 360;
        }

        public double MaxMeasure
        {
            get
            {
                return maxMeasure;
            }
            set
            {
                maxMeasure = value;
            }
        }


      public static Dictionary<double, List<int>> TPShapeGridStruct(List<TPShape> tpShapes)
        {
            Dictionary<double, List<int>> dictionary = new Dictionary<double, List<int>>();

            double avg_x = 0;
            for (int i = 1; i < tpShapes.Count; i++) 
                avg_x+=tpShapes[i].Extent.XMax - tpShapes[i].Extent.XMin; 
            avg_x = avg_x / tpShapes.Count;
           // Console.WriteLine("平均最小外接矩形的大小:" + avg_x);

            double max_x = avg_x;
            double max_y = avg_x;
            for (int i = 0; i < tpShapes.Count; i++)
            {


                //记录每个图形最小外接矩形的Grid编码
                HashSet<double> gridhashs = new HashSet<double>();

                TPExtent tpExtent = tpShapes[i].Extent;
                gridhashs.Add(Gridhash.Encode(tpExtent.XMin,tpExtent.YMin,  max_x, max_y));
                gridhashs.Add(Gridhash.Encode(tpExtent.XMax,tpExtent.YMax,  max_x, max_y));

                if (gridhashs.Count > 1)
                {
                    double x;
                    double id;
                    for (double y = tpExtent.YMin; y <= tpExtent.YMax; y += max_y)
                    {
                         x = tpExtent.XMin;
                         id = Gridhash.Encode(x, y, max_x, max_y);
                        do
                        {
                            gridhashs.Add(id);
                            x += max_x;
                            id += 1;
                           
                        } while (x <= tpExtent.XMax);
 
                        id = Gridhash.Encode(tpExtent.XMax, y, max_x, max_y);
                        gridhashs.Add(id);
                    }

                    x = tpExtent.XMin;
                    id = Gridhash.Encode(x, tpExtent.YMax, max_x, max_y);
                    do
                    {
                        gridhashs.Add(id);
                        x+= max_x;
                        id += 1;

                    } while (x <= tpExtent.XMax);
                    
                }

                tpShapes[i].GridHashs= new List<double>(gridhashs);


                foreach (double gridhash in gridhashs)
                {
                    if (dictionary.ContainsKey(gridhash))
                        dictionary[gridhash].Add(i);
                    else
                        dictionary.Add(gridhash, new List<int> { i });
                }

                //foreach (double gridhash in gridhashs)
                //    Console.WriteLine(i + "占网格数量：" + String.Join(",", tpShapes[i].GridHashs.ToArray()));

            }

          
           
            return dictionary;
        }


         public static int TwoLevel_GridStruct(List<TPShape> tpShapes, Dictionary<double, List<int>> gridStruct)
        {

           
            int count = 0;
            for (int i = 0; i < tpShapes.Count; i++)
            {
                //DateTime beforDT = System.DateTime.Now;
                //MBR求交.根据图形的最小外接图形的grid编码获取相关的图形，并与编码相同的图形逐一比较是否相交.若相交，则进一步判断是否有公共边  

                //图形的最小外接图形的grid编码             
                List<double> gridhashs = tpShapes[i].GridHashs;

               // Console.WriteLine("图形" + i + "覆盖的网格数量 " + gridhashs.Count);

                List<int> ids1 = new List<int>();
                foreach (double gridhash in gridhashs)
                {
                    //根据图形的最小外接图形的grid编码获取相关的图形
                    ids1.AddRange(gridStruct[gridhash]);
                    ids1.Remove(i);
                }
                //去重复
                HashSet<int> ids = new HashSet<int>(ids1);

                //DateTime afterDT = System.DateTime.Now;
                //TimeSpan ts2 = afterDT.Subtract(beforDT);
                //Console.WriteLine("图形" + i + "查找候选可能相交图形的时间= " + ts2.TotalMilliseconds +" ;" +ids.Count);
                //beforDT = System.DateTime.Now;

                //标记该图形与其他图形间的公共点
                foreach (int id in ids)
                {
                    if (CheckCross(tpShapes[i].Extent, tpShapes[id].Extent))
                    {
                        //判断外接矩形相交的两个图形是否有公共边                                  
                        tpShapes[i].RelatedTPShapes.Add(tpShapes[id]);
                       // tpShapes[id].RelatedTPShapes.Add(tpShapes[i]);
                       
                    }
                }

                foreach (TPShape r in tpShapes[i].RelatedTPShapes)
                {
                    if (i < r.Id)
                    {
                        //判断外接矩形相交的两个图形是否有公共边   
                        if (tpShapes[i].VertexNumbers > tpShapes[r.Id].VertexNumbers)
                            count += JudgeCommonPointByGridHash(i, r.Id, tpShapes);
                        else
                            count += JudgeCommonPointByGridHash(r.Id, i, tpShapes);

                    }
                }
 
            }
           
            return count;

        }

         private static int JudgeCommonPointByGridHash(int shapeID1, int shapeID2, List<TPShape> tpShapes)
        {
            TPShape r1 = tpShapes[shapeID1];
            TPShape r2 = tpShapes[shapeID2];
            int count = 0;
            Dictionary<double, List<TPVertex>> dictionary = r1.GridStruct;

            bool preIsCom = false;//标识前一个点是否为公共点
            TPVertex preCom2 = null;
            TPVertex preCom1 = null;
            bool flag = false;//标识当前点t是否为公共点

            for (int j = 0; j < r2.TPLines.Count; j++)
            {
                List<TPVertex> list = r2.TPLines[j];

                preIsCom = false;//标识前一个点是否为公共点
                preCom2 = null;
                preCom1 = null;
                flag = false;//标识当前点t是否为公共点
                foreach (TPVertex t2 in list)
                {

                    double gridhash = t2.Gridhash;

                    flag = false;//标识当前点t是否为公共点
                    if (dictionary.ContainsKey(gridhash))
                    {
                        List<TPVertex> l = dictionary[gridhash];
                        foreach (TPVertex t1 in l)
                            if (t2.Equals(t1))//当前是公共点 
                            {

                              

                                t2.Count++;
                                t1.Count++;
                                t2.TouchedVertexes.Add(t1);
                                t1.TouchedVertexes.Add(t2);
                                count++;
                                flag = true;


                                if (t2.Count > 1 || t1.Count > 1)
                                {
                                    //r1.TPLines[t1.LineIndex][t1.Id - 1].Status = TPVertexStatus.End;
                                    //r2.TPLines[t2.LineIndex][t2.Id-1].Status = TPVertexStatus.End;

                                    if (t2.Count > 1)
                                    {
                                        SignSpltPoint_BeforeAndNext(tpShapes[t2.ShapeIndex], t2);
                                        foreach (TPVertex touched in t2.TouchedVertexes)
                                        {
                                            SignSpltPoint_BeforeAndNext(tpShapes[touched.ShapeIndex], touched);
                                        }
                                    }
                                    if (t1.Count > 1)
                                    {
                                        SignSpltPoint_BeforeAndNext(tpShapes[t1.ShapeIndex], t1);
                                        foreach (TPVertex touched in t1.TouchedVertexes)
                                        {
                                            SignSpltPoint_BeforeAndNext(tpShapes[touched.ShapeIndex], touched);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!preIsCom)//是公共点且前一个点不是公共点，则为第一个公共点
                                    {

                                        //t2.Status = TPVertexStatus.Start; 
                                        //t1.Status = TPVertexStatus.Start;
                                        //t2.TouchedVertexes.Add(t1);
                                        //t1.TouchedVertexes.Add(t2);    

                                        // SignSpltPoint(r1, t1, r2, t2);
                                        SignSpltPoint_Single(r1, t1);
                                        SignSpltPoint_Single(r2, t2);

                                        preCom2 = t2;
                                        preCom1 = t1;
                                        preIsCom = true;
                                       
                                    }
                                    else//中间的公共点，需要进一步判断坐标是否连续(有正连续或是负连续),或者是否为多于两个图形的公共点
                                    {
                                        //if ((t2.Id - preCom2.Id) != 1 || Math.Abs(t1.Id - preCom1.Id) != 1 || t1.LineIndex != preCom1.LineIndex)
                                        if (Math.Abs(t1.Id - preCom1.Id) != 1 || t1.LineIndex != preCom1.LineIndex) //不连续为的一个公共点或者不在一个同一条曲线上，应拆分 
                                        {
                                            //preCom2.Status = TPVertexStatus.End;
                                            //preCom1.Status = TPVertexStatus.End;
                                            //preCom2.TouchedVertexes.Add(preCom1);
                                            //preCom1.TouchedVertexes.Add(preCom2);                                      

                                            // SignSpltPoint(r1, preCom1, r2, preCom2);
                                            SignSpltPoint_Single(r1, preCom1);
                                            SignSpltPoint_Single(r2, preCom2);


                                            //t2.Status = TPVertexStatus.Start;
                                            //t1.Status = TPVertexStatus.Start;
                                            //t2.TouchedVertexes.Add(t1);
                                            //t1.TouchedVertexes.Add(t2);

                                            // SignSpltPoint(r1, t1, r2, t2);
                                            SignSpltPoint_Single(r1, t1);
                                            SignSpltPoint_Single(r2, t2);
                                            
                                        }


                                    }

                                    if (t2.Id == list.Count - 1)//当前点为最后一个点
                                    {
                                        //t2.Status = TPVertexStatus.End;
                                        //t1.Status = TPVertexStatus.End;
                                        //t2.TouchedVertexes.Add(t1);
                                        //t1.TouchedVertexes.Add(t2);

                                        //SignSpltPoint(r1, t1, r2, t2);
                                        SignSpltPoint_Single(r1, t1);
                                        SignSpltPoint_Single(r2, t2);
                                       
                                    }
                                }
                                preCom2 = t2;
                                preCom1 = t1;
                                preIsCom = true;

                            }
                    }


                    if (flag == false)//flag==false当前点不是公共点
                    {
                        if (preIsCom)//flag==false当前点不是公共点，preIsCom==true 是公共点
                        {
                            //preCom2.Status = TPVertexStatus.End;
                            //preCom1.Status = TPVertexStatus.End;
                            //preCom2.TouchedVertexes.Add(preCom1);
                            //preCom1.TouchedVertexes.Add(preCom2);

                            //SignSpltPoint(r1, preCom1, r2, preCom2);
                            SignSpltPoint_Single(r1, preCom1);
                            SignSpltPoint_Single(r2, preCom2);



                        }
                        preIsCom = false;
                    }

                }

            }
            //Console.WriteLine("公共点= " + count);
            return count;
        }


         private static void SignSpltPoint_BeforeAndNext(TPShape shp, TPVertex r)
        {
            if (r != null)
            {
                TPVertex pre1 = null;
                if (r.Id - 1 >= 0)
                    pre1 = shp.TPLines[r.LineIndex][r.Id - 1];
                SignSpltPoint_Single(shp, pre1);

                SignSpltPoint_Single(shp, r);

                TPVertex next1 = null;
                if (r.Id + 1 < shp.TPLines[r.LineIndex].Count)
                    next1 = shp.TPLines[r.LineIndex][r.Id + 1];


                SignSpltPoint_Single(shp, next1);
            }

        }


        private static void SignSpltPoint_Single(TPShape r1, TPVertex r)
        {

            if (r != null)
            {
                if (r1.SplitPoint.ContainsKey(r.LineIndex))
                {
                    if (!r1.SplitPoint[r.LineIndex].ContainsKey(r.Id))
                        r1.SplitPoint[r.LineIndex].Add(r.Id, r);
                }
                else
                {
                    SortedList<int, TPVertex> s2 = new SortedList<int, TPVertex>();
                    s2.Add(r.Id, r);
                    r1.SplitPoint.Add(r.LineIndex, s2);
                }
            }
        }
}
=======
﻿using System;
using System.Collections.Generic;
using ShapeDataSource;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
namespace SimplifiedAlgorithm
{
    public class ImprovedAlgorithm
    {
        private double maxMeasure;

        public ImprovedAlgorithm()
        {
            maxMeasure = 360;
        }

        public double MaxMeasure
        {
            get
            {
                return maxMeasure;
            }
            set
            {
                maxMeasure = value;
            }
        }


      public static Dictionary<double, List<int>> TPShapeGridStruct(List<TPShape> tpShapes)
        {
            Dictionary<double, List<int>> dictionary = new Dictionary<double, List<int>>();

            double avg_x = 0;
            for (int i = 1; i < tpShapes.Count; i++) 
                avg_x+=tpShapes[i].Extent.XMax - tpShapes[i].Extent.XMin; 
            avg_x = avg_x / tpShapes.Count;
           // Console.WriteLine("平均最小外接矩形的大小:" + avg_x);

            double max_x = avg_x;
            double max_y = avg_x;
            for (int i = 0; i < tpShapes.Count; i++)
            {


                //记录每个图形最小外接矩形的Grid编码
                HashSet<double> gridhashs = new HashSet<double>();

                TPExtent tpExtent = tpShapes[i].Extent;
                gridhashs.Add(Gridhash.Encode(tpExtent.XMin,tpExtent.YMin,  max_x, max_y));
                gridhashs.Add(Gridhash.Encode(tpExtent.XMax,tpExtent.YMax,  max_x, max_y));

                if (gridhashs.Count > 1)
                {
                    double x;
                    double id;
                    for (double y = tpExtent.YMin; y <= tpExtent.YMax; y += max_y)
                    {
                         x = tpExtent.XMin;
                         id = Gridhash.Encode(x, y, max_x, max_y);
                        do
                        {
                            gridhashs.Add(id);
                            x += max_x;
                            id += 1;
                           
                        } while (x <= tpExtent.XMax);
 
                        id = Gridhash.Encode(tpExtent.XMax, y, max_x, max_y);
                        gridhashs.Add(id);
                    }

                    x = tpExtent.XMin;
                    id = Gridhash.Encode(x, tpExtent.YMax, max_x, max_y);
                    do
                    {
                        gridhashs.Add(id);
                        x+= max_x;
                        id += 1;

                    } while (x <= tpExtent.XMax);
                    
                }

                tpShapes[i].GridHashs= new List<double>(gridhashs);


                foreach (double gridhash in gridhashs)
                {
                    if (dictionary.ContainsKey(gridhash))
                        dictionary[gridhash].Add(i);
                    else
                        dictionary.Add(gridhash, new List<int> { i });
                }

                //foreach (double gridhash in gridhashs)
                //    Console.WriteLine(i + "占网格数量：" + String.Join(",", tpShapes[i].GridHashs.ToArray()));

            }

          
           
            return dictionary;
        }


         public static int TwoLevel_GridStruct(List<TPShape> tpShapes, Dictionary<double, List<int>> gridStruct)
        {

           
            int count = 0;
            for (int i = 0; i < tpShapes.Count; i++)
            {
                //DateTime beforDT = System.DateTime.Now;
                //MBR求交.根据图形的最小外接图形的grid编码获取相关的图形，并与编码相同的图形逐一比较是否相交.若相交，则进一步判断是否有公共边  

                //图形的最小外接图形的grid编码             
                List<double> gridhashs = tpShapes[i].GridHashs;

               // Console.WriteLine("图形" + i + "覆盖的网格数量 " + gridhashs.Count);

                List<int> ids1 = new List<int>();
                foreach (double gridhash in gridhashs)
                {
                    //根据图形的最小外接图形的grid编码获取相关的图形
                    ids1.AddRange(gridStruct[gridhash]);
                    ids1.Remove(i);
                }
                //去重复
                HashSet<int> ids = new HashSet<int>(ids1);

                //DateTime afterDT = System.DateTime.Now;
                //TimeSpan ts2 = afterDT.Subtract(beforDT);
                //Console.WriteLine("图形" + i + "查找候选可能相交图形的时间= " + ts2.TotalMilliseconds +" ;" +ids.Count);
                //beforDT = System.DateTime.Now;

                //标记该图形与其他图形间的公共点
                foreach (int id in ids)
                {
                    if (CheckCross(tpShapes[i].Extent, tpShapes[id].Extent))
                    {
                        //判断外接矩形相交的两个图形是否有公共边                                  
                        tpShapes[i].RelatedTPShapes.Add(tpShapes[id]);
                       // tpShapes[id].RelatedTPShapes.Add(tpShapes[i]);
                       
                    }
                }

                foreach (TPShape r in tpShapes[i].RelatedTPShapes)
                {
                    if (i < r.Id)
                    {
                        //判断外接矩形相交的两个图形是否有公共边   
                        if (tpShapes[i].VertexNumbers > tpShapes[r.Id].VertexNumbers)
                            count += JudgeCommonPointByGridHash(i, r.Id, tpShapes);
                        else
                            count += JudgeCommonPointByGridHash(r.Id, i, tpShapes);

                    }
                }
 
            }
           
            return count;

        }

         private static int JudgeCommonPointByGridHash(int shapeID1, int shapeID2, List<TPShape> tpShapes)
        {
            TPShape r1 = tpShapes[shapeID1];
            TPShape r2 = tpShapes[shapeID2];
            int count = 0;
            Dictionary<double, List<TPVertex>> dictionary = r1.GridStruct;

            bool preIsCom = false;//标识前一个点是否为公共点
            TPVertex preCom2 = null;
            TPVertex preCom1 = null;
            bool flag = false;//标识当前点t是否为公共点

            for (int j = 0; j < r2.TPLines.Count; j++)
            {
                List<TPVertex> list = r2.TPLines[j];

                preIsCom = false;//标识前一个点是否为公共点
                preCom2 = null;
                preCom1 = null;
                flag = false;//标识当前点t是否为公共点
                foreach (TPVertex t2 in list)
                {

                    double gridhash = t2.Gridhash;

                    flag = false;//标识当前点t是否为公共点
                    if (dictionary.ContainsKey(gridhash))
                    {
                        List<TPVertex> l = dictionary[gridhash];
                        foreach (TPVertex t1 in l)
                            if (t2.Equals(t1))//当前是公共点 
                            {

                              

                                t2.Count++;
                                t1.Count++;
                                t2.TouchedVertexes.Add(t1);
                                t1.TouchedVertexes.Add(t2);
                                count++;
                                flag = true;


                                if (t2.Count > 1 || t1.Count > 1)
                                {
                                    //r1.TPLines[t1.LineIndex][t1.Id - 1].Status = TPVertexStatus.End;
                                    //r2.TPLines[t2.LineIndex][t2.Id-1].Status = TPVertexStatus.End;

                                    if (t2.Count > 1)
                                    {
                                        SignSpltPoint_BeforeAndNext(tpShapes[t2.ShapeIndex], t2);
                                        foreach (TPVertex touched in t2.TouchedVertexes)
                                        {
                                            SignSpltPoint_BeforeAndNext(tpShapes[touched.ShapeIndex], touched);
                                        }
                                    }
                                    if (t1.Count > 1)
                                    {
                                        SignSpltPoint_BeforeAndNext(tpShapes[t1.ShapeIndex], t1);
                                        foreach (TPVertex touched in t1.TouchedVertexes)
                                        {
                                            SignSpltPoint_BeforeAndNext(tpShapes[touched.ShapeIndex], touched);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!preIsCom)//是公共点且前一个点不是公共点，则为第一个公共点
                                    {

                                        //t2.Status = TPVertexStatus.Start; 
                                        //t1.Status = TPVertexStatus.Start;
                                        //t2.TouchedVertexes.Add(t1);
                                        //t1.TouchedVertexes.Add(t2);    

                                        // SignSpltPoint(r1, t1, r2, t2);
                                        SignSpltPoint_Single(r1, t1);
                                        SignSpltPoint_Single(r2, t2);

                                        preCom2 = t2;
                                        preCom1 = t1;
                                        preIsCom = true;
                                       
                                    }
                                    else//中间的公共点，需要进一步判断坐标是否连续(有正连续或是负连续),或者是否为多于两个图形的公共点
                                    {
                                        //if ((t2.Id - preCom2.Id) != 1 || Math.Abs(t1.Id - preCom1.Id) != 1 || t1.LineIndex != preCom1.LineIndex)
                                        if (Math.Abs(t1.Id - preCom1.Id) != 1 || t1.LineIndex != preCom1.LineIndex) //不连续为的一个公共点或者不在一个同一条曲线上，应拆分 
                                        {
                                            //preCom2.Status = TPVertexStatus.End;
                                            //preCom1.Status = TPVertexStatus.End;
                                            //preCom2.TouchedVertexes.Add(preCom1);
                                            //preCom1.TouchedVertexes.Add(preCom2);                                      

                                            // SignSpltPoint(r1, preCom1, r2, preCom2);
                                            SignSpltPoint_Single(r1, preCom1);
                                            SignSpltPoint_Single(r2, preCom2);


                                            //t2.Status = TPVertexStatus.Start;
                                            //t1.Status = TPVertexStatus.Start;
                                            //t2.TouchedVertexes.Add(t1);
                                            //t1.TouchedVertexes.Add(t2);

                                            // SignSpltPoint(r1, t1, r2, t2);
                                            SignSpltPoint_Single(r1, t1);
                                            SignSpltPoint_Single(r2, t2);
                                            
                                        }


                                    }

                                    if (t2.Id == list.Count - 1)//当前点为最后一个点
                                    {
                                        //t2.Status = TPVertexStatus.End;
                                        //t1.Status = TPVertexStatus.End;
                                        //t2.TouchedVertexes.Add(t1);
                                        //t1.TouchedVertexes.Add(t2);

                                        //SignSpltPoint(r1, t1, r2, t2);
                                        SignSpltPoint_Single(r1, t1);
                                        SignSpltPoint_Single(r2, t2);
                                       
                                    }
                                }
                                preCom2 = t2;
                                preCom1 = t1;
                                preIsCom = true;

                            }
                    }


                    if (flag == false)//flag==false当前点不是公共点
                    {
                        if (preIsCom)//flag==false当前点不是公共点，preIsCom==true 是公共点
                        {
                            //preCom2.Status = TPVertexStatus.End;
                            //preCom1.Status = TPVertexStatus.End;
                            //preCom2.TouchedVertexes.Add(preCom1);
                            //preCom1.TouchedVertexes.Add(preCom2);

                            //SignSpltPoint(r1, preCom1, r2, preCom2);
                            SignSpltPoint_Single(r1, preCom1);
                            SignSpltPoint_Single(r2, preCom2);



                        }
                        preIsCom = false;
                    }

                }

            }
            //Console.WriteLine("公共点= " + count);
            return count;
        }


         private static void SignSpltPoint_BeforeAndNext(TPShape shp, TPVertex r)
        {
            if (r != null)
            {
                TPVertex pre1 = null;
                if (r.Id - 1 >= 0)
                    pre1 = shp.TPLines[r.LineIndex][r.Id - 1];
                SignSpltPoint_Single(shp, pre1);

                SignSpltPoint_Single(shp, r);

                TPVertex next1 = null;
                if (r.Id + 1 < shp.TPLines[r.LineIndex].Count)
                    next1 = shp.TPLines[r.LineIndex][r.Id + 1];


                SignSpltPoint_Single(shp, next1);
            }

        }


        private static void SignSpltPoint_Single(TPShape r1, TPVertex r)
        {

            if (r != null)
            {
                if (r1.SplitPoint.ContainsKey(r.LineIndex))
                {
                    if (!r1.SplitPoint[r.LineIndex].ContainsKey(r.Id))
                        r1.SplitPoint[r.LineIndex].Add(r.Id, r);
                }
                else
                {
                    SortedList<int, TPVertex> s2 = new SortedList<int, TPVertex>();
                    s2.Add(r.Id, r);
                    r1.SplitPoint.Add(r.LineIndex, s2);
                }
            }
        }
}
>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
