using BudgetingTool.Logic;
using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Enums;
using System;
using System.Collections.Generic;

namespace BudgetingTool.ConsoleProgram
{
    internal class ConsoleBudgetProgram
    {
        private string BudgetFilePath;
        private JsonBudget Budget;

        internal ConsoleBudgetProgram() { }

        internal void CreateBudget()
        {
            ConsoleHelper.WriteSpacedLine("Enter a file name:");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter a path to the directory in which to save the budget:");
            string directoryPath = Console.ReadLine();
            BudgetFilePath = $@"{directoryPath}\{fileName}";
            Budget = new JsonBudget(AddBudgetItems());
            SaveBudget();
        }

        internal void AddItemsToBudget()
        {
            LoadBudget();
            Budget.AddBudgetItems(AddBudgetItems());
        }

        private void LoadBudget()
        {
            ConsoleHelper.WriteSpacedLine("Enter Budget FilePath (including filename)");
            BudgetFilePath = Console.ReadLine();
            Budget = JsonBudget.LoadBudget(BudgetFilePath);
        }

        private void SaveBudget()
        {
            if (ConsoleHelper.GetBooleanInput("Save Budget?"))
            {
                Budget.SaveBudget(BudgetFilePath);
            }
        }

        private List<ABudgetItem> AddBudgetItems()
        {
            bool repeat = true;
            List<ABudgetItem> budgetItems = new List<ABudgetItem>();
            ConsoleBudgetItemCreator budgetItemCreator = new ConsoleBudgetItemCreator();
            ConsoleHelper.WriteSpacedLine("Adding Budget Items.");

            while (repeat)
            {
                IncomeOutcomeEnum inOrOut = ConsoleHelper.GetEnumValueFromConsoleInput<IncomeOutcomeEnum>("Income or Outcome?");
                if (inOrOut.Equals(IncomeOutcomeEnum.Income))
                {
                    IncomeBudgetItem item = budgetItemCreator.CreateIncomeBudgetItem();
                    budgetItems.Add(item);
                }
                else
                {
                    OutcomeBudgetItem item = budgetItemCreator.CreateOutcomeBudgetItem();
                    budgetItems.Add(item);
                }

                repeat = ConsoleHelper.GetBooleanInput("Add More Items?");
            }

            return budgetItems;
        }
    }
}