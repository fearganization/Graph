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
        private EquationLinePlane _equation;
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
            _equation = new EquationLinePlane(_beginPoint, _endPoint);
            sb.Append($"{Environment.NewLine}\tEquation: {_equation}");
            _vectorSection = _endPoint - _beginPoint;
            sb.Append($"{Environment.NewLine}\tVector section: {_vectorSection}");
            Debug.WriteLine(sb.ToString());
        }


        public bool IsIntersectionPoint(Section a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Environment.NewLine}Check exist intersection point");
            sb.Append($"{Environment.NewLine}\tFirst section");
            sb.Append($"{Environment.NewLine}\t\tBegin point\t- {this.BeginPoint}");
            sb.Append($"{Environment.NewLine}\t\tEnd point\t- {this.EndPoint}");
            sb.Append($"{Environment.NewLine}\t\tSection's vector\t- {this.VectorSection}");
            sb.Append($"{Environment.NewLine}\tSecond section");
            sb.Append($"{Environment.NewLine}\t\tBegin point\t- {a.BeginPoint}");
            sb.Append($"{Environment.NewLine}\t\tEnd point\t- {a.EndPoint}");
            sb.Append($"{Environment.NewLine}\t\tSection vector\t- {a.VectorSection}");
            Debug.WriteLine(sb.ToString());
            sb.Clear();
            Point vectorToA1 = a._beginPoint - _beginPoint,
                vectorToA2 = a._endPoint - _beginPoint,
                vResult1 = Point.VectorMult(_vectorSection, vectorToA1),
                vResult2 = Point.VectorMult(_vectorSection, vectorToA2);
            sb.Append($"{Environment.NewLine}\tResult vectors");
            sb.Append($"{Environment.NewLine}\t\tVector AC\t- {vectorToA1}");
            sb.Append($"{Environment.NewLine}\t\tVector AD\t- {vectorToA2}");
            sb.Append($"{Environment.NewLine}\t\tVector AB*AC\t- {vResult1}");
            sb.Append($"{Environment.NewLine}\t\tVector AB*AD\t- {vResult2}");
            Debug.WriteLine(sb.ToString());
            sb.Clear();
            double z1 = vResult1.Z;
            double z2 = vResult2.Z;
            sb.Append($"{Environment.NewLine}\tResult");
            sb.Append($"{Environment.NewLine}\t\tAB*AC.Z\t- {z1:F2}");
            sb.Append($"{Environment.NewLine}\t\tAB*AD.Z\t- {z2:F2}");
            Debug.WriteLine(sb.ToString());
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
                throw new Exception("Is not intersection point");
            double mu = chislitel / znamenatel;
            double x = b._beginPoint.X + b._vectorSection.X * mu,
                y = b._beginPoint.Y + b._vectorSection.Y * mu;
            return new Point(x, y);
        }
    }
}