using FigureLibrary.Exceptions;
using System;

namespace FigureLibrary.Figures2D
{
    public class Triangle : IFigure2D
    {
        public readonly double SideA;
        public readonly double SideB;
        public readonly double SideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Validate();
        }

        public double CalculateArea()
        {
            return HeronArea(SideA, SideB, SideC);
        }

        public bool IfRightTriangle()
        {
            if (SideA * SideA + SideB * SideB == SideC * SideC)
                return true;
            else if (SideA * SideA + SideC * SideC == SideB * SideB)
                return true;
            else if (SideC * SideC + SideB * SideB == SideA * SideA)
                return true;
            return false;
        }

        private double HeronArea(double sideA, double sideB, double sideC)
        {
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return area;
        }

        private void Validate()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                throw new ArgumentException(ExceptionConstants.NegativeSideError);
            }
            if (SideA + SideB <= SideC || SideA + SideC <= SideB || SideC + SideB <= SideA)
            {
                throw new ArgumentException(ExceptionConstants.ImpossibleTriangleError);
            }
        }
    }
}
