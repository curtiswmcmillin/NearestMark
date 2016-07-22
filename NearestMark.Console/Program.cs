using NearestMark.Core.Model;
using NearestMark.Core;
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
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
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

        private static void processCoordinatesFile(string coordinatesFile, string coordinatesInputFile)
        {
            var coordinatesFromFile = loadCoordinatesFromFile(coordinatesFile);
            var inputCoordinates = loadCoordinatesFromFile(coordinatesInputFile);
            foreach (var inputCoordinate in inputCoordinates)
            {
                var nearestCoordinate = Distance.GetNearestCoordinate(inputCoordinate, coordinatesFromFile);

                Console.WriteLine("Input coordinate: {0}", inputCoordinate.ToString());
                Console.WriteLine("Nearest coordinate to input coordinate: {0}", nearestCoordinate.ToString());
                Console.WriteLine("The distance is: {0}", nearestCoordinate.Distance.ToString());
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Near and Far!");
            Console.WriteLine();

            processCoordinatesFile("2D.txt", "2DTest.txt");
            processCoordinatesFile("3D.txt", "3DTest.txt");

            Console.Read();

            Console.WriteLine("Please enter a 2D or 3D coordinate and then press <ENTER>");
            var userInput = Console.ReadLine();
            Console.WriteLine(userInput);
        }

        
    }
}
