using FigureLibrary.Exceptions;
using System;

namespace FigureLibrary.Figures2D
{
    public class Circle : IFigure2D
    {
        public readonly double Radius;

        public Circle(double radius)
        {
            Radius = radius;
            Validate();
        }

        public double CalculateArea()
        {
            double area = Math.PI * Radius * Radius;
            return area;
        }

        private void Validate()
        {
            if (Radius <= 0)
            {
                throw new ArgumentException(ExceptionConstants.NegativeRadiusError);
            }
        }
    }
}
