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
            IBudget budget = budgetProgram.Run();

            summaryProgram.Run(budget);

            Console.WriteLine("End Program");
        }
    }
}