using System;
using System.Diagnostics;
using System.Text;
using Graph.Math.Equations;

namespace Graph.Math
{
    public struct Section
    {
        private Point _beginPoint;
        private Point _endPoint;
        private Equation _equation;
        private Point _vectorSection;

        public Point VectorSection { get => _vectorSection; }
        public Point EndPoint { get => _endPoint; }
        public Point BeginPoint { get => _beginPoint; }

        public Section(Point beginPoint, Point endPoint)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Environment.NewLine}Build new section");
            _beginPoint = beginPoint;
            sb.Append($"{Environment.NewLine}\tBegin point = {_beginPoint}");
            _endPoint = endPoint;
            sb.Append($"{Environment.NewLine}\tEnd point = {_endPoint}");
            _equation = new Equation(_beginPoint, _endPoint);
            sb.Append($"{Environment.NewLine}\tEquation: {_equation}");
            _vectorSection = _endPoint - _beginPoint;
            sb.Append($"{Environment.NewLine}\tVector section: {_vectorSection}");
            Debug.Write(sb.ToString());
        }


        public bool IsIntersectionPoint(Section a)
        {
            Point vectorToA1 = a._beginPoint - _beginPoint,
                vectorToA2 = a._endPoint - _beginPoint;
            double z1 = Point.VectorMult(_vectorSection, vectorToA1).Z;
            double z2 = Point.VectorMult(_vectorSection, vectorToA2).Z;
            if (z1 > 0 & z2 > 0 || z2 < 0 & z1 < 0)
                return false;
            return true;
        }
        public Point GetIntersectionPoint(Section b)
        {
            double cx = _beginPoint.X - b._beginPoint.X,
                cy = _beginPoint.Y - b._beginPoint.Y,
                znamenatel = b._vectorSection.X * _vectorSection.Y - b._vectorSection.Y * _vectorSection.X,
                chislitel = cx * _vectorSection.Y - cy * _vectorSection.X;

            if (znamenatel == 0)
                return null;
            double mu = chislitel / znamenatel;
            double x = b._beginPoint.X + b._vectorSection.X * mu,
                y = b._beginPoint.Y + b._vectorSection.Y * mu;
            return new Point(x, y);
        }
    }
}