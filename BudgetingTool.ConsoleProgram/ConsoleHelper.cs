using System;
using System.Globalization;
using System.Text;

namespace BudgetingTool.ConsoleProgram
{
    internal static class ConsoleHelper
    {
        internal static int ReadInt()
        {
            string line = Console.ReadLine();
            int convertedResult;
            if (!int.TryParse(line, out convertedResult))
            {
                Console.WriteLine("Value entered was not numeric. Please try again.");
                return ReadInt();
            }

            return convertedResult;
        }

        internal static bool GetBooleanInput(string prompt)
        {
            WriteSpacedLine($"{prompt} y/n");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                return true;
            }
            else if (input.ToLower().Equals("n"))
            {
                return false;
            }

            Console.WriteLine("Invalid Input, please try again");
            return GetBooleanInput(prompt);
        }

        internal static T GetEnumValueFromConsoleInput<T>(string prompt) where T : Enum
        {
            WriteSpacedLine(prompt);
            Console.Write(EnumToConsoleText<T>());
            int numericEnumVal = ReadInt();

            if (!Enum.IsDefined(typeof(T), numericEnumVal))
            {
                Console.WriteLine($"{numericEnumVal} is not a valid value (for {typeof(T).Name}). Please Try Again.");
                return GetEnumValueFromConsoleInput<T>(prompt);
            }

            return (T)(object)numericEnumVal;
        }

        internal static string EnumToConsoleText<T>() where T : Enum
        {
            StringBuilder builder = new StringBuilder();

            foreach (T enumValue in Enum.GetValues(typeof(T)))
            {
                builder.Append(string.Format("{0}. {1}", Convert.ToInt32(enumValue), enumValue.ToString()));
                builder.AppendLine();
            }

            return builder.ToString();
        }

        internal static DateTime GetDateInput(string prompt)
        {
            WriteSpacedLine($"{prompt} using format ddMMyyyy");
            DateTime itemDate = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", CultureInfo.InvariantCulture);
            return itemDate;
        }

        internal static DateTime GetDateTimeInput(string prompt)
        {
            WriteSpacedLine($"{prompt} using format \"ddMMyyyyHH24mmss\"");
            DateTime itemDate;
            if (DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyyHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out itemDate))
            {
                return itemDate;
            }
            WriteSpacedLine("Input not recognised. Try Again.");
            return GetDateTimeInput(prompt);
        }

        internal static string GetStringInput(string prompt)
        {
            WriteSpacedLine(prompt);
            return Console.ReadLine();
        }

        internal static decimal GetDecimalInput(string prompt)
        {
            WriteSpacedLine(prompt);
            decimal value = decimal.Parse(Console.ReadLine());
            return value;
        }

        internal static void WriteSpacedLine(string line)
        {
            Console.WriteLine();
            Console.WriteLine(line);
        }
    }
}