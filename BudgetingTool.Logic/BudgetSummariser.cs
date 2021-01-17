using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Enums;
using BudgetingTool.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetingTool.Logic
{
    public class BudgetSummariser
    {
        private readonly IBudget Budget;
        private readonly TimePeriodEnum Period;
        private readonly DateTime EndDate;

        public BudgetSummariser(IBudget budget, TimePeriodEnum period, DateTime endDate)
        {
            Budget = budget;
            Period = period;
            EndDate = endDate;
        }

        public BudgetSummary BuildSummary()
        {
            switch (Period)
            {
                case TimePeriodEnum.Weekly:
                    return CalculateSummary(EndDate.AddDays(-7));
                case TimePeriodEnum.Monthly:
                    return CalculateSummary(EndDate.AddMonths(-1));
                case TimePeriodEnum.Annually:
                    return CalculateSummary(EndDate.AddYears(-1));
            }

            throw new Exception("Unknown Exception.");
        }

        private BudgetSummary CalculateSummary(DateTime startDateTime)
        {
            IEnumerable<ABudgetItem> budgetItems = Budget.BudgetItems.Where(x => x.ItemDate >= startDateTime && x.ItemDate <= EndDate);

            IEnumerable<IncomeBudgetItem> incomeItems =
                budgetItems
                    .Where(x => x.IncomeOrOutcome.Equals(IncomeOutcomeEnum.Income))
                    .Cast<IncomeBudgetItem>();
            decimal totalIncomeValue = incomeItems.Sum(x => x.Value);

            IEnumerable<OutcomeBudgetItem> outcomeItems =
                budgetItems
                    .Where(x => x.IncomeOrOutcome.Equals(IncomeOutcomeEnum.Outcome))
                    .Cast<OutcomeBudgetItem>();
            decimal totalOutcomeValue = outcomeItems.Sum(x => x.Value);

            BudgetSummary summary = new BudgetSummary(TimePeriodEnum.Monthly, EndDate, startDateTime, totalIncomeValue, totalOutcomeValue);

            foreach (IncomeCategoryEnum incomeCategory in Enum.GetValues(typeof(IncomeCategoryEnum)))
            {
                IEnumerable<IncomeBudgetItem> categoryBudgetItems = incomeItems.Where(x => x.Category.Equals(incomeCategory));
                decimal value = categoryBudgetItems.Sum(x => x.Value);
                if (!value.Equals(decimal.Zero))
                {
                    summary.AddIncomeCategoryTotal(incomeCategory, value);
                }
            }

            foreach (OutcomeCategoryEnum outcomeCategory in Enum.GetValues(typeof(OutcomeCategoryEnum)))
            {
                IEnumerable<OutcomeBudgetItem> categoryBudgetItems = outcomeItems.Where(x => x.Category.Equals(outcomeCategory));
                decimal value = categoryBudgetItems.Sum(x => x.Value);
                if (!value.Equals(decimal.Zero))
                {
                    summary.AddOutcomeCategoryTotal(outcomeCategory, value);
                }
            }

            return summary;
        }
    }
}