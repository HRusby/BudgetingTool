using BudgetingTool.Logic;
using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace BudgetingTool.ConsoleProgram
{
    internal class ConsoleBudgetProgram
    {
        private string BudgetFilePath;
        private JsonBudget Budget;
        private readonly ConsoleBudgetItemCreator BudgetItemCreator;
        internal ConsoleBudgetProgram()
        {
            BudgetItemCreator = new ConsoleBudgetItemCreator();
        }

        public IBudget Run()
        {
            Budget = GetBudget();
            SaveBudget();
            return Budget;
        }

        private JsonBudget GetBudget()
        {
            Console.WriteLine("Load an existing Budget or Create a new Budget?");
            Console.WriteLine("1. Load");
            Console.WriteLine("2. New");
            int input = ConsoleHelper.ReadInt();

            if (input.Equals(1))
            {
                Console.WriteLine("Enter Budget FilePath (including filename)");
                BudgetFilePath = Console.ReadLine();
                return JsonBudget.LoadBudget(BudgetFilePath);
            }
            else if (input.Equals(2))
            {
                Console.WriteLine("Enter a file name:");
                string fileName = Console.ReadLine();
                Console.WriteLine("Enter a path to the directory in which to save the budget:");
                string directoryPath = Console.ReadLine();
                BudgetFilePath = $@"{directoryPath}\{fileName}";
                return new JsonBudget(AddIncomeBudgetItems(), AddOutcomeBudgetItems());
            }
            else
            {
                Console.WriteLine("Invalid Input. Please Try Again.");
                return GetBudget();
            }
        }

        private void SaveBudget()
        {
            Budget.SaveBudget(BudgetFilePath);
        }

        private List<IncomeBudgetItem> AddIncomeBudgetItems()
        {
            bool repeat = true;
            List<IncomeBudgetItem> budgetItems = new List<IncomeBudgetItem>();
            ConsoleBudgetItemCreator budgetItemCreator = new ConsoleBudgetItemCreator();
            Console.WriteLine("Entering Input Items");

            while (repeat)
            {
                IncomeBudgetItem item = budgetItemCreator.CreateIncomeBudgetItem();
                budgetItems.Add(item);

                repeat = ConsoleHelper.GetBooleanInput("Add More Income Items?");
            }

            return budgetItems;
        }

        private List<OutcomeBudgetItem> AddOutcomeBudgetItems()
        {
            bool repeat = true;
            List<OutcomeBudgetItem> budgetItems = new List<OutcomeBudgetItem>();
            
            Console.WriteLine("Entering Outcome Items");

            while (repeat)
            {
                OutcomeBudgetItem item = BudgetItemCreator.CreateOutcomeBudgetItem();
                budgetItems.Add(item);

                repeat = ConsoleHelper.GetBooleanInput("Add More Outcome Items?");
            }

            return budgetItems;
        }
    }
}
