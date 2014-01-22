using System;
/*  Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them.
Use System.Math. */

class CalculateSurface
{
    static void CalculateTriangleSurface(double side, double altitude)
    {
        double surface = side * altitude / 2;
        Console.WriteLine(surface);
        return;
    }
    static void CalculateTriangleSurface(double sideOne, double sideTwo, double sideThree)
    {
        double perimeter = sideOne + sideTwo + sideThree;
        double surface = Math.Sqrt(perimeter*(perimeter - sideOne) * (perimeter - sideTwo) * (perimeter - sideThree));
        Console.WriteLine(surface);
        return;
    }
    static void CalculateTriangleSurface(double sideOne, double sideTwo, int angle)
    {
        double surface = sideOne * sideTwo * Math.Sin(angle * Math.PI / 180) / 2;
        Console.WriteLine(surface);
        return;
    }
    static void Main()
    {
        Console.WriteLine("Choose a way to calculate triangle surface: ");
        Console.WriteLine("1 - side + altitude, 2 - three sides, 3 - two sides and angle: ");
        byte way = byte.Parse(Console.ReadLine());
        double valueOne;
        double valueTwo;
        double valueThree;
        int angle;
        switch (way)
        {
            case 1:
                Console.Write("Enter side: ");
                valueOne = double.Parse(Console.ReadLine());
                Console.Write("Enter altitude: ");
                valueTwo = double.Parse(Console.ReadLine());
                CalculateTriangleSurface(valueOne, valueTwo);
                break;
            case 2:
                Console.Write("Enter side: ");
                valueOne = double.Parse(Console.ReadLine());
                Console.Write("Enter second side: ");
                valueTwo = double.Parse(Console.ReadLine());
                Console.Write("Enter third side: ");
                valueThree = double.Parse(Console.ReadLine());
                CalculateTriangleSurface(valueOne, valueTwo, valueThree);
                break;
            case 3:
                Console.Write("Enter side: ");
                valueOne = double.Parse(Console.ReadLine());
                Console.Write("Enter second side: ");
                valueTwo = double.Parse(Console.ReadLine());
                Console.Write("Enter angle in grad: ");
                angle = int.Parse(Console.ReadLine());
                CalculateTriangleSurface(valueOne, valueTwo, angle);
                break;
            default: Console.WriteLine("Invalid Selection!");
                break;
        }
    }
}

