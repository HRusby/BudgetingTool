using BudgetingTool.Logic;
using BudgetingTool.Logic.Enums;
using System;

namespace BudgetingTool.ConsoleProgram
{
    internal class ConsoleBudgetItemCreator
    {
        public ConsoleBudgetItemCreator() { }

        public IncomeBudgetItem CreateIncomeBudgetItem()
        {
            DateTime itemDate = ConsoleHelper.GetDateInput("Enter item date");
            string description = ConsoleHelper.GetStringInput("Enter an Item Description");
            decimal value = ConsoleHelper.GetDecimalInput("Enter the Value:");

            IncomeCategoryEnum category = ConsoleHelper.GetEnumValueFromConsoleInput<IncomeCategoryEnum>("Enter an Income Category:");
            return new IncomeBudgetItem(category, value, description, itemDate);

        }

        public OutcomeBudgetItem CreateOutcomeBudgetItem()
        {
            DateTime itemDate = ConsoleHelper.GetDateInput("Enter item date");
            string description = ConsoleHelper.GetStringInput("Enter an Item Description");
            decimal value = ConsoleHelper.GetDecimalInput("Enter the Value:");
            OutcomeCategoryEnum category = ConsoleHelper.GetEnumValueFromConsoleInput<OutcomeCategoryEnum>("Enter an Outcome Category:");
            return new OutcomeBudgetItem(category, value, description, itemDate);
        }
    }
}