using NearestMark.Core.Model;
using System;
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
                return new Coordinates(File.ReadAllText(filePath));
            }
            else
            {
                Console.WriteLine("Please confirm that this file exists: " + filePath);
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
            if (coordinatesFromFile == null)
                return null;

            var inputCoordinates = loadCoordinatesFromFile(coordinatesInputFileName);
            if (inputCoordinates == null)
                return null;

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
                    Console.WriteLine("Please enter a 2D or 3D coordinate (comma-separated numbers) and press <ENTER>.");

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
            catch (Exception ex)
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
            Console.WriteLine("Press a key to begin processing 2D and 3D points(in 2D.txt and 3D.txt).");
            Console.WriteLine();
            Console.ReadKey();

            coordinatesFromFile2D = processCoordinatesFile("2D.txt", "2DTest.txt");

            coordinatesFromFile3D = processCoordinatesFile("3D.txt", "3DTest.txt");

            if (coordinatesFromFile2D != null && coordinatesFromFile3D != null)
            {
                processUserInput();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please confirm that 2D and 3D points(in 2D.txt and 3D.txt) are located in program folder.");
                Console.ReadKey();
            }
        }
    }
}