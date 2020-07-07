/*
 * Code made by Chuck Allen for submission as a lab.
 * This asks the user to give the height, length, and width of a room.
 * It then calculates some statistics based on that information.
 * 
 */

using System;
using System.ComponentModel;

namespace DB4_Room_Calculator
{
    class RoomCalculator
    {

        private const int SMALL_ROOM = 250;
        private const int MEDIUM_ROOM = 650;
        private const int WINDOW_WIDTH = 50;
        private const int WINDOW_HEIGHT = 25;

        public void Start()
        {
            bool moreRooms = true;
            double width, length, height; //user entered variables
            double area, perimeter, volume; //calculated variables
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.WriteLine("Welcome to the Room Detail Generator!\n");

            while(moreRooms)
            {
                width = Math.Abs(GetValidInput<double>("Enter Width: "));
                length = Math.Abs(GetValidInput<double>("Enter Length: "));
                height = Math.Abs(GetValidInput<double>("Enter Height: "));

                area = GetArea(width, length);
                perimeter = GetPerimeter(width, length);
                volume = GetVolume(width, length, height);

                ShowStatistics(area, perimeter, volume);

                moreRooms = KeepGoing();
                Console.WriteLine("\n");
            }

            Console.WriteLine("Thank you for using the Room Detail Generator!");
        }

        private void ShowStatistics(double area, double perimeter, double volume)
        {
            //This will output the values in square footage.
            Console.WriteLine($"\nThe perimeter is {string.Format("{0:#,#.##}", perimeter)} feet.");
            Console.WriteLine($"The area is {string.Format("{0:#,#.##}", area)} square feet.");
            Console.WriteLine($"The volume is: {string.Format("{0:#,#.##}", volume)} cubic feet.\n");

            //based on room size clasify the room.
            if (area < SMALL_ROOM)
            {
                Console.WriteLine("This is a small sized room.\n");
            }
            else if (area < MEDIUM_ROOM)
            {
                Console.WriteLine("This is a medium sized room.\n");
            }
            else
            {
                Console.WriteLine("This is a large sized room.\n");
            }
        }

        //returns area of a rectangle
        private double GetArea(double width, double length)
        {
            return (width * length);
        }

        //returns the perimeter of a rectangle
        private double GetPerimeter(double width, double length)
        {
            return ((2*width) + (2*length));
        }

        //returns the volume of a rectangular prism
        private double GetVolume(double width, double length, double height)
        {
            return (GetArea(width, length) * height);
        }

        private bool KeepGoing()
        {
            Console.WriteLine("Continue (y/n)");
            if(Console.ReadKey().Key == ConsoleKey.Y) //continue on Y, but not anything else
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get an input with a desired type.
        static T GetValidInput<T>(string prompt)
        {
            //initialize the required variables to store input and assess it's validity.
            bool validEntry = false;
            string input = "";

            //while the input is not valid, keep trying to get a valid input.
            while (!validEntry)
            {
                Console.Write(prompt); //provide user prompt
                input = Console.ReadLine();

                //verify that the input is able to be converted to the desired type
                validEntry = TypeDescriptor.GetConverter(typeof(T)).IsValid(input);
            }

            //return the results of converting the input to the desired type.
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);
        }
    }
}
