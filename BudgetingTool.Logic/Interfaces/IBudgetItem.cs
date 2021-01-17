using BudgetingTool.Logic.Enums;
using System;

namespace BudgetingTool.Logic.Interfaces
{
    public interface IBudgetItem
    {
        IncomeOutcomeEnum IncomeOrOutcome { get; }
        string Description { get; }
        DateTime ItemDate { get; }
        decimal Value { get; }

        void UpdateDescription(string description);
        void UpdateItemDate(DateTime itemDate);
        void UpdateValue(decimal value);
    }
}