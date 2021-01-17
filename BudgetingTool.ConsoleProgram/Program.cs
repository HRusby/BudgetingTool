using BudgetingTool.Logic.Interfaces;
using System;

namespace BudgetingTool.ConsoleProgram
{
    /* Modules:
     *      Profile
     *          User Name
     *      Input
     *          Categories - Done
     *          Income/Outcome - Done
     *          Input multiple and save to pick up later
     *          
     *      Tax:
     *          Based on Income items calculate expected tax using gov.uk brackets factoring in tax free allowance
     *              May be dependant on using tool since start of tax year
     *      
     *      Savings
     *          Accounts - Balances
     *          When Savings Category Selected automatically add to savings
     *      
     *      Projection
     *      
     *      Summary
     */

    public class Program
    {
        private static ConsoleBudgetProgram budgetProgram;
        private static ConsoleSummaryProgram summaryProgram;
        static Program()
        {
            budgetProgram = new ConsoleBudgetProgram();
            summaryProgram = new ConsoleSummaryProgram();
        }

        
        public static void Main(string[] args)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("------- BudgetingTool -------");
            Console.WriteLine("=============================");

            SelectSubRoutine();

            ConsoleHelper.WriteSpacedLine("End Program");
        }

        private static void SelectSubRoutine()
        {
            ConsoleHelper.WriteSpacedLine("Select a Program:");
            Console.WriteLine("1. Create a New Budget.");
            Console.WriteLine("2. Add BudgetItems to an Existing Budget.");
            Console.WriteLine("3. View Summary data for an Existing Budget.");

            int input = ConsoleHelper.ReadInt();

            switch (input)
            {
                case 1:
                    budgetProgram.CreateBudget();
                    break;
                case 2:
                    budgetProgram.AddItemsToBudget();
                    break;
                case 3:
                    summaryProgram.Run();
                    break;
                default:
                    ConsoleHelper.WriteSpacedLine("Unexpected input. Try Again.");
                    SelectSubRoutine();
                    break;
            }

            if (ConsoleHelper.GetBooleanInput("Select Another Program?"))
            {
                SelectSubRoutine();
            }
        }
    }
}