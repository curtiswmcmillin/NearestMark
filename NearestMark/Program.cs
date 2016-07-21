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

            var coordinate = new Coordinate();
            coordinate.Points.Add(1);
            coordinate.Points.Add(2);
            coordinate.Points.Add(3);
            coordinate.Points.Add(4);

            var initialSet = new List<Coordinate>();
            for(var i = 0; i<5; i++)
            {
                var c = new Coordinate();

                c.Points.Add(new Random(i).Next(1));
                c.Points.Add(new Random(i).Next(10));
                c.Points.Add(new Random(i).Next(100));
                c.Points.Add(new Random(i).Next(1000));
                
                initialSet.Add(c);
            }

            var nearestCoordinate = NearestMark.Core.Distance.GetNearestCoordinate(coordinate, initialSet);

            Console.WriteLine("Your coordinate is: {0}", coordinate.ToString());
            Console.WriteLine("Nearest coordinate is: {0}", nearestCoordinate.ToString());
            Console.WriteLine("The distance is: {0}", nearestCoordinate.Distance.ToString());

            Console.Read();

        }
    }
}
