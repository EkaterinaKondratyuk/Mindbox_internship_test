using FigureLibrary.Exceptions;
using FigureLibrary.Figures2D;
using System;
using Xunit;

namespace FigureLibraryTests.Figures2DTests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, 1)]
        [InlineData(-1, -1, -1)]
        public void CreateTriangle_SideLengthsNotPositive_ShouldThrowException(float sideA, float sideB, float sideC)
        {
            //ARRANGE

            //ACT
            var exception = Assert.Throws<ArgumentException>
                (() => new Triangle(sideA, sideB, sideC));

            //ASSERT
            Assert.Contains(ExceptionConstants.NegativeSideError, exception.Message);
        }

        [Theory]
        [InlineData(2, 3, 1)]
        public void CreateTriangle_WrongSides_ShouldThrowException(float sideA, float sideB, float sideC)
        {
            //ARRANGE

            //ACT
            var exception = Assert.Throws<ArgumentException>
                (() => new Triangle(sideA, sideB, sideC));

            //ASSERT
            Assert.Contains(ExceptionConstants.ImpossibleTriangleError, exception.Message);
        }

        [Theory]
        [InlineData(5, 4, 3, 6)]
        public void CalculateArea_SuccessPass_ReturnsCorrectAnswer(float sideA, float sideB, float sideC, double expectedResult)
        {
            //ARRANGE
            var triangle = new Triangle(sideA, sideB, sideC);

            //ACT
            var result = triangle.CalculateArea();

            //ASSERT
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5, 4, 3, true)]
        [InlineData(6, 4, 3, false)]
        public void CheckIfRightTriangle_NotRightAngleInput_ReturnsCorrectAnswer(float sideA, float sideB, float sideC, bool expectedResult)
        {
            //ARRANGE
            var triangle = new Triangle(sideA, sideB, sideC);

            //ACT
            var result = triangle.IfRightTriangle();

            //ASSERT
            Assert.Equal(expectedResult, result);
        }
    }
}
