using System;

namespace Orckestra
{
    class Program
    {
        static void Main(string[] args)
        {
            int argsCount = args?.Length ?? 0;
            if (argsCount < 1 && argsCount > 3)
            {
                Console.WriteLine("Specify 1 param for circle radius, 2 for square|rectangle sides, 3 for triangle sides.");
                Environment.Exit(-1);
            }

            // TODO: add extra param validations here

            switch (args.Length)
            {
                case 1:
                    double circleRadius = double.Parse(args[0]);
                    double circleArea = circleRadius * circleRadius * Math.PI;
                    Console.WriteLine($"Shape type: Circle, Area: {circleArea}");
                    break;
                case 2:
                    double rectSideA = double.Parse(args[0]);
                    double rectSideB = double.Parse(args[1]);
                    double rectArea = rectSideA * rectSideB;
                    Console.WriteLine($"Shape type: {(rectSideA == rectSideB ? "Square" : "Rectangle")}, Area: {rectArea}");
                    break;
                case 3:
                    double triSideA = double.Parse(args[0]);
                    double triSideB = double.Parse(args[1]);
                    double triSideC = double.Parse(args[2]);
                    double s = (triSideA + triSideB + triSideC) / 2;
                    double triangleArea = Math.Sqrt(s * (s - triSideA) * (s - triSideB) * (s - triSideC));
                    Console.WriteLine($"Shape type: Triangle, Area: {triangleArea}");
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
