<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifiedAlgorithm
{
    public static class Gridhash
    {
        private static double gridWidth = 0.1757563;

        private static double widthNums = Math.Ceiling(360 / Gridhash.GridWidth);
        //private static double num1 = 100;//分母   
        //private static double num2 = 5;//分子   
        //private static double widthNums = Math.Ceiling(360*num1 / num2);
        public static double GridWidth
        {
            get { return gridWidth;  }

            set { gridWidth = value; }
        }

        public static double WidthNums
        {
            get { return widthNums;}

            set { widthNums = value;}
        }

        //public static string Encode(TPVertex t)
        //{
        //    string gridhash = "";
        //    //double longitude = t.X;
        //    //double latitude = t.Y;

        //    gridhash = Math.Ceiling((t.X + 180) / GridWidth)+"-"+ Math.Ceiling((t.Y+ 90) / GridWidth);

        //    return gridhash;
        //}
        public static double Encode(TPVertex t)
        {   
            //double gridhash = Math.Ceiling((t.Y + 90)* num1 / num2) * Gridhash.WidthNums + Math.Ceiling((t.X + 180)* num1 / num2); 
            double gridhash = Math.Ceiling((t.Y + 90) / Gridhash.GridWidth) * Gridhash.WidthNums + Math.Ceiling((t.X + 180) / Gridhash.GridWidth);
            return gridhash;
        }

        public static double Encode(double x ,double y,double width ,double height)
        {
            //double gridhash = Math.Ceiling((t.Y + 90)* num1 / num2) * Gridhash.WidthNums + Math.Ceiling((t.X + 180)* num1 / num2); 
            double widthNums= Math.Ceiling(360 / width);
            double gridhash = Math.Ceiling((y + 90) / height) * widthNums + Math.Ceiling((x + 180) / width);
            return gridhash;
        }

        public static double Encode(double x, double y)
        {
            //double gridhash = Math.Ceiling((t.Y + 90)* num1 / num2) * Gridhash.WidthNums + Math.Ceiling((t.X + 180)* num1 / num2); 
            double gridhash = Math.Ceiling((y + 90) / Gridhash.GridWidth) * Gridhash.WidthNums + Math.Ceiling((x + 180) / Gridhash.GridWidth);
            return gridhash;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifiedAlgorithm
{
    public static class Gridhash
    {
        private static double gridWidth = 0.1757563;

        private static double widthNums = Math.Ceiling(360 / Gridhash.GridWidth);
        //private static double num1 = 100;//分母   
        //private static double num2 = 5;//分子   
        //private static double widthNums = Math.Ceiling(360*num1 / num2);
        public static double GridWidth
        {
            get { return gridWidth;  }

            set { gridWidth = value; }
        }

        public static double WidthNums
        {
            get { return widthNums;}

            set { widthNums = value;}
        }

        //public static string Encode(TPVertex t)
        //{
        //    string gridhash = "";
        //    //double longitude = t.X;
        //    //double latitude = t.Y;

        //    gridhash = Math.Ceiling((t.X + 180) / GridWidth)+"-"+ Math.Ceiling((t.Y+ 90) / GridWidth);

        //    return gridhash;
        //}
        public static double Encode(TPVertex t)
        {   
            //double gridhash = Math.Ceiling((t.Y + 90)* num1 / num2) * Gridhash.WidthNums + Math.Ceiling((t.X + 180)* num1 / num2); 
            double gridhash = Math.Ceiling((t.Y + 90) / Gridhash.GridWidth) * Gridhash.WidthNums + Math.Ceiling((t.X + 180) / Gridhash.GridWidth);
            return gridhash;
        }

        public static double Encode(double x ,double y,double width ,double height)
        {
            //double gridhash = Math.Ceiling((t.Y + 90)* num1 / num2) * Gridhash.WidthNums + Math.Ceiling((t.X + 180)* num1 / num2); 
            double widthNums= Math.Ceiling(360 / width);
            double gridhash = Math.Ceiling((y + 90) / height) * widthNums + Math.Ceiling((x + 180) / width);
            return gridhash;
        }

        public static double Encode(double x, double y)
        {
            //double gridhash = Math.Ceiling((t.Y + 90)* num1 / num2) * Gridhash.WidthNums + Math.Ceiling((t.X + 180)* num1 / num2); 
            double gridhash = Math.Ceiling((y + 90) / Gridhash.GridWidth) * Gridhash.WidthNums + Math.Ceiling((x + 180) / Gridhash.GridWidth);
            return gridhash;
        }
    }
}
>>>>>>> 00fe4e941c6f15b227f262153279e56767255361
