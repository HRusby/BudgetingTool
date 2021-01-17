using BudgetingTool.Logic;
using BudgetingTool.Logic.Enums;
using BudgetingTool.Logic.Interfaces;
using System;

namespace BudgetingTool.ConsoleProgram
{
    internal class ConsoleSummaryProgram
    {
        internal void Run()
        {
            ConsoleHelper.WriteSpacedLine("Enter Budget FilePath (including filename)");
            IBudget budget = JsonBudget.LoadBudget(Console.ReadLine());

            TimePeriodEnum summaryPeriod = ConsoleHelper.GetEnumValueFromConsoleInput<TimePeriodEnum>("Select Summary TimePeriod: ");
            DateTime endDate;
            if (ConsoleHelper.GetBooleanInput("From Current Date?"))
            {
                endDate = DateTime.Today;
            }
            else
            {
                endDate = ConsoleHelper.GetDateInput("Enter the last date of the period to summarise");
            }

            BudgetSummariser summariser = new BudgetSummariser(budget, summaryPeriod, endDate);

            OutputSummary(summariser.BuildSummary());
        }

        private static void OutputSummary(BudgetSummary summary)
        {
            Console.WriteLine(summary.ToString());
        }
    }
}