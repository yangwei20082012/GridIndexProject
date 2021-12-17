<<<<<<< HEAD
﻿using System.Collections.Generic;

namespace SimplifiedAlgorithm
{
    public class TPShape
    {
        private int id;
        private List<List<TPVertex>> tpLines;
        private TPExtent extent;
        private int vertexNumbers;//定点个数 
       
        private Dictionary<int, SortedList<int, TPVertex>> splitPoint;//拆分点 
        private Dictionary<string,  List<int> > reduceResult;//公共边的化简结果 
        //string  第几条线，表示拆分点ID    list表示在化简结果在原始曲线中的位置
        public Dictionary<string, List<TPVertex>> hashStruct;
        private List<TPShape> relatedTPShapes;//外界矩形相交的TPShape

        public Dictionary<double, List<TPVertex>> gridStruct;

        private List<double> gridHashs;

        public TPShape()
        {
            tpLines = new List<List<TPVertex>>();
            extent = new TPExtent();
            vertexNumbers = 0;
            relatedTPShapes = new List<TPShape>();
            reduceResult = new Dictionary<string, List<int>>();
            splitPoint = new Dictionary<int, SortedList<int, TPVertex>>();
            gridHashs = new List<double>();
        }

        public List<List<TPVertex>> TPLines
        {
            get
            {
                return tpLines;
            }
            set
            {
                tpLines = value;
            }
        }

       

        public TPExtent Extent
        {
            get
            {
                return extent;
            }
            set
            {
                extent = value;
            }
        }

        public Dictionary<int, SortedList<int, TPVertex>> SplitPoint
        {
            get { return splitPoint; }
            set { splitPoint = value; }
        }

        public Dictionary<string, List<TPVertex>> HashStruct
        {
            get { return hashStruct; }
            set { hashStruct = value; }
        }

        public Dictionary<double, List<TPVertex>> GridStruct
        {
            get { return gridStruct; }
            set { gridStruct = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public List<TPShape> RelatedTPShapes
        {
            get { return relatedTPShapes; }
            set { relatedTPShapes = value; }
        }
        public int VertexNumbers
        {
            get { return vertexNumbers; }
            set { vertexNumbers = value; }
        }

        public Dictionary<string, List<int>> ReduceResult
        {
            get { return reduceResult; }
            set { reduceResult = value; }
        }

        public List<double> GridHashs
        {
            get { return gridHashs; }
            set { gridHashs = value;}
        }

        public static Dictionary<string, List<TPVertex>> ToHashStruct(TPShape tpShape)
        {

            Dictionary<string, List<TPVertex>> dictionary = new Dictionary<string, List<TPVertex>>();

            for (int j = 0; j < tpShape.TPLines.Count; j++)
            {
                List<TPVertex> list = tpShape.TPLines[j];
                tpShape.vertexNumbers += list.Count;
                for (int i = 0; i < list.Count;i++)
                {
                    TPVertex t = list[i];
                    t.Id = i;
                    t.LineIndex = j;
                    t.ShapeIndex = tpShape.id;
                    t.Geohash = Geohash.Encode(t);
                    string geohash = t.Geohash;
                    if (dictionary.ContainsKey(geohash))
                        dictionary[geohash].Add(t);
                    else
                        dictionary.Add(geohash, new List<TPVertex> { t });

                }

            }
            return dictionary;


        }

        public static Dictionary<double, List<TPVertex>> ToGridStruct(TPShape tpShape)
        {

            Dictionary<double, List<TPVertex>> dictionary = new Dictionary<double, List<TPVertex>>();

            for (int j = 0; j < tpShape.TPLines.Count; j++)
            {
                List<TPVertex> list = tpShape.TPLines[j];
                tpShape.vertexNumbers += list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    TPVertex t = list[i];
                    t.Id = i;
                    t.LineIndex = j;
                    t.ShapeIndex = tpShape.id;
                    t.Gridhash = Gridhash.Encode(t);
                    double gridhash = t.Gridhash;
                    if (dictionary.ContainsKey(gridhash))
                        dictionary[gridhash].Add(t);
                    else
                        dictionary.Add(gridhash, new List<TPVertex> { t });



                }

            }
            return dictionary;


        }



    }
}
=======
﻿using System.Collections.Generic;

namespace SimplifiedAlgorithm
{
    public class TPShape
    {
        private int id;
        private List<List<TPVertex>> tpLines;
        private TPExtent extent;
        private int vertexNumbers;//定点个数 
       
        private Dictionary<int, SortedList<int, TPVertex>> splitPoint;//拆分点 
        private Dictionary<string,  List<int> > reduceResult;//公共边的化简结果 
        //string  第几条线，表示拆分点ID    list表示在化简结果在原始曲线中的位置
        public Dictionary<string, List<TPVertex>> hashStruct;
        private List<TPShape> relatedTPShapes;//外界矩形相交的TPShape

        public Dictionary<double, List<TPVertex>> gridStruct;

        private List<double> gridHashs;

        public TPShape()
        {
            tpLines = new List<List<TPVertex>>();
            extent = new TPExtent();
            vertexNumbers = 0;
            relatedTPShapes = new List<TPShape>();
            reduceResult = new Dictionary<string, List<int>>();
            splitPoint = new Dictionary<int, SortedList<int, TPVertex>>();
            gridHashs = new List<double>();
        }

        public List<List<TPVertex>> TPLines
        {
            get
            {
                return tpLines;
            }
            set
            {
                tpLines = value;
            }
        }

       

        public TPExtent Extent
        {
            get
            {
                return extent;
            }
            set
            {
                extent = value;
            }
        }

        public Dictionary<int, SortedList<int, TPVertex>> SplitPoint
        {
            get { return splitPoint; }
            set { splitPoint = value; }
        }

        public Dictionary<string, List<TPVertex>> HashStruct
        {
            get { return hashStruct; }
            set { hashStruct = value; }
        }

        public Dictionary<double, List<TPVertex>> GridStruct
        {
            get { return gridStruct; }
            set { gridStruct = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public List<TPShape> RelatedTPShapes
        {
            get { return relatedTPShapes; }
            set { relatedTPShapes = value; }
        }
        public int VertexNumbers
        {
            get { return vertexNumbers; }
            set { vertexNumbers = value; }
        }

        public Dictionary<string, List<int>> ReduceResult
        {
            get { return reduceResult; }
            set { reduceResult = value; }
        }

        public List<double> GridHashs
        {
            get { return gridHashs; }
            set { gridHashs = value;}
        }

        public static Dictionary<string, List<TPVertex>> ToHashStruct(TPShape tpShape)
        {

            Dictionary<string, List<TPVertex>> dictionary = new Dictionary<string, List<TPVertex>>();

            for (int j = 0; j < tpShape.TPLines.Count; j++)
            {
                List<TPVertex> list = tpShape.TPLines[j];
                tpShape.vertexNumbers += list.Count;
                for (int i = 0; i < list.Count;i++)
                {
                    TPVertex t = list[i];
                    t.Id = i;
                    t.LineIndex = j;
                    t.ShapeIndex = tpShape.id;
                    t.Geohash = Geohash.Encode(t);
                    string geohash = t.Geohash;
                    if (dictionary.ContainsKey(geohash))
                        dictionary[geohash].Add(t);
                    else
                        dictionary.Add(geohash, new List<TPVertex> { t });

                }

            }
            return dictionary;


        }

        public static Dictionary<double, List<TPVertex>> ToGridStruct(TPShape tpShape)
        {

            Dictionary<double, List<TPVertex>> dictionary = new Dictionary<double, List<TPVertex>>();

            for (int j = 0; j < tpShape.TPLines.Count; j++)
            {
                List<TPVertex> list = tpShape.TPLines[j];
                tpShape.vertexNumbers += list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    TPVertex t = list[i];
                    t.Id = i;
                    t.LineIndex = j;
                    t.ShapeIndex = tpShape.id;
                    t.Gridhash = Gridhash.Encode(t);
                    double gridhash = t.Gridhash;
                    if (dictionary.ContainsKey(gridhash))
                        dictionary[gridhash].Add(t);
                    else
                        dictionary.Add(gridhash, new List<TPVertex> { t });



                }

            }
            return dictionary;


        }



    }
}
>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
