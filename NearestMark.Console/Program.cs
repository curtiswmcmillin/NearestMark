using NearestMark.Core.Model;
using System;
using System.IO;

namespace NearestMark
{
    class Program
    {
        private static Coordinates testCoordinates = null;
        private static Coordinates inputCoordinates = null;

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

        private static void processInputCoordinates()
        {
            foreach (var inputCoordinate in inputCoordinates)
            {
                var nearestCoordinate = testCoordinates.GetNearestCoordinate(inputCoordinate);
                var farthestCoordinate = testCoordinates.GetFarthestCoordinate(inputCoordinate);

                displayResults(inputCoordinate, nearestCoordinate, farthestCoordinate);

                Console.WriteLine();
            }

            Console.WriteLine(string.Format("{0} Coordinates compared.", inputCoordinates.Count));
        }

        private static void processUserInput()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Please enter a coordinate and press <ENTER>.");

                    var userInput = Console.ReadLine();
                    Coordinate inputCoordinate = new Coordinate(userInput);
                    displayResults(inputCoordinate, testCoordinates.GetNearestCoordinate(inputCoordinate), testCoordinates.GetFarthestCoordinate(inputCoordinate));
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

        /// <summary>
        /// Takes 2 arguments, only one is required.
        /// Parameter 1 is the test file containing points to be compared against.
        /// Parameter 2 is OPTIONAL, contains points to iterate through, comparing against the test file.        
        /// Example: 
        /// NearestMark.exe 2DTest.txt 2DInput.txt
        /// NearestMark.exe 2DTest.txt
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Near and Far!");

            if (args.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Please supply a test file name in the first argument.");
                Console.ReadKey();
                return;
            }

            if (args.Length == 2)
            {
                var testFileName = args[0];
                var inputFileName = args[1];

                Console.WriteLine();

                Console.WriteLine(string.Format("Press a key to begin comparing test coordinates found in {0} with those in {1}.", testFileName, inputFileName));
                Console.WriteLine();
                Console.ReadKey();

                testCoordinates = loadCoordinatesFromFile(args[0]);
                inputCoordinates = loadCoordinatesFromFile(args[1]);

                processInputCoordinates();
                                
                Console.ReadKey();

                return;
            }

            if (args.Length == 1)
            {
                testCoordinates = loadCoordinatesFromFile(args[0]);

                processUserInput();
            }
        }
    }
}