
using System;

namespace PracticalWork1
{
    class TCircle
    {
        private double radius;

        public TCircle()
        {
            radius = 1;
        }

        public TCircle(double r)
        {
            if (r < 0)
                throw new ArgumentException("Radius cannot be negative!");

            radius = r;
        }

        public TCircle(TCircle circle)
        {
            radius = circle.radius;
        }

        public void Input()
        {
            while (true)
            {
                Console.Write("Enter circle radius: ");

                if (double.TryParse(Console.ReadLine(), out double r)
                    && r >= 0)
                {
                    radius = r;
                    break;
                }

                Console.WriteLine("Invalid radius! Try again.");
            }
        }

        public void Output()
        {
            Console.WriteLine("Circle radius: " + radius);
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public double SectorArea(double angle)
        {
            return Math.PI * radius * radius * angle / 360;
        }

        public double Length()
        {
            return 2 * Math.PI * radius;
        }

        public int Compare(TCircle circle)
        {
            return radius.CompareTo(circle.radius);
        }

        public static TCircle operator +(TCircle a, TCircle b)
        {
            return new TCircle(a.radius + b.radius);
        }

        public static TCircle operator -(TCircle a, TCircle b)
        {
            return new TCircle(Math.Abs(a.radius - b.radius));
        }

        public static TCircle operator *(TCircle a, double number)
        {
            return new TCircle(a.radius * number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            TCircle circle1 = new TCircle();

            Console.WriteLine("First circle:");
            circle1.Input();

            TCircle circle2 = new TCircle();

            Console.WriteLine("\nSecond circle:");
            circle2.Input();

            Console.WriteLine("\nFirst circle info:");
            circle1.Output();
            Console.WriteLine("Area: " + circle1.Area());
            Console.WriteLine("Circumference: " + circle1.Length());
            Console.WriteLine("Sector area (90 degrees): " +
                circle1.SectorArea(90));

            Console.WriteLine("\nSecond circle info:");
            circle2.Output();
            Console.WriteLine("Area: " + circle2.Area());
            Console.WriteLine("Circumference: " + circle2.Length());
            Console.WriteLine("Sector area (90 degrees): " +
                circle2.SectorArea(90));

            Console.WriteLine("\nComparison:");

            int result = circle1.Compare(circle2);

            if (result > 0)
                Console.WriteLine("The first circle is larger.");
            else if (result < 0)
                Console.WriteLine("The second circle is larger.");
            else
                Console.WriteLine("Both circles are equal.");

            Console.WriteLine("\noperator +");
            TCircle sum = circle1 + circle2;
            sum.Output();

            Console.WriteLine("\noperator -");
            TCircle difference = circle1 - circle2;
            difference.Output();

            Console.WriteLine("\noperator * ");
            TCircle multiplication = circle1 * 2;
            multiplication.Output();

            Console.WriteLine("\nProgram completed successfully!");

            Console.ReadKey();
        }
    }
}
