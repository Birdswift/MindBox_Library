using System;
using MindBox_Library;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void TriangleTest()
        {
            var trig1 = new Triangle(3, 4, 5);
            var trig2 = new Triangle(2, 3, 4);


            Assert.Throws<ArgumentException>(() => new Triangle(-1, 0, -3)); // Отрицательные и нулевые длины сторон
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 100));  // Несуществующий треугольник

            Assert.True(trig1.IsRectangular()); // Проверяем, что треугольник прямоугольный
            Assert.Equal(6, trig1.CountArea(), 2); // Площадь прямоугольного треугольника

            Assert.False(trig2.IsRectangular()); // Проверяем, что треугольник не прямоугольный
            Assert.Equal(2.9047375096555625, trig2.CountArea(), 10); // Площадь обычного треугольника
        }

        [Fact]
        public void CircleTest()
        {

            var circl1 = new Circle(5);

            Assert.Throws<ArgumentException>(() => new Circle(-5)); // Отрицательный радиус

            Assert.Equal(78.53981633974483, circl1.CountArea(), 10); // Площадь круга
        }

        [Fact]
        public void UnknownTypeTest()
        {
            IFigures fig1 = new Triangle(3, 4, 5);
            IFigures fig2 = new Circle(5);

            // Проверка вычисления площади через интерфейс
            Assert.Equal(6, fig1.CountArea(), 2); // Площадь треугольника
            Assert.Equal(78.53981633974483, fig2.CountArea(), 10); // Площадь круга
        }
    }
}
