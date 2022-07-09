using System;

namespace FigureLibrary.Figures2D
{
    public class Circle : IFigure2D
    {
        private readonly float _radius;

        public Circle(float radius)
        {
            _radius = radius;
            Validate();
        }

        public double CalculateArea()
        {
            double area = Math.PI * Math.Pow(_radius, 2);
            return Math.Round(area, 2);
        }

        public void Validate()
        {
            if (_radius <= 0)
            {
                throw new ArgumentException("Radius value must be positive.");
            }
        }
    }
}
