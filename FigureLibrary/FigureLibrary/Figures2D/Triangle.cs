using System;

namespace FigureLibrary.Figures2D
{
    public class Triangle
    {
        private readonly float _sideA;
        private readonly float _sideB;
        private readonly float _sideC;

        public Triangle(float sideA, float sideB, float sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            Validate();
        }

        public double CalculateArea()
        {
            return HeronArea(_sideA, _sideB, _sideC);
        }

        public bool IfRightTriangle()
        {
            if (_sideA * _sideA + _sideB * _sideB == _sideC * _sideC)
                return true;
            if (_sideA * _sideA + _sideC * _sideC == _sideB * _sideB)
                return true;
            if (_sideC * _sideC + _sideB * _sideB == _sideA * _sideA)
                return true;
            return false;
        }

        private static double HeronArea(float sideA, float sideB, float sideC)
        {
            float halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return Math.Round(area, 2);
        }

        public void Validate()
        {
            if (_sideA <= 0 || _sideB <= 0 || _sideC <= 0)
            {
                throw new ArgumentException("Side lengths must be positive.");
            }
            if (_sideA + _sideB <= _sideC || _sideA + _sideC <= _sideB || _sideC + _sideB <= _sideA)
            {
                throw new ArgumentException("A triangle with such sides does not exist.");
            }
        }
    }
}
