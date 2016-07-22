using NearestMark.Core;
using NearestMark.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace NearestMark
{
    class Program
    {
        private static Coordinates coordinatesFromFile2D = null;
        private static Coordinates coordinatesFromFile3D = null;

        private static Coordinates loadCoordinatesFromFile(string fileName)
        {
            // read the file
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            if (File.Exists(filePath))
            {
                var allText = File.ReadAllText(filePath);

                // parse into coordinates
                var rawCoordinates = allText.Replace(")(", "|");
                rawCoordinates = rawCoordinates.Replace("(", "");
                rawCoordinates = rawCoordinates.Replace(")", "");
                var coordinates = new Coordinates();
                foreach (var rawCoordinate in rawCoordinates.Split(new char[] { '|' }))
                {
                    coordinates.Add(new Coordinate(rawCoordinate));
                }

                return coordinates;
            }
            else
            {
                Console.WriteLine("Please ensure a file exists at " + fileName);
                return null;
            }
        }

        private static void displayResults(Coordinate inputCoordinate, Coordinate nearestCoordinate, Coordinate farthestCoordinate)
        {
            Console.WriteLine("Input coordinate: {0}", inputCoordinate.ToString());
            Console.WriteLine("Nearest coordinate to input coordinate: {0}", nearestCoordinate.ToString());
            Console.WriteLine("Nearest distance is: {0}", nearestCoordinate.Distance.ToString());
            Console.WriteLine("Farthest coordinate from input coordinate: {0}", farthestCoordinate.ToString());
            Console.WriteLine("Farthest distance is: {0}", farthestCoordinate.Distance.ToString());
        }

        private static Coordinates processCoordinatesFile(string coordinatesFileName, string coordinatesInputFileName)
        {
            var coordinatesFromFile = loadCoordinatesFromFile(coordinatesFileName);
            var inputCoordinates = loadCoordinatesFromFile(coordinatesInputFileName);
            foreach (var inputCoordinate in inputCoordinates)
            {
                var nearestCoordinate = coordinatesFromFile.GetNearestCoordinate(inputCoordinate);
                var farthestCoordinate = coordinatesFromFile.GetFarthestCoordinate(inputCoordinate);

                displayResults(inputCoordinate, nearestCoordinate, farthestCoordinate);

                Console.WriteLine();
            }
            return coordinatesFromFile;
        }

        private static void processUserInput()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Please enter a 2D or 3D coordinate (comma-separated numbers) press <ENTER>.");

                    var userInput = Console.ReadLine();
                    Coordinate inputCoordinate = new Coordinate(userInput);
                    if (inputCoordinate.Points.Count == 2)
                    {
                        displayResults(inputCoordinate, coordinatesFromFile2D.GetNearestCoordinate(inputCoordinate), coordinatesFromFile2D.GetFarthestCoordinate(inputCoordinate));
                    }
                    else if (inputCoordinate.Points.Count == 3)
                    {
                        displayResults(inputCoordinate, coordinatesFromFile3D.GetNearestCoordinate(inputCoordinate), coordinatesFromFile3D.GetFarthestCoordinate(inputCoordinate));
                    }
                    Console.WriteLine();
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                processUserInput();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Near and Far!");
            Console.WriteLine();
            Console.WriteLine("Press a key to begin processing 2D and 3D points(in 2D.txt and 3D.txt)");
            Console.ReadKey();

            coordinatesFromFile2D = processCoordinatesFile("2D.txt", "2DTest.txt");

            coordinatesFromFile3D = processCoordinatesFile("3D.txt", "3DTest.txt");

            processUserInput();
        }
    }
}