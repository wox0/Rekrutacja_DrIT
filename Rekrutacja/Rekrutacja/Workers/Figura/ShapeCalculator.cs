using System;

namespace Rekrutacja.Workers.Figura
{
    public class ShapeCalculator
    {
        public int Calculate(double a, double b, ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Square:
                    return ToInt(a * a);
                case ShapeType.Rectangle:
                    return ToInt(a * b);
                case ShapeType.Circle:
                    return ToInt(Math.PI * Math.Sqrt(a));
                case ShapeType.Triangle:
                    return ToInt(a * b * 0.5d);
            }

            return 0;
        }

        private int ToInt(double value) => Convert.ToInt32(Math.Floor(value));
    }
}
