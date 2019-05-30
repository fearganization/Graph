using System;

namespace Graph.Math
{
    public struct Point
    {
        public Point(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Point operator *(Point a, double d)
        {
            return new Point(a.X * d, a.Y * d, a.Z * d);
        }
        public static Point operator *(double d, Point a)
        {
            return new Point(a.X * d, a.Y * d);
        }
        public static double ScalarMult(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public static Point VectorMult(Point a, Point b)
        {
            return new Point(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);
        }
        public override string ToString()
        {
            return $"({X:F2}; {Y:F2}; {Z:F2})";
        }
    }
}