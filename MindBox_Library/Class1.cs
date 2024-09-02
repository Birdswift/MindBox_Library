using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBox_Library
{
    public interface IFigures //интерфейс для легкости добавления других фигур
    {
        double CountArea();
    }

    public class Triangle : IFigures
    {
        //стороны
        private readonly double a;
        private readonly double b;
        private readonly double c;

        public Triangle(double a, double b, double c)//конструктор
        {
            if (a <= 0 || b <= 0 || c <= 0) //проверка на положительные длины стороны
            {
                throw new ArgumentException("The length of the side should be positive");
            }
            if (!((a + b > c) && (a + c > b) && (b + c > a))) //проверка условия существования треугольника
            {
                throw new ArgumentException("The triangle cannot exist");
            }
            this.a = a;
            this.b = b;
            this.c = c;
        }


        public double CountArea()//реализация интерфейса
        {
            double p = (this.a + this.b + this.c) / 2; //Использую формулу Герона
            return Math.Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
        }

        public bool IsRectangular()//проверка, является ли треугольник прямоугольным
        {
            double[] sides = { this.a, this.b, this.c };
            Array.Sort(sides);
            return sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2];
        }
    }

    public class Circle : IFigures
    {
        private readonly double radius;

        public Circle(double radius)//конструктор
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The length of the radius should be positive");
            }

            this.radius = radius;
        }

        public double CountArea()//реализация интерфейса
        {
            return Math.PI * this.radius * this.radius;
        }
    }

    public class FigureAreaCalculator//подсчет площади фигуры без знания ее типа
    {
        public static double CalculateArea(IFigures fig)
        {
            return fig.CountArea();
        }
    }
}
