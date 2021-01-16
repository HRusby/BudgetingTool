using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Enums;
using System;

namespace BudgetingTool.Logic
{
    public class IncomeBudgetItem : ABudgetItem
    {
        public IncomeCategoryEnum Category { get; private set; }

        public IncomeBudgetItem(IncomeCategoryEnum category, decimal value, string description, DateTime itemDate) 
            : base(IncomeOutcomeEnum.Income, value, description, itemDate)
        {
            Category = category;
        }

        public void UpdateCategory(IncomeCategoryEnum category) { Category = category; }
    }
}