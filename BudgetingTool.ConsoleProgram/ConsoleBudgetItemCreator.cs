using BudgetingTool.Logic;
using BudgetingTool.Logic.Enums;
using System;

namespace BudgetingTool.ConsoleProgram
{
    internal class ConsoleBudgetItemCreator
    {
        internal ConsoleBudgetItemCreator() { }

        internal IncomeBudgetItem CreateIncomeBudgetItem()
        {
            DateTime itemDate = ConsoleHelper.GetDateTimeInput("Enter item date");
            string description = ConsoleHelper.GetStringInput("Enter an Item Description");
            decimal value = ConsoleHelper.GetDecimalInput("Enter the Value:");

            IncomeCategoryEnum category = ConsoleHelper.GetEnumValueFromConsoleInput<IncomeCategoryEnum>("Enter an Income Category:");
            return new IncomeBudgetItem(category, value, description, itemDate);

        }

        internal OutcomeBudgetItem CreateOutcomeBudgetItem()
        {
            DateTime itemDate = ConsoleHelper.GetDateTimeInput("Enter item date");
            string description = ConsoleHelper.GetStringInput("Enter an Item Description");
            decimal value = ConsoleHelper.GetDecimalInput("Enter the Value:");
            OutcomeCategoryEnum category = ConsoleHelper.GetEnumValueFromConsoleInput<OutcomeCategoryEnum>("Enter an Outcome Category:");
            return new OutcomeBudgetItem(category, value, description, itemDate);
        }
    }
}