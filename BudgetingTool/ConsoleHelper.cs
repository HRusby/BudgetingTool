using System;
using System.Globalization;
using System.Text;

namespace BudgetingTool.ConsoleProgram
{
    internal static class ConsoleHelper
    {
        public static int ReadInt()
        {
            string line = Console.ReadLine();
            int convertedResult;
            if(!int.TryParse(line, out convertedResult))
            {
                Console.WriteLine("Value entered was not numeric. Please try again.");
                return ReadInt();
            }

            return convertedResult;
        }

        public static bool GetBooleanInput(string prompt)
        {
            Console.WriteLine($"{prompt} y/n");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                return true;
            }else if (input.ToLower().Equals("n"))
            {
                return false;
            }

            Console.WriteLine("Invalid Input, please try again");
            return GetBooleanInput(prompt);
        }

        public static T GetEnumValueFromConsoleInput<T>(string prompt) where T : Enum
        {
            Console.WriteLine(prompt);
            Console.Write(EnumToConsoleText<T>());
            int numericEnumVal = ReadInt();

            if (!Enum.IsDefined(typeof(T), numericEnumVal))
            {
                Console.WriteLine($"{numericEnumVal} is not a valid value (for {typeof(T).Name}). Please Try Again.");
                return GetEnumValueFromConsoleInput<T>(prompt);
            }

            return (T)(object)numericEnumVal;
        }

        private static string EnumToConsoleText<T>() where T : Enum
        {
            StringBuilder builder = new StringBuilder();

            foreach (T enumValue in Enum.GetValues(typeof(T)))
            {
                builder.Append(string.Format("{0}. {1}", Convert.ToInt32(enumValue), enumValue.ToString()));
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public static DateTime GetDateInput(string prompt)
        {
            Console.WriteLine($"{prompt} using format ddMMyyyy");
            DateTime itemDate = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", CultureInfo.InvariantCulture);
            return itemDate;
        }

        public static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static decimal GetDecimalInput(string prompt)
        {
            Console.WriteLine(prompt);
            decimal value = decimal.Parse(Console.ReadLine());
            return value;
        }
    }
}