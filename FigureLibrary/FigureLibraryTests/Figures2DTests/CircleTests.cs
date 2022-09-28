using FigureLibrary.Exceptions;
using FigureLibrary.Figures2D;
using System;
using Xunit;

namespace FigureLibraryTests.Figures2DTests
{
    public class CircleTests
    {
        [Fact]
        public void CreateCircle_RadiusNotPositive_ShouldThrowException()
        {
            //ARRANGE
            float radius = -3;

            //ACT
            var exception = Assert.Throws<ArgumentException>
                (() => new Circle(radius));

            //ASSERT
            Assert.Contains(ExceptionConstants.NegativeRadiusError, exception.Message);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(9)]
        public void CalculateArea_SuccessPass_ReturnsCorrectAnswer(float radius)
        {
            //ARRANGE
            var circle = new Circle(radius);

            //ACT
            var result = circle.CalculateArea();

            //ASSERT
            Assert.Equal(result, Math.PI * radius * radius);
        }
    }
}
