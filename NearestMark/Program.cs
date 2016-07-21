using NearestMark.Core.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NearestMark
{
    class Program
    {
        private static List<Coordinate> loadCoordinatesFromFile(string fileName)
        {
            // read the file
            string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            var allText = File.ReadAllText(filePath);

            // parse into coordinates
            var rawCoordinates = allText.Replace(")(", "|");
            rawCoordinates = rawCoordinates.Replace("(", "");
            rawCoordinates = rawCoordinates.Replace(")", "");
            var coordinates = new List<Coordinate>();
            foreach (var rawCoordinate in rawCoordinates.Split(new char[] { '|' }))
            {
                coordinates.Add(new Coordinate(rawCoordinate));
            }
            return coordinates;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Near and Far!");
            Console.WriteLine();

            var coordinatesFromFile = loadCoordinatesFromFile("2D.txt");

            var coordinate = new Coordinate();
            coordinate.Points.Add(1);
            coordinate.Points.Add(2);

            var nearestCoordinate = NearestMark.Core.Distance.GetNearestCoordinate(coordinate, coordinatesFromFile);

            Console.WriteLine("Your coordinate is: {0}", coordinate.ToString());
            Console.WriteLine("Nearest coordinate is: {0}", nearestCoordinate.ToString());
            Console.WriteLine("The distance is: {0}", nearestCoordinate.Distance.ToString());

            Console.Read();

        }
    }
}
