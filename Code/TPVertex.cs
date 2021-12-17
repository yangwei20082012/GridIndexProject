<<<<<<< HEAD
﻿using System.Collections.Generic;
using ShapeDataSource;
using System;

namespace SimplifiedAlgorithm
{
    public class TPVertex
    {
        private Dictionary<TPVertex, double> relatedVertexes;
        private List<TPVertex> touchedVertexes;
        private double x;
        private double y;
        private double precision;
        private int count = 0;
        private int shapeIndex;//点所属图形

       
        private int lineIndex;//点所属图形中的第几个线段部分
        private int id;//点所属线段中的下标
        private string geohash;
        private double gridhash;
        public string Geohash
        {
            get { return geohash; }
            set { geohash = value; }
        }
        public double Gridhash
        {
            get { return gridhash; }
            set { gridhash = value; }
        }

        public int LineIndex
        {
            get { return lineIndex; }
            set { lineIndex = value; }
        }
       
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
     
       
        private TPVertexStatus status;

        public TPVertex()
            : this(0, 0, 0.000001)
        {
            ;
        }

        public TPVertex(double x, double y, double precision)
        {
            this.x = x;
            this.y = y;
            this.precision = precision;
            this.relatedVertexes = new Dictionary<TPVertex, double>();
            this.touchedVertexes = new List<TPVertex>();
            this.status = TPVertexStatus.Middle;
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Precision
        {
            get
            {
                return precision;
            }
            set
            {
                precision = value;
            }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private ShapeDataSource.MapProjection.PointD pointD;

        public ShapeDataSource.MapProjection.PointD PointD
        {
            get { return pointD; }
            set { pointD = value; }
        }
        public Dictionary<TPVertex, double> RelatedVertexes
        {
            get
            {
                return relatedVertexes;
            }
        }

        public List<TPVertex> TouchedVertexes
        {
            get
            {
                return touchedVertexes;
            }
        }

        public TPVertexStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

      
        public List<TPVertex> GetRelatedWithinDistance(double distance)
        {
            List<TPVertex> resultVertexes = new List<TPVertex>();
            foreach (TPVertex vertex in relatedVertexes.Keys)
            {
                if (relatedVertexes[vertex] <= distance)
                {
                    resultVertexes.Add(vertex);
                }
            }
            return resultVertexes;
        }

        public bool Equals(TPVertex desc)
        {

            if (this.X == desc.X && this.Y == desc.Y)
                return true;
            else
                return false;

        }

        public override bool Equals(Object desc1)
        {   
            if(!(desc1 is TPVertex))
                return false;

            TPVertex desc = (TPVertex)desc1;
            if (this.X == desc.X && this.Y == desc.Y)
                return true;
            else
                return false;

        }

        public int ShapeIndex
        {
            get { return shapeIndex; }
            set { shapeIndex = value; }
        }
      
    }
}
=======
﻿using System.Collections.Generic;
using ShapeDataSource;
using System;

namespace SimplifiedAlgorithm
{
    public class TPVertex
    {
        private Dictionary<TPVertex, double> relatedVertexes;
        private List<TPVertex> touchedVertexes;
        private double x;
        private double y;
        private double precision;
        private int count = 0;
        private int shapeIndex;//点所属图形

       
        private int lineIndex;//点所属图形中的第几个线段部分
        private int id;//点所属线段中的下标
        private string geohash;
        private double gridhash;
        public string Geohash
        {
            get { return geohash; }
            set { geohash = value; }
        }
        public double Gridhash
        {
            get { return gridhash; }
            set { gridhash = value; }
        }

        public int LineIndex
        {
            get { return lineIndex; }
            set { lineIndex = value; }
        }
       
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
     
       
        private TPVertexStatus status;

        public TPVertex()
            : this(0, 0, 0.000001)
        {
            ;
        }

        public TPVertex(double x, double y, double precision)
        {
            this.x = x;
            this.y = y;
            this.precision = precision;
            this.relatedVertexes = new Dictionary<TPVertex, double>();
            this.touchedVertexes = new List<TPVertex>();
            this.status = TPVertexStatus.Middle;
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Precision
        {
            get
            {
                return precision;
            }
            set
            {
                precision = value;
            }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private ShapeDataSource.MapProjection.PointD pointD;

        public ShapeDataSource.MapProjection.PointD PointD
        {
            get { return pointD; }
            set { pointD = value; }
        }
        public Dictionary<TPVertex, double> RelatedVertexes
        {
            get
            {
                return relatedVertexes;
            }
        }

        public List<TPVertex> TouchedVertexes
        {
            get
            {
                return touchedVertexes;
            }
        }

        public TPVertexStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

      
        public List<TPVertex> GetRelatedWithinDistance(double distance)
        {
            List<TPVertex> resultVertexes = new List<TPVertex>();
            foreach (TPVertex vertex in relatedVertexes.Keys)
            {
                if (relatedVertexes[vertex] <= distance)
                {
                    resultVertexes.Add(vertex);
                }
            }
            return resultVertexes;
        }

        public bool Equals(TPVertex desc)
        {

            if (this.X == desc.X && this.Y == desc.Y)
                return true;
            else
                return false;

        }

        public override bool Equals(Object desc1)
        {   
            if(!(desc1 is TPVertex))
                return false;

            TPVertex desc = (TPVertex)desc1;
            if (this.X == desc.X && this.Y == desc.Y)
                return true;
            else
                return false;

        }

        public int ShapeIndex
        {
            get { return shapeIndex; }
            set { shapeIndex = value; }
        }
      
    }
}
>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
