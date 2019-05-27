using System;
using System.Diagnostics;
using System.Text;

namespace Graph.Math.Equations
{
    public class EquationsPlane
    {
        private double _A;
        private double _B;
        private double _C;
        private double _D;
        private Point _normalVectorFront;
        private Point _normalVectorBack;

        public double A { get => _A; }
        public double B { get => _B; }
        public double C { get => _C; }
        public double D { get => _D; }
        public Point NormalVectorFront { get => _normalVectorFront; }
        public Point NormalVectorBack { get => _normalVectorBack; }

        public void SwapFacePlane()
        {
            Point temp = _normalVectorBack;
            _normalVectorBack = _normalVectorFront;
            _normalVectorFront = _normalVectorBack;
        }
        public EquationsPlane(Point pointOne, Point pointTwo, Point pointThree)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Environment.NewLine}Build equation plane");
            Debug.WriteLine(sb.ToString());
            sb.Clear();
            Point vectorOne = new Point(pointTwo.X - pointOne.X, pointTwo.Y - pointOne.Y, pointTwo.Z - pointOne.Z),
                vectorTwo = new Point(pointThree.X - pointOne.X, pointThree.Y - pointOne.Y, pointThree.Z - pointOne.Z);
            sb.Append($"{Environment.NewLine}\tVector 1 = {vectorOne}");
            sb.Append($"{Environment.NewLine}\tVector 2 = {vectorTwo}");
            Debug.WriteLine(sb.ToString());
            sb.Clear();
            _A = vectorOne.Y * vectorTwo.Z - vectorTwo.Y * vectorOne.Z;
            _B = vectorOne.Z * vectorTwo.X - vectorTwo.Z * vectorOne.X;
            _C = vectorOne.X * vectorTwo.Y - vectorTwo.X * vectorOne.Y;
            _D = (pointOne.Y * (vectorOne.X * vectorTwo.Z - vectorTwo.X * vectorOne.Z) - pointOne.X * (_A) - pointOne.Z * (_C));
            Debug.WriteLine($"{Environment.NewLine}\tEquation : {this.ToString()}");
            double k = 1.0 / (System.Math.Sqrt(_A * _A + _B * _B + _C * _C));
            _normalVectorFront = new Point(_A * k, _B * k, _C * k);

        }
        public override string ToString()
        {
            return $"({A:F2}) * x + ({B:F2}) * y + ({C:F2}) * z + ({D:F2}) = 0";
        }
    }
}