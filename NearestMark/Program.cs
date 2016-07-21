using NearestMark.Core.Model;
using System;
using System.Collections.Generic;

namespace NearestMark
{
    class Program
    {
        private static string _filePath;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Near and Far!");
            Console.WriteLine();
            _filePath = AppDomain.CurrentDomain.BaseDirectory + "fileThatContainsPoints.txt";

            var initialSet = new List<Coordinate>();

            var coordinate = new Coordinate();
            coordinate.Points.Add(1);
            coordinate.Points.Add(1);
            coordinate.Points.Add(1);
            coordinate.Points.Add(1);
            coordinate.Points.Add(1);
            coordinate.Points.Add(1);

            var nearestCoordinate = NearestMark.Core.Distance.GetNearestCoordinate(coordinate, initialSet);

            Console.WriteLine("Nearest coordinate is: {0}", nearestCoordinate.ToString());
            Console.Read();

            // Solve problem
        }
    }
}
