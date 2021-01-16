using BudgetingTool.Logic;
using BudgetingTool.Logic.Enums;
using BudgetingTool.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace BudgetingTool.ConsoleProgram
{
    internal class ConsoleSummaryProgram
    {

        public void Run(IBudget budget)
        {
            TimePeriodEnum summaryPeriod = ConsoleHelper.GetEnumValueFromConsoleInput<TimePeriodEnum>("Select Summary TimePeriod: ");
            DateTime endDate;
            if(ConsoleHelper.GetBooleanInput("From Current Date?"))
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
            Console.WriteLine("Summary: ");
            Console.WriteLine($"Summary Start Date: {summary.StartDate}");
            Console.WriteLine($"Summary End Date: {summary.EndDate}");
            Console.WriteLine($"Income Total: {summary.TotalIncome}");
            Console.WriteLine($"Outcome Total: {summary.TotalOutcome}");
            Console.WriteLine("Income Category Totals:");
            foreach (KeyValuePair<IncomeCategoryEnum, decimal> pair in summary.GetReadableIncomeCategoryTotals())
            {
                Console.WriteLine($"\t{pair.Key} - £{pair.Value}");
            }

            Console.WriteLine("Outcome Category Totals:");
            foreach (KeyValuePair<OutcomeCategoryEnum, decimal> pair in summary.GetReadableOutcomeCategoryTotals())
            {
                Console.WriteLine($"\t{pair.Key} - £{pair.Value}");
            }
        }
    }
}