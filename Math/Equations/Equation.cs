using System;
using System.Diagnostics;
using System.Text;

namespace Graph.Math.Equations
{
    public class Equation
    {

        private double _A;
        private double _B;
        private double _C;

        private Point _normalVectorLeft;
        private Point _normalVectorRight;

        public double A { get => _A; }
        public double B { get => _B; }
        public double C { get => _C; }
        public Point NormalVectorLeft { get => _normalVectorLeft; }
        public Point NormalVectorRight { get => _normalVectorRight; }

        public Equation(Point point1, Point point2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Environment.NewLine}Build new equation");
            _A = point1.Y - point2.Y;
            sb.Append($"{Environment.NewLine}\tA = {_A:F3}");
            _B = point2.X - point1.X;
            sb.Append($"{Environment.NewLine}\tB = {_B:F3}");
            _C = point1.X * point2.Y - point1.Y * point2.X;
            sb.Append($"{Environment.NewLine}\tC = {_C:F3}");
            if (_A != 0)
            {
                _B /= _A;
                _C /= _A;
                _A /= _A;
            }
            double k = 1 / System.Math.Sqrt(_A * _A + _B * _B);
            _normalVectorLeft = new Point(_A * k, _B * k);
            sb.Append($"{Environment.NewLine}\tNormal vector 1 {_normalVectorLeft}");
            _normalVectorRight = new Point(-_A * k, -_B * k);
            sb.Append($"{Environment.NewLine}\tNormal vector 2 {_normalVectorRight}");
            sb.Append($"{Environment.NewLine}\tEquation: {ToString()}");

            Debug.Write(sb.ToString());
        }

        public double GetResult(double parameter)
        {
            if (_B == 0)
                throw new DivideByZeroException($"y = {_A:F3}/{_B:F3} * x + {_C:F3}/{_B:F3};");
            return (_A * parameter + _C) / _B * (-1.0);
        }
        public double GetParameter(double result)
        {
            if (_A == 0)
                throw new DivideByZeroException($"x = {_B:F3}/{_A:F3} * y + {_C:F3}/{_A:F3};");
            return (_B * result + _C) / _A * (-1.0);
        }
        public override string ToString()
        {
            return $"{_A:F2}x + ({_B:F2})y + {_C:F2} = 0";
        }
    }
}