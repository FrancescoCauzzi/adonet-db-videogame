using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;

namespace csharp_gestore_eventi
{
    public static class InputChecker
    {

        public static int GetIntInput()
        {
            while (true)
            {

                if (int.TryParse(ReadLine(), out int result))
                {
                    return result;
                }
                Write("Invalid input, please enter a number: ");
            }
        }

        public static double GetDoubleInput()
        {
            while (true)
            {
                string? inputString = ReadLine();
                if (inputString!.Contains(','))
                {
                    inputString = inputString.Replace(',', '.');
                }
                if (double.TryParse(inputString, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
                Write("Invalid input, please enter a number: ");
            }
        }

        public static string GetStringInput()
        {
            while (true)
            {
                
                string? word = ReadLine();
                if (!string.IsNullOrEmpty(word))
                {
                    if (int.TryParse(word, out int result))
                    {
                        Write("Invalid input, please enter a string: ");
                        continue;
                    }
                    return word;
                }
                WriteLine("Invalid input, please enter a string: ");

            }
        }

        public static bool IsStringYes(string myString)
        {
            while (true)
            {
                string[] acceptableYesValues = { "si", "s", "y", "ye", "yes" };
                string[] acceptableNoValues = { "no", "n" };
                if (acceptableYesValues.Contains(myString.ToLower()))
                {
                    return true;
                }
                else if (acceptableNoValues.Contains(myString.ToLower()))
                {
                    return false;
                }
                else
                {
                    Console.Write("Invalid input, please enter yes or no: ");
                    myString = GetStringInput();
                }
            }
        }

        public static DateTime GetDateTimeInput()
        {
            while (true)
            {

                string? eventDate = ReadLine();
                string format = "dd/MM/yyyy"; // Specify the format

                if (DateTime.TryParseExact(eventDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate;
                }
                else
                {
                    Write("Invalid input, please enter a date in the format dd/mm/yyyy: ");
                }
            }
        }
        public static DateOnly GetDateOnlyInput()
        {
            while (true)
            {

                string? eventDate = ReadLine();
                string format = "dd/MM/yyyy"; // Specify the format

                if (DateOnly.TryParseExact(eventDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly parsedDate))
                {
                    return parsedDate;
                }
                else
                {
                    Write("Invalid input, please enter a date in the format dd/mm/yyyy: ");
                }
            }
        }
    }
}

