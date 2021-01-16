using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Enums;
using System;

namespace BudgetingTool.Logic
{
    public class OutcomeBudgetItem : ABudgetItem
    {
        public OutcomeCategoryEnum Category { get; private set; }
        public OutcomeBudgetItem(OutcomeCategoryEnum category, decimal value, string description, DateTime itemDate)
            : base(IncomeOutcomeEnum.Outcome, value, description, itemDate)
        {
            Category = category;
        }

        public void UpdateCategory(OutcomeCategoryEnum category) { Category = category; }
    }
}
