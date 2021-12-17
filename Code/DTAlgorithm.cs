<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace SimplifiedAlgorithm
{
    public class DTAlgorithm
    {
        public DTAlgorithm()
        {
            ;
        }


        //经纬度坐标版本
        public List<TPVertex> Execute(List<TPVertex> srcLine, double limit)
        {
            if (srcLine.Count <= 1)
            {
                // 是点图形
                return srcLine;
            }

            // 对多边形图形不取起止点
            List<TPVertex> splitLine = new List<TPVertex>();
            bool isLine = GetDistance(srcLine[0], srcLine[srcLine.Count - 1]) > srcLine[0].Precision ? true : false;
            int s = isLine ? 0 : 1;
            int e = isLine ? srcLine.Count - 1 : srcLine.Count - 2;
            for (int i = s; i <= e; i++)
            {
                splitLine.Add(srcLine[i]);
            }

            // 进行迭代
            List<TPVertex> resultLine = DTIteration(splitLine, limit);
            if (!isLine)
            {
                // 加入多边形图形起止点
                resultLine.Insert(0, srcLine[0]);
                resultLine.Add(srcLine[srcLine.Count - 1]);
            }

            return resultLine;
        }

        private List<TPVertex> DTIteration(List<TPVertex> srcLine, double limit)
        {
            // 确定顶点数量
            if (srcLine.Count <= 2)
            {
                // 迭代终止
                List<TPVertex> resultLine = new List<TPVertex>();
                foreach (TPVertex vertex in srcLine)
                {
                    resultLine.Add(vertex);
                }
                return resultLine;
            }

            // 获得起止顶点
            TPVertex startVertex = srcLine[0];
            TPVertex endVertex = srcLine[srcLine.Count - 1];

            // 计算起止点所在直线段的斜率
            double slop = double.NaN;
            if (!(startVertex.X - endVertex.X).Equals(0))
            {
                slop = (startVertex.Y - endVertex.Y) / (startVertex.X - endVertex.X);
            }

            // 记录最大距离值最大距离值
            double maxLimit = limit;

            // 记录最大距离所属顶点的索引编号
            int maxIdx = -1;

            // 一次遍历除起止点外的所有顶点，计算这些顶点到起止点所在直线段的距离，
            // 并记录最大距离所属顶点的索引编号
            for (int i = 1; i < srcLine.Count - 1; i++)
            {
                TPVertex focus = srcLine[i];

                // 运用点到直线的计算公式进行距离计算
                double distance;
                if (slop.Equals(double.NaN))
                {
                    distance = Math.Abs(focus.X - startVertex.X);
                }
                else
                {
                    distance = Math.Abs(slop * (focus.X - startVertex.X) + startVertex.Y - focus.Y)
                        / Math.Sqrt(Math.Pow(slop, 2) + 1);
                }

                // 更新最大距离的记录
                if (distance > maxLimit)
                {
                    maxLimit = distance;
                    maxIdx = i;
                }
            }

            // 根据记录情况进行下一步处理
            if (maxIdx != -1)
            {
                // 存在最大顶点索引的记录，则以此顶点为分割点进行分割，
                // 对分割完成的左右两新的顶点集合进行迭代
                List<TPVertex> subLine1 = new List<TPVertex>(srcLine.GetRange(0, maxIdx + 1));
                List<TPVertex> subLine2 = new List<TPVertex>(srcLine.GetRange(maxIdx, srcLine.Count - maxIdx));

                List<TPVertex> subResult1 = DTIteration(subLine1, limit);
                List<TPVertex> subResult2 = DTIteration(subLine2, limit);

                // 将迭代完成的左右两顶点集合重新合并为新的顶点集合
                subResult1.RemoveAt(subResult1.Count - 1);
                subResult1.AddRange(subResult2);

                // 迭代完成
                return subResult1;
            }
            else
            {
                // 不存在最大顶点的索引记录，则剔除起止顶点间的所有顶点，
                // 迭代完成
                List<TPVertex> resultVertex = new List<TPVertex>();
                resultVertex.Add(startVertex);
                resultVertex.Add(endVertex);
                return resultVertex;
            }
        }


        //平面坐标转换版本
        public List<TPVertex> Execute_10(List<TPVertex> srcLine, double limit)
        {
            if (srcLine.Count <= 1)
            {
                // 是点图形
                return srcLine;
            }

            // 对多边形图形不取起止点
            List<TPVertex> splitLine = new List<TPVertex>();
            bool isLine = GetDistance(srcLine[0], srcLine[srcLine.Count - 1]) > srcLine[0].Precision ? true : false;
            int s = isLine ? 0 : 1;
            int e = isLine ? srcLine.Count - 1 : srcLine.Count - 2;
            for (int i = s; i <= e; i++)
            {
                splitLine.Add(srcLine[i]);
            }

            // 进行迭代
            List<TPVertex> resultLine = DTIteration_10(splitLine, limit);
            if (!isLine)
            {
                // 加入多边形图形起止点
                resultLine.Insert(0, srcLine[0]);
                resultLine.Add(srcLine[srcLine.Count - 1]);
            }

            return resultLine;
        }
        //平面坐标转换版本
        private List<TPVertex> DTIteration_10(List<TPVertex> srcLine, double limit)
        {
            // 确定顶点数量
            if (srcLine.Count <= 2)
            {
                // 迭代终止
                List<TPVertex> resultLine = new List<TPVertex>();
                foreach (TPVertex vertex in srcLine)
                {
                    resultLine.Add(vertex);
                }
                return resultLine;
            }

            // 获得起止顶点
            TPVertex startVertex = srcLine[0];
            TPVertex endVertex = srcLine[srcLine.Count - 1];

            // 计算起止点所在直线段的斜率
            double slop = double.NaN;
            if (!(startVertex.X - endVertex.X).Equals(0))
            {
                slop = (startVertex.PointD.Y - endVertex.PointD.Y) / (startVertex.PointD.X - endVertex.PointD.X);
            }

            // 记录最大距离值最大距离值
            double maxLimit = limit;

            // 记录最大距离所属顶点的索引编号
            int maxIdx = -1;

            // 一次遍历除起止点外的所有顶点，计算这些顶点到起止点所在直线段的距离，
            // 并记录最大距离所属顶点的索引编号
            for (int i = 1; i < srcLine.Count - 1; i++)
            {
                TPVertex focus = srcLine[i];

                // 运用点到直线的计算公式进行距离计算
                double distance;
                if (slop.Equals(double.NaN))
                {
                    distance = Math.Abs(focus.PointD.X - startVertex.PointD.X);
                }
                else
                {
                    distance = Math.Abs(slop * (focus.PointD.X - startVertex.PointD.X) + startVertex.PointD.Y - focus.PointD.Y)
                        / Math.Sqrt(Math.Pow(slop, 2) + 1);
                }

                // 更新最大距离的记录
                if (distance > maxLimit)
                {
                    maxLimit = distance;
                    maxIdx = i;
                }
            }

            // 根据记录情况进行下一步处理
            if (maxIdx != -1)
            {
                // 存在最大顶点索引的记录，则以此顶点为分割点进行分割，
                // 对分割完成的左右两新的顶点集合进行迭代
                List<TPVertex> subLine1 = new List<TPVertex>(srcLine.GetRange(0, maxIdx + 1));
                List<TPVertex> subLine2 = new List<TPVertex>(srcLine.GetRange(maxIdx, srcLine.Count - maxIdx));

                List<TPVertex> subResult1 = DTIteration_10(subLine1, limit);
                List<TPVertex> subResult2 = DTIteration_10(subLine2, limit);

                // 将迭代完成的左右两顶点集合重新合并为新的顶点集合
                subResult1.RemoveAt(subResult1.Count - 1);
                subResult1.AddRange(subResult2);

                // 迭代完成
                return subResult1;
            }
            else
            {
                // 不存在最大顶点的索引记录，则剔除起止顶点间的所有顶点，
                // 迭代完成
                List<TPVertex> resultVertex = new List<TPVertex>();
                resultVertex.Add(startVertex);
                resultVertex.Add(endVertex);
                return resultVertex;
            }
        }

        private double GetDistance(TPVertex v1, TPVertex v2)
        {
            // 获得两顶点的距离
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;

namespace SimplifiedAlgorithm
{
    public class DTAlgorithm
    {
        public DTAlgorithm()
        {
            ;
        }


        //经纬度坐标版本
        public List<TPVertex> Execute(List<TPVertex> srcLine, double limit)
        {
            if (srcLine.Count <= 1)
            {
                // 是点图形
                return srcLine;
            }

            // 对多边形图形不取起止点
            List<TPVertex> splitLine = new List<TPVertex>();
            bool isLine = GetDistance(srcLine[0], srcLine[srcLine.Count - 1]) > srcLine[0].Precision ? true : false;
            int s = isLine ? 0 : 1;
            int e = isLine ? srcLine.Count - 1 : srcLine.Count - 2;
            for (int i = s; i <= e; i++)
            {
                splitLine.Add(srcLine[i]);
            }

            // 进行迭代
            List<TPVertex> resultLine = DTIteration(splitLine, limit);
            if (!isLine)
            {
                // 加入多边形图形起止点
                resultLine.Insert(0, srcLine[0]);
                resultLine.Add(srcLine[srcLine.Count - 1]);
            }

            return resultLine;
        }

        private List<TPVertex> DTIteration(List<TPVertex> srcLine, double limit)
        {
            // 确定顶点数量
            if (srcLine.Count <= 2)
            {
                // 迭代终止
                List<TPVertex> resultLine = new List<TPVertex>();
                foreach (TPVertex vertex in srcLine)
                {
                    resultLine.Add(vertex);
                }
                return resultLine;
            }

            // 获得起止顶点
            TPVertex startVertex = srcLine[0];
            TPVertex endVertex = srcLine[srcLine.Count - 1];

            // 计算起止点所在直线段的斜率
            double slop = double.NaN;
            if (!(startVertex.X - endVertex.X).Equals(0))
            {
                slop = (startVertex.Y - endVertex.Y) / (startVertex.X - endVertex.X);
            }

            // 记录最大距离值最大距离值
            double maxLimit = limit;

            // 记录最大距离所属顶点的索引编号
            int maxIdx = -1;

            // 一次遍历除起止点外的所有顶点，计算这些顶点到起止点所在直线段的距离，
            // 并记录最大距离所属顶点的索引编号
            for (int i = 1; i < srcLine.Count - 1; i++)
            {
                TPVertex focus = srcLine[i];

                // 运用点到直线的计算公式进行距离计算
                double distance;
                if (slop.Equals(double.NaN))
                {
                    distance = Math.Abs(focus.X - startVertex.X);
                }
                else
                {
                    distance = Math.Abs(slop * (focus.X - startVertex.X) + startVertex.Y - focus.Y)
                        / Math.Sqrt(Math.Pow(slop, 2) + 1);
                }

                // 更新最大距离的记录
                if (distance > maxLimit)
                {
                    maxLimit = distance;
                    maxIdx = i;
                }
            }

            // 根据记录情况进行下一步处理
            if (maxIdx != -1)
            {
                // 存在最大顶点索引的记录，则以此顶点为分割点进行分割，
                // 对分割完成的左右两新的顶点集合进行迭代
                List<TPVertex> subLine1 = new List<TPVertex>(srcLine.GetRange(0, maxIdx + 1));
                List<TPVertex> subLine2 = new List<TPVertex>(srcLine.GetRange(maxIdx, srcLine.Count - maxIdx));

                List<TPVertex> subResult1 = DTIteration(subLine1, limit);
                List<TPVertex> subResult2 = DTIteration(subLine2, limit);

                // 将迭代完成的左右两顶点集合重新合并为新的顶点集合
                subResult1.RemoveAt(subResult1.Count - 1);
                subResult1.AddRange(subResult2);

                // 迭代完成
                return subResult1;
            }
            else
            {
                // 不存在最大顶点的索引记录，则剔除起止顶点间的所有顶点，
                // 迭代完成
                List<TPVertex> resultVertex = new List<TPVertex>();
                resultVertex.Add(startVertex);
                resultVertex.Add(endVertex);
                return resultVertex;
            }
        }


        //平面坐标转换版本
        public List<TPVertex> Execute_10(List<TPVertex> srcLine, double limit)
        {
            if (srcLine.Count <= 1)
            {
                // 是点图形
                return srcLine;
            }

            // 对多边形图形不取起止点
            List<TPVertex> splitLine = new List<TPVertex>();
            bool isLine = GetDistance(srcLine[0], srcLine[srcLine.Count - 1]) > srcLine[0].Precision ? true : false;
            int s = isLine ? 0 : 1;
            int e = isLine ? srcLine.Count - 1 : srcLine.Count - 2;
            for (int i = s; i <= e; i++)
            {
                splitLine.Add(srcLine[i]);
            }

            // 进行迭代
            List<TPVertex> resultLine = DTIteration_10(splitLine, limit);
            if (!isLine)
            {
                // 加入多边形图形起止点
                resultLine.Insert(0, srcLine[0]);
                resultLine.Add(srcLine[srcLine.Count - 1]);
            }

            return resultLine;
        }
        //平面坐标转换版本
        private List<TPVertex> DTIteration_10(List<TPVertex> srcLine, double limit)
        {
            // 确定顶点数量
            if (srcLine.Count <= 2)
            {
                // 迭代终止
                List<TPVertex> resultLine = new List<TPVertex>();
                foreach (TPVertex vertex in srcLine)
                {
                    resultLine.Add(vertex);
                }
                return resultLine;
            }

            // 获得起止顶点
            TPVertex startVertex = srcLine[0];
            TPVertex endVertex = srcLine[srcLine.Count - 1];

            // 计算起止点所在直线段的斜率
            double slop = double.NaN;
            if (!(startVertex.X - endVertex.X).Equals(0))
            {
                slop = (startVertex.PointD.Y - endVertex.PointD.Y) / (startVertex.PointD.X - endVertex.PointD.X);
            }

            // 记录最大距离值最大距离值
            double maxLimit = limit;

            // 记录最大距离所属顶点的索引编号
            int maxIdx = -1;

            // 一次遍历除起止点外的所有顶点，计算这些顶点到起止点所在直线段的距离，
            // 并记录最大距离所属顶点的索引编号
            for (int i = 1; i < srcLine.Count - 1; i++)
            {
                TPVertex focus = srcLine[i];

                // 运用点到直线的计算公式进行距离计算
                double distance;
                if (slop.Equals(double.NaN))
                {
                    distance = Math.Abs(focus.PointD.X - startVertex.PointD.X);
                }
                else
                {
                    distance = Math.Abs(slop * (focus.PointD.X - startVertex.PointD.X) + startVertex.PointD.Y - focus.PointD.Y)
                        / Math.Sqrt(Math.Pow(slop, 2) + 1);
                }

                // 更新最大距离的记录
                if (distance > maxLimit)
                {
                    maxLimit = distance;
                    maxIdx = i;
                }
            }

            // 根据记录情况进行下一步处理
            if (maxIdx != -1)
            {
                // 存在最大顶点索引的记录，则以此顶点为分割点进行分割，
                // 对分割完成的左右两新的顶点集合进行迭代
                List<TPVertex> subLine1 = new List<TPVertex>(srcLine.GetRange(0, maxIdx + 1));
                List<TPVertex> subLine2 = new List<TPVertex>(srcLine.GetRange(maxIdx, srcLine.Count - maxIdx));

                List<TPVertex> subResult1 = DTIteration_10(subLine1, limit);
                List<TPVertex> subResult2 = DTIteration_10(subLine2, limit);

                // 将迭代完成的左右两顶点集合重新合并为新的顶点集合
                subResult1.RemoveAt(subResult1.Count - 1);
                subResult1.AddRange(subResult2);

                // 迭代完成
                return subResult1;
            }
            else
            {
                // 不存在最大顶点的索引记录，则剔除起止顶点间的所有顶点，
                // 迭代完成
                List<TPVertex> resultVertex = new List<TPVertex>();
                resultVertex.Add(startVertex);
                resultVertex.Add(endVertex);
                return resultVertex;
            }
        }

        private double GetDistance(TPVertex v1, TPVertex v2)
        {
            // 获得两顶点的距离
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }
    }
}
>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
